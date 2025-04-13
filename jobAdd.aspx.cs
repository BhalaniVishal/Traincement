using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    ConnectionClass con;
    protected void Page_Load(object sender, EventArgs e)
    {
        con = new ConnectionClass();
    }
    protected void addjob_Click(object sender, EventArgs e)
    {
        string ajt = jt.Text;
        string ajdesc = jdesc.Text;
        string logoimgname = logoimg.FileName;

        string query = "insert into job(title,description,logo) values('" + ajt + "','" + ajdesc.Replace("'", "''") + "','" + logoimgname + "')";
        int row = con.allQuery(query);
        if (row > 0)
        {
            logoimg.SaveAs(Server.MapPath("photo/joblogo/") + logoimgname);
            Response.Write("<script>alert('Record Addedd Successfully ✅ ')</script>");
        }
        else
        {
            Response.Write("<script>alert('some error')</script>");
        }
        jt.Text = jdesc.Text = string.Empty;

    }
}