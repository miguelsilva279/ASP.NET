using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.IO;
using System.Data;
using ContactosApp.Class;
using System.Web.UI.WebControls;

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

        public bool CreateAuthor(Author a)
        {
            OpenConnection();
            bool flag = false;
            string strSQL = @"INSERT INTO Authors(au_id, au_lname, au_fname, au_phone, au_city) values (?,?,?,?,?)";

            OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
            myCmd.Parameters.AddWithValue("au_id", a.Id);
            myCmd.Parameters.AddWithValue("au_lname", a.LastName);
            myCmd.Parameters.AddWithValue("au_fname", a.FirstName);
            myCmd.Parameters.AddWithValue("au_phone", a.Phone);
            myCmd.Parameters.AddWithValue("au_city", a.City);
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

        public bool CreateBook(Book u)
        {
            OpenConnection();
            bool flag = false;
            string strSQL = @"INSERT INTO Books(title_id, title, type, pub_id, price, pubdate) values (?,?,?,?,?,?)";

            OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
            myCmd.Parameters.AddWithValue("title_id", u.id);
            myCmd.Parameters.AddWithValue("title", u.Title);
            myCmd.Parameters.AddWithValue("type", u.Type);
            myCmd.Parameters.AddWithValue("pub_id", u.PubId);
            myCmd.Parameters.AddWithValue("price", u.Price);
            myCmd.Parameters.AddWithValue("pubdate", u.PubDate);

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

        public bool CreateBookAuthor(string a, string b)
        {
            OpenConnection();
            bool flag = false;
            string strSQL = @"INSERT INTO BookAuthor(au_id, title_id) values (?,?)";

            OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
            myCmd.Parameters.AddWithValue("pub_id", a);
            myCmd.Parameters.AddWithValue("pub_name", b);

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

        public bool CreatePublisher(Publisher p)
        {
            OpenConnection();
            bool flag = false;
            string strSQL = @"INSERT INTO Publishers(pub_id, pub_name, city, country) values (?,?,?,?)";

            OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
            myCmd.Parameters.AddWithValue("pub_id", p.Id);
            myCmd.Parameters.AddWithValue("pub_name", p.Name);
            myCmd.Parameters.AddWithValue("city", p.City);
            myCmd.Parameters.AddWithValue("country", p.Country);


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

        public bool ExisteBook(Book e)
        {
            throw new NotImplementedException();
        }

        public int readLastBookId()
        {
            OpenConnection();
            bool flag = false;
            string strSQL = @"SELECT title_id FROM Books WHERE title_id LIKE'BC%' ORDER BY title_id DESC";

            OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
            

            OleDbDataReader reader;
            int x = 0;

            try
            {
                reader = myCmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    x = 1000;
                }
                else
                {

                }
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

            return x;
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

        public bool UpdateAuthor(Author a)
        {
            OpenConnection();
            bool flag = false;
            string strSQL = @"UPDATE Authors SET au_lname=@lastN, au_fname=@firdtN, au_phone=@phone, au_city=@city WHERE au_id=@id";

            OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
            myCmd.Parameters.AddWithValue("@lastN", a.LastName);
            myCmd.Parameters.AddWithValue("@firdtN", a.FirstName);
            myCmd.Parameters.AddWithValue("@phone", a.Phone);
            myCmd.Parameters.AddWithValue("@city", a.City);
            myCmd.Parameters.AddWithValue("@id", a.Id);
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

        public bool UpdateBook(Book u)
        {
            OpenConnection();
            bool flag = false;
            string strSQL = @"UPDATE Books SET title=@title, type=@type, pub_id=@pubId, price=@price, pubdate=@pubdate WHERE title_id=@id";

            OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
            myCmd.Parameters.AddWithValue("@title", u.Title);
            myCmd.Parameters.AddWithValue("@type", u.Type);
            myCmd.Parameters.AddWithValue("@pubId", u.PubId);
            myCmd.Parameters.AddWithValue("@price", u.Price);
            myCmd.Parameters.AddWithValue("@pubdate", u.PubDate);
            myCmd.Parameters.AddWithValue("@id", u.id);
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
        /*
        public bool UpdateBookAuthor(string a, string b)
        {
            OpenConnection();
            bool flag = false;
            string strSQL = @"UPDATE BooksAuthor SET pub_name=@name, city=@city, country=@country WHERE pub_id=@id";

            OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
            myCmd.Parameters.AddWithValue("@name", a);
            myCmd.Parameters.AddWithValue("@city", b);

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
        */
        public bool UpdatePublisher(Publisher p)
        {
            OpenConnection();
            bool flag = false;
            string strSQL = @"UPDATE Publishers SET pub_name=@name, city=@city, country=@country WHERE pub_id=@id";

            OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
            myCmd.Parameters.AddWithValue("@name", p.Name);
            myCmd.Parameters.AddWithValue("@city", p.City);
            myCmd.Parameters.AddWithValue("@country", p.Country);
            myCmd.Parameters.AddWithValue("@id", p.Id);
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

        public bool DelAuthor(Author a)
        {
            OpenConnection();
            bool flag = false;
            string strSQL = @"DELETE FROM Authors WHERE Id=@id";

            OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
            myCmd.Parameters.AddWithValue("@id", a.Id);

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

        public bool DelBook(Book b)
        {
            OpenConnection();
            bool flag = false;
            string strSQL = @"DELETE FROM Books WHERE Id=@id";

            OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
            myCmd.Parameters.AddWithValue("@id", b.id);

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

        public bool DelBookAuthor(string a, string b)
        {
            throw new NotImplementedException();
        }

        public bool DelPublisher(Publisher p)
        {
            OpenConnection();
            bool flag = false;
            string strSQL = @"DELETE FROM Publishers WHERE Id=@id";

            OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
            myCmd.Parameters.AddWithValue("@id", p.Id);

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
