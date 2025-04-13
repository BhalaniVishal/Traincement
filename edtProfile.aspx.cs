using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class edtProfile : System.Web.UI.Page
{
    ConnectionClass con;
    int fetch;
    protected void Page_Load(object sender, EventArgs e)
    {
        con = new ConnectionClass();
        Session["sid"].ToString();
        if (!IsPostBack)
            loadData();
    }
    public void loadData()
    {
        editProfile.DataSource = con.allRecord("select * from traineeStudents where Id='" + fetch + "'");
        editProfile.DataBind();

    }

    protected void edtple_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        RepeaterItem item = (RepeaterItem)btn.NamingContainer;
        string tsName = ((TextBox)item.FindControl("edtplename")).Text;
        string tsMno=((TextBox)item.FindControl("edtplecontact")).Text;
       // string tsGender((RadioButton)item.findControl("edtplegender")).Text;
        string tsAddress=((TextBox)item.FindControl("edtpleaddress")).Text;
        string tsEducation=((TextBox)item.FindControl("edtpleedu")).Text;
        string tsSkills=((TextBox)item.FindControl("edtpleskill")).Text;
        string email=((TextBox)item.FindControl("edtpleemail")).Text;
        string password=((TextBox)item.FindControl("edtplepswrd")).Text;
        string profilePicture = ((FileUpload)item.FindControl("profilePicture")).FileName;

        int row = 0;
        if (profilePicture == "")
        {

            //tsGender='"+tsGender+"',


            row = con.allQuery("update traineeStudents set tsName='" + tsName + "',tsMno='" + tsMno
                + "',tsAddress='" + tsAddress + "',tsEducation='" + tsEducation + "',tsSkills='" + tsSkills
                + "',email='" + email + "',password='" + password + "',profilePicture='" + profilePicture + "' where Id='" + fetch + "'");
        }
        else
        {
            row = con.allQuery("update traineeStudents set tsName='" + tsName + "',tsMno='" + tsMno
                + "',tsAddress='" + tsAddress + "',tsEducation='" + tsEducation + "',tsSkills='" + tsSkills
                + "',email='" + email + "',password='" + password + "',profilePicture='" + profilePicture + "' where Id='" + fetch + "'");

            ((FileUpload)item.FindControl("pic")).SaveAs(Server.MapPath("photo/student/") + profilePicture);
        }
        if (row > 0)
        {

            Response.Write("<script>alert('Profile Updated Successfully🪪✅')</script>");
        }
    }
}