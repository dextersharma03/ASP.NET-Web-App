<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Feedback.aspx.cs" Inherits="part3_Feedback" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Droid+Sans:400,700"/>
    <link rel="stylesheet" type="text/css" href="../main.css"/>
    <link rel="stylesheet" type="text/css" href="ComputerHub.css"/>
    <title>Feedback</title>
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
            <section id="computerContent_feedback">
                <h1 class="content-heading">Feedback Form</h1>
                <p>Please fill out the form fully and click Submit.</p>
                <h3>Name:</h3><asp:Label runat="server" CssClass="error" id="errName"></asp:Label>
                <asp:TextBox id="tbxName" runat="server" MaxLength="50" placeholder="John Doe" Width="335px" OnTextChanged="tbxName_TextChanged"></asp:TextBox>
                <br />
                <h3>Email:</h3><asp:Label runat="server" CssClass="error" id="errEmail"></asp:Label>
                <asp:TextBox ID="tbxEmail" runat="server" MaxLength="50" placeholder="johndoe@mail.com" Width="335px" OnTextChanged="tbxEmail_TextChanged"></asp:TextBox>
                <br />
                <h3>Subject Line:</h3><asp:Label runat="server" CssClass="error" id="errSubject"></asp:Label>
                <asp:TextBox ID="tbxSubject" runat="server" MaxLength="100" placeholder="Billing" Width="474px" OnTextChanged="tbxSubject_TextChanged"></asp:TextBox>
                <br />
                <h3>Details:</h3><asp:Label runat="server" CssClass="error" id="errDetails"></asp:Label>
                <asp:TextBox ID="tbxDetails" runat="server" placeholder="Enter your feedback" Height="191px" TextMode="MultiLine" Width="964px" OnTextChanged="tbxDetails_TextChanged"></asp:TextBox>
                <asp:Label runat="server" CssClass="error" id="errSubmit"></asp:Label><br />
                <asp:Button style="margin-bottom: 30px" runat="server" Text="SUBMIT FORM" ID="btnSubmit" OnClick="btnSubmit_Click" CssClass="submit-button"/>
            </section>
        </main>
    </form>
     <!-- Footer -->
     <footer>
        <p>&copy; 2023 Dikshit Sharma - Web App Development. All rights reserved.</p>
    </footer>
</body>
</html>
