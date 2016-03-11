using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Publisher
/// </summary>
public class Publisher
{
    private string _id;
    private string _name;
    private string _city;
    private string _country;


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
    public string City
    {
        get { return _city; }
        set { _city = value; }
    }

    public string Country
    {
        get { return _country; }
        set { _country = value; }
    }

    public Publisher(string b, string c, string d)
    {
        _id= createId();
        _name= b;
        _city= c;
        _country = d;
    }

    public Publisher()
    {
        _id = createId();
        _name = "";
        _city = "";
        _country = "";
    }

    public string createId()
    {
        Random rnd = new Random();
        DataLayer x = new DataLayer();

        int a = rnd.Next(1000, 9999);

        string d = a.ToString();
        if (!x.compareIdPublisher(d))
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