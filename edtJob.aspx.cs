using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class edtJob : System.Web.UI.Page
{
    ConnectionClass con;
    int fetch;

    protected void Page_Load(object sender, EventArgs e)
    {
        con = new ConnectionClass();
        fetch = Convert.ToInt32(Request.QueryString["jid"]);

        if (!IsPostBack)
            loadData();
    }
    public void loadData()
    {
        editJob.DataSource = con.allRecord("select * from job where Id='" + fetch + "'");
        editJob.DataBind();

    }
    protected void editjob_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        RepeaterItem item = (RepeaterItem)btn.NamingContainer;
        string title = ((TextBox)item.FindControl("jt")).Text;
        string description = ((TextBox)item.FindControl("jdesc")).Text;
        string logo = ((FileUpload)item.FindControl("logoimg")).FileName;

        int row = 0;
        
      if(logo == "")
      {
          row = con.allQuery("update job set title='" + title + "',description='" + description + "',logo='" + logo + "' where Id ='"+fetch+"'");

      }
        else
      {
          row = con.allQuery("update job set title='" + title + "',description='" + description + "',logo='" + logo + "' where Id ='" + fetch + "'");
          ((FileUpload)item.FindControl("logoimg")).SaveAs(Server.MapPath("photo/joblogo") + logo);
      }
      if (row > 0)
      {

          Response.Write("<script>alert('Record Updated Successfully✅')</script>");
      }
    }
}