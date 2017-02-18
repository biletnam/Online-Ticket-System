using System;
using Newtonsoft.Json;
using System.Web.UI;
using System.IO;

namespace WebClient.Admin
{
    public partial class Spot : System.Web.UI.Page
    {
        HaishengServiceRef.Service1Client haishengService;

        protected void Page_Load(object sender, EventArgs e)
        {
            haishengService = new HaishengServiceRef.Service1Client();
        }

        protected void btnAddSpot_Click(Object sender, EventArgs e)
        {
            try
            {
                SpotRootObject rootObj = new SpotRootObject();
                SpotModel spot = new SpotModel();

                spot.name = Name.Text;

                MemoryStream ms = new MemoryStream(Img.FileBytes);
                byte[] array = ms.ToArray();
                spot.imgBytes = array;
                //spot.imgStr = Encoding.UTF8.GetString(array,0,array.Length);

                SpotLocation location = new SpotLocation();
                location.state = State.Text;
                location.city = City.Text;
                location.zipcode = ZipCode.Text;
                spot.location = location;

                spot.introduction = Introduction.Text;
                spot.price = Price.Text;

                rootObj.key = spot;
                String json = JsonConvert.SerializeObject(rootObj);
                Boolean flag = haishengService.addSpot(json);

                if (!flag) ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "<script>$('#remindModal').modal('show');</script>", false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}