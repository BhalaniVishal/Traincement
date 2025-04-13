using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class edtCourse : System.Web.UI.Page
{
    ConnectionClass con;
    int fetch;

    protected void Page_Load(object sender, EventArgs e)
    {
        con = new ConnectionClass();
        fetch = Convert.ToInt32(Request.QueryString["cid"]);
       
        if (!IsPostBack)
            loadData();
       
    }

    public void loadData()
    {
        editCourse.DataSource = con.allRecord("select * from courses where Id='" + fetch + "'");
        editCourse.DataBind();

    }
    protected void edtco_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        RepeaterItem item = (RepeaterItem)btn.NamingContainer;
        string title = ((TextBox)item.FindControl("cotitle")).Text;
        string languages = ((TextBox)item.FindControl("colang")).Text;
        string description = ((TextBox)item.FindControl("codesc")).Text;
        string duration = ((TextBox)item.FindControl("coduration")).Text;
        string price = ((TextBox)item.FindControl("coprice")).Text;
        string pdf = ((FileUpload)item.FindControl("copdf")).FileName;
        string oldpdf = ((HiddenField)item.FindControl("old")).Value;

        int row = 0;
        if(pdf == "")
        {
            row = con.allQuery("update courses set title = '"
                + title + "',languages = '" + languages 
                + "',description = '"
                + description + "',duration = '" 
                + duration + "',pdf = '" + oldpdf 
                + "',price = '"+price+"' where Id = '" + fetch + "'");
        }
        else
        {
            row = con.allQuery("update courses set title = '" 
                + title + "',languages = '" + languages 
                + "',description = '" + description
                + "',duration = '" + duration + "',pdf = '"
                + pdf + "',price = '" + price 
+ "' where Id = '" + fetch + "'");
            ((FileUpload)item.FindControl("copdf")).SaveAs(Server.MapPath("coursePDF/") + pdf);
        }
        if(row > 0)
        {

            Response.Write("<script>alert('Record Updated Successfully✅')</script>");
        }
    }
}