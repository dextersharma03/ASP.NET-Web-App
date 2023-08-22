using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class part3_ComputerParts : System.Web.UI.Page
{
    private string User;
    private bool IsUserLoggedIn => User != "Log In";

    protected void Page_Load(object sender, EventArgs e)
    {
        var loginCookie = Request.Cookies[Constants.LOGIN_COOKIE];
        var user = loginCookie?.Values[Constants.LOGIN_USER];
        var loggedIn = loginCookie != null && !string.IsNullOrEmpty(user);
        loginSignUp.Text = loggedIn ? $"{user}" : "Log In";
        User = loginSignUp.Text;

        UpdateGui();
        partPanel.Update();
    }

    /*private void UpdateGui()
    {
        if (partsList.FindControl("1") != null)
            return;

        var comps = Dao.GetAllComponents();
        foreach (var comp in comps)
        {
            var ctrl = new ImageButton
            {
                ID = comp.Id.ToString(),
                ImageUrl = comp.ImgUrl,
            };
            ctrl.CssClass = "AddToCart";
            ctrl.Style["width"] = "256px";
            ctrl.Style["height"] = "256px";
            ctrl.Click += Comp_Click;
            ctrl.Style["display"] = "block";

            partsList.Controls.Add(ctrl);
            ScriptManager.GetCurrent(this).RegisterPostBackControl(ctrl);

            var lblctrl = new Label();
            lblctrl.CssClass = "product-caption";
            lblctrl.Text = $"{comp.DisplayName} ({comp.Value})";
            partsList.Controls.Add(lblctrl);
        }
    }*/
    private void UpdateGui()
    {
        if (partsList.FindControl("1") != null)
            return;

        var comps = Dao.GetAllComponents();
        foreach (var comp in comps)
        {
            var productDiv = new Panel();
            productDiv.CssClass = "product";

            var imageButton = new ImageButton
            {
                ID = comp.Id.ToString(),
                ImageUrl = comp.ImgUrl,
            };
            imageButton.CssClass = "AddToCart";
            imageButton.Click += Comp_Click;

            var captionLabel = new Label();
            captionLabel.CssClass = "product-caption";
            captionLabel.Text = $"{comp.DisplayName} ({comp.Value})";

            productDiv.Controls.Add(imageButton);
            productDiv.Controls.Add(new LiteralControl("<br />"));
            productDiv.Controls.Add(captionLabel);

            partsList.Controls.Add(productDiv);
            ScriptManager.GetCurrent(this).RegisterPostBackControl(imageButton);
        }
    }


    private void Comp_Click(object sender, ImageClickEventArgs e)
    {
        var comp = Dao.GetComponent(Int32.Parse(((ImageButton) sender).ID));
        var cartItem = new CartItem(comp, new List<Component>());
        AddCartItem(cartItem);
    }

    private void AddCartItem(CartItem item)
    {
        err.Text = IsUserLoggedIn ? "" : "PLEASE LOG IN TO ADD TO CART";
        partPanel.Update();

        if (IsUserLoggedIn)
        {
            item.TableRowId = Dao.AddCartItemToOrder(item, User);
            Constants.Part4CartItems.Add(item);
            partPanel.Update();

            Server.Transfer("Cart.aspx", false);
        }
    }
}