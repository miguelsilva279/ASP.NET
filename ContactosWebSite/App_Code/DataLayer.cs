using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.IO;
using System.Data;
using ContactosApp.Class;

namespace ContactosApp.DAL
{

     

    public class DataLayer : IDAL
    {
        private OleDbConnection conexao;
      
       
        public bool BDExiste()
        {
            bool flag = false;
            try
            {
                string path = AppDomain.CurrentDomain.GetData("DataDirectory").ToString(); 
                if (File.Exists(path + "\\BD.mdb"))
                    flag = true;
            }
            catch (Exception)
            {
                flag = false;
            }
            return flag;
        }
        public void CloseConnection()
        {

            try
            {
                if (conexao.State != ConnectionState.Closed)
                {
                    conexao.Close();
                }
            }
            catch (Exception)
            {
                throw new Exception("Erro ao fechar conexão à base de dados.");
            }
        }
        public bool ConnectionIsOpen()
        {
            try
            {
                if (conexao.State != ConnectionState.Open)
                {
                    return false;
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void OpenConnection()
        {
            try
            {
                if (conexao == null)
                {
                    string constr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\BD.mdb";
                    conexao = new OleDbConnection(constr);
                    conexao.Open();
                }
                else
                    if (conexao.State != ConnectionState.Open)
                    conexao.Open();
            }
            catch (Exception)
            {
                throw new NotImplementedException("Erro ao abrir conexão á base de dados.");
            }
        }

       
     

        #region CRUD

        #region CREATE
        public bool InsereUtilizador(Utilizador u)
        {
            OpenConnection();
            bool flag = false;
            string strSQL = @"INSERT INTO Utilizador(Id, Nome, PalavraPasse, IsAdmin) values (?,?,?,?)";
            
            OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
            myCmd.Parameters.AddWithValue("Id", u.Id);
            myCmd.Parameters.AddWithValue("Nome", u.Nome);
            myCmd.Parameters.AddWithValue("PalavraPasse", u.PalavraPasse);
            myCmd.Parameters.AddWithValue("IsAdmin", u.IsAdmin);
            try
            {
                myCmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception)
            {
                CloseConnection();
                //MessageBox.Show("nao insere na bd");
                flag = false;
            }
            finally
            {
                CloseConnection();
               
            }
            return flag;

        }

        public bool InsereEmpresa(string idCon, Empresa e)
        {
            InsereContactoEmpresa(idCon, e.Id);
            OpenConnection();
            bool flag = false;
            string strSQL = @"INSERT INTO Empresa(Id, Nome, MoradaP, Nif) values (?,?,?,?)";
          
            OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
            myCmd.Parameters.AddWithValue("Id", e.Id);
            myCmd.Parameters.AddWithValue("Nome", e.Nome);
            myCmd.Parameters.AddWithValue("MoradaP", e.MoradaP);
            myCmd.Parameters.AddWithValue("Nif", e.Nif);

            try
            {
                myCmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception)
            {
                CloseConnection();
                flag = false;
            }
            finally
            {
                CloseConnection();
            }
            return flag;
        }

        public bool InsereContactoEmpresa(string idCon, string idEmp)
        {
            OpenConnection();
            bool flag = false;
            string strSQL = @"INSERT INTO ContactoEmpresa(IdContacto, IdEmpresa) values (?,?)";

            OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
            myCmd.Parameters.AddWithValue("IdContacto", idCon);
            myCmd.Parameters.AddWithValue("IdEmpresa", idEmp);

            try
            {
                myCmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                CloseConnection();
                flag = false;
            }
            finally
            {
                CloseConnection();
            }
            return flag;
        }

        public bool InsereMorada(Morada m)
        {
            OpenConnection();
            bool flag = false;
            string strSQL = @"INSERT INTO Morada(Id, Rua, CodPostal, Localidade) values (?,?,?,?)";
            
            OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
            myCmd.Parameters.AddWithValue("Id", m.Id);
            myCmd.Parameters.AddWithValue("Rua", m.Rua);
            myCmd.Parameters.AddWithValue("CodPostal", m.CPostal);
            myCmd.Parameters.AddWithValue("Localidade", m.Localidade);

            try
            {
                myCmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception)
            {
                CloseConnection();
                flag = false;
            }
            finally
            {
                CloseConnection();
               
            }
            return flag;
        }

        public bool InsereContacto(Contacto c)
        {
            OpenConnection();
            bool flag = false;
            string strSQL = @"INSERT INTO Contacto(Id, Nome, Titulo, MoradaP, Nif, IsPublic, Criador) values (?,?,?,?,?,?,?)";

            OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
            myCmd.Parameters.AddWithValue("Id", c.Id);
            myCmd.Parameters.AddWithValue("Nome", c.Nome);
            myCmd.Parameters.AddWithValue("Titulo", c.Titulo);
            myCmd.Parameters.AddWithValue("MoradaP", c.MoradaP);
            myCmd.Parameters.AddWithValue("Nif", c.Nif);
            myCmd.Parameters.AddWithValue("IsPublic", c.IsPublic);
            myCmd.Parameters.AddWithValue("Criador", c.Criador);
          
            try
            {
                myCmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception)
            {
                CloseConnection();
                flag = false;
            }
            finally
            {
                CloseConnection();
                
            }
            return flag;
        }

        public bool InsereContactos(string idCon, Contactos cs)
        {
            InsereContactoContactos(idCon,cs.Id);
            OpenConnection();
            bool flag = false;
            string strSQL = @"INSERT INTO Contactos(Id, TipoContacto, Valor) VALUES (?,?,?)";
           
            OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
            myCmd.Parameters.AddWithValue("Id", cs.Id);
            myCmd.Parameters.AddWithValue("TipoContacto", cs.Tipo.ToString());
            myCmd.Parameters.AddWithValue("Valor", cs.Valor);
           

            try
            {
                myCmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception)
            {
                CloseConnection();
                flag = false;
            }
            finally
            {
                CloseConnection();
            }
            return flag;

        }

        public bool InsereContactoContactos(string idCon, string idCons)
        {
            OpenConnection();
            bool flag = false;
            string strSQL = @"INSERT INTO ContactoContactos(IdContacto, IdContactos) VALUES (?,?)";

            OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
            myCmd.Parameters.AddWithValue("IdContacto", idCon);
            myCmd.Parameters.AddWithValue("IdContactos", idCons);

            try
            {
                myCmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception)
            {
                CloseConnection();
                flag = false;
            }
            finally
            {
                CloseConnection();
             
            }
            return flag;
        }
        #endregion

        #region READ 

        public bool ExisteUtilizador()
        {
            OpenConnection();
            bool flag = false;
            string strSQL = @"SELECT *FROM Utilizador";
            
            OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);

            OleDbDataReader reader;
            //int count = 0;
            try
            {
                reader = myCmd.ExecuteReader();
                if (reader.HasRows)
                    flag = true;
                //if (reader.Read())
                //{
                //    count++;
                //}

            }
            catch (Exception)
            {
                CloseConnection();
                flag = false;
            }
            finally
            {
                //if (count > 0)
                //flag = true;
                CloseConnection();
            }
            return flag;
        }

        public Utilizador ExisteUserPass(string a, string b)
        {
            OpenConnection();
            
            string strSQL = @"SELECT * FROM Utilizador WHERE Nome=@nome AND PalavraPasse=@pass";
            Utilizador x = new Utilizador();

            OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
            myCmd.Parameters.AddWithValue("@nome", a);
            myCmd.Parameters.AddWithValue("@passe", b);
            OleDbDataReader reader;
            
            try
            {
                reader = myCmd.ExecuteReader();
                if (reader.Read())
                {
                    x.Nome = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                    x.Id = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                    x.IsAdmin = reader.GetBoolean(3);
                    
                }
                else
                {
                    x = null;
                }
            }
            catch (Exception)
            {
                CloseConnection();
                //MessageBox.Show("erro a ler da bd");
                x = null;
            }
            finally
            {
                CloseConnection();
            }

            return x;
        }

        public bool jaExisteUser(string a)
        {
            OpenConnection();
            bool flag = false;
            string strSQL = @"SELECT * FROM Utilizador WHERE Nome=@nome";

            OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
            myCmd.Parameters.AddWithValue("@nome", a);

            OleDbDataReader reader;
            
            try
            {
                reader = myCmd.ExecuteReader();
                if (reader.HasRows)
                    flag = true;
            }
            catch (Exception)
            {
                CloseConnection();
                //MessageBox.Show("erro a ler da bd");
                flag = false;
            }
            finally
            {
                CloseConnection();
            }

            return flag;
        }


        public bool ExisteEmpresa(Empresa e)
        {
            throw new NotImplementedException();
        }

        public Morada lerMorada(string m)
        {
            OpenConnection();

            string strSQL = @"SELECT *FROM Morada WHERE Id=@id";

            OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);

            myCmd.Parameters.AddWithValue("@id", m);
            OleDbDataReader reader;

            Morada x = new Morada();

            try
            {
                reader = myCmd.ExecuteReader();


                while (reader.Read())
                {
                    x.Id = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                    x.Rua = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                    x.CPostal = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                    x.Localidade = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
          
                }
                reader.Close();
                

            }
            catch (Exception)
            {
                CloseConnection();
               
            }
            finally
            {
               

            }
            
            return x;
        }
        /*
        public DataGridView lerContacto(DataGridView dataGrid ,string id)
        {
            OpenConnection();
            
            string strSQL = @"SELECT * FROM Contacto WHERE Criador=@criador OR IsPublic=true";

            OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
           
            myCmd.Parameters.AddWithValue("@criador", id);
            OleDbDataReader reader;
            
            Contacto x = new Contacto();
            
            try
            {
                reader = myCmd.ExecuteReader();
                
                
                    while (reader.Read()) { 

                    x.Id = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                    x.Nome = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                    x.Titulo = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                    x.MoradaP = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                    x.Nif = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                    x.IsPublic = reader.GetBoolean(5);
                    x.Criador = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
                    Morada m = lerMorada(x.MoradaP);
                  
                    
                    dataGrid.Rows.Add(new object[] { x.Id, x.Nome, x.Titulo, x.MoradaP, x.Nif, (x.IsPublic).ToString(), x.Criador , m.Id, m.Rua, m.CPostal, m.Localidade});
                    }
                    reader.Close();
                

            }
            catch (Exception)
            {
                CloseConnection();
                dataGrid = null;
            }
            finally
            {
                CloseConnection();
                
            }
            return dataGrid;


        }

        public DataGridView lerContactos(DataGridView dataGrid, string idCon)
        {
            OpenConnection();

            string strSQL = @"SELECT Contactos.* FROM Contactos, ContactoContactos WHERE ContactoContactos.IdContacto=@id AND ContactoContactos.IdContactos= Contactos.Id";

            OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);

            myCmd.Parameters.AddWithValue("@id", idCon);
            OleDbDataReader reader;

            Contactos x = new Contactos();

            try
            {
                reader = myCmd.ExecuteReader();


                while (reader.Read())
                {

                    x.Id = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);

                    switch (reader.IsDBNull(1) ? string.Empty : reader.GetString(1))
                    {
                        case "EMAIL":
                            x.Tipo = TipoC.EMAIL;
                            break;
                        case "FAX":
                            x.Tipo = TipoC.FAX;
                            break;
                        case "TELEFONE":
                            x.Tipo = TipoC.TELEFONE;
                            break;
                        case "TELEMOVEL":
                            x.Tipo = TipoC.TELEMOVEL;
                            break;
                        default:
                            x.Tipo = TipoC.DEFAULT;
                            break;
                    }

                    x.Valor = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);

                    dataGrid.Rows.Add(new object[] { x.Id, x.Tipo, x.Valor});
                }
                reader.Close();


            }
            catch (Exception)
            {
                CloseConnection();
                dataGrid = null;
            }
            finally
            {
                CloseConnection();

            }
            return dataGrid;
        }

        public DataGridView lerEmpresa(DataGridView dataGrid, string idCon)
        {
            OpenConnection();

            string strSQL = @"SELECT Empresa.* FROM Empresa, ContactoEmpresa WHERE ContactoEmpresa.IdContacto=@id AND ContactoEmpresa.IdEmpresa= Empresa.Id";

            OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);

            myCmd.Parameters.AddWithValue("@id", idCon);
            OleDbDataReader reader;

            Empresa x = new Empresa();

            try
            {
                reader = myCmd.ExecuteReader();


                while (reader.Read())
                {

                    x.Id = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                    x.Nome = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                    x.MoradaP = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                    x.Nif = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                    dataGrid.Rows.Add(new object[] { x.Id, x.Nome, x.Nif, x.MoradaP});
                }
                reader.Close();


            }
            catch (Exception)
            {
                CloseConnection();
                dataGrid = null;
            }
            finally
            {
                CloseConnection();

            }
            return dataGrid;
        }

        public DataGridView lerUtilizador(DataGridView dataGrid)
        {
            OpenConnection();

            string strSQL = @"SELECT * FROM Utilizador";

            OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);

            OleDbDataReader reader;

            Utilizador x = new Utilizador();

            try
            {
                reader = myCmd.ExecuteReader();


                while (reader.Read())
                {

                    x.Id = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                    x.Nome = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                    x.PalavraPasse = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                    x.IsAdmin = reader.GetBoolean(3);
                    dataGrid.Rows.Add(new object[] { x.Id, x.Nome, x.PalavraPasse, x.IsAdmin });
                }
                reader.Close();


            }
            catch (Exception)
            {
                CloseConnection();
                dataGrid = null;
            }
            finally
            {
                CloseConnection();

            }
            return dataGrid;
        }
        */
        #endregion

        #region UPDATE
        public bool AlteraUtilizador(Utilizador u)
        {
            OpenConnection();
            bool flag = false;
            string strSQL = @"UPDATE Utilizador SET Nome=@nome, PalavraPasse=@pass, IsAdmin=@admin WHERE Id=@id";

            OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
            myCmd.Parameters.AddWithValue("@nome", u.Nome);
            myCmd.Parameters.AddWithValue("@pass", u.PalavraPasse);
            myCmd.Parameters.AddWithValue("@admin", u.IsAdmin);
            myCmd.Parameters.AddWithValue("@id", u.Id);
            try
            {
                myCmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception)
            {
                CloseConnection();
                flag = false;
            }
            finally
            {
                CloseConnection();

            }
            return flag;
        }

        public bool AlteraEmpresa(Empresa e)
        {
            OpenConnection();
            bool flag = false;
            string strSQL = @"UPDATE Empresa SET Nome=@nome, MoradaP=@morada, Nif=@nif WHERE Id=@id";

            OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
            myCmd.Parameters.AddWithValue("@nome", e.Nome);
            myCmd.Parameters.AddWithValue("@morada", e.MoradaP);
            myCmd.Parameters.AddWithValue("@nif", e.Nif);
            myCmd.Parameters.AddWithValue("@id", e.Id);

            try
            {
                myCmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception)
            {
                CloseConnection();
                flag = false;
            }
            finally
            {
                CloseConnection();
            }
            return flag;

        }

        public bool AlteraMorada(Morada m)
        {
            OpenConnection();
            bool flag = false;
            string strSQL = @"UPDATE Morada SET Rua=@rua, CodPostal=@cp, Localidade=@local WHERE Id=@id";

            OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
            myCmd.Parameters.AddWithValue("@rua", m.Rua);
            myCmd.Parameters.AddWithValue("@cp", m.CPostal);
            myCmd.Parameters.AddWithValue("@local", m.Localidade);
            myCmd.Parameters.AddWithValue("@id", m.Id);

            try
            {
                myCmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception)
            {
                CloseConnection();
                flag = false;
            }
            finally
            {
                CloseConnection();
            }
            return flag;

        }

        public bool AlteraContacto(Contacto c)
        {
            OpenConnection();
            bool flag = false;
            string strSQL = @"UPDATE Contacto SET Nome=@nome, Titulo=@titulo, Nif=@nif, IsPublic=@isPublic WHERE Id=@id";

            OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
            myCmd.Parameters.AddWithValue("@nome", c.Nome);
            myCmd.Parameters.AddWithValue("@titulo", c.Titulo);
            myCmd.Parameters.AddWithValue("@nif", c.Nif);
            myCmd.Parameters.AddWithValue("@isPublic", c.IsPublic);
            myCmd.Parameters.AddWithValue("@id", c.Id);

            try
            {
                myCmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception)
            {
                CloseConnection();
                flag = false;
            }
            finally
            {
                CloseConnection();
            }
            return flag;
        }

        public bool AlteraContactos(Contactos cs)
        {
            OpenConnection();
            bool flag = false;
            string strSQL = @"UPDATE Contactos SET TipoContacto=@tipo, Valor=@valor WHERE Id=@id";

            OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
            myCmd.Parameters.AddWithValue("@tipo", cs.Tipo.ToString());
            myCmd.Parameters.AddWithValue("@valor", cs.Valor);
            myCmd.Parameters.AddWithValue("@id", cs.Id);


            try
            {
                myCmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception)
            {
                CloseConnection();
                flag = false;
            }
            finally
            {
                CloseConnection();
            }
            return flag;
        }
        #endregion

        #region DELETE
        public bool ApagaUtilizador(Utilizador u)
        {
            OpenConnection();
            bool flag = false;
            string strSQL = @"DELETE FROM Utilizador WHERE Id=?";

            OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
            myCmd.Parameters.AddWithValue("Id", u.Id);

            try
            {
                myCmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception)
            {
                CloseConnection();
                flag = false;
            }
            finally
            {
                CloseConnection();
            }
            return flag;

        }

        public bool ApagaEmpresa(Empresa e)
        {
            OpenConnection();
            bool flag = false;
            string strSQL = @"DELETE FROM Empresa WHERE Id=?";

            OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
            myCmd.Parameters.AddWithValue("Id", e.Id);

            try
            {
                myCmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception)
            {
                CloseConnection();
                flag = false;
            }
            finally
            {
                CloseConnection();
            }
            return flag;

        }

        public bool ApagaMorada(Morada m)
        {
            OpenConnection();
            bool flag = false;
            string strSQL = @"DELETE FROM Morada WHERE Id=?";

            OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
            myCmd.Parameters.AddWithValue("Id", m.Id);

            try
            {
                myCmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception)
            {
                CloseConnection();
                flag = false;
            }
            finally
            {
                CloseConnection();
            }
            return flag;

        }

        public bool ApagaContacto(Contacto c)
        {
            OpenConnection();
            bool flag = false;
            string strSQL = @"DELETE FROM Contacto WHERE Id=?";

            OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
            myCmd.Parameters.AddWithValue("Id", c.Id);

            try
            {
                myCmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception)
            {
                CloseConnection();
                flag = false;
            }
            finally
            {
                CloseConnection();
               
            }
            return flag;

        }

        public bool ApagaContactos(Contactos cs)
        {
            OpenConnection();
            bool flag = false;
            string strSQL = @"DELETE FROM Contactos WHERE Id=?";

            OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
            myCmd.Parameters.AddWithValue("Id", cs.Id);

            try
            {
                myCmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception)
            {
                CloseConnection();
                flag = false;
            }
            finally
            {
                CloseConnection();
                
            }
            return flag;

        }



        #endregion
        #endregion








    }

}
