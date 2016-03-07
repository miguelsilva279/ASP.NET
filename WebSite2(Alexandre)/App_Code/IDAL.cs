using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactosApp.Class;
using System.Web.UI.WebControls;

namespace ContactosApp.DAL
{
    public interface IDAL
    {
        bool BDExiste();
        bool ConnectionIsOpen();
        void OpenConnection();
        void CloseConnection();

      
        #region CRUD
        #region CREATE
        bool InsereUtilizador(Utilizador u);
        bool CreateBook(Book u);
        bool CreateAuthor(Author a);
        bool CreatePublisher(Publisher p);
        bool CreateBookAuthor(string a, string b);
        #endregion
        #region Read
        bool ExisteUtilizador();
        Utilizador ExisteUserPass(string a, string b);
        bool jaExisteUser(string a);
        bool ExisteBook(Book e);
        int readLastBookId();
        GridView ReadBook(GridView dataGrid, string idCriador);
        GridView ReadAuthor(GridView dataGrid, string idCon);
        GridView ReadPublisher(GridView dataGrid, string idCon);
        #endregion
        #region UPDATE
        bool AlteraUtilizador(Utilizador u);
        bool UpdateBook(Book u);
        bool UpdateAuthor(Author a);
        bool UpdatePublisher(Publisher p);
        /*bool UpdateBookAuthor(string a, string b);*/

        #endregion
        #region DELETE
        bool ApagaUtilizador(Utilizador u);
        bool DelBook(Book b);
        bool DelAuthor(Author a);
        bool DelPublisher(Publisher p);
        bool DelBookAuthor(string a, string b);

        #endregion
        #endregion

    }
}
