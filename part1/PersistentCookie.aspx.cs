using System;
using System.Web;

public partial class part1_PersistentCookie : System.Web.UI.Page
{
    private const string CookieName = "visitHitCookie";
    private const string CookieCountValue = "count";

    protected void Page_Load(object sender, EventArgs e)
    {
        AddToCounter();
        UpdateGui();
    }

    private void UpdateGui()
    {
        var cookie = GetCookie();
        LblHitsCount.Text = GetCurrentCount(cookie);
        LblIpAddr.Text = GetClientIpAddr();
    }

    private void AddToCounter(bool reset = false)
    {
        var cookie = GetCookie();
        var currCount = GetCurrentCount(cookie);

        if (!reset && Int32.TryParse(currCount, out int countNum))
        {
            var countStr = (++countNum).ToString();
            cookie.Values.Set(CookieCountValue, countStr);
            Response.Cookies.Add(cookie);
        }
        else cookie.Values.Set(CookieCountValue, "0");
    }

    private string GetCurrentCount(HttpCookie cookie) => cookie.Values[CookieCountValue];

    private HttpCookie GetCookie()
    {
        var visitHitCookie = Request.Cookies[CookieName];
        return visitHitCookie ?? CreateCookie();
    }

    private HttpCookie CreateCookie()
    {
        var cookie = new HttpCookie(CookieName);
        cookie.Values.Add(CookieCountValue, "0");
        cookie.Expires = DateTime.MaxValue;
        Response.Cookies.Add(cookie);
        return cookie;
    }

    private string GetClientIpAddr()
    {
        var context = HttpContext.Current;
        string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        if (string.IsNullOrEmpty(ipAddress))
        {
            ipAddress = context.Request.ServerVariables["REMOTE_ADDR"];
        }
        else
        {
            // The IP address can be a comma-separated list; get the first IP
            ipAddress = ipAddress.Split(',')[0].Trim();
        }

        return ipAddress;
    }

    protected void btnResetCookie_Click(object sender, EventArgs e)
    {
        AddToCounter(true);
        UpdateGui();
    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
    }
}