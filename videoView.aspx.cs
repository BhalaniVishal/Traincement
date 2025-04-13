using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class videoView : System.Web.UI.Page
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
        dispVid.DataSource = con.allRecord("select v.*,c.* from video v,courses c where c.Id = v.coid");
        dispVid.DataBind();
    }
    protected void del_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        RepeaterItem item = btn.NamingContainer as RepeaterItem;
        int row = con.allQuery("delete from video where Id = " + btn.CommandArgument.ToString());
        if (row > 0)
        {
            Response.Write("<script>alert('deleted❌❌❌')</script>");
            loadData();
        }
    }
}