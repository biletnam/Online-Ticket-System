using System;
using Newtonsoft.Json;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebClient.Member
{
    public partial class SpotDetails : System.Web.UI.Page
    {
        HaishengServiceRef.Service1Client haishengService;
        HttpCookie myCookie;
        SpotModel spot;

        protected void Page_Load(object sender, EventArgs e)
        {
            haishengService = new HaishengServiceRef.Service1Client();
            String json = (String)Session["SpotDetails"];
            spot = JsonConvert.DeserializeObject<SpotRootObject>(json).key;

            image.ImageUrl = "../ImgCache/" + spot.name + ".jpg";
            name.Text = "<Strong><h3>" + spot.name + "</h3></Strong>";
            address.Text = spot.location.city + ", " + spot.location.state + ", " + spot.location.zipcode;

            introduction.Text = spot.introduction;

            price.Text = "<Strong><h1>" + "$" + spot.price + "</h1></Strong>";

            searchWeather();
            searchPOI();
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            TicketServiceRef.Service1Client client = new TicketServiceRef.Service1Client();
            string userId = (string)Session["Email"];
            string attractionName = spot.name;
            string ticket = client.GenerateTicket(userId, attractionName);

            lab_ticket.Text = ticket;

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "<script>$('#remindModal').modal('show');</script>", false);
        }

        private void searchPOI()
        {
            String[] data = haishengService.getPOI(spot.location.zipcode);

            if (data.Length > 0) table_store.Visible = true;
            //lab_weatherGetResult.Text = data[0] + "," + data[1];
            for (int i = 0; i < data.Length; i++)
            {
                TableRow row = new TableRow();

                //fill business col
                TableCell cell_business = new TableCell();
                Label lab_business = new Label();
                lab_business.Text = data[i].Split(',')[0];
                cell_business.Controls.Add(lab_business);
                row.Cells.Add(cell_business);

                //fill distance col
                TableCell cell_distance = new TableCell();
                Label lab_distance = new Label();
                lab_distance.Text = data[i].Split(',')[1];
                cell_distance.Controls.Add(lab_distance);
                row.Cells.Add(cell_distance);

                //fill learn col
                TableCell cell_learn = new TableCell();
                Label lab_learn = new Label();
                lab_learn.Text = data[i].Split(',')[2];
                cell_learn.Controls.Add(lab_learn);
                row.Cells.Add(cell_learn);

                table_store.Rows.Add(row);
            }
        }

        private void searchWeather()
        {
            String[] data = haishengService.getWeatherForcast(spot.location.zipcode);

            if (data.Length > 0) table_weather.Visible = true;

            for (int i = 0; i < data.Length; i++)
            {
                TableRow row = new TableRow();

                //fill date col
                TableCell cell_date = new TableCell();
                Label lab_date = new Label();
                lab_date.Text = data[i].Split(',')[0];
                cell_date.Controls.Add(lab_date);
                row.Cells.Add(cell_date);

                //fill weather condition col
                TableCell cell_wc = new TableCell();
                Label lab_wc = new Label();
                lab_wc.Text = data[i].Split(',')[1];
                cell_wc.Controls.Add(lab_wc);
                row.Cells.Add(cell_wc);

                //fill date col
                TableCell cell_temp = new TableCell();
                Label lab_temp = new Label();
                lab_temp.Text = data[i].Split(',')[2];
                cell_temp.Controls.Add(lab_temp);
                row.Cells.Add(cell_temp);

                table_weather.Rows.Add(row);
            }
        }
    }
}