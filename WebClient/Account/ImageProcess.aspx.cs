using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebClient.Account
{
    public partial class ImageProcess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Drawing.Image bitObject = (System.Drawing.Image)Session["ImageVerifying"];
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            bitObject.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);

            stream.Position = 0;
            int streamLength = unchecked((int)stream.Length);
            byte[] data = new byte[streamLength];
            stream.Read(data, 0, streamLength);

            Response.Clear();
            Response.ContentType = "image/jpeg";
            Response.BinaryWrite(data);
        }
    }
}