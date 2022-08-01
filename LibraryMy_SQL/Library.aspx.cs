using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CringLibrary
{
    public partial class WebForm3 : System.Web.UI.Page
    { 
        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainView.aspx");
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            string author = AuthorBox.Text;
            string title = TitleBox.Text;
            string release = ReleaseBox.Text;
            string ISBN = ISBNBox.Text;
            string format = FormatBox.Text;
            string page = PagesBox.Text;
            string desc = DescBox.Text;

            MySqlConnection mySqlConnection = CLibraryConn.connect();
            mySqlConnection.Open();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Id", typeof(Int32));
            dataTable.Columns.Add("Authors", typeof(string));
            dataTable.Columns.Add("Title", typeof(string));
            dataTable.Columns.Add("Release_date", typeof(string));
            dataTable.Columns.Add("ISBN", typeof(string));
            dataTable.Columns.Add("Format", typeof(string));
            dataTable.Columns.Add("Pages", typeof(Int32));
            dataTable.Columns.Add("Description", typeof(string));
            MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();

            mySqlCommand.CommandText = "SELECT * FROM " + CLibraryConn.table + " WHERE "; 
            if (author != "")
            {
                mySqlCommand.CommandText += "Authors='" + author + "' AND ";
            }
            if (title != "")
            {
                mySqlCommand.CommandText += "Title='" + title + "' AND ";
            }
            if (release != "")
            {
                mySqlCommand.CommandText += "Release_date='" + release + "' AND ";
            }
            if (ISBN != "")
            {
                mySqlCommand.CommandText += "ISBN='" + ISBN + "' AND ";
            }
            if (format != "")
            {
                mySqlCommand.CommandText += "Format='" + format + "' AND ";
            }
            if (page != "")
            {
                mySqlCommand.CommandText += "Pages='" + page + "' AND ";
            }
            if (desc != "")
            {
                mySqlCommand.CommandText += "Description='" + desc + "' AND ";
            }
            mySqlCommand.CommandText += " 1='1'";

            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            int ID, pages;
            while (mySqlDataReader.Read())
            {
                ID = mySqlDataReader.GetInt32("Id");
                author = mySqlDataReader.GetString("Authors");
                title = mySqlDataReader.GetString("Title");
                release = mySqlDataReader.GetString("Release_date");
                ISBN = mySqlDataReader.GetString("ISBN");
                format = mySqlDataReader.GetString("Format");
                pages = mySqlDataReader.GetInt32("Pages");
                desc = mySqlDataReader.GetString("Description");
                DataRow dataRow = dataTable.NewRow();
                dataRow["Id"] = ID;
                dataRow["Authors"] = author;
                dataRow["Title"] = title;
                dataRow["Release_date"] = release;
                dataRow["ISBN"] = ISBN;
                dataRow["Format"] = format;
                dataRow["Pages"] = pages;
                dataRow["Description"] = desc;
                dataTable.Rows.Add(dataRow);
            }
            GridView1.DataSource = dataTable;
            GridView1.DataBind();
        }
    }
}