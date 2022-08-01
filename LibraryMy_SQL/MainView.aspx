<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainView.aspx.cs" Inherits="CringLibrary.View" enableEventValidation="false" %>

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

        }

        input{
            border-radius: 10px;
        }

        .controls {
            width: 90%;
            display: flex;
            flex-direction: row;
            justify-content: space-evenly;
            margin: auto 5%;
        }

        .buttonfake {
            height: 2rem;
            width: 100%;
            background-color: var(--item-background);
            color: var(--primary);
            border: none;

        }

        .grid{
            margin:0 auto;
            display:flex;
            justify-content:center;
            width:800px;
            padding:20px;
            margin-bottom:30px;
        }       
        .grid td{
            padding:15px;
            text-align:center;
        }
        .grid th{
            font-size:25px;
            padding:20px;
            text-align:center;
            background-color: var(--background-color);
            color: var(--primary);
        }

        
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <div class="grid">
            <asp:GridView ID="GridView1" runat="server" Width="209px">
                <Columns>              
                    <asp:TemplateField>
                         <ItemTemplate>
                            <asp:Button runat="server" class="buttonfake" ID="ButtonDelete" Text="Delete" CommandArgument="<%# Container.DataItemIndex %>" OnClick="ButtonDelete_Click" ></asp:Button>    
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField>
                         <ItemTemplate>
                            <asp:Button runat="server" class="buttonfake" ID="ButtonUpdate" Text="Update" CommandArgument="<%# Container.DataItemIndex %>" OnClick="ButtonUpdate_Click" ></asp:Button>    
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
        </asp:GridView>
        </div>
        <div class="controls">
            <asp:Button class="button left" ID="ButtonSearch" runat="server" OnClick="ButtonSearch_Click"  Text="Search" />
            <asp:Button class="button" ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" Text="Add" />
        </div>
        
            
    </form>
</body>
</html>
