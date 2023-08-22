<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AllComputers.aspx.cs" Inherits="part3_Products" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Droid+Sans:400,700"/>
    <link rel="stylesheet" type="text/css" href="../main.css"/>
    <link rel="stylesheet" type="text/css" href="ComputerHub.css"/>
    <title>Computer Products</title>
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
            <section class="product-section">
                <h2>Computers</h2>
                <div class="product-container">
                    <div class="product">
                        <asp:ImageButton CssClass="AddToCart" runat="server" ImageUrl="../images/part3_4/pic2-comp.png" ID="btnMacbook" OnClick="btnMacbook_Click"/>
                        <p class="product-caption">Macbook Pro</p>
                     </div>
        
                    <div class="product">
                        <asp:ImageButton CssClass="AddToCart" runat="server" ImageUrl="../images/part3_4/microsoft-surface.jpg" ID="btnMS" OnClick="btnMS_Click"/>
                        <p class="product-caption">Mircrosoft Surface</p>
                    </div>

                    <div class="product">
                        <asp:ImageButton CssClass="AddToCart" runat="server" ImageUrl="../images/part3_4/lenovo.png" ID="btnLenovo" OnClick="btnLenovo_Click"/>
                        <p class="product-caption">Lenovo</p>
                    </div>
        
                    <div class="product">
                        <asp:ImageButton CssClass="AddToCart" runat="server" ImageUrl="../images/part3_4/hp.png" ID="btnHp" OnClick="btnHp_Click"/>
                        <p class="product-caption">HP Notebook</p>
                    </div>
                </div>
            </section>
        </main>
    </form>
     <!-- Footer -->
     <footer>
        <p>&copy; 2023 Dikshit Sharma - Web App Development. All rights reserved.</p>
    </footer>
</body>
</html>
