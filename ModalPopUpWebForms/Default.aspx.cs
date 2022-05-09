using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ModalPopUpWebForms
{
    public partial class _Default : Page
    {
        private String strConnString = ConfigurationManager.ConnectionStrings["ModalPopupconnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDisplayModalPopUp_Click(object sender, EventArgs e)
        {
            BindData();
        }
        private void BindData()
        {
            SqlCommand cmd = new SqlCommand("Select * from Person");
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    con.Open();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                    gv.DataSource = dt;
                    gv.DataBind();
                }
            }
            ClientScript.RegisterStartupScript(this.GetType(), "Pop", "OpenModal();", true);

        }
    }
}