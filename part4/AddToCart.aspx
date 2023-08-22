<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddToCart.aspx.cs" Inherits="part3_AddToCart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Droid+Sans:400,700"/>
    
    <link rel="stylesheet" type="text/css" href="../main.css"/>
    <link rel="stylesheet" type="text/css" href="ComputerHub.css"/>

    <title>Product Item</title>
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <img class="logo" src="../images/img1.jpg"/><h1 id="title">COMP 466: TMA 3A</h1>
        </header>
        <!-- Navigation menu -->
        <nav>
            <div class="nav-left">
                <a href="../tma3a.htm">Home</a>
            </div>
            <div class="nav-right">
                <a href="../part1/PersistentCookie.aspx">Part 1</a>
                <a href="../part2/Slideshow.aspx">Part 2</a>
                <a href="../part3/ComputerHub.aspx">Part 3</a>
                <a href="../part4/ComputerHub.aspx">Part 4</a>
            </div>
        </nav>
        <main id="content">
            <section id="computerNav">
                <div class="logo">
                    <img src="../images/if_computer_406819.png" alt="ComputOS Logo" class="logo-image"/>
                    <h1 class="store-name">Computer Hub</h1>
                </div>
                <div class="navigation">
                    <asp:Menu ID="Menu1" CssClass="menu"
                              Orientation="Horizontal" runat="server">
                        <Items>
                            <asp:MenuItem NavigateUrl="ComputerHub.aspx" Text="HOME"/>
                            <asp:MenuItem Text="PRODUCTS" Selectable="False">
                                <asp:MenuItem NavigateUrl="AllComputers.aspx" Text="COMPUTERS"></asp:MenuItem>
                                <asp:MenuItem NavigateUrl="ComputerParts.aspx" Text="COMPUTER PARTS"></asp:MenuItem>
                            </asp:MenuItem>
                            <asp:MenuItem NavigateUrl="Contact.aspx" Text="CONTACT"/>
                            <asp:MenuItem NavigateUrl="Feedback.aspx" Text="FEEDBACK"/>
                        </Items>
                    </asp:Menu>
                </div>
                <div class="user-panel">
                    <asp:Button runat="server" ID="loginSignUp" PostBackUrl="LoginPage.aspx" CssClass="loginSignup" Text="Log In"/>
                    <div class="cart">
                        <a href="Cart.aspx">
                            <img src="../images/if_shopping-cart_85774.png" alt="Shopping Cart" class="cart-icon"/>
                        </a>
                    </div>
                </div>
            </section>           
            <div id="computerContent">
                <div id="productDetails">
                    <div id="productTitle">
                        <h1>Product</h1>
                        <asp:Label runat="server" ID="compLbl" Font-Size="30px"></asp:Label>
                    </div>
                </div>
                <asp:Label runat="server" ID="err" CssClass="error"></asp:Label>
                <asp:Image ID="compImg" runat="server"/>
                <table id="productOptions">
                    <tr>
                        <td>Display:</td>
                        <td><asp:DropDownList runat="server" id="optDisplay" OnSelectedIndexChanged="CalculateTotal" AutoPostBack="True"/></td>
                    </tr>
                    <tr>
                        <td>Drive:</td>
                        <td><asp:DropDownList runat="server" id="optDrive" OnSelectedIndexChanged="CalculateTotal" AutoPostBack="True"/></td>
                    </tr>
                    <tr>
                        <td>RAM:</td>
                        <td><asp:DropDownList runat="server" id="optRam" OnSelectedIndexChanged="CalculateTotal" AutoPostBack="True"/></td>
                    </tr>
                    <tr>
                        <td>CPU:</td>
                        <td><asp:DropDownList runat="server" id="optCpu" OnSelectedIndexChanged="CalculateTotal" AutoPostBack="True"/></td>
                    </tr>
                    <tr>
                        <td>OS:</td>
                        <td><asp:DropDownList runat="server" id="optOs" OnSelectedIndexChanged="CalculateTotal" AutoPostBack="True"/></td>
                    </tr>
                </table><br />
                <div id="productActions">
                        <h2>Total Price: <asp:Label runat="server" ID="totalPrice" Font-Size="30px"></asp:Label></h2><br />
                        <asp:Button runat="server" Text="ADD TO CART" BackColor="#006699" BorderColor="#006699" BorderStyle="Solid" ForeColor="White" ID="btnAddToCart" OnClick="btnAddToCart_Click"/>
                </div>
            </div>
        </main>
    </form>
</body>
</html>
