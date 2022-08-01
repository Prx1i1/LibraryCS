using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CringLibrary
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private MySqlConnection connect()
        {
            string myconnection =
                "Server=" + serverTextBox.Text + ";" +
                "Database=" + databaseTextBox.Text + ";" +
                "User=" + userTextBox.Text + ";";
            MySqlConnection mySqlConnection = new MySqlConnection(myconnection);
            CLibraryConn.server = serverTextBox.Text;
            CLibraryConn.db = databaseTextBox.Text;
            CLibraryConn.table = databaseTextBox.Text;
            CLibraryConn.user = userTextBox.Text;

            try
            {
                mySqlConnection.Open();
                Label1.Text = "Connected";
                Response.Redirect("UserLogin.aspx");
                return mySqlConnection;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Label1.Text = "Database error: " + ex;
                //if returns error, database is wrong/missing
            }
            return null;
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            connect();
        }
    }
}