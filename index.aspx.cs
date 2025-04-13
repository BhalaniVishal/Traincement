using System;
using System.Collections.Generic;
using System.Data;
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
        loadJob();
    }
    public void loadJob()
    {
        joblist.DataSource = new ConnectionClass().allRecord("select top 2 * from job");
        joblist.DataBind();
        DataTable dt = new ConnectionClass().allRecord("select * from job");
        dt.Rows.RemoveAt(0);
        dt.Rows.RemoveAt(0);
        dispmore.DataSource = dt;
        dispmore.DataBind();
    }
   
    protected void apply_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        string jobid = btn.CommandArgument;
       
       

        if(Session["sid"] == null)
        {
            Response.Redirect("login.aspx");
        }
        int total = Convert.ToInt32(con.allScalar("select count(*) from applyJob where Jid = '" + jobid + "' and Sid = '" + Session["sid"] + "'"));
        if(total < 1)
        {

            int row = con.allQuery("insert into applyJob(Jid,Sid) values ('" + jobid + "','" + Session["sid"].ToString() + "')");

            if (row > 0)
            {

                Response.Write("<script>alert('Applied for Job Successfully✅✅✅.  Further communication and conformation  for your job application  will take place via EMAIL📧')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('💁‍♂️Already Applied✅👍')</script>");
        }
    }
   
    
}