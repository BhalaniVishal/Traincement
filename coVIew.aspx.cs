using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class coVIew : System.Web.UI.Page
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
        dispCour.DataSource = con.allRecord("select * from courses");
        dispCour.DataBind();
    }
    protected void del_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        RepeaterItem item = btn.NamingContainer as RepeaterItem;
        int row = con.allQuery("delete from courses where Id = " + btn.CommandArgument.ToString());
        if (row > 0)
        {
            Response.Write("<script>alert('deleted❌❌❌')</script>");
            loadData();
        }
    }
}