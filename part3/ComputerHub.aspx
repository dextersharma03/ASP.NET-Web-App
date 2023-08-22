<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ComputerHub.aspx.cs" Inherits="part3_ComputerHub" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Droid+Sans:400,700"/>
    <link rel="stylesheet" type="text/css" href="ComputerHub.css"/>
    <link rel="stylesheet" type="text/css" href="../main.css"/>

    <title>Part 3: Computer Store 1.0</title>
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
            <section id="computerContent" style="text-align: center">
                <h2>Welcome To Computer Hub!</h2>
                <asp:Image runat="server" ImageUrl="../images/part3_4/pic1.jpg" ImageAlign="Middle" CssClass="compBanner"/>
            </section>
            <!-- Add a section for Computers -->
            <section class="product-section">
                <h2>Computers</h2>
                <div class="product-container">
                    <div class="product">
                        <img src="../images/part3_4/pic2-comp.png" alt="MacBook Pro">
                        <p class="product-caption">MacBook Pro</p>
                        <p class="product-price">Starting at $1699.99</p>
                        <a href="AllComputers.aspx" class="product-link">View Details</a>
                    </div>
            
                    <div class="product">
                        <img src="../images/part3_4/microsoft-surface.jpg" alt="Microsoft Surface">
                        <p class="product-caption">Microsoft Surface</p>
                        <p class="product-price">Starting at $1499.99</p>
                        <a href="AllComputers.aspx" class="product-link">View Details</a>
                    </div>
            
                </div>
            </section>
    
            <section class="product-section">
                <h2>Computer Parts</h2>
                <div class="product-container">
                    <div class="product">
                        <img src="../images/part3_4/keyboard.jpg" alt="Keyboard">
                        <p class="product-caption">High-performance Keyboards</p>
                        <p class="product-price">Starting at $349.99</p>
                        <a href="ComputerParts.aspx" class="product-link">View Details</a>
                    </div>
            
                    <div class="product">
                        <img src="../images/part3_4/mice.jpg" alt="Mouse">
                        <p class="product-caption">Gaming Mouse</p>
                        <p class="product-price">Starting at $59.99</p>
                        <a href="ComputerParts.aspx" class="product-link">View Details</a>
                    </div>
                  </div>
            </section>

            <section id="aboutUs">
                <h2>About Us</h2>
                <p>Welcome to Computer Hub, your one-stop shop for all things tech. With a wide range of laptops, computer parts, and accessories, we're here to cater to your computing needs.</p>
                <p>Our team of experts ensures that you get the latest and greatest products, backed by our exceptional customer service. Join us on the journey to explore the world of cutting-edge technology.</p>
            </section>
        </main>
    </form>
    <!-- Footer -->
    <footer>
        <p>&copy; 2023 Dikshit Sharma - Web App Development. All rights reserved.</p>
    </footer>
</body>
</html>
