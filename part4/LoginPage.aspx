<%@ Page Language="C#" EnableViewState="true" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" Inherits="part3_LoginPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Droid+Sans:400,700"/>
    <link rel="stylesheet" type="text/css" href="../main.css"/>
    <link rel="stylesheet" type="text/css" href="ComputerHub.css"/>
    <link rel="stylesheet" type="text/css" href="Login.css"/>
    <title>Login Page</title>
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
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="loginUpdate" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
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
            <section id="computerContent_login">
                <h1 class="content-heading">Log In</h1>
                <div class="login-section" id="login">
                    <h3>Returning Customer?</h3>
                    <p>Please log into your account</p>
                    <p>Email:</p>
                    <asp:Label runat="server" CssClass="error" ID="errUser"></asp:Label>
                    <asp:TextBox runat="server" ID="tbxUser"></asp:TextBox>
                    <p>Password:</p>
                    <asp:Label runat="server" CssClass="error" ID="errPw"></asp:Label>
                    <asp:TextBox runat="server" ID="tbxPw" TextMode="Password"></asp:TextBox>
                    <asp:Button runat="server" Text="LOG IN" BackColor="#006699" BorderColor="#006699" BorderStyle="Solid" ForeColor="White" ID="btnLogin" OnClick="btnLogin_Click"/>
                    <asp:Label runat="server" CssClass="error" ID="errLogin"></asp:Label>
                </div>
                <div class="create-account-section" id="createAccount">
                    <h3>Don't have an account?</h3>
                    <p>The benefits of having an account are to keep track of orders, carts, and save your information for ease of purchase!</p>
                    <p>Email:</p>
                    <asp:Label runat="server" CssClass="error" ID="errUserCreate"></asp:Label>
                    <asp:TextBox runat="server" ID="tbxUserCreate"></asp:TextBox>
                    <p>Password:</p>
                    <asp:Label runat="server" CssClass="error" ID="errPwCreate"></asp:Label>
                    <asp:TextBox runat="server" ID="tbxPwCreate" TextMode="Password"></asp:TextBox>
                    <asp:Button runat="server" Text="CREATE ACCOUNT" BackColor="#006699" BorderColor="#006699" BorderStyle="Solid" ForeColor="White" ID="btnCreateAccount" OnClick="btnCreateAccount_Click"/>
                    <asp:Label runat="server" CssClass="error" ID="errCreate"></asp:Label>
                </div>
                <asp:Button runat="server" Text="Log Out" BackColor="#006699" BorderColor="#006699" BorderStyle="Solid" ForeColor="White" ID="btnLogout" CssClass="btnLogout" OnClick="btnLogout_Click"/>
                <br />
                <div id="pwRecovery">
                    <asp:Button runat="server" Text="PASSWORD RECOVERY" BackColor="#006699" BorderColor="#006699" BorderStyle="Solid" ForeColor="White" ID="btnPwRecovery" OnClick="btnPwRecovery_Click"/>
                    <asp:Label ID="lblNewPw" runat="server" Text="New Password"></asp:Label>
                    <asp:TextBox ID="tbxNewPw" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:Button runat="server" Text="SAVE NEW PASSWORD" BackColor="#006699" BorderColor="#006699" BorderStyle="Solid" ForeColor="White" ID="btnSaveNewPw" OnClick="btnSaveNewPw_Click"/>
                    <asp:Label runat="server" CssClass="error" ID="errNwPw"></asp:Label>
                </div>
            </section>
        </main>
        </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>