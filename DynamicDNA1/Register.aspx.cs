using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

public partial class Register : System.Web.UI.Page
{
    private object txtSurname;
    private object txtGrade;
    private object txtContact;
    private object txtEmail;

    public string txtName { get; private set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
        conn.Open();

    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            conn.Open();

            /*query*/
            string insertQuery = "insert into Users (Name, Surname, Grade,Contact,Email) Values @Name, @Surname, @Grade , @Contact , @Email";
            SqlCommand com = new SqlCommand(insertQuery, conn);

            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            
            com.Parameters.AddWithValue("@Name", txtName.Text);
            com.Parameters.AddWithValue("@Surname", txtSurname.Text);
            com.Parameters.AddWithValue("@Grade", txtGrade.Text);
            com.Parameters.AddWithValue("@Contact", txtContact.Text);
            com.Parameters.AddWithValue("@Email", txtEmail.Text);

            
            com.ExecuteNonQuery();
            Response.Redirect("Manager.aspx");
            Response.Write("Registration is successful");

           conn.Close();
        }
        catch 
            (Exception ex)
        {
            Response.Write("Error" + ex.ToString());
        }
    }
}