using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class part3_Products : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var loginCookie = Request.Cookies[Constants.LOGIN_COOKIE];
        var user = loginCookie?.Values[Constants.LOGIN_USER];
        var loggedIn = loginCookie != null && !string.IsNullOrEmpty(user);
        loginSignUp.Text = loggedIn ? $"{user}" : "Log In";

        ConfigureComps();
        computerPanel.Update();
    }

    private void ConfigureComps()
    {
        if (ComputerList.FindControl("1") != null)
            return;

        var computers = Dao.GetAllComputers();
        foreach (var comp in computers)
        {
            var productDiv = new Panel();
            productDiv.CssClass = "product";

            var imageButton = new ImageButton();
            imageButton.CssClass = "AddToCart";
            imageButton.ID = comp.Id.ToString();
            imageButton.ImageUrl = comp.ImgUrl;
            imageButton.Click += Comp_Click;

            var captionLabel = new Label();
            captionLabel.CssClass = "product-caption";
            captionLabel.Text = comp.DisplayName;

            productDiv.Controls.Add(imageButton);
            productDiv.Controls.Add(new LiteralControl("<br />"));
            productDiv.Controls.Add(captionLabel);

            ComputerList.Controls.Add(productDiv);
            ScriptManager.GetCurrent(this).RegisterPostBackControl(imageButton);
        }
    }

        protected void Comp_Click(object sender, ImageClickEventArgs e)
        => SetComputerCookie(((ImageButton)sender).ID);

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