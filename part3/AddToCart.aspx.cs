using System;
using System.Collections.Generic;
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
            UpdateGui(comp);
            ConfigureComponents();
            CalculateTotal(sender, e);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
        }
    }

    protected void ConfigureComponents()
    {
        if(optDisplay.Items.Count > 0)
            return;

        optDisplay.Items.Add(new ListItem("11 inch ($111.99)","111.99"));
        optDisplay.Items.Add(new ListItem("13 inch. ($161.99)", "161.99"));
        optDisplay.Items.Add(new ListItem("15 inch. ($199.99)", "199.99"));
        optDisplay.SelectedIndex = 1;

        optDrive.Items.Add(new ListItem("HDD 256GB ($49.99)", "49.99"));
        optDrive.Items.Add(new ListItem("HDD 500GB ($50.00)", "50.00"));
        optDrive.Items.Add(new ListItem("HDD 750GB ($69.99)", "69.99"));
        optDrive.Items.Add(new ListItem("SSD 128GB ($89.99)", "89.99"));
        optDrive.Items.Add(new ListItem("SSD 256GB ($119.99)", "119.99"));
        optDrive.Items.Add(new ListItem("SSD 500GB ($169.99)", "169.99"));
        optDrive.SelectedIndex = 3;

        optRam.Items.Add(new ListItem("4GB ($25.99)", "25.99"));
        optRam.Items.Add(new ListItem("8GB ($79.00)", "79.00"));
        optRam.Items.Add(new ListItem("16GB ($139.99)", "139.99"));
        optRam.Items.Add(new ListItem("32GB ($200.00)", "200.00"));
        optRam.SelectedIndex = 1;

        optCpu.Items.Add(new ListItem("Intel i3 ($111.99)", "111.99"));
        optCpu.Items.Add(new ListItem("Intel i5 ($159.99)", "159.99"));
        optCpu.Items.Add(new ListItem("Intel i7 ($250.00)", "250.00"));
        optCpu.SelectedIndex = 1;

        optOs.Items.Add(new ListItem("Windows 10 ($19.99)", "19.99"));
        optOs.Items.Add(new ListItem("Windows 11 ($49.99)", "49.99"));
        optOs.Items.Add(new ListItem("Mac High Sierra ($60.00)", "60.00"));
        optOs.Items.Add(new ListItem("Ubuntu 17.10 ($29.99)", "29.99"));
        optOs.SelectedIndex = 0;
    }

    private void UpdateGui(Constants.Computer comp)
    {
        compImg.ImageUrl = Constants.ComputerImages[comp];
        compLbl.Text = Constants.ComputerDisplayName[comp];
    }

    private Constants.Computer GetComputer()
    {
        var cookie = Request.Cookies[Constants.COMPUTER_COOKIE];
        var comp = cookie?.Values[Constants.COMPUTER_NAME];
        var vals = comp?.Split(',');
        comp = vals?.Length > 0 ? vals[vals.Length - 1] : "";

        if (Enum.TryParse(comp, out Constants.Computer compEnum))
            return compEnum;

        throw new ArgumentNullException("Cannot get the computer product information");
    }

    protected void btnAddToCart_Click(object sender, EventArgs e)
    {
        var comp = GetComputer();
        var compItem = new Component(Constants.ComponentType.Computer, Constants.ComputerDisplayName[comp],
            Constants.ComputerPrices[comp], false);

        var subItems = new List<Component>();
        var selectedDisplay = optDisplay.SelectedItem;
        subItems.Add(new Component(Constants.ComponentType.Display, selectedDisplay.Text,
            Double.Parse(selectedDisplay.Value), false));
        var selectedDrive = optDrive.SelectedItem;
        subItems.Add(new Component(Constants.ComponentType.Drive, selectedDrive.Text,
            Double.Parse(selectedDrive.Value), false));
        var selectedRam = optRam.SelectedItem;
        subItems.Add(new Component(Constants.ComponentType.Ram, selectedRam.Text,
            Double.Parse(selectedRam.Value), false));
        var selectedCpu = optCpu.SelectedItem;
        subItems.Add(new Component(Constants.ComponentType.Cpu, selectedCpu.Text,
            Double.Parse(selectedCpu.Value), false));
        var selectedOs = optOs.SelectedItem;
        subItems.Add(new Component(Constants.ComponentType.Os, selectedOs.Text,
            Double.Parse(selectedOs.Value), false));

        var cartItem = new CartItem(compItem, subItems);
        AddCartItemCookie(cartItem);
    }

    private void AddCartItemCookie(CartItem item)
    {
        var cookie = Request.Cookies[Constants.CART_COOKIE];
        var cartItems = cookie?.Values[Constants.CART_ITEMS];
        if (cartItems == null)
        {
            cookie = new HttpCookie(Constants.CART_COOKIE);
            cookie.Values.Add(Constants.CART_ITEMS, item.Id.ToString());
            cookie.Expires = DateTime.MaxValue;
            Response.Cookies.Add(cookie);
        }
        else
            cookie.Values.Add(Constants.CART_ITEMS, item.Id.ToString());

        Constants.CartItems.Add(item);
        Server.Transfer("Cart.aspx", false);
    }

    protected void CalculateTotal(object sender, EventArgs e)
    {
        var total = ParseDropDownListForPrice(optDisplay);
        total += ParseDropDownListForPrice(optDrive);
        total += ParseDropDownListForPrice(optRam);
        total += ParseDropDownListForPrice(optCpu);
        total += ParseDropDownListForPrice(optOs);

        totalPrice.Text = total.ToString("C");
    }

    private double ParseDropDownListForPrice(DropDownList dropdown)
        => Double.Parse(dropdown.SelectedItem.Value);
}