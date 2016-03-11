using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Author
/// </summary>
public class Author
{
    private string _id;
    private string _lastName;
    private string _firstName;
    private string _phone;
    private string _city;


    public string Id
    {
        get { return _id; }
        set { _id = value; }
    }

    public string LastName
    {
        get { return _lastName; }
        set { _lastName = value; }
    }

    public string FirstName
    {
        get { return _firstName; }
        set { _firstName = value; }
    }

    public string Phone
    {
        get { return _phone; }
        set { _phone = value; }
    }

    public string City
    {
        get { return _city; }
        set { _city = value; }
    }


    public Author(string b, string c, string d, string e)
    {
        _id = createId();
        _lastName = b;
        _firstName = c;
        _phone = d;
        _city = e;
    }

    public Author()
    {
        _id = createId();
        _lastName = "";
        _firstName = "";
        _phone = "";
        _city = "";
    }

    public string createId()
    {
        Random rnd = new Random();
        DataLayer x= new DataLayer();

        int a = rnd.Next(100, 999);
        int b = rnd.Next(10, 99);
        int c = rnd.Next(1000, 9999);
        string d =a.ToString()+"-"+b.ToString()+"-"+c.ToString();
        if (!x.compareIdAuthor(d))
        {
            return d;
        }
        else
        {
            createId();
        }
        return d;
    }
}