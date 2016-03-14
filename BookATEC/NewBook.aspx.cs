using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class NewBook : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        DataLayer x = new DataLayer(); 
        List<string> lista = x.ReadUniqPublishers();
        ddlType.Items.Add("");
        ddlPublisher.Items.Add("");
        foreach (string str in lista)
        {
            ddlPublisher.Items.Add(str);
        }

        List<string> lstType = x.ReadUniqType();
        foreach (string str in lstType)
        {
            ddlType.Items.Add(str);
        }
        

    }

    protected void btnOk_Click(object sender, EventArgs e)
    {

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
}