<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ComputerParts.aspx.cs" Inherits="part3_ComputerParts" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Droid+Sans:400,700"/>
    
    <link rel="stylesheet" type="text/css" href="../main.css"/>
    <link rel="stylesheet" type="text/css" href="ComputerHub.css"/>
    <title>Computer Parts</title>
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
            <section id="computerContent">
                <h1 class="content-heading">Computer Parts</h1>
            </section>
                <!-- Display Options -->
                <section class="product-part-section">
                    <h2>Display Options</h2>
                    <ul class="products-partt">
                        <li>
                            <asp:ImageButton CssClass="productPartItem" OnClick="Item_Click" ToolTip="Add to Cart" runat="server" ImageUrl="../images/part3_4/11.png" ID="item_11"/>
                            <br/>11 inch. Display ($105.05)
                        </li>
                        <li><asp:ImageButton CssClass="productPartItem" OnClick="Item_Click" ToolTip="Add to Cart" runat="server" ImageUrl="../images/part3_4/13.png" ID="item_13"/><br/>13 inch. Display ($155.33)</li>
                        <li><asp:ImageButton CssClass="productPartItem" OnClick ="Item_Click" ToolTip="Add to Cart" runat="server" ImageUrl="../images/part3_4/15.png" ID="item_15"/><br/>15 inch. Display ($205.99)</li>
                    </ul>
                </section>
                <!-- Drive Options -->
                <section class="product-part-section">
                    <h2>Drive Options</h2>
                    <ul class="products-partt">
                        <li>
                            <asp:ImageButton CssClass="productPartItem" OnClick="Item_Click" ToolTip="Add to Cart" runat="server" ImageUrl="../images/part3_4/hdd256.png" ID="item_hdd256"/>
                            <br/>HDD 256GB ($43.95)
                        </li>
                        <li><asp:ImageButton CssClass="productPartItem" OnClick ="Item_Click" ToolTip="Add to Cart" runat="server" ImageUrl="../images/part3_4/hdd500.png" ID="item_hdd500"/><br/>HDD 500GB ($54.00)</li>
                        <li><asp:ImageButton CssClass="productPartItem" OnClick ="Item_Click" ToolTip="Add to Cart" runat="server" ImageUrl="../images/part3_4/hdd750.png" ID="item_hdd750"/><br/>HDD 750GB ($62.99)</li>
                        <li><asp:ImageButton CssClass="productPartItem" OnClick ="Item_Click" ToolTip="Add to Cart" runat="server" ImageUrl="../images/part3_4/ssd128.png" ID="item_ssd128"/><br/>SSD 128GB ($72.75)</li>
                        <li><asp:ImageButton CssClass="productPartItem" OnClick ="Item_Click" ToolTip="Add to Cart" runat="server" ImageUrl="../images/part3_4/ssd256.png" ID="item_ssd256"/><br/>SSD 256GB ($103.32)</li>
                        <li><asp:ImageButton CssClass="productPartItem" OnClick ="Item_Click" ToolTip="Add to Cart" runat="server" ImageUrl="../images/part3_4/ssd500.png" ID="item_ssd500"/><br/>SSD 500GB ($183.99)</li>
                    </ul>
                </section>
    
                <!-- RAM Options -->
                <section class="product-part-section">
                    <h2>RAM Options</h2>
                    <ul class="products-partt">
                        <li>
                            <asp:ImageButton CssClass="productPartItem" OnClick="Item_Click" ToolTip="Add to Cart" runat="server" ImageUrl="../images/part3_4/ram4.png" ID="item_ram4"/>
                            <br/>RAM 4GB ($34.95)
                        </li>
                        <li><asp:ImageButton CssClass="productPartItem" OnClick ="Item_Click" ToolTip="Add to Cart" runat="server" ImageUrl="../images/part3_4/ram8.png" ID="item_ram8"/><br/>RAM 8GB ($88.02)</li>
                        <li><asp:ImageButton CssClass="productPartItem" OnClick ="Item_Click" ToolTip="Add to Cart" runat="server" ImageUrl="../images/part3_4/ram16.png" ID="item_ram16"/><br/>RAM 16GB ($124.10)</li>
                        <li><asp:ImageButton CssClass="productPartItem" OnClick ="Item_Click" ToolTip="Add to Cart" runat="server" ImageUrl="../images/part3_4/ram32.png" ID="item_ram32"/><br/>RAM 32GB ($305.75)</li>
                    </ul>
                </section>
    
                <!-- CPU Options -->
                <section class="product-part-section">
                    <h2>CPU Options</h2>
                    <ul class="products-partt">
                        <li>
                            <asp:ImageButton CssClass="productPartItem" OnClick="Item_Click" ToolTip="Add to Cart" runat="server" ImageUrl="../images/part3_4/i3.png" ID="item_i3"/>
                            <br/>Intel i3 ($110.99)
                        </li>
                         <li><asp:ImageButton CssClass="productPartItem" OnClick ="Item_Click" ToolTip="Add to Cart" runat="server" ImageUrl="../images/part3_4/i5.png" ID="item_i5"/><br/>Intel i5 ($188.25)</li>
                        <li><asp:ImageButton CssClass="productPartItem" OnClick ="Item_Click" ToolTip="Add to Cart" runat="server" ImageUrl="../images/part3_4/i7.png" ID="item_i7"/><br/>Intel i7 ($263.97)</li>
                    </ul>
                </section>
    
                <!-- OS Options -->
                <section class="product-part-section">
                    <h2>OS Options</h2>
                    <ul class="products-partt">
                        <li>
                            <asp:ImageButton CssClass="productPartItem" OnClick="Item_Click" ToolTip="Add to Cart" runat="server" ImageUrl="../images/part3_4/win7.png" ID="item_win7"/>
                            <br/>Windows 10 ($20.99)
                        </li>
                        <li><asp:ImageButton CssClass="productPartItem" OnClick ="Item_Click" ToolTip="Add to Cart" runat="server" ImageUrl="../images/part3_4/win10.png" ID="item_win10"/><br/>Windows 11 ($47.70)</li>
                        <li><asp:ImageButton CssClass="productPartItem" OnClick ="Item_Click" ToolTip="Add to Cart" runat="server" ImageUrl="../images/part3_4/macsierra.png" ID="item_macsierra"/><br/>Mac High Sierra ($52.98)</li>
                        <li><asp:ImageButton CssClass="productPartItem" OnClick ="Item_Click" ToolTip="Add to Cart" runat="server" ImageUrl="../images/part3_4/ubuntu.png" ID="item_ubuntu"/><br/>Ubuntu 17.10 ($12.65)</li>
                    </ul>
                </section>
        </main>
    </form>
     <!-- Footer -->
     <footer>
        <p>&copy; 2023 Dikshit Sharma - Web App Development. All rights reserved.</p>
    </footer>
</body>
</html>
