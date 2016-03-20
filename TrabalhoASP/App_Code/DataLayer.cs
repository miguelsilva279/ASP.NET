using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for DataLayer
/// </summary>
public class DataLayer : IDAL
{
    private OleDbConnection conexao;

    public bool BDExiste()
    {

        bool flag = false;
        try
        {
            if (File.Exists("|DataDirectory|\\Books.mdb"))
                flag = true;
        }
        catch (Exception)
        {
            flag = false;
        }
        return flag;
    }

    public bool OpenConnection()
    {
        bool flag = false;
        try
        {
            if (conexao == null)
            {
                string constr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\Books.mdb";
                conexao = new OleDbConnection(constr);
                conexao.Open();

                flag = true;
                return flag;
            }
            else
                if (conexao.State != ConnectionState.Open)
            {
                conexao.Open();
                flag = true;
                return flag;
            }
                    
        }
        catch (Exception)
        {
            throw new NotImplementedException("Erro ao abrir conexão á base de dados.");
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

    #region CRUD
    #region CREATE
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
        myCmd.Parameters.AddWithValue("pubdate", u.PubDate.ToString("dd-MM-yyyy"));

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
        myCmd.Parameters.AddWithValue("au_id", a);
        myCmd.Parameters.AddWithValue("title_id", b);

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

    public bool CreateUser(User u)
    {
        OpenConnection();
        bool flag = false;
        string strSQL = @"INSERT INTO User(id, name, password) values (?,?,?)";

        OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
        myCmd.Parameters.AddWithValue("pub_id", u.Id);
        myCmd.Parameters.AddWithValue("pub_name", u.Name);
        myCmd.Parameters.AddWithValue("city", u.Password);

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
    public bool DelAuthor(string a)
    {
        OpenConnection();
        bool flag = false;
        string strSQL = @"DELETE FROM Authors WHERE Id=@id";

        OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
        myCmd.Parameters.AddWithValue("@id", a);

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

    public bool DelBook(string b)
    {
        OpenConnection();
        bool flag = false;
        DelBookAuthor(b);
        string strSQL = @"DELETE FROM Books WHERE title_id=@id";
        OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
        OleDbTransaction trans = conexao.BeginTransaction();
        myCmd.Parameters.AddWithValue("@id", b);

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

    public bool DelBookAuthor( string b)
    {
        OpenConnection();
        bool flag = false;
        string strSQL = @"DELETE FROM Books WHERE title_id=@id";
        string strSQL2 = @"DELETE FROM BookAuthors WHERE title_id=@id";
        OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
        OleDbCommand myCmd2 = new OleDbCommand(strSQL2, conexao);

        myCmd.Parameters.AddWithValue("@id", b);
        myCmd2.Parameters.AddWithValue("@id", b);

        OleDbTransaction trans = conexao.BeginTransaction();
        myCmd.Transaction = trans;
        myCmd2.Transaction = trans;

        try
        {
            myCmd2.ExecuteNonQuery();
            myCmd.ExecuteNonQuery();
            flag = true;

            trans.Commit();
        }
        catch (Exception)
        {
            if (trans != null)
                trans.Rollback();
            if (conexao != null && OpenConnection())
                CloseConnection();
            flag = false;
        }
        finally
        {
            CloseConnection();
        }
        return flag;

    }

    public bool DelPublisher(string p)
    {
        OpenConnection();
        bool flag = false;
        string strSQL = @"DELETE FROM Publishers WHERE Id=@id";

        OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
        myCmd.Parameters.AddWithValue("@id", p);

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

    public bool DelUser(User u)
    {
        OpenConnection();
        bool flag = false;
        string strSQL = @"DELETE FROM User WHERE Id=@id";

        OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
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
    #endregion
    #region READ
    public bool ExisteBook(Book e)
    {
        throw new NotImplementedException();
    }

    public User ExisteUserPass(string a, string b)
    {
        OpenConnection();

        string strSQL = @"SELECT * FROM User WHERE name=@nome AND password=@pass";
        User x = new User();

        OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
        myCmd.Parameters.AddWithValue("@nome", a);
        myCmd.Parameters.AddWithValue("@passe", b);
        OleDbDataReader reader;

        try
        {
            reader = myCmd.ExecuteReader();
            if (reader.Read())
            {
                x.Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                x.Id = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);

            }
            else
            {
                x = null;
            }
        }
        catch (Exception)
        {
            CloseConnection();
            x = null;
        }
        finally
        {
            CloseConnection();
        }

        return x;
    }

    public bool ExisteUtilizador()
    {
        OpenConnection();
        bool flag = false;
        string strSQL = @"SELECT *FROM User";

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

    public bool jaExisteUser(string a)
    {
        OpenConnection();
        bool flag = false;
        string strSQL = @"SELECT * FROM User WHERE name=@nome";

        OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
        myCmd.Parameters.AddWithValue("@nome", a);

        OleDbDataReader reader;

        try
        {
            reader = myCmd.ExecuteReader();
            if (!reader.HasRows)
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

    public bool compareIdAuthor(string id)
    {
        OpenConnection();

        string strSQL = @"SELECT au_id FROM Author WHERE au_id = @id";

        OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
        myCmd.Parameters.AddWithValue("@id", id);

        OleDbDataReader reader;
        bool flag = false;

        try
        {
            reader = myCmd.ExecuteReader();
            if (!reader.HasRows)
            {
               flag = true;
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

        return flag;
    }

    public bool compareIdPublisher(string id)
    {
        OpenConnection();

        string strSQL = @"SELECT pub_id FROM Author WHERE pub_id = @id";

        OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
        myCmd.Parameters.AddWithValue("@id", id);

        OleDbDataReader reader;
        bool flag = false;

        try
        {
            reader = myCmd.ExecuteReader();
            if (!reader.HasRows)
            {
                flag = true;
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

        return flag;
    }

    public string readLastBookId()
    {
        OpenConnection();

        string strSQL = @"SELECT title_id FROM Books WHERE title_id LIKE 'TD%' ORDER BY title_id DESC";

        OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);


        OleDbDataReader reader;
        string x = string.Empty;

        try
        {
            reader = myCmd.ExecuteReader();
            if (!reader.HasRows)
            {
                x = "TD1000";
            }
            else
            {
                while (reader.Read())
                {
                    x = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                    return x;
                }

            }
        }
        catch (Exception)
        {
            CloseConnection();
        }
        finally
        {
            CloseConnection();
        }

        return x;
    }

    public List<string> ReadAuthorBook(string id)
    {
        OpenConnection();

        string strSQL = @"SELECT Authors.au_lname, Authors.au_fname FROM (Authors INNER JOIN BookAuthor ON Authors.au_id = BookAuthor.au_id) WHERE (BookAuthor.title_id = @id)";


        OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
        myCmd.Parameters.AddWithValue("@id", id);
        OleDbDataReader reader;

        List<string> lista = new List<string>();

        try
        {
            reader = myCmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string x = string.Empty;
                    x = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                    x += " ";
                    x += reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                    lista.Add(x);
                }
            }

        }
        catch (Exception)
        {
            CloseConnection();
        }
        finally
        {
            CloseConnection();
        }

        return lista;
    }

    public List<Author> ReadAuthors()
    {
        OpenConnection();

        string strSQL = @"SELECT * FROM Authors";

        OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
        OleDbDataReader reader;

        List<Author> lista = new List<Author>();

        try
        {
            reader = myCmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Author x = new Author();
                    x.Id = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                    x.LastName = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                    x.FirstName = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                    x.Phone = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                    x.City = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                    lista.Add(x);
                }
            }

        }
        catch (Exception)
        {
            CloseConnection();
        }
        finally
        {
            CloseConnection();
        }

        return lista;
    }

    public Book ReadBook(string id)
    {
        OpenConnection();

        string strSQL = @"SELECT * FROM Books WHERE title_id=@id";

        OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
        myCmd.Parameters.AddWithValue("@id", id);
        OleDbDataReader reader;

        Book x = new Book();
        try
        {
            reader = myCmd.ExecuteReader();
            while (reader.Read())
            {

                x.id = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                x.Title = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                x.Type = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                x.Price = reader.IsDBNull(4) ? 0 : reader.GetDecimal(4);
                x.PubId = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                x.PubDate = Convert.ToDateTime(reader.GetDateTime(5));
            }
            reader.Close();
        }
        catch (Exception)
        {
            CloseConnection();
        }
        finally
        {
            CloseConnection();
        }

        return x;
    }

    public List<Book> ReadBooks()
    {
        OpenConnection();

        string strSQL = @"SELECT * FROM Books";

        OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);

        OleDbDataReader reader;
        List<Book> listaBooks = new List<Book>();

        try
        {
            reader = myCmd.ExecuteReader();
            while (reader.Read())
            {
                Book x = new Book();
                x.id = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                x.Title = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                x.Type = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                x.Price = reader.IsDBNull(4) ? 0 : reader.GetDecimal(4);
                x.PubId = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                x.PubDate = reader.GetDateTime(5);
                listaBooks.Add(x);
            }
            reader.Close();
        }
        catch (Exception)
        {
            CloseConnection();
        }
        finally
        {
            CloseConnection();
        }

        return listaBooks;
    }

    public string ReadPublisherBook(string id)
    {
        OpenConnection();

        string strSQL = @"SELECT pub_name FROM Publishers WHERE pub_id=@id";

        OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
        myCmd.Parameters.AddWithValue("@id", id);
        OleDbDataReader reader;

        string x = string.Empty;
        try
        {
            reader = myCmd.ExecuteReader();
            while (reader.Read())
            {

                x = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
            }
            reader.Close();
        }
        catch (Exception)
        {
            CloseConnection();
        }
        finally
        {
            CloseConnection();
        }

        return x;
    }

    public List<Publisher> ReadPublishers()
    {
        OpenConnection();

        string strSQL = @"SELECT * FROM Publishers";

        OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
        OleDbDataReader reader;

        List<Publisher> lista = new List<Publisher>();

        try
        {
            reader = myCmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Publisher x = new Publisher();
                    x.Id = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                    x.Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                    x.City = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                    x.Country = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                    lista.Add(x);
                }
            }

        }
        catch (Exception)
        {
            CloseConnection();
        }
        finally
        {
            CloseConnection();
        }

        return lista;
    }

    public List<string> ReadUniqPublishers()
    {
        OpenConnection();

        string strSQL = @"SELECT DISTINCT pub_name FROM Publishers";

        OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
        OleDbDataReader reader;

        List<string> lista = new List<string>();

        try
        {
            reader = myCmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string x = string.Empty;
                    x = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                    lista.Add(x);
                }
            }

        }
        catch (Exception)
        {
            CloseConnection();
        }
        finally
        {
            CloseConnection();
        }

        return lista;
    }

    public List<string> ReadUniqType()
    {
        OpenConnection();

        string strSQL = @"SELECT DISTINCT type FROM Books";

        OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
        OleDbDataReader reader;

        List<string> lista = new List<string>();

        try
        {
            reader = myCmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string x = string.Empty;
                    x = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                    lista.Add(x);
                }
            }

        }
        catch (Exception)
        {
            CloseConnection();
        }
        finally
        {
            CloseConnection();
        }

        return lista;
    }

    public List<string> ReadNameAuthor()
    {
        OpenConnection();

        string strSQL = @"SELECT au_fname, au_lname FROM Authors";

        OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
        OleDbDataReader reader;
        
        List<string> lista = new List<string>();

        try
        {
            reader = myCmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string x = string.Empty;
                    x = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                    x += " " + (reader.IsDBNull(1) ? string.Empty : reader.GetString(1));
                    lista.Add(x);
                }
            }

        }
        catch (Exception)
        {
            CloseConnection();
        }
        finally
        {
            CloseConnection();
        }

        return lista;
    }

    public string ReadIdAuthor(string name)
    {
        OpenConnection();

        string strSQL = @"SELECT au_id FROM Authors WHERE au_fname=@fname AND au_lname=@lname";

        OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
        OleDbDataReader reader;
        String[] substrings = name.Split(new string[] { " " }, StringSplitOptions.None);

        myCmd.Parameters.AddWithValue("@fname", substrings[0]);
        myCmd.Parameters.AddWithValue("@lname", substrings[1]);

        string x = string.Empty;
        try
        {
            reader = myCmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    x = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                }
            }

        }
        catch (Exception)
        {
            CloseConnection();
        }
        finally
        {
            CloseConnection();
        }

        return x;
    }

    public string readPubID(string name)
    {
        OpenConnection();

        string strSQL = @"SELECT pub_id FROM Publishers WHERE pub_name=@name";

        OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
        OleDbDataReader reader;

        myCmd.Parameters.AddWithValue("@name", name);


        string x = string.Empty;
        try
        {
            reader = myCmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    x = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                }
            }

        }
        catch (Exception)
        {
            CloseConnection();
        }
        finally
        {
            CloseConnection();
        }

        return x;
    }


    #endregion
    #region UPDATE
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

    public bool UpdateUser(User u)
    {
        OpenConnection();
        bool flag = false;
        string strSQL = @"UPDATE User SET name=@name, password=@pass WHERE title_id=@id";

        OleDbCommand myCmd = new OleDbCommand(strSQL, conexao);
        myCmd.Parameters.AddWithValue("@name", u.Name);
        myCmd.Parameters.AddWithValue("@pass", u.Password);
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
    #endregion
    #endregion

}