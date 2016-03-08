using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for DataLayer
/// </summary>
public class DataLayer : IDAL
{
    public bool BDExiste()
    {
        throw new NotImplementedException();
    }

    public void OpenConnection()
    {
        throw new NotImplementedException();
    }

    public void CloseConnection()
    {
        throw new NotImplementedException();
    }  
    public bool ConnectionIsOpen()
    {
        throw new NotImplementedException();
    }

    #region CRUD
    #region CREATE
    public bool CreateAuthor(Author a)
    {
        throw new NotImplementedException();
    }

    public bool CreateBook(Book u)
    {
        throw new NotImplementedException();
    }

    public bool CreateBookAuthor(string a, string b)
    {
        throw new NotImplementedException();
    }

    public bool CreatePublisher(Publisher p)
    {
        throw new NotImplementedException();
    }

    public bool CreateUser(User u)
    {
        throw new NotImplementedException();
    }
    #endregion
    #region DELETE
    public bool DelAuthor(Author a)
    {
        throw new NotImplementedException();
    }

    public bool DelBook(Book b)
    {
        throw new NotImplementedException();
    }

    public bool DelBookAuthor(string a, string b)
    {
        throw new NotImplementedException();
    }

    public bool DelPublisher(Publisher p)
    {
        throw new NotImplementedException();
    }

    public bool DelUser(User u)
    {
        throw new NotImplementedException();
    }
    #endregion
    #region READ
    public bool ExisteBook(Book e)
    {
        throw new NotImplementedException();
    }

    public User ExisteUserPass(string a, string b)
    {
        throw new NotImplementedException();
    }

    public bool ExisteUtilizador()
    {
        throw new NotImplementedException();
    }

    public bool jaExisteUser(string a)
    {
        throw new NotImplementedException();
    }

   
    public GridView ReadAuthor(GridView dataGrid, string idCon)
    {
        throw new NotImplementedException();
    }

    public GridView ReadBook(GridView dataGrid, string idCriador)
    {
        throw new NotImplementedException();
    }

    public GridView ReadPublisher(GridView dataGrid, string idCon)
    {
        throw new NotImplementedException();
    }
    #endregion
    #region UPDATE
    public bool UpdateAuthor(Author a)
    {
        throw new NotImplementedException();
    }

    public bool UpdateBook(Book u)
    {
        throw new NotImplementedException();
    }

    public bool UpdateBookAuthor(string a, string b)
    {
        throw new NotImplementedException();
    }

    public bool UpdatePublisher(Publisher p)
    {
        throw new NotImplementedException();
    }

    public bool UpdateUser(User u)
    {
        throw new NotImplementedException();
    }
    #endregion
    #endregion
}