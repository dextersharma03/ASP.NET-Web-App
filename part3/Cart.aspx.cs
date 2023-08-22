using System;
using System.Linq;

public partial class part3_Cart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var loginCookie = Request.Cookies[Constants.LOGIN_COOKIE];
        var user = loginCookie?.Values[Constants.LOGIN_USER];
        var loggedIn = loginCookie != null && !string.IsNullOrEmpty(user);
        loginSignUp.Text = loggedIn ? $"{user}" : "Log In";

        var cookie = Request.Cookies[Constants.CART_COOKIE];
        var cartItemIds = cookie?.Values[Constants.CART_ITEMS];
        if (cookie == null || string.IsNullOrEmpty(cartItemIds))
            return;

        var ids = cartItemIds.Split(new []{','}, StringSplitOptions.RemoveEmptyEntries);
        var text = "";
        foreach (var id in ids)
        {
            var item = Constants.CartItems.FirstOrDefault(c => c.Id.ToString() == id);
            if(item == null)
                continue;

            text += $"{item.Summary}\r\n\r\n";
        }

        cartItems.Text = text;
    }
}