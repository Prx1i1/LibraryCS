using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CringLibrary
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object semder, EventArgs eeee)
        {
            if (Session["loggedInUser"] == null)
            {
                Response.Redirect("UserLogin.aspx");
                return;
            }
        }
        public int insert(string author, string title, string date, string isbn, string format, int pages, string description)
        {
            if ( author == "" | title == "" | date == "" | isbn == "" | format == "" | pages.ToString() == "" | description == "")
            {
                Label1.Text = "Empty boxes!";
            }
            MySqlConnection mySqlConnection = CLibraryConn.connect();
            mySqlConnection.Open();
            if (mySqlConnection == null) return -1;
            MySqlCommand command = mySqlConnection.CreateCommand();
            try
            {
                command.CommandText = "INSERT INTO " + CLibraryConn.table + " ( Authors, Title, Release_date, ISBN, Format, Pages, Description) VALUES ('" + author + "', '" + title + "', '" + date + "', '" + isbn + "', '" + format + "', '" + pages + "', '" + description + "');";
                command.ExecuteNonQuery();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Label1.Text = "Database error: " + ex;
            }
            return 1;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                insert(AuthorBox.Text, TitleBox.Text, ReleaseBox.Text, ISBNBox.Text, FormatBox.Text, Int32.Parse(PagesBox.Text), DescBox.Text);
                Response.Redirect("MainView.aspx");
            }
            catch
            {
                Label1.Text = "Incorrect data!";
            }    
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainView.aspx");
        }
    }
}