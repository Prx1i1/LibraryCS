using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CringLibrary
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs eeee)
        {
            if(Session["loggedInUser"] != null )
            {
                Response.Redirect("MainView.aspx");
                return;
            }

        }
        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            MySqlConnection mySqlConnection = CLibraryConn.connect();
            mySqlConnection.Open();
            MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();

            try
            {
                MySqlDataReader mySqlReader = MySqlHelper.ExecuteReader(mySqlConnection, "SELECT * FROM users WHERE username=@username", new MySqlParameter("@username", loginTB.Text));
                if (mySqlReader.HasRows)
                {
                    mySqlReader.Read();
                    
                    string hash = mySqlReader.GetString("hash");
                    if (Sodium.PwHash.Verify(passwordTB.Text, hash))
                    {
                        Session["loggedInUser"] = mySqlReader.GetString("username");
                        Response.Redirect("MainView.aspx");

                    }
                    else
                    {
                        Label1.Text = "User credentials incorrect";

                    }
                   


                }
                else
                {
                    Label1.Text = "No such user in database.";
                }
            } catch (MySqlException SqlEX)
            {
                Label1.Text = "database error: " + SqlEX;
            } 
           

        }

        protected void ButtonRegistration_Click(object sender, EventArgs e)
        {
            MySqlConnection mySqlConnection = CLibraryConn.connect();
            mySqlConnection.Open();
            MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            try
            {
                MySqlDataReader mySqlReader = MySqlHelper.ExecuteReader(mySqlConnection, "SELECT * FROM users WHERE username=@username", new MySqlParameter("@username", loginTB.Text));
                if (!mySqlReader.HasRows)
                {
                    mySqlReader.Close();
                    MySqlHelper.ExecuteNonQuery(mySqlConnection, "INSERT INTO users (username, hash) VALUES (@username, @hash)", new MySqlParameter("@username", loginTB.Text), new MySqlParameter("@hash", Sodium.PwHash.Hash(passwordTB.Text, 3, 16384)));
                    Session["loggedInUser"] = loginTB.Text;
                    Response.Redirect("MainView.aspx");
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Label1.Text = "Database error: " + ex;
            }
        }
    }
}