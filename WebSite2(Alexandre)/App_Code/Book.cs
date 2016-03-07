using ContactosApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for Book
/// </summary>
public class Book
{
    private string _id;
    private string _title;
    private string _type;
    private string _pubId;
    private double _price;
    private string _date;


    public string id
    {
        get { return _id; }
        set { _id = value; }
    }

    public string Title
    {
        get { return _title; }
        set { _title = value; }
    }

    public string Type
    {
        get { return _type; }
        set { _type = value; }
    }

    public string PubId
    {
        get { return _pubId; }
        set { _pubId = value; }
    }

    public double Price
    {
        get { return _price; }
        set { _price = value; }
    }

    public string PubDate
    {
        get { return _date; }
        set { _date = value; }
    }

    public Book(string b, string c, double d)
    {
        DataLayer x = new DataLayer();
        string a = (x.readLastBookId()).ToString();
        _id = "TD"+ a;
        _title = b;
        _type = c;
        _price = d;
        _date = DateTime.Now.ToString("MM/dd/yyyy");
    }
}