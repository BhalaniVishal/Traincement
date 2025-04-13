using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;


public partial class edtVideo : System.Web.UI.Page
{
    ConnectionClass con;
    int fetch;

    protected void Page_Load(object sender, EventArgs e)
    {
        con = new ConnectionClass();
        fetch = Convert.ToInt32(Request.QueryString["vid"]);

        if (!IsPostBack)
            loadData();
    }

    public void loadData()
    {
        editVideo.DataSource = con.allRecord("select * from video where Id='" + fetch + "'");
        editVideo.DataBind();

    }
    public void loadCourse(DropDownList coid)
    {
        coid.DataSource = con.allRecord("select * from courses");
        coid.DataTextField = "title";
        coid.DataValueField = "Id";
        coid.DataBind();
        coid.SelectedValue = con.allRecord("select coid from video where Id = '" + fetch + "'").Rows[0]["coid"].ToString();
    }
    protected void edtpost_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        RepeaterItem item = (RepeaterItem)btn.NamingContainer;

        string url = ((TextBox)item.FindControl("vurl")).Text;
        string description = ((TextBox)item.FindControl("vdesc")).Text;
        string coid = ((DropDownList)item.FindControl("coid")).Text;

        int row = 0;
        row = con.allQuery("update video set url='" + url + "',description='" + description + "',coid='" + coid + "' where Id='" + fetch + "'  ");

        if (row > 0)
        {

            Response.Write("<script>alert('Record Updated Successfully✅')</script>");
        }
    }
    protected void editVideo_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DropDownList coid = e.Item.FindControl("coid") as DropDownList;
        loadCourse(coid);
        }
}