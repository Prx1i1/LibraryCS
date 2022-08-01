using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CringLibrary
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedInUser"] == null)
            {
                Response.Redirect("UserLogin.aspx");
                return;
            }
            if (!IsPostBack)
            {
                MySqlConnection mySqlConnection = CLibraryConn.connect();
                mySqlConnection.Open();
                MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
                mySqlCommand.CommandText = "SELECT * FROM library";
                MySqlDataReader reader = mySqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    if (update.id == reader.GetInt32("Id"))
                    {
                        AuthorBox.Text = reader.GetString("Authors");
                        TitleBox.Text = reader.GetString("Title");
                        ReleaseBox.Text = reader.GetString("Release_date");
                        ISBNBox.Text = reader.GetString("ISBN");
                        FormatBox.Text = reader.GetString("Format");
                        PagesBox.Text = reader.GetInt32("Pages").ToString();
                        DescBox.Text = reader.GetString("Description");
                    }
                }
                }
        }
        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainView.aspx");
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            
            MySqlConnection mySqlConnection = CLibraryConn.connect();
            mySqlConnection.Open();
            MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            string author = AuthorBox.Text;
            string title = TitleBox.Text;
            string release = ReleaseBox.Text;
            string ISBN = ISBNBox.Text;
            string format = FormatBox.Text;
            string pages = PagesBox.Text;
            string description = DescBox.Text;
            Label1.Text = author;
            try
            {
                mySqlCommand.CommandText = "UPDATE " + CLibraryConn.table + " SET Authors='" + author + "', Title='" +
                    title + "', Release_date='"+ release + "', ISBN='"+ ISBN + "', Format='"+ format +
                    "', Pages='"+ pages + "', Description='"+ description + "' WHERE Id=" + update.id.ToString();
                mySqlCommand.ExecuteNonQuery();
                
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Label1.Text = "Database error: " + ex;
            }

            Response.Redirect("MainView.aspx");
        }
    }
}