using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web;
using System.Drawing.Imaging;
using System.IO;

namespace WebClient.Member
{
    public partial class Home : System.Web.UI.Page
    {
        HaishengServiceRef.Service1Client haishengService;
        List<SpotModel> list;

        protected void Page_Load(object sender, EventArgs e)
        {
            username.Text = "Hello, " + (String)Session["Email"] + "! This is your ordered tickets";
            // tab info
            TicketServiceRef.Service1Client client = new TicketServiceRef.Service1Client();
            string userId = (string)Session["Email"];
            string tickets = client.getUserTicket(userId);
            string[] ticketArray = tickets.Split(';');

            if (ticketArray.Length > 0) table_info.Visible = true;
            else table_info.Visible = false;

            for (int i = 0; i < ticketArray.Length; i++) {
                if (ticketArray[i] == String.Empty) break;

                TableRow row = new TableRow();
                String attraction = ticketArray[i].Split('|')[1];
                String verification = ticketArray[i].Split('|')[2];

                TableCell cell_attraction = new TableCell();
                Label lab_attraction = new Label();
                lab_attraction.Text = attraction;
                cell_attraction.Controls.Add(lab_attraction);
                row.Cells.Add(cell_attraction);

                TableCell cell_verification = new TableCell();
                Label lab_verification = new Label();
                lab_verification.Text = verification;
                cell_verification.Controls.Add(lab_verification);
                row.Cells.Add(cell_verification);

                table_info.Rows.Add(row);
            }

            // tab spots
            haishengService = new HaishengServiceRef.Service1Client();

            String json = haishengService.getSpots();
            SpotRootObject rootObj = JsonConvert.DeserializeObject<SpotRootObject>(json);
            list = rootObj.list;

            for (int i = 0; i < list.Count; i++)
            {

                System.Drawing.Image img = System.Drawing.Image.FromStream(new MemoryStream(list[i].imgBytes));
                //System.Drawing.Image img = System.Drawing.Image.FromStream(new MemoryStream(Encoding.UTF8.GetBytes(list[i].imgStr)));
                int imgHeight = img.Height;
                int imgWidth = img.Width;

                System.Drawing.Image.GetThumbnailImageAbort dCallBack = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
                System.Drawing.Image thumbnailImg = img.GetThumbnailImage(imgWidth, imgHeight, dCallBack, IntPtr.Zero);
                String imgFile = list[i].name + ".jpg";
                thumbnailImg.Save(Path.Combine(HttpContext.Current.Server.MapPath("../ImgCache/"), imgFile), ImageFormat.Jpeg);
                thumbnailImg.Dispose();
            }

            if (!IsPostBack)
            {
                bindList();
            }
        }

        public void bindList()
        {
            spotList.DataSource = list;
            spotList.DataBind();
        }

        protected void imgBtn_Click(object sender, ImageClickEventArgs e)
        {

            String arg = (String)((ImageButton)sender).CommandArgument;
            String[] values = arg.Split('|');
            SpotModel spot = new SpotModel();

            SpotLocation location = new SpotLocation();
            location.state = values[0];
            location.city = values[1];
            location.zipcode = values[2];
            spot.location = location;

            spot.name = values[3];
            spot.introduction = values[4];
            spot.price = values[5];

            SpotRootObject rootObj = new SpotRootObject();
            rootObj.key = spot;
            String json = JsonConvert.SerializeObject(rootObj);
            Session["SpotDetails"] = json;
            Response.Redirect("~/Member/SpotDetails");
        }

        public bool ThumbnailCallback() { return false; }
    }
}