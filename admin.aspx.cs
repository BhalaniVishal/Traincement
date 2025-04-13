using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin : System.Web.UI.Page
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
        dispAdn.DataSource = con.allRecord("select * from admin");
        dispAdn.DataBind();
    }
}

   
   