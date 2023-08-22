using System;
using System.Web;

public partial class part3_Products : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var loginCookie = Request.Cookies[Constants.LOGIN_COOKIE];
        var user = loginCookie?.Values[Constants.LOGIN_USER];
        var loggedIn = loginCookie != null && !string.IsNullOrEmpty(user);
        loginSignUp.Text = loggedIn ? $"{user}" : "Log In";
    }

    protected void btnMacbook_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        => SetComputerCookie(Constants.Computer.Macbook.ToString());

    protected void btnMS_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        => SetComputerCookie(Constants.Computer.MS.ToString());
    protected void btnLenovo_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        => SetComputerCookie(Constants.Computer.Lenovo.ToString());

    protected void btnHp_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        => SetComputerCookie(Constants.Computer.Hp.ToString());

    private void SetComputerCookie(string val)
    {
        var cookie = Request.Cookies[Constants.COMPUTER_COOKIE] ?? CreateCookie();
        cookie.Values.Add(Constants.COMPUTER_NAME, val);
        Response.Cookies.Add(cookie);
        Server.Transfer("AddToCart.aspx", false);
    }

    private HttpCookie CreateCookie()
    {
        var cookie = new HttpCookie(Constants.COMPUTER_COOKIE);
        cookie.Values.Add(Constants.COMPUTER_NAME, "");
        cookie.Expires = DateTime.MaxValue;
        Response.Cookies.Add(cookie);
        return cookie;
    }
}