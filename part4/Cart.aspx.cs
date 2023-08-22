using System;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using TextBox = System.Web.UI.WebControls.TextBox;

public partial class part3_Cart : System.Web.UI.Page
{
    private string User;
    private bool IsLoggedIn => User != "Log In";

    protected void Page_Load(object sender, EventArgs e)
    {
        var loginCookie = Request.Cookies[Constants.LOGIN_COOKIE];
        var user = loginCookie?.Values[Constants.LOGIN_USER];
        var loggedIn = loginCookie != null && !string.IsNullOrEmpty(user);
        loginSignUp.Text = loggedIn ? $"{user}" : "Log In";
        User = loginSignUp.Text;
        UpdateCart();
        GetTotal();
        cartPanel.Update();
    }

    private void GetTotal()
    {
        var orders = Dao.GetOrdersForUser(User);
        var tot = 0.0;
        foreach (var order in orders)
        {
            var tbx = computerContent.FindControl($"id_{order.TableRowId}");
            var qty = Int32.Parse((tbx as TextBox).Text);
            tot += order.TotalPrice * qty;
        }

        total.Text = tot.ToString("C");
    }

    /*private void GetTotal()
    {
        var orders = Dao.GetOrdersForUser(User);
        var tot = 0.0;
        foreach (var order in orders)
        {
            var orderDiv = (HtmlGenericControl)computerContent.FindControl($"order_{order.TableRowId}");
            if (orderDiv != null)
            {
                var tbx = (TextBox)orderDiv.FindControl($"id_{order.TableRowId}");
                if (tbx != null)
                {
                    var qty = Int32.Parse(tbx.Text);
                    tot += order.TotalPrice * qty;
                }
            }
        }

        total.Text = tot.ToString("C");
    }*/

    /*private void UpdateCart()
    {
        if (!IsLoggedIn)
            return;

        var orders = Dao.GetOrdersForUser(User);
        foreach (var order in orders)
        {
            var img = new Image { ImageUrl = order.Item.ImgUrl };
            img.Style["width"] = "256px";
            img.Style["height"] = "256px";
            img.Style["display"] = "block";

            computerContent.Controls.Add(img);

            var details = new TextBox
            {
                TextMode = TextBoxMode.MultiLine,
                ReadOnly = true,
                Text = order.Summary
            };
            details.Style["display"] = "block";
            computerContent.Controls.Add(details);

            var qty = new TextBox
            {
                TextMode = TextBoxMode.Number,
                Text = order.Qty.ToString(),
                ID = $"id_{order.TableRowId}",
                AutoPostBack = true
            };
            qty.Style["display"] = "block";
            qty.TextChanged += UpdateOrder;
            computerContent.Controls.Add(qty);
        }
    }*/

    private void UpdateCart()
    {
        if (!IsLoggedIn)
            return;

        var orders = Dao.GetOrdersForUser(User);
        foreach (var order in orders)
        {
            var orderDiv = new HtmlGenericControl("div");
            orderDiv.Attributes["class"] = "order-container";

            // Create and configure the image
            var img = new Image { ImageUrl = order.Item.ImgUrl };
            img.Style["width"] = "256px";
            img.Style["height"] = "256px";
            img.Style["display"] = "block";
            orderDiv.Controls.Add(img);

            var itemDetails = order.Summary.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            var formattedItemDetails = string.Join("<br>", itemDetails);

            var orderDetails = new LiteralControl(
                $"<p class='item-details'>{formattedItemDetails}</p>");

            orderDiv.Controls.Add(orderDetails);

            computerContent.Controls.Add(orderDiv);

            var qty = new TextBox
            {
                TextMode = TextBoxMode.Number,
                Text = order.Qty.ToString(),
                ID = $"id_{order.TableRowId}",
                AutoPostBack = true
            };
            qty.Style["display"] = "block";
            qty.TextChanged += UpdateOrder;
            computerContent.Controls.Add(qty);
        }
    }




    private void UpdateOrder(object sender, EventArgs e)
    {
        var tbx = (TextBox)sender;
        var id = tbx.ID;
        id = id.Replace("id_", "");
        var orderId = Int32.Parse(id);
        Dao.UpdateOrderQty(orderId, Int32.Parse(tbx.Text));
        GetTotal();
        cartPanel.Update();
    }

}