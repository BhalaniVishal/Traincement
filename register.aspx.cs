    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class register : System.Web.UI.Page
{
    ConnectionClass con;

    protected void Page_Load(object sender, EventArgs e)
    {
        con = new ConnectionClass();
    }
    protected void sumbit_Click(object sender, EventArgs e)
    {
        string aurgname = urgname.Text;
        string aurgcontact = urgcontact.Text;
        string ardb=rdb.Text;
        string aurgaddress = urgaddress.Text;
        string aurgeducation = urgeducation.Text;
        string aurgskills = urgskills.Text;
        string aurgemail = urgemail.Text;
        string aurgpass = urgpass.Text;
        string aurgfu = urgfu.FileName;


        string query = "insert into traineeStudents(tsName,tsMno,tsGender,tsAddress,tsEducation,tsSkills,email,password,profilePicture) values('" + aurgname 
            + "','" + aurgcontact + "','" + ardb
            + "','" + aurgaddress + "','" + aurgeducation
            + "','" + aurgskills + "','" + aurgemail
            + "','" + aurgpass + "','" + aurgfu + "')";
       
        int row = con.allQuery(query);
       
        if (row > 0)
        {
            urgfu.SaveAs(Server.MapPath("photo/student/") + aurgfu);
            Response.Write("<script>alert('Registered Successfully✅')</script>");
        }
        else
        {
            Response.Write("<script>alert('some error')</script>");
        }
        rdb.ClearSelection();
        urgname.Text = urgcontact.Text = urgaddress.Text = urgeducation.Text = urgskills.Text = urgemail.Text = string.Empty;


    }
}