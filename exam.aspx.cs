using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["sid"] == null)
            Response.Redirect("login.aspx");
    }
    protected void goto_Click(object sender, EventArgs e)
    {
        Session["score"] = checkScore();
        Response.Redirect("certificate.aspx");
        
    }
    public int checkScore()
    {
        int s = 0;
        int qa1 = que1.SelectedIndex;
        int qa2 = que2.SelectedIndex;
        int qa3 = que3.SelectedIndex;
        int qa4 = que4.SelectedIndex;
        int qa5 = que5.SelectedIndex;
        int qa6 = que6.SelectedIndex;
        int qa7 = que7.SelectedIndex;
        int qa8 = que8.SelectedIndex;
        int qa9 = que9.SelectedIndex;
        int qa10 = que10.SelectedIndex;
        if (qa1 == 0)
            s++;
        if (qa2 == 1)
            s++;
        if (qa3 == 1)
            s++;
        if (qa4 == 3)
            s++;
        if (qa5 == 0)
            s++;
        if (qa6 == 2)
            s++;
        if (qa7 == 2)
            s++;
        if (qa8 == 3)
            s++;
        if (qa9 == 1)
            s++;
        if (qa10 == 3)
            s++;
        return s;
    }
}