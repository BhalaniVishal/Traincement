using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class videoAdd : System.Web.UI.Page
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
        coid.DataSource = con.allRecord("select * from courses");
        coid.DataTextField = "title";
        coid.DataValueField = "Id";
        coid.DataBind();
    }
    protected void addpost_Click(object sender, EventArgs e)
    {
       
       
        string avurl = vurl.Text;
        string avdesc = vdesc.Text;
        string acoid = coid.Text;
        

        string query = "insert into video(url,description,coid) values('" + avurl+ "','" + avdesc + "','" + acoid + "')";

        int row = con.allQuery(query);
        if (row > 0)
        {
           
            Response.Write("<script>alert('Video Addedd Successfully✅👍  ')</script>");
        }
        else
        {
            Response.Write("<script>alert('some error')</script>");
        }

    }
}