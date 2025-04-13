using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class applyJobsView : System.Web.UI.Page
{
     ConnectionClass con;
    protected void Page_Load(object sender, EventArgs e)
    {
         con = new ConnectionClass();
        if (!IsPostBack)
            loadData();
    }

    public void loadData()
    {
        dispAppli.DataSource = con.allRecord("select a.*,s.*,j.* from applyjob a,traineeStudents s,job j where j.Id = a.JId and s.tsId = a.SId");
        dispAppli.DataBind();
    }

    protected void del_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        RepeaterItem item = btn.NamingContainer as RepeaterItem;
        int row = con.allQuery("delete from applyjob where AId = " + btn.CommandArgument.ToString());
        if (row > 0)
        {
            Response.Write("<script>alert('deleted❌❌❌')</script>");
            loadData();
        }
    }
}

