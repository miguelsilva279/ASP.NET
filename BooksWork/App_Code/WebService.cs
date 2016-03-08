using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

    public WebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string getBooks()
    {
        DataLayer x = new DataLayer();
        string resultado = string.Empty;

        List<Book> lista = new List<Book>();
        lista = x.ReadBook(lista);


        foreach (Book element in lista)
        {
            resultado += "<tr>";
            resultado += "<td>" + element.id + "</td>";
            resultado += "<td>" + element.Title + "</td>";
            resultado += "<td>" + element.Type + "</td>";
            List<string> listaAutor = x.ReadAuthor(element.id);
            int i = 0;
            resultado += "<td>";
            foreach (string item in listaAutor)
            {

                if (item[i] == (listaAutor.Count - 1))
                    resultado += item ;
                else
                    resultado += item + ", ";

            }
            resultado += "</td>";
            string str = x.ReadPublisher(element.PubId);
            resultado += "<td>" + str + "</td>";
            resultado += "<td>" + element.Price.ToString() + "</td>";
            resultado += "<td>" + element.PubDate + "</td>";
            resultado += "</tr>";

        }
        return resultado;
    }

}
