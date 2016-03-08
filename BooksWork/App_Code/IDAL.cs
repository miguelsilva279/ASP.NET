using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for IDAL
/// </summary>
public interface IDAL
{
    bool BDExiste();
    bool ConnectionIsOpen();
    void OpenConnection();
    void CloseConnection();



    #region CRUD

    #region CREATE
    bool CreateUser(User u);
    bool CreateBook(Book u);
    bool CreateAuthor(Author a);
    bool CreatePublisher(Publisher p);
    bool CreateBookAuthor(string a, string b);

    #endregion
    #region Read
    bool ExisteUtilizador();
    User ExisteUserPass(string a, string b);
    bool jaExisteUser(string a);
    bool ExisteBook(Book e);
    string readLastBookId();
    List<Book> ReadBook(List<Book> listaBooks);
    List<string> ReadAuthor(string id);
    string ReadPublisher( string id);
    #endregion
    #region UPDATE
    bool UpdateUser(User u);
    bool UpdateBook(Book u);
    bool UpdateAuthor(Author a);
    bool UpdatePublisher(Publisher p);
    /*bool UpdateBookAuthor(string a, string b);*/
    #endregion
    #region DELETE
    bool DelUser(User u);
    bool DelBook(Book b);
    bool DelAuthor(Author a);
    bool DelPublisher(Publisher p);
    bool DelBookAuthor(string a, string b);

    #endregion
    #endregion
}