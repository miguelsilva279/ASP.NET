using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
//To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

    public WebService()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    string[,] veiculos =
       {
            {"RENAULT","Clio 1.5 Dci","19790" },
            {"VOLKSWAGEN","Glof 1.4 TSI","22500" },
            {"FORD","Focus 1.6 TdCi","21050" },
            {"SEAT","Ibiza 1.4 TSI","15620" },
            {"BMW","320d","44700" }
        };


    [WebMethod]
    public int getValor(string marca)
    {

        for (int i = 0; i < veiculos.GetLength(0); i++)
        {
            marca = marca.ToUpper();
            if (string.Compare(marca, veiculos[i, 0], true) == 0)
            {
                return int.Parse(veiculos[i, 2]);
            }

        }
        return 0;

    }

    [WebMethod]
    public string getModelo(string marca)
    {
        marca = marca.ToUpper();
        for (int i = 0; i < veiculos.GetLength(0); i++)
        {
            if (string.Compare(marca, veiculos[i, 0], true) == 0)
            {
                return veiculos[i, 1];
            }
        }
        return "NOT FOUND";

    }
    [WebMethod]
    public string getMarcas()
    {
        XmlTextReader xmlTextReader = new XmlTextReader(Server.MapPath("XMLFile.xml"));
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load((XmlReader)xmlTextReader);
        xmlTextReader.Close();

        XmlNodeList xnList = xmlDocument.GetElementsByTagName("MARCA");
        List<string> lista = new List<string>();
        string resultado = string.Empty;
        if (xnList.Count != 0)


            foreach (XmlNode xn in xnList)
            {
                if (!lista.Contains(xn.InnerText))
                {
                    resultado += "<option>" + xn.InnerText + "</option>";
                    lista.Add(xn.InnerText);
                }
            }
        return resultado;
    }

    [WebMethod]
    public string getModelos(string marca)
    {
        XmlTextReader xmlTextReader = new XmlTextReader(Server.MapPath("XMLFile.xml"));
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load((XmlReader)xmlTextReader);
        xmlTextReader.Close();

        XmlNodeList xnList = xmlDocument.GetElementsByTagName("VEICULO");

        string resultado = string.Empty;


        foreach (XmlNode xn in xnList)
        {
            if (xn.ChildNodes[0].InnerText == marca)
            {
                resultado += "<option>" + xn.ChildNodes[1].InnerText + "</option>";
            }
        }
        return resultado;
    }
    [WebMethod]
    public string getPreco2(string marca, string modelo)
    {
        XmlTextReader xmlTextReader = new XmlTextReader(Server.MapPath("XMLFile.xml"));
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load((XmlReader)xmlTextReader);
        xmlTextReader.Close();

        XmlNodeList xnList = xmlDocument.GetElementsByTagName("VEICULO");

        string resultado = string.Empty;


        foreach (XmlNode xn in xnList)
        {
            if (xn.ChildNodes[0].InnerText == marca && xn.ChildNodes[1].InnerText == modelo)
            {
                resultado +="<img src="+xn.ChildNodes[2].InnerText+"/>";
                
            }
        }
        return resultado;
    }

    [WebMethod]
    public string getImg(string marca)
    {
        XmlTextReader xmlTextReader = new XmlTextReader(Server.MapPath("XMLFile.xml"));
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load((XmlReader)xmlTextReader);
        xmlTextReader.Close();

        XmlNodeList xnList = xmlDocument.GetElementsByTagName("VEICULO");

        string resultado = string.Empty;


        foreach (XmlNode xn in xnList)
        {
            if (xn.ChildNodes[0].InnerText == marca)
            {
                resultado = xn.ChildNodes[3].InnerText;
                return resultado;
            }
        }
        return resultado;
    }
}

