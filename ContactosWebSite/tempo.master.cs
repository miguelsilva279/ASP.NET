using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class tempo : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        carregarTempo();
    }

    private void carregarTempo()
    {

        string url = "http://weather.yahooapis.com/forecastrss?w=750800&u=c";
        XmlTextReader xmlTextReader = new XmlTextReader(url);
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load((XmlReader)xmlTextReader);
        xmlTextReader.Close();

        XmlNodeList xnList = xmlDocument.GetElementsByTagName("item");
        
        string resultado = string.Empty;

        string a = string.Empty; 
        string b = string.Empty;
        string c = string.Empty;
        string d = string.Empty;

        foreach (XmlNode xn in xnList)
        {
            a = xn.ChildNodes[5].Attributes["code"].InnerText;
            b = xn.ChildNodes[5].Attributes["temp"].InnerText;
            c = xn.ChildNodes[7].Attributes["high"].InnerText;
            d = xn.ChildNodes[7].Attributes["low"].InnerText;
        }
        try
        {
            weather_img.Text = "<img width='50' src='http://l.yimg.com/a/i/us/we/52/"+ a +".gif'/>";
            weather_temp.Text = b + "ºC";
            weather_max_temp.Text = "Max:" + c + "ºC";
            weather_min_temp.Text = "Min:" + d + "ºC";
        }

        catch
        {

            weather_tr.Visible = false;
        }

    }

}
