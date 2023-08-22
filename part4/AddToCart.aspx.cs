using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

public partial class part3_AddToCart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var loginCookie = Request.Cookies[Constants.LOGIN_COOKIE];
        var user = loginCookie?.Values[Constants.LOGIN_USER];
        var loggedIn = loginCookie != null && !string.IsNullOrEmpty(user);
        loginSignUp.Text = loggedIn ? $"{user}" : "Log In";

        try
        {
            var comp = GetComputer();
            if (comp == null)
                return;

            UpdateGui(comp);
            ConfigureComponents();
            CalculateTotal(sender, e);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
        }
    }

    private void PopulateDropDown(IReadOnlyList<Component> components, DropDownList dropdown, Constants.ComponentType compType)
    {
        ListItem selectedItem = null;
        foreach (var comp in components.Where(c => c.ParentComponent == compType))
        {
            var item = new ListItem($"{comp.DisplayName} ({comp.Value})", $"{comp.Id}");
            dropdown.Items.Add(item);
            if (comp.IsDefault)
                selectedItem = item;
        }
        dropdown.SelectedIndex = dropdown.Items.IndexOf(selectedItem);
    }

    protected void ConfigureComponents()
    {
        if(optDisplay.Items.Count > 0)
            return;

        var components = Dao.GetAllComponents();

        PopulateDropDown(components, optDisplay, Constants.ComponentType.Display);
        PopulateDropDown(components, optDrive, Constants.ComponentType.Drive);
        PopulateDropDown(components, optRam, Constants.ComponentType.Ram);
        PopulateDropDown(components, optCpu, Constants.ComponentType.Cpu);
        PopulateDropDown(components, optOs, Constants.ComponentType.Os);
    }

    private void UpdateGui(Component comp)
    {
        compImg.ImageUrl = comp.ImgUrl;
        compLbl.Text = comp.DisplayName;
    }

    private Component GetComputer()
    {
        var cookie = Request.Cookies[Constants.COMPUTER_COOKIE];
        var compId = cookie?.Values[Constants.COMPUTER_NAME];
        var vals = compId?.Split(',');
        compId = vals?.Length > 0 ? vals[vals.Length - 1] : "";

        return Dao.GetComputer(Int32.Parse(compId));
    }

    protected void btnAddToCart_Click(object sender, EventArgs e)
    {
        var comp = GetComputer();
        comp.UnitPrice = GetDoubleTotal();
        var subItems = new List<Component>
        {
            Dao.GetComponent(Int32.Parse(optDisplay.SelectedItem.Value)),
            Dao.GetComponent(Int32.Parse(optDrive.SelectedItem.Value)),
            Dao.GetComponent(Int32.Parse(optRam.SelectedItem.Value)),
            Dao.GetComponent(Int32.Parse(optCpu.SelectedItem.Value)),
            Dao.GetComponent(Int32.Parse(optOs.SelectedItem.Value))
        };

        var cartItem = new CartItem(comp, subItems);
        AddCartItem(cartItem);
    }

    private void AddCartItem(CartItem item)
    {
        var IsUserLoggedIn = loginSignUp.Text != "Log In";
        err.Text = IsUserLoggedIn ? "" : "PLEASE LOG IN TO ADD TO CART";

        if (IsUserLoggedIn)
        {
            item.TableRowId = Dao.AddCartItemToOrder(item, loginSignUp.Text);
            Constants.Part4CartItems.Add(item);
            Server.Transfer("Cart.aspx", false);
        }
    }

    private double GetDoubleTotal()
    {
        var total = GetComputer().UnitPrice;
        total += ParseDropDownListForPrice(optDisplay);
        total += ParseDropDownListForPrice(optDrive);
        total += ParseDropDownListForPrice(optRam);
        total += ParseDropDownListForPrice(optCpu);
        total += ParseDropDownListForPrice(optOs);
        return total;
    }

    protected void CalculateTotal(object sender, EventArgs e)
    {
        var total = GetDoubleTotal();
        totalPrice.Text = total.ToString("C");
    }

    private double ParseDropDownListForPrice(DropDownList dropdown)
    {
        var itemId = dropdown.SelectedItem.Value;
        var item = Dao.GetComponent(Int32.Parse(itemId));
        return item.UnitPrice;
    }
}