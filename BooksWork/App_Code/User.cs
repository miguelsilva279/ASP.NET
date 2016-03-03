using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for User
/// </summary>
public class User
{
    private string _name;
    private string _password;

    public User(string name, string pass)
    {
        _name = name;
        _password = pass;
    }

}