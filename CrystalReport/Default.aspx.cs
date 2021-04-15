using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalReport.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CrystalReport
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=SPTest;User ID=sa;Password=sa");
            SqlCommand cmd = new SqlCommand("Select * from Customer",con);
            SqlDataAdapter sad = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sad.Fill(ds);
            //SPTestEntities dbContext = new SPTestEntities();
            //List<Customer> customers = dbContext.Customers.ToList();
            
            //customers.Fill

            ReportDocument crp = new ReportDocument();
            crp.Load(Server.MapPath("CrystalReport1.rpt"));
            crp.SetDataSource(ds.Tables["table"]);
            CrystalReportViewer1.ReportSource = crp;
            crp.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Report");



        }
    }
}