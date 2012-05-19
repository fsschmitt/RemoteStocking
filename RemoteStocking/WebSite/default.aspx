<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebSite._default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Remote Stocks WebSite</title>

    <link rel="stylesheet" href="stylesheets/foundation.css">
	<link rel="stylesheet" href="stylesheets/app.css">
    <script src="javascripts/modernizr.foundation.js"></script>
    <link REL="SHORTCUT ICON" HREF="images/stocks-small.ico">
    <link href='http://fonts.googleapis.com/css?family=Righteous' rel='stylesheet' type='text/css'>
    <script type="text/javascript">
        function doCheck(field) {
         if (isNaN(document.getElementById(field).value)) {
            alert('This is not a number! Please enter a valid number before submitting the form.');
            document.getElementById(field).focus();
            document.getElementById(field).select(); 
            return false;
         }

         else {
            return true;
         }
        }
    </script>
</head>
<body>
    <div id="container">
        <div class="header">
        	<ul class="breadcrumbs">
        		<div class="logo"> <img class="logo-pic" src="/images/stocks-small.png"/> Remote Stocks</div>
        	</ul>
        </div>
        <div class="line"></div>
        <div class ="main-container">
            <form id="searchForm" runat="server" onsubmit="return doCheck('txtSearch');">
                <div class="row display">
                    <div class="six columns">
                        <div class="welcome"> 
                            <h1> Bem vindo!</h1> 
                            <div id="error-server"><asp:Label ID="lblServer" runat="server"></asp:Label> </div> 
                        </div>
                    </div>
                </div>
                <div class="row display">
                    <div class="six columns info">
                        <div class="column-container">
                            <h2> Add new stocks! </h2>

                            <div class="myfield">
                                <div class="mylabel">
                                    <asp:Label ID="lblIDClient" runat="server">Client ID:</asp:Label>
                                </div>
                                <div class="myinput">
                                    <asp:TextBox ID="txtIDClient" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="myfield">
                                <div class="mylabel">
                                    <asp:Label ID="lblEmail" runat="server">Email:</asp:Label>
                                </div>
                                <div class="myinput">
                                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="myfield">
                                <div class="mylabel">
                                    <asp:Label ID="lblType" runat="server">Type:</asp:Label>
                                </div>
                                <div class="myinput">
                                    <asp:DropDownList ID="ddType" runat="server">
                                        <asp:ListItem>Buy</asp:ListItem>
                                        <asp:ListItem>Sell</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="myfield">
                                <div class="mylabel">
                                    <asp:Label ID="lblQuantity" runat="server">Quantity:</asp:Label>
                                </div>
                                <div class="myinput">
                                    <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="myfield">
                                <div class="mylabel">
                                    <asp:Label ID="lblShare" runat="server">Share:</asp:Label>
                                </div>
                                <div class="myinput">
                                    <asp:DropDownList ID="ddShare" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="myfield">
                                <div class="mylabel">
                                    <asp:Label ID="lblPrice" runat="server">Price:</asp:Label>
                                </div>
                                <div class="myinput">
                                    <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="myfield">
                                <asp:Button ID="btnNew" runat="server" onclick="btnNew_Click" 
                                        Text="Add stock" />
                            </div>
                            <div class="myfield">
                                <asp:Label ID="lblStatus" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="six columns info">
                        <div class="column-container">
                            <h2> See your stocks! </h2>
                            
                                <div id="history-form">
                                    <asp:Label ID="lblSearch" runat="server">Client ID:</asp:Label>
                                    <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                                    <asp:Button ID="btnHistory" runat="server" onclick="btnHistory_Click" 
                                        Text="Search" />
                                    <div id="history-list"><asp:ListBox ID="lbHistory" runat="server" Width="326px" Height="147px"></asp:ListBox></div>
                                </div>
                        </div>
                    </div>
                </div>
            </form>
        </div>
    </div>
    <div id="footer">
        <div class="section">
                <img src="/images/network.png"> 
                <div id="subject-name">Tecnologias de Distribuição de Integração (2012) @ FEUP</div>
        </div>
    </div>
</body>
</html>
