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
        List<string> lstType = x.ReadUniqType();
        literalType.Text = "<select id='selType'><option value='Selecione----'></option>";
        foreach (string str in lstType)
        {
            literalType.Text+="<option value='"+str+"'>"+str+"</option>";
      }
        literalType.Text += "</select>";

        List<string> lstPub = x.ReadUniqPublishers();
        literalPublisher.Text = "<select id='selPub'><option value='Selecione----'></option>";
        
        foreach (string str in lstPub)
        {
            literalPublisher.Text += "<option value='" + str + "'>" + str + "</option>";
        }
        literalPublisher.Text += "</select>";

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Server.Transfer("Default.aspx", true);
    }
   
}