using System;

public partial class part3_ComputerHub : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var loginCookie = Request.Cookies[Constants.LOGIN_COOKIE];
        var user = loginCookie?.Values[Constants.LOGIN_USER];
        var loggedIn = loginCookie != null && !string.IsNullOrEmpty(user);
        loginSignUp.Text = loggedIn ? $"{user}" : "Log In";
    }
}