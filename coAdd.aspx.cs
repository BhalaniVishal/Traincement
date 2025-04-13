using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class coAdd : System.Web.UI.Page
{
   
        ConnectionClass con;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new ConnectionClass();
        }
   
        protected void addco_Click(object sender, EventArgs e)
        {
            
            string acotitle = cotitle.Text;
            string acolang = colang.Text;
            string acodesc = codesc.Text;
            string acoduration =coduration.Text;
            string acopdf = copdf.FileName;
            string acoprice = coprice.Text;
            
            if(copdf.HasFile)
            {
                string query = "insert into courses(title,languages,description,duration,pdf,price) values('" + acotitle + "','" + acolang + "','" + acodesc + "','" + acoduration + "','" + acopdf + "','" + acoprice + "')";
                int row = con.allQuery(query);
                if (row > 0)
                {
                    copdf.SaveAs(Server.MapPath("coursePDF/") + acopdf);
                    Response.Write("<script>alert('Record Addedd Successfully✅')</script>");
                }
                else
                {
                    Response.Write("<script>alert('some error')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Please Select PDF')</script>");
            }
                
                
       }
    


    
}