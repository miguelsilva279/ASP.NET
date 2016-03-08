using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactosApp.Class;

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
        bool InsereContactoEmpresa(string idCon, string idEmp);
        bool InsereEmpresa(string idCon, Empresa e);
        bool InsereMorada(Morada m);
        bool InsereContacto(Contacto c);
        bool InsereContactos(string idCon, Contactos cs);
        bool InsereContactoContactos(string idCon, string idCons);
        #endregion
        #region Read
        bool ExisteUtilizador();
        Utilizador ExisteUserPass(string a, string b);
        bool jaExisteUser(string a);
        bool ExisteEmpresa(Empresa e);
        Morada lerMorada(string m);
        //DataGridView lerContacto(DataGridView dataGrid ,string idCriador);
        //DataGridView lerContactos(DataGridView dataGrid, string idCon);
        //DataGridView lerEmpresa(DataGridView dataGrid, string idCon);
        //DataGridView lerUtilizador(DataGridView dataGrid);
        #endregion
        #region UPDATE
        bool AlteraUtilizador(Utilizador u);
        bool AlteraEmpresa(Empresa e);
        bool AlteraMorada(Morada m);
        bool AlteraContacto(Contacto c);
        bool AlteraContactos(Contactos cs);
        #endregion
        #region DELETE
        bool ApagaUtilizador(Utilizador u);
        bool ApagaEmpresa(Empresa e);
        bool ApagaMorada(Morada m);
        bool ApagaContacto(Contacto c);
        bool ApagaContactos(Contactos cs);
        #endregion
        #endregion

    }
}
