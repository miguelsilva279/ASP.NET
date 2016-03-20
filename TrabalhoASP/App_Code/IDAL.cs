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
    bool OpenConnection();
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
    bool compareIdAuthor(string id);
    bool compareIdPublisher(string id);
    User ExisteUserPass(string a, string b);
    bool jaExisteUser(string a);
    bool ExisteBook(Book e);
    string readLastBookId();
    List<Book> ReadBooks();
    Book ReadBook(string id);
    List<string> ReadAuthorBook(string id);
    string ReadPublisherBook( string id);
    List<Publisher> ReadPublishers();
    List<string> ReadUniqPublishers();
    List<string> ReadUniqType();
    List<string> ReadNameAuthor();
    string ReadIdAuthor(string name);
    string readPubID(string name);
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
    bool DelBook(string b);
    bool DelAuthor(string a);
    bool DelPublisher(string p);

    #endregion
    #endregion
}