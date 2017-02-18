using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebClient.Account
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e) {

            AccountServiceRef.Service1Client client = new AccountServiceRef.Service1Client();
            string email = Email.Text;
            string password = Password.Text;
            string firstName = First.Text;
            string lastName = Last.Text;
            string inputCaptcha = Capcha.Text;
            string rule = "User";

            Boolean result = false;
            string captcha = (string)Session["Captcha"];

            if (captcha.Equals(inputCaptcha)){

                result = client.addUser1(firstName, lastName, email, password, rule);

                if (result == true) linkBtn.Visible = true;
                else ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "<script>$('#remindModal').modal('show');</script>", false);
            }
            else{
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "<script>$('#remindCapchaModal').modal('show');</script>", false);
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            ImageVerifierServiceRef.ServiceClient client = new ImageVerifierServiceRef.ServiceClient();
            int strLength = 4;
            string captcha = client.GetVerifierString(strLength.ToString());
            System.Drawing.Image bitObject = System.Drawing.Bitmap.FromStream(client.GetImage(captcha));

            Session["ImageVerifying"] = bitObject;
            Session["Captcha"] = captcha;

            image.ImageUrl = "~/Account/ImageProcess.aspx";
        }

        protected void linkBtn_Click(object sender, EventArgs e){
            Response.Redirect("~/Account/Login.aspx");
        }
    }
}