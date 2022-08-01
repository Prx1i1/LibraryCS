<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateBook.aspx.cs" Inherits="CringLibrary.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="Styles.css"/>
    <style type="text/css">    

        .main {
            height: 20rem;
            border-radius: 15px;
            width: 40vw;
            margin: 10% auto;
            background-color: var(--background-color);
            display: flex;
            flex-direction: column;
            justify-content: space-evenly;
            align-items:center;
            border: 1px solid var(--item-background);
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

        .div {
            color: var(--element-color);
        }
        table{
            margin-bottom:20px;
        }
        td{
            display:flex;
            justify-content:center;
        }
        .div{
           width:100px;   
        }

        </style>
</head>
<body>
    <form id="form2" runat="server">
        <div class="main">
            <table>
            <tr>
                <td><div class="div">Authors</div><asp:TextBox ID="AuthorBox" runat="server" style="margin-left: 30px" Width="203px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td><div class="div">Title</div><asp:TextBox ID="TitleBox" runat="server" style="margin-left: 30px" Width="203px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td><div class="div">Release_date</div><asp:TextBox ID="ReleaseBox" runat="server" style="margin-left: 30px" Width="203px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td><div class="div">ISBN</div><asp:TextBox ID="ISBNBox" runat="server" style="margin-left: 30px" Width="203px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td><div class="div">Format</div><asp:TextBox ID="FormatBox" runat="server" style="margin-left: 30px" Width="203px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td><div class="div">Pages</div><asp:TextBox ID="PagesBox" runat="server" style="margin-left: 30px" Width="203px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td><div class="div">Description</div><asp:TextBox ID="DescBox" runat="server" style="margin-left: 30px" Width="203px"></asp:TextBox>
                </td>
            </tr>
        </table>
                
        <asp:Label ID="Label1" runat="server"></asp:Label>
                <asp:Button class="button mr" ID="ButtonUpdate" runat="server" OnClick="ButtonUpdate_Click" Text="Update" />

        <asp:Button class="button" ID="ButtonBack" runat="server" OnClick="ButtonBack_Click" Text="Back" />
            
        </div>
        
        
    </form>
    
</body>
</html>
