using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    ConnectionClass con;
    protected void Page_Load(object sender, EventArgs e)
    {
        con = new ConnectionClass();
    }
  
    protected void loginbtn_Click(object sender, EventArgs e)
    {
        string email, pass;
        email = lgnemail.Text;
        pass = lgnpassword.Text;

        int sid = con.studentAvailable(email,pass);
        int aid = con.adminAvailable(email, pass);
        if(sid > 0)
        {
            Session["sid"] = sid;
            Response.Redirect("index.aspx");
        }
        else if(aid > 0)
        {
            Session["aid"] = aid;
            Response.Redirect("admnDashboard.aspx");
        }
        else
        {
            Response.Write("<script>alert('Email Or Password is wrong')</script>");
        }

    }
}