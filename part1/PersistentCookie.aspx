<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PersistentCookie.aspx.cs" Inherits="part1_PersistentCookie" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Droid+Sans:400,700"/>
    
    <link rel="stylesheet" type="text/css" href="../main.css"/>
    <link rel="stylesheet" type="text/css" href="PersistentCookie.css"/>

    <script type="text/javascript">
        function GetClientTimeZone() {
            var offset = new Date().getTimezoneOffset() / 60; /*minutes to hour*/
            var timeZone = "UTC " + new Date().toUTCString();
            timeZone += (offset < 0) ? " (+" : " (-";
            timeZone += offset + " hrs)";
            document.getElementById("LblTime").innerHTML = timeZone;
        }
    </script>

    <title>Part 1 Persistent Cookie</title>
</head>
<body onload="GetClientTimeZone()">
    <form id="form1" runat="server">
        <img class="logo" src="../images/img1.jpg"/><h1 id="title">COMP 466: TMA 3A</h1>
        <ul id="navBar">
            <li><a href="../tma3a.htm">Home</a></li>
            <li><a id="active">Part 1</a></li>
            <li><a href="../part2/Slideshow.aspx">Part 2</a></li>
            <li><a href="../part3/ComputerHub.aspx">Part 3</a></li>
            <li><a href="../part4/ComputerHub.aspx">Part 4</a></li>
        </ul>
        <div id="content">
            <asp:Image ID="ImageCookieIcon" runat="server" ImageUrl="~/images/if_Cookie_2138188.png"/>
            <h1 id="partTitle">Persistent Cookie</h1>
            <h3>Number of Hits: </h3><asp:Label runat="server" id="LblHitsCount">placeholder for visit counts</asp:Label><br/>
            <h3>Your IP Address: </h3><asp:Label runat="server" id="LblIpAddr">placeholder for visit counts</asp:Label><br/>
            <h3>Your Time Zone: </h3><asp:Label runat="server"  id="LblTime"></asp:Label><br/>

            <div id="buttons">
                <asp:Button runat="server" ID="btnResetCookie" BackColor="#990033" BorderColor="#990033"
                            BorderStyle="None" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="50px" Text="RESET COOKIE" OnClick="btnResetCookie_Click"/>
                <asp:Button runat="server" ID="btnRefresh" BackColor="#159CB9" BorderColor="#159CB9"
                            BorderStyle="None" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="50px" Text="REFRESH" OnClick="btnRefresh_Click"/>
            </div>
        </div>
    </form>
</body>
</html>--%>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PersistentCookie.aspx.cs" Inherits="part1_PersistentCookie" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Droid+Sans:400,700"/>
    <link rel="stylesheet" type="text/css" href="../main.css"/>
    <link rel="stylesheet" type="text/css" href="PersistentCookie.css"/>
   <title>Part 1 Persistent Cookie</title>
</head>
<body onload="GetClientTimeZone()">
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
    <form id="form1" runat="server">        
        <main>
            <section id="cookie-section">
                <img id="ImageCookieIcon" runat="server" src="~/images/if_Cookie_2138188.png"/><br />
                <h1 id="partTitle">Persistent Cookie</h1><br />
                <h3>Number of Hits: <asp:Label runat="server" id="LblHitsCount">placeholder for visit counts</asp:Label></h3><br />
                <h3>Your IP Address: <asp:Label runat="server" id="LblIpAddr">placeholder for visit counts</asp:Label></h3><br />
                <h3>Your Time Zone: <asp:Label runat="server"  id="LblTime"></asp:Label></h3><br />

                <div id="buttons">
                    <asp:Button runat="server" ID="btnResetCookie" BackColor="#990033" BorderColor="#990033"
                                BorderStyle="None" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="50px" Text="RESET COOKIE" OnClick="btnResetCookie_Click"/>
                    <asp:Button runat="server" ID="btnRefresh" BackColor="#159CB9" BorderColor="#159CB9"
                                BorderStyle="None" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="50px" Text="REFRESH" OnClick="btnRefresh_Click"/>
                </div>
            </section>
        </main>
    </form>
    <script type="text/javascript">
        function GetClientTimeZone() {
            var offsetMinutes = new Date().getTimezoneOffset();
            var offsetHours = offsetMinutes / 60;
            var offsetString = (offsetHours >= 0 ? '+' : '-') + (Math.abs(offsetHours) < 10 ? '0' : '') + Math.abs(offsetHours) + ':' + (offsetMinutes % 60 < 10 ? '0' : '') + (offsetMinutes % 60);
            var timeZone = Intl.DateTimeFormat().resolvedOptions().timeZone;
            document.getElementById("LblTime").textContent = timeZone + ' (UTC' + offsetString + ')';
        }
    </script>
    <!-- Footer -->
    <footer>
        <p>&copy; 2023 Dikshit Sharma - Web App Development. All rights reserved.</p>
    </footer>
</body>
</html>

