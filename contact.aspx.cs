using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;

public partial class contact : System.Web.UI.Page
{
    ConnectionClass con;

    protected void Page_Load(object sender, EventArgs e)
    {
        con = new ConnectionClass();
    }
    protected void cntsmsg_Click(object sender, EventArgs e)
    {
        string acntname = cntname.Text;
        string acntemail=cntemail.Text;
        string acntsubject = cntsubject.Text;
        string acntmessage = cntmessage.Text;

        string query = "insert into contact(name,email,subject,message) values('"+acntname+"','"+acntemail+"','"+acntsubject+"','"+acntmessage+"')";

        int row = con.allQuery(query);

        if (row > 0)
        {
          
            Response.Write("<script>alert('MESSAGE SENT SUCCESSFULLY✅')</script>");
        }
        else
        {
            Response.Write("<script>alert('some error')</script>");
        }
        
    }
}