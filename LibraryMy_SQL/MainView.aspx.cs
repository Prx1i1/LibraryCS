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
    public partial class View : System.Web.UI.Page
    {
        public List<int> booksTable = new List<int>();
        public void view()
        {

            booksTable.Clear();
            MySqlConnection mySqlConnection = CLibraryConn.connect();
            mySqlConnection.Open();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Authors", typeof(string));
            dataTable.Columns.Add("Title", typeof(string));
            dataTable.Columns.Add("Release_date", typeof(string));
            dataTable.Columns.Add("ISBN", typeof(string));
            dataTable.Columns.Add("Format", typeof(string));
            dataTable.Columns.Add("Pages", typeof(Int32));
            dataTable.Columns.Add("Description", typeof(string));
            dataTable.Columns.Add("a", typeof(Button));

            MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = "SELECT * FROM " + CLibraryConn.table;
            
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            string authors, title, releseDate, ISBN, format, description;
            int ID, pages;
            while (mySqlDataReader.Read())
            {
                ID = mySqlDataReader.GetInt32("Id");
                authors = mySqlDataReader.GetString("Authors");
                title = mySqlDataReader.GetString("Title");
                releseDate = mySqlDataReader.GetString("Release_date");
                ISBN = mySqlDataReader.GetString("ISBN");
                format = mySqlDataReader.GetString("Format");
                pages = mySqlDataReader.GetInt32("Pages");
                description = mySqlDataReader.GetString("Description");
                DataRow dataRow = dataTable.NewRow();
                Button button = new Button();
                button.Text = "Delete";
                booksTable.Add(ID);

                dataRow["Authors"] = authors;
                dataRow["Title"] = title;
                dataRow["Release_date"] = releseDate;
                dataRow["ISBN"] = ISBN;
                dataRow["Format"] = format;
                dataRow["Pages"] = pages;
                dataRow["Description"] = description;
                dataRow["a"] = button;

                dataTable.Rows.Add(dataRow);

            }
            GridView1.DataSource = dataTable;

            GridView1.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedInUser"] == null)
            {
                Response.Redirect("UserLogin.aspx");
                return;
            }
            view();
        }


        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddBook.aspx");
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("Library.aspx");
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int index = Int32.Parse(button.CommandArgument);
            string t = booksTable[index].ToString();
            index++;
            MySqlConnection mySqlConnection = CLibraryConn.connect();
            mySqlConnection.Open();
            DataTable dataTable = new DataTable();

            MySqlCommand command = mySqlConnection.CreateCommand();
            command.CommandText = "DELETE FROM library WHERE ID='" + t + "'";
            MySqlDataReader mySqlDataReader = command.ExecuteReader();

            view();

        }
        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int index = Int32.Parse(button.CommandArgument);
            int id = booksTable[index];
            update.id = id;
            Label1.Text = update.id.ToString();
            Response.Redirect("UpdateBook.aspx");
        }
    }
}