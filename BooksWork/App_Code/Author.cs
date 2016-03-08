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


    public Author(string a, string b, string c, string d, string e)
    {
        _id = a;
        _lastName = b;
        _firstName = c;
        _phone = d;
        _city = e;
    }

    public Author()
    {
        _id = "";
        _lastName = "";
        _firstName = "";
        _phone = "";
        _city = "";
    }
}