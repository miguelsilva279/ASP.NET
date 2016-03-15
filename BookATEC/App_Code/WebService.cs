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
            resultado += "<td id='tabHide'>" + element.id + "</td>";
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
        string resultado = string.Empty;
        List<Book> lista = new List<Book>();
        lista = x.ReadBooks();


        foreach (Book element in lista)
        {

            resultado += "<tr>";
            resultado += "<td id='tabHide'>" + element.id + "</td>";
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
            resultado += "<td><button type='button' class='editar'>edit</button> <button type='button' class='apagar'>delete</button></td>";
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
            resultado += "<td id='tabHide'>" + element.Id + "</td>";
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
            resultado += "<td id='tabHide'>" + element.Id + "</td>";
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
            resultado += "<td id='tabHide'>" + element.Id + "</td>";
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
            resultado += "<td id='tabHide'>" + element.Id + "</td>";
            resultado += "<td>" + element.Name + "</td>";
            resultado += "<td>" + element.City + "</td>";
            resultado += "<td>" + element.Country + "</td>";
            resultado += "</tr>";

        }
        return resultado;
    }

    [WebMethod]
    public string EditBook(string id)
    {
        DataLayer x = new DataLayer();
        string resultado = string.Empty;

        Book livro = x.ReadBook(id);

        resultado += "<table><tr><td></td><td><input id='txtID'type='hidden'value='" + livro.id + "'/></td></tr>";
        resultado += "<tr><td>Título:</td><td><input id='txtTitle'type='text' value='" + livro.Title + "'/></td></tr>";
        resultado += "<tr id='oldType'><td>Categoria:</td><td><select id='typeBook'><option value='empty' selected></option>";
        List<string> listaTipo = x.ReadUniqType();
        foreach(string str in listaTipo)
        {
            if(str==livro.Type)
                resultado+="<option value='"+str+"' selected>"+str+"</option>";
            else
                resultado+="<option value='"+str+"'>"+str+"</option>";
        }

        resultado += "</select><button type='button' id='addType'>Adicionar Categoria</button></td></tr><tr id='newType'><td>Categoria:</td><td><input id='txtType' type='text'/></td></tr>";
        resultado += "<tr><td>Autor(es):</td>";
        List<string> listaAutor = x.ReadAuthorBook(livro.id);
        for (int i = 0; i < listaAutor.Count; i++)
        {
            if(i==0)
            resultado+="<td><input  type='text' value='"+ listaAutor[i]+"' readonly/><button class='eliminarAutor' type='button'>Eliminar</button></td></tr>";
            else
            resultado += "<tr><td></td><td><input type='text' value='" + listaAutor[i] + "'readonly/><button class='eliminarAutor' type='button'>Eliminar</button></td></tr>";

        }
        resultado += "<tr><td></td><td><button type='button' id='btnAddAuthor'>Adicionar</button></td></tr>";
        resultado += "<tr><td>Data publicação:</td><td><input type='text'id=data value='" + livro.PubDate + "'/></td></tr>";
      
        string edi = x.ReadPublisherBook(livro.PubId);
        resultado += "<tr><td>Editora:</td><td><select id='pubName'><option value='empty' selected></option>";
        List<string> listaEdi = x.ReadUniqPublishers();
        foreach(string str in listaEdi)
        {
            if(str==edi)
                resultado+="<option value='"+str+"' selected>"+str+"</option>";
            else
                resultado+="<option value='"+str+"'>"+str+"</option>";
        }
        resultado += "</select><button type='button' id='addEditora'>Adicionar Editora</button></td></tr></table>";
        resultado += "<button id='btnGuardar' type='button'>Guardar</button><button id='btnCancelar' type='button'>Cancelar</button>";



        return resultado;
    }
 
    
    [WebMethod]
    public bool DeleteBook(string id)
    {
        DataLayer x = new DataLayer();

        bool flag = x.DelBook(id);

        return flag;
    }

    [WebMethod]
    public string PesquisaAuthor()
    {
        DataLayer x = new DataLayer();
        string resultado = string.Empty;
        List<string> listaAutor = x.ReadNameAuthor();

        int i = 1;
        
        foreach (string item in listaAutor)
        {

            if (i == listaAutor.Count)
                resultado += item;
            else
                resultado += item + ", ";
            i++;

        }
        return resultado;
    }

    [WebMethod]
    public bool AddAuthor(List<string> arr)
    {
        DataLayer x = new DataLayer();

        Author au = new Author(arr[0], arr[1], arr[2], arr[3]);

        bool flag = x.CreateAuthor(au);

       
        return flag;
    }
    
    
    [WebMethod]
    public bool AddPublisher(List<string> arr)
    {
        DataLayer x = new DataLayer();

        Publisher p = new Publisher(arr[0], arr[1], arr[2]);

        bool flag = x.CreatePublisher(p);

       
        return flag;
    }
}
