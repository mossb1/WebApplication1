using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e) /* Button1_click event */
        {
            try
            {

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString)) /* Starts a connection on button click using the Sctring foun in Web.config */
                {
                    if (cn.State == ConnectionState.Closed) /* restarts the connection if it is closed */
                        cn.Open();
                    using (DataTable dt = new DataTable("Customer")) /* a new data table is created named Customer */
                    {
                        using (SqlCommand cmd = new SqlCommand("select * from macentry where UserName=@UserName", cn)) /* This selects all info tied with the Username that is entered. You can replace the * if you only want to pull specific columns */
                        {
                            cmd.Parameters.AddWithValue("@UserName",TextBox1.Text); /*this takes in the string entered into the textbox*/
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            adapter.Fill(dt); /* fills the datatable with the values from the SQL Server */
                            GridView1.DataSource = dt; /*Sets the Grid data course to the datatable */
                            GridView1.DataBind();



                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw;
            }


        }
    }
}

