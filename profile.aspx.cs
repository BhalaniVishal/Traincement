using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class profile : System.Web.UI.Page
{
    ConnectionClass con;
    string fetch;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["sid"] == null)
            Response.Redirect("login.aspx");
        fetch = Session["sid"].ToString();


        con = new ConnectionClass();
        if (!IsPostBack)
            loadData();
    }
    public void loadData()
    {
        dispProfile.DataSource = con.allRecord("select * from traineeStudents where tsId='"+Session["sid"].ToString()+"'");
        dispProfile.DataBind();
    }



    protected void edit_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        RepeaterItem item = (RepeaterItem)btn.NamingContainer;
        string tsName = ((TextBox)item.FindControl("plename")).Text;
        string tsMno = ((TextBox)item.FindControl("plecontact")).Text;
        string tsGender=((RadioButtonList)item.FindControl("plegender")).Text;
        string tsAddress = ((TextBox)item.FindControl("pleaddresss")).Text;
        string tsEducation = ((TextBox)item.FindControl("pleedu")).Text;
        string tsSkills = ((TextBox)item.FindControl("pleskill")).Text;
        string email = ((TextBox)item.FindControl("pleemail")).Text;
        string password = ((TextBox)item.FindControl("plepswrd")).Text;
        string profilePicture = ((FileUpload)item.FindControl("profilePicture")).FileName;
        string old = ((HiddenField)item.FindControl("old")).Value;
        int row = 0;
        if (profilePicture == "")
        {

            


            row = con.allQuery("update traineeStudents set tsName='" + tsName + "',tsMno='" + tsMno
                + "',tsAddress='" + tsAddress + "',tsEducation='" + tsEducation + "',tsSkills='" + tsSkills
                + "',email='" + email + "',tsGender='"+tsGender+"',password='" + password + "',profilePicture='" + old + "' where tsId='" + fetch + "'");
        }
        else
        {
            row = con.allQuery("update traineeStudents set tsName='" + tsName + "',tsMno='" + tsMno
                + "',tsAddress='" + tsAddress + "',tsEducation='" + tsEducation + "',tsSkills='" + tsSkills
                + "',email='" + email + "',tsGender='"+tsGender+"',password='" + password + "',profilePicture='" + profilePicture + "' where tsId='" + fetch + "'");

            ((FileUpload)item.FindControl("profilePicture")).SaveAs(Server.MapPath("photo/student/") + profilePicture);
        }
        if (row > 0)
        {

            Response.Write("<script>alert('Profile Updated Successfully🪪✅')</script>");
        }
    }
   
    protected void dispProfile_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        RadioButtonList gender = e.Item.FindControl("plegender") as RadioButtonList;
        gender.SelectedValue = con.allRecord("select * from traineeStudents where tsId='" + fetch + "'").Rows[0]["tsGender"].ToString();
    }
}