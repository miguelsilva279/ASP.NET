using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for User
/// </summary>
public class User
{
    private string _id;
    private string _name;
    private string _password;

    public string Id
    {
        get { return _id; }
        set { _id = value; }
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public string Password
    {
        get { return _password; }
        set { _password = value; }
    }

    public User()
    {
        _id = Guid.NewGuid().ToString();
        _name = "";
        _password = "";
    }
    public User(string name, string pass)
    {
        _id = Guid.NewGuid().ToString();
        _name = name;
        _password = pass;
    }

}