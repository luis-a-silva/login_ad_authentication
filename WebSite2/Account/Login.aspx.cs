using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Web;
using System.Web.UI;
using WebSite2;
using System.DirectoryServices.AccountManagement;

public partial class Account_Login : Page
{
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Validate the user password
                    try
                    {
                        using (PrincipalContext context = new PrincipalContext(ContextType.Domain, "creaba.org.br"))
                        {
                            if (context.ValidateCredentials(UserName.Text, Password.Text) == false)
                            {
                                Response.Write("Login não efetuado!");
                            }
                            else
                            {
                                Response.Write("Login efetuado");
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Erro de autenticação: " + ex.Message);

                    }
        }
        }
}