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
            List<string> listaAutor = x.ReadAuthorBook(element.id);
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
            string str = x.ReadPublisherBook(element.PubId);
            resultado += "<td>" + str + "</td>";
            resultado += "<td>" + element.Price.ToString() + "</td>";
            resultado += "<td>" + element.PubDate + "</td>";
            resultado += "</tr>";

        }
        return resultado;
    }

    [WebMethod]
    public string getBooks2()
    {
        DataLayer x = new DataLayer();
        string resultado = "<tr><td>ID</td><td>TITLE</td><td>TYPE</td><td>AUTHOR</td><td>PUB</td><td>PRICE</td><td>DATE</td><td>açao</td></tr>";

        List<Book> lista = new List<Book>();
        lista = x.ReadBooks();


        foreach (Book element in lista)
        {

            resultado += "<tr>";
            resultado += "<td>" + element.id + "</td>";
            resultado += "<td>" + element.Title + "</td>";
            resultado += "<td>" + element.Type + "</td>";
            List<string> listaAutor = x.ReadAuthorBook(element.id);
            int i = 1;
            resultado += "<td>";
            foreach (string item in listaAutor)
            {

                if (i == listaAutor.Count)
                    resultado += item;
                else
                    resultado += item + ", ";
                i++;

            }
            resultado += "</td>";
            string str = x.ReadPublisherBook(element.PubId);
            resultado += "<td>" + str + "</td>";
            resultado += "<td>" + element.Price.ToString() + "</td>";
            resultado += "<td>" + element.PubDate + "</td>";
            resultado += "<td><button class='mdl-button mdl-js-button mdl-button--icon'><i class='material-icons' style='color:black;'>edit</i></button> <button id='delete' class='mdl-button mdl-js-button mdl-button--icon'><i class='material-icons' style='color:black;'>delete</i></button></td>";
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
    public string getAuthors2()
    {
        DataLayer x = new DataLayer();
        string resultado = string.Empty;

        List<Author> lista = x.ReadAuthors();



        foreach (Author element in lista)
        {
            resultado += "<tr><th>ID</th><th>TITLE</th><th>TYPE</th><th>AUTHOR</th><th>PUB</th><th>PRICE</th><th>DATE</th></tr><tr>";
            resultado += "<td>" + element.Id + "</td>";
            resultado += "<td>" + element.FirstName + " " + element.LastName + "</td>";
            resultado += "<td>" + element.Phone + "</td>";
            resultado += "<td>" + element.City + "</td>";
            resultado += "<td><button id='edit' class='mdl-button mdl-js-button mdl-button--icon edit'><i class='material-icons' style='color:black;'>edit</i></button> <button id='delete' class='mdl-button mdl-js-button mdl-button--icon'><i class='material-icons' style='color:black;'>delete</i></button></td>";
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

    [WebMethod]
    public string getPublishers2()
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

    [WebMethod]
    public Array EditBook(string id)
    {
        DataLayer x = new DataLayer();
        string resultado = string.Empty;

        Book livro = x.ReadBook(id);

        string[] arr = new string[]{livro.id, livro.Title, livro.Type, livro.PubId,livro.Price.ToString(),livro.PubDate};
        return arr;

    }

    [WebMethod]
    public bool DeleteBook(string id)
    {
        DataLayer x = new DataLayer();

        bool flag = x.DelBook(id);

        return flag;
    }
}
