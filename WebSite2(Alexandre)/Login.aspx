<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="http://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <link type="text/css" rel="stylesheet" href="css/materialize.min.css"  media="screen,projection"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <link rel="stylesheet" href="css/hello.css" />
    <script src="js/js.js"></script>

    <link rel="stylesheet" href="css/mdl.min.css"/>
    <script defer src="js/mdl.min.js"></script>
</head>
<body>
    <script type="text/javascript" src="https://code.jquery.com/jquery-2.1.1.min.js"></script>
    <script type="text/javascript" src="js/materialize.min.js"></script>
    <div>
    <!-- Tabela de login -->
        <div id="idaddtabela" class="addtabela z-depth-3" style="background: white">
        <h4 style="text-align:center">Login</h4>
        <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="#FF3300"></asp:Label>
        <form runat="server">

            <div class="row">
                <div class="input-field col s12">
                    <asp:TextBox ID="TxtUsername" runat="server"></asp:TextBox>
                    <label for="username">UserName</label>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:TextBox ID="TxtPassword" TextMode="Password" runat="server"></asp:TextBox>
                    <label for="TxtPassword">Password</label>
                </div>
            </div>
            <button class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect mdl-button--primary" style="margin-left: 240px;" onServerClick="BotaoLogin_Click" runat="server">Entrar</button>

        </form>
    </div>
    </div>
</body>
</html>
