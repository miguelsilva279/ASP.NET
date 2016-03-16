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
            resultado += "<td><a href='#' class='editar'><i class='material-icons' style='color:black;'>edit</i></a> <a href='#' class='apagar'><i class='material-icons' style='color:black;'>delete</i></a></td>";
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
    public string getBook(string id)
    {
        DataLayer x = new DataLayer();
        string resultado = string.Empty;

        Book livro = x.ReadBook(id);

        resultado += "<input class='send' id='txtID' type='hidden'value='" + livro.id + "'/>";
        resultado += "Título:</td><td><input id='txtTitle'type='text' value='" + livro.Title + "'/></br>";
        resultado += "<asp:Label ID='Label2'Text='Label>Categoria:</asp:Label></br><div id='oldCategoria'><select id='selType'><option value='empty' selected></option>";
        List<string> listaTipo = x.ReadUniqType();
        foreach(string str in listaTipo)
        {
            if(str==livro.Type)
                resultado+="<option value='"+str+"' selected>"+str+"</option>";
            else
                resultado+="<option value='"+str+"'>"+str+"</option>";
        }

        resultado += "</select><button type='button' id='btnCategoria'>Adicionar</button></div><div id='newCategoria'><input type='text' id='txtNewCategoria' /><button type='button' id='btnOkCategoria'>OK</button></br></div><div class='ui-widget'><label>Autor: </label></br>Pesquisar:<input id='tags'><button type='button' id='addAuthor'>Adicionar</button><button type='button' id='addAuthorNew'>Novo Registo</button></div><div id=newRegistoAutor><div>Primeiro Nome:</br><input id='fnameAuthor' type='text' /></br>Ultimo Nome:</br><input id='lnameAuthor' type='text' /></br>Telefone:</br><input id='telefoneAuthor' type='text' /></br>Cidade:</br><input id='cidadeAuthor' type='text' /></br><button id='btnOkAuthor' type='button'>Ok</button><button id='btnCancelAuthor' type='button'>Cancelar</button></div></div><div id='showAuthor'>";
        List<string> listaAutor = x.ReadAuthorBook(livro.id);
        for (int i = 0; i < listaAutor.Count; i++)
        {
            resultado += "<div><input  type='text' value='" + listaAutor[i] + "' readonly/><button class='eliminarAutor' type='button'>Eliminar</button></div>";

        }
        resultado += "</div><asp:Label ID='Label4' runat='server' Text='Label'>Editora:</asp:Label></br><div id='oldPub'><select id='selPub><option value='empty' selected></option>'";

        string edi = x.ReadPublisherBook(livro.PubId);

        List<string> listaEdi = x.ReadUniqPublishers();

        foreach (string str in listaEdi)
        {
            if(str==edi)
                resultado+="<option value='"+str+"' selected>"+str+"</option>";
            else
                resultado+="<option value='"+str+"'>"+str+"</option>";
        }
        resultado += "</select></div><div id='newPub'>Nome:<input type='text' id='txtNewPName'></input>City:<input type='text' id='txtNewPCity'></input>Country:<input type='text' id='txtNewPCountry'></input><button id='btnOkPublisher' type='button'>Ok</button><button id='btnCancelPublisher' type='button'>Cancelar</button></div><asp:Label ID='Label5' Text='Label'>Preço:</asp:Label></br>";
        resultado += "<input class='send' type='text' value='" + livro.Price + "' ID='txtPreco'></input></br><asp:Label ID='Label6' runat='server' Text='Label'>Data:</asp:Label></br>";
        resultado += "<input class='send' value='" + livro.PubDate + "' type='text' ID='txtDate'></input></br><label id='lblRes'></label></br><button ID='btnEditarBook' type='button'>Enviar</button><button ID='btnCancel'>Cancelar</button>";


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

    [WebMethod]
    public bool AddBook(List<string> arr1, List<string> arr2)
    {
        DataLayer x = new DataLayer();
        bool flag = false;
        DateTime dt = Convert.ToDateTime(arr1[4]);
        List<string> lista = new List<string>();

        string idPub = x.readPubID(arr1[2]);
        Book b = new Book(arr1[0], arr1[1], idPub, Convert.ToDecimal(arr1[3]), dt);

        flag = x.CreateBook(b);

        foreach (string a in arr2)
        {
            string str = x.ReadIdAuthor(a);
            lista.Add(str);
        }

        foreach (string id in lista)
        {
            flag = x.CreateBookAuthor(id, b.id);
        }

        return flag;

    }

    [WebMethod]
    public bool editBook(List<string> arr1, List<string> arr2)
    {
        DataLayer x = new DataLayer();
        bool flag = false;
        DateTime dt = Convert.ToDateTime(arr1[4]);
        List<string> lista = new List<string>();

        string idPub = x.readPubID(arr1[3]);
        Book b = new Book(arr1[1], arr1[2], idPub, Convert.ToDecimal(arr1[4]), dt);
        b.id = arr1[0];
        flag = x.UpdateBook(b);

        foreach (string a in arr2)
        {
            string str = x.ReadIdAuthor(a);
            lista.Add(str);
        }

        foreach (string id in lista)
        {
            flag = x.CreateBookAuthor(id, b.id);
        }

        return flag;

    }
}
