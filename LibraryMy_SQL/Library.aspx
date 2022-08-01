<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Library.aspx.cs" Inherits="CringLibrary.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="Styles.css"/>    
    <style type="text/css">

        .main{
            margin:0 auto;
            display:flex;
            flex-direction:column;
            border: 3px solid var(--item-background);
            width:400px;
            padding:20px;
            margin-bottom:30px;
            border-radius: 10px;
        }
        
        .a{
            display:flex;
            justify-content:center;
            margin-bottom:10px;
        }
        .a input{
            width:150px;
        }
        .div{
           width:100px;   
        }
        h1, .b{
            display:flex;
            justify-content:center;
        }
        .mr{
            margin-right:20px;
        }
        table{
            margin-bottom:20px;
        }
        .q{
            display:flex;
            justify-content:center;
        }
        .down{
            display:flex;
            justify-content:center;
        }
        .down td{
            padding:20px;
        }
        .down th{
            padding:20px;
            font-size:18px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="main">
        <table>
            <tr>
                <td class="q"><div class="div">Authors</div><asp:TextBox ID="AuthorBox" runat="server" style="margin-left: 31px" Width="203px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="q"><div class="div">Title</div><asp:TextBox ID="TitleBox" runat="server" style="margin-left: 31px" Width="203px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="q"><div class="div">Release_date</div><asp:TextBox ID="ReleaseBox" runat="server" style="margin-left: 31px" Width="203px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="q"><div class="div">ISBN</div><asp:TextBox ID="ISBNBox" runat="server" style="margin-left: 31px" Width="203px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="q"><div class="div">Format</div><asp:TextBox ID="FormatBox" runat="server" style="margin-left: 31px" Width="203px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="q"><div class="div">Pages</div><asp:TextBox ID="PagesBox" runat="server" style="margin-left: 31px" Width="203px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="q"><div class="div">Description</div><asp:TextBox ID="DescBox" runat="server" style="margin-left: 31px" Width="203px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:Label ID="Label1" runat="server"></asp:Label>
            <div class="b">
                <asp:Button class="button mr" ID="ButtonBack" runat="server" OnClick="ButtonBack_Click" Text="Back" />
            <asp:Button class="button" ID="ButtonSearch" runat="server" OnClick="ButtonSearch_Click" Text="Search" />
            </div>
            
        </div>
        <div class="down">
             <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        </div>
       
    </form>
</body>
</html>
