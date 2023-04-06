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
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if (cn.State == ConnectionState.Closed)
                        cn.Open();
                    using (DataTable dt = new DataTable("Customer"))
                    {
                        using (SqlCommand cmd = new SqlCommand("select * from macentry where UserName=@UserName", cn))
                        {
                            cmd.Parameters.AddWithValue("@UserName",/*string.Format("%{0}%",*/TextBox1.Text);
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            adapter.Fill(dt);
                            GridView1.DataSource = dt;
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

