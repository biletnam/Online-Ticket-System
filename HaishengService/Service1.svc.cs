using System;
using Newtonsoft.Json;
using System.Xml;
using System.Web;
using SecClassLibrary;
using System.IO;
using System.ServiceModel.Channels;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace HaishengService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        // Final Service URL: http://webstrar39.fulton.asu.edu/Page1/Service1.svc
        // Weather Service URL: http://graphical.weather.gov/xml/SOAP_server/ndfdXMLserver.php?wsdl

        WeatherServiceRef.ndfdXMLPortTypeClient weatherService = new WeatherServiceRef.ndfdXMLPortTypeClient();

        public Boolean addSpot(String json)
        {

            try
            {
                SpotRootObject rootObj = JsonConvert.DeserializeObject<SpotRootObject>(json);
                SpotModel key = rootObj.key;

                //Add spot into spot.xml
                String spotXml = HttpContext.Current.Server.MapPath("~/App_Data/Spot.xml");
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(spotXml);

                //create a new spot element and set value or attribute
                XmlElement spot = xmlDoc.CreateElement("Spot");
                spot.SetAttribute("Name", Security.Encryption(key.name));
                xmlDoc.SelectSingleNode("/Spots").AppendChild(spot);

                // location
                XmlElement location = xmlDoc.CreateElement("Location");
                spot.AppendChild(location);

                XmlElement state = xmlDoc.CreateElement("State");
                state.InnerText = Security.Encryption(key.location.state);
                location.AppendChild(state);

                XmlElement city = xmlDoc.CreateElement("City");
                city.InnerText = Security.Encryption(key.location.city);
                location.AppendChild(city);

                XmlElement zipcode = xmlDoc.CreateElement("ZipCode");
                zipcode.InnerText = Security.Encryption(key.location.zipcode);
                location.AppendChild(zipcode);

                // image stream save as jpg file
                Image img = Image.FromStream(new MemoryStream(key.imgBytes));
                var ratio = (double)225 / img.Height;
                int imgHeight = (int)(img.Height * ratio);
                int imgWidth = (int)(img.Width * ratio);

                Image.GetThumbnailImageAbort dCallBack = new Image.GetThumbnailImageAbort(ThumbnailCallback);
                Image thumbnailImg = img.GetThumbnailImage(imgWidth, imgHeight, dCallBack, IntPtr.Zero);
                String imgFile = key.name + ".jpg";
                thumbnailImg.Save(Path.Combine(HttpContext.Current.Server.MapPath("~/Thumbnail"), imgFile), ImageFormat.Jpeg);
                thumbnailImg.Dispose();

                // introduction
                XmlElement intro = xmlDoc.CreateElement("Introduction");
                intro.InnerText = Security.Encryption(key.introduction);
                spot.AppendChild(intro);

                // price
                XmlElement price = xmlDoc.CreateElement("Price");
                price.InnerText = Security.Encryption(key.price);
                spot.AppendChild(price);

                xmlDoc.Save(spotXml);

                return true;
            }
            catch { return false; }
        }

        public String getSpots()
        {
            List<SpotModel> list = new List<SpotModel>();

            XmlDocument xmlDoc = new XmlDocument();
            String spotXml = HttpContext.Current.Server.MapPath("~/App_Data/Spot.xml");
            xmlDoc.Load(spotXml);
            XmlNodeList spotList = xmlDoc.SelectNodes("/Spots[@*]/Spot");

            foreach (XmlNode spotNode in spotList)
            {
                SpotModel spot = new SpotModel();

                // get name
                spot.name = Security.Decryption(spotNode.Attributes["Name"].Value);

                // get image
                String path = HttpContext.Current.Server.MapPath("~/Thumbnail/") + spot.name + ".jpg";
                Image image = Image.FromFile(path);
                MemoryStream stream = new MemoryStream();
                image.Save(stream, ImageFormat.Jpeg);
                stream.Position = 0;
                byte[] array = stream.ToArray();
                spot.imgBytes = array;
                //spot.imgStr = Encoding.UTF8.GetString(array,0,array.Length);

                // get location
                SpotLocation location = new SpotLocation();
                location.state = Security.Decryption(spotNode.SelectSingleNode("Location").SelectSingleNode("State").InnerText);
                location.city = Security.Decryption(spotNode.SelectSingleNode("Location").SelectSingleNode("City").InnerText);
                location.zipcode = Security.Decryption(spotNode.SelectSingleNode("Location").SelectSingleNode("ZipCode").InnerText);
                spot.location = location;

                //get introduction
                spot.introduction = Security.Decryption(spotNode.SelectSingleNode("Introduction").InnerText);

                //get price
                spot.price = Security.Decryption(spotNode.SelectSingleNode("Price").InnerText);

                list.Add(spot);
            }

            SpotRootObject rootObj = new SpotRootObject();
            rootObj.list = list;
            String json = JsonConvert.SerializeObject(rootObj);
            return json;
        }

        public String getLocation(String zipcode)
        {

            CustomBinding binding = new CustomBinding(
                new CustomTextMessageBindingElement("iso-8859-1", "text/xml", MessageVersion.Soap11),
                new HttpTransportBindingElement());
            weatherService.Endpoint.Binding = binding;

            String str_getLocation = weatherService.LatLonListZipCode(zipcode);
            weatherService.LatLonListZipCode(zipcode);
            XmlDocument xml_getLocation = new XmlDocument();
            xml_getLocation.LoadXml(str_getLocation);
            XmlNode locationNode = xml_getLocation.SelectSingleNode("/dwml[@*]/latLonList");
            String location = locationNode.InnerText;//the format is like xxx,xxx

            return location;
        }

        public String[] getWeatherForcast(String zipcode)
        {

            // weather service URL:http://graphical.weather.gov/xml/SOAP_server/ndfdXMLserver.php?wsdl

            const int NUMDAYS = 6;
            const String UNIT = "e";
            const String FORMAT = "24 hourly";

            CustomBinding binding = new CustomBinding(
                new CustomTextMessageBindingElement("iso-8859-1", "text/xml", MessageVersion.Soap11),
                new HttpTransportBindingElement());
            weatherService.Endpoint.Binding = binding;

            String location = getLocation(zipcode);

            DateTime time = DateTime.Now;
            String str_getWeather = weatherService.NDFDgenByDayLatLonList(location, time, Convert.ToString(NUMDAYS), UNIT, FORMAT);

            String[] res = new String[NUMDAYS - 1];
            String[] dates = new String[NUMDAYS - 1];
            String[] maxTemp = new String[NUMDAYS - 1];
            String[] minTemp = new String[NUMDAYS - 1];
            String[] weatherCondition = new String[NUMDAYS - 1];

            XmlDocument xml_getWeather = new XmlDocument();
            xml_getWeather.LoadXml(str_getWeather);
            XmlNodeList xnList = xml_getWeather.SelectNodes("/dwml[@*]/data");

            //extract weather data
            foreach (XmlNode xn in xnList)
            {
                //obtain dates
                XmlNode dNode = xn.SelectSingleNode("time-layout");
                XmlNodeList dateList = dNode.SelectNodes("start-valid-time");
                int i = 0;
                foreach (XmlNode date in dateList)
                {
                    if (date != null && i < dates.Length)
                    {
                        dates[i++] = date.InnerText.Split('T')[0];
                    }
                }

                //obtain temperature
                XmlNodeList tempNodes = xn.SelectNodes("parameters/temperature");
                foreach (XmlNode tempNode in tempNodes)
                {
                    if (tempNode.Attributes["type"].Value.Equals("maximum"))
                    {
                        i = 0;
                        XmlNodeList tempList = tempNode.SelectNodes("value");
                        foreach (XmlNode tempVal in tempList)
                        {
                            if (tempVal != null && i < maxTemp.Length)
                            {
                                maxTemp[i++] = tempVal.InnerText;
                            }
                        }
                    }
                    else if (tempNode.Attributes["type"].Value.Equals("minimum"))
                    {
                        i = 0;
                        XmlNodeList tempList = tempNode.SelectNodes("value");
                        foreach (XmlNode tempVal in tempList)
                        {
                            if (tempVal != null && i < minTemp.Length)
                            {
                                minTemp[i++] = tempVal.InnerText;
                            }
                        }
                    }
                }

                //obtain weather conditions
                i = 0;
                XmlNodeList wcNodes = xn.SelectNodes("parameters/weather/weather-conditions");
                foreach (XmlNode wcNode in wcNodes)
                {
                    if (wcNode != null && i < weatherCondition.Length)
                    {
                        weatherCondition[i++] = wcNode.Attributes["weather-summary"].Value;
                    }
                }
            }

            for (int i = 0; i < res.Length; i++)
            {
                res[i] = dates[i] + "," + weatherCondition[i] + "," + minTemp[i] + "-" + maxTemp[i] + " 'F";
            }
            return res;
        }

        public String[] getPOI(String zipcode)
        {
            const String URL_API = "https://maps.googleapis.com/maps/api/place/nearbysearch/";
            const String KEY = "AIzaSyBP1FiROiWev2dQUMoVeh7GNpRwMOLUSsk";

            String[] res;
            String location = getLocation(zipcode);
            double curLat = Convert.ToDouble(location.Split(',')[0]);
            double curLng = Convert.ToDouble(location.Split(',')[1]);

            String query = "&radius=500&types=food|drink|cloth"; // here you can change query to what you want

            String temp = "location=" + curLat + "," + curLng + query;

            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(URL_API + "json?" + temp + "&key=" + KEY);
            httpRequest.Timeout = 2000;
            httpRequest.Method = "GET";
            HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            StreamReader sr = new StreamReader(httpResponse.GetResponseStream(), Encoding.UTF8);
            String response = sr.ReadToEnd();
            sr.Close();

            SearchRootObject rootObject = JsonConvert.DeserializeObject<SearchRootObject>(response);
            List<Result> result = rootObject.results;

            res = new String[result.Count];
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = result[i].name + "," + getDistance(curLat, curLng, result[i].geometry.location.lat, result[i].geometry.location.lng) + "m," + result[i].vicinity;
            }
            return res;
        }

        //distance in meter
        private int getDistance(double lat1, double lng1, double lat2, double lng2)
        {
            const double EARTH_RADIUS = 6378.137;//地球半径km
            double radLat1 = lat1 * Math.PI / 180;
            double radLat2 = lat2 * Math.PI / 180;
            double a = radLat1 - radLat2;
            double b = (lng1 * Math.PI / 180) - (lng2 * Math.PI / 180);
            double s = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) +
                    Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2)));
            s = s * EARTH_RADIUS;
            s = Math.Round(s * 10000) / 10;
            return (int)s;
        }
        public bool ThumbnailCallback() { return false; }
    }
}
