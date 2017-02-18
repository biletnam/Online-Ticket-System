using System;
using System.Web;
using System.Web.UI;
using System.Web.Security;

namespace WebClient.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(Object sender, EventArgs e)
        {
            string email = Email.Text;
            string password = Password.Text;
            int result = 0;

            AccountServiceRef.Service1Client client = new AccountServiceRef.Service1Client();
            result = client.verifyUser(email, password);

            if (result > 0){
                FormsAuthentication.RedirectFromLoginPage(email,false);
                
                Session["Email"] = email;
                Session["Rule"] = result;

                if (result == 1) Response.Redirect("~/Member/Home.aspx");
                else if (result == 2) Response.Redirect("~/Staff/Home.aspx");
                else Response.Redirect("~/Admin/Home.aspx");
            }

            else{
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "<script>$('#remindModal').modal('show');</script>", false);
            }
        }
    }
}