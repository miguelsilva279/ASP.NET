using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Book
/// </summary>
public class Book
{
    private string _id;
    private string _title;
    private string _type;
    private string _pubId;
    private decimal _price;
    private DateTime _date;


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

    public decimal Price
    {
        get { return _price; }
        set { _price = value; }
    }

    public DateTime PubDate
    {
        get { return _date; }
        set { _date = value; }
    }

    public Book(string b, string c, string f, decimal d, DateTime e)
    {

        _id = "TD"+ createId().ToString();
        _title = b;
        _type = c;
        _price = d;
        _date = e;
        _pubId = f;
    }
    public Book()
    {
        _id = "TD"+ createId().ToString();
        _title = "";
        _type = "";
        _price = 0;
        _pubId = "";
        _date = DateTime.Now;
    }

    public int createId()
    {
        DataLayer x = new DataLayer();
        string a = x.readLastBookId();

        string [] b = a.Split( new string [] {"TD"}, StringSplitOptions.None);

        return (Convert.ToInt32(b[1]))+1;
    }
}