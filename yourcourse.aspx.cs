using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class courseList : System.Web.UI.Page
{
    ConnectionClass con;
    protected void Page_Load(object sender, EventArgs e)
    {
        con = new ConnectionClass();
        loadCourse();
    }
    public void loadCourse()
    {
        joblist.DataSource = new ConnectionClass().allRecord("select * from courses where Id in (select courseId from courseApply where studentId = '" + Session["sid"] +"')");
        joblist.DataBind();
    }

    protected void apply_Click(object sender, EventArgs e)
    {
        if (Session["sid"] == null)
        {
            Response.Redirect("login.aspx");
        }
        Button btn = (Button)sender;
        string jobid = btn.CommandArgument;
        int rowCourse = checkCourse(Convert.ToInt32(jobid));
        if (rowCourse <= 0)
        {

            if (Session["sid"] == null)
            {
                Response.Redirect("login.aspx");
            }
            int row = con.allQuery("insert into courseApply(studentId,courseId,applyDate) values ('" + Session["sid"].ToString() + "','" + jobid + "','"+DateTime.Now.ToString("yyyy-MM-dd")+"')");

            if (row > 0)
            {
                Response.Write("<script>alert('Successfully applied for course✅ you need to pay fees online within 2 days otherwise your course application will be declined❌')</script>");
            }

        }
        else
        {
            Response.Write("<script>alert('💁‍♂️Already Applied✅👍')</script>");
        }

    }
    public int checkCourse(int id)
    {
        int row = Convert.ToInt32(con.allScalar("select count(*) from courseApply where studentId = '" + Session["sid"].ToString() +"' and courseId = '"+id.ToString()+"'").ToString());
        return row;
    }
}