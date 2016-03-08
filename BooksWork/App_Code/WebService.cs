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
        lista = x.ReadBooks();


        foreach (Book element in lista)
        {
            resultado += "<tr>";
            resultado += "<td>" + element.id + "</td>";
            resultado += "<td>" + element.Title + "</td>";
            resultado += "<td>" + element.Type + "</td>";
            List<string> listaAutor = x.ReadAuthor(element.id);
            int i = 1;
            resultado += "<td>";
            foreach (string item in listaAutor)
            {

                if (i==listaAutor.Count)
                    resultado += item ;
                else
                    resultado += item + ", ";
                i++;

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

    [WebMethod]
    public string getAuthors()
    {
        DataLayer x = new DataLayer();
        string resultado = string.Empty;

        List<Author> lista = x.ReadAuthors();
        


        foreach (Author element in lista)
        {
            resultado += "<tr>";
            resultado += "<td>" + element.Id + "</td>";
            resultado += "<td>" + element.FirstName+" "+ element.LastName+"</td>";
            resultado += "<td>" + element.Phone+ "</td>";
            resultado += "<td>" + element.City + "</td>";
            resultado += "</tr>";

        }
        return resultado;
    }

    [WebMethod]
    public string getPublishers()
    {
        DataLayer x = new DataLayer();
        string resultado = string.Empty;

        List<Publisher> lista = x.ReadPublishers();



        foreach (Publisher element in lista)
        {
            resultado += "<tr>";
            resultado += "<td>" + element.Id + "</td>";
            resultado += "<td>" + element.Name + "</td>";
            resultado += "<td>" + element.City + "</td>";
            resultado += "<td>" + element.Country + "</td>";
            resultado += "</tr>";

        }
        return resultado;
    }
}
