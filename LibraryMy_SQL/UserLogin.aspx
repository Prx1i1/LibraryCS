<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="CringLibrary.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="Styles.css" />
    <style>
 
        .main {
            height: 20rem;
            width: 40vw;
            margin: 10% auto;
            background-color: var(--background-color);
            display: flex;
            flex-direction: column;
            justify-content: space-evenly;
            align-items:center;
            border: 1px solid var(--item-background)

        }

        .a {
            width: 75%;
            
        }

        input {
            text-align: center;
        }

        input:focus {
            outline: none;
        }

        .span {
            display: flex;
            flex-direction: column;
            justify-content: space-evenly;

        }

        .a > .span > .input {
            width: 100%;
        }
        .a > .span {
            margin: 0 20%;
        }

        span {
            color: var(--primary);
        }


    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="main">
            <div class="a"><span class="span">Login<asp:TextBox class="input" ID="loginTB" runat="server"></asp:TextBox></span></div>
            <div class="a"><span class="span">Password<asp:TextBox class="input" ID="passwordTB" runat="server" TextMode="Password" ></asp:TextBox></span></div>
        <asp:Button class="button mr" ID="ButtonLogin" runat="server" Text="Login" OnClick="ButtonLogin_Click" />
        <asp:Button class="button" ID="ButtonRegistration" runat="server" Text="Register" OnClick="ButtonRegistration_Click" />
        <asp:Label ID="Label1" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
