using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Configuration;
using System.Data.OleDb;

public partial class _Default : System.Web.UI.Page
{
    private OleDbConnection conexao;
    StringBuilder table = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        string constr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\Books.mdb";
        conexao = new OleDbConnection(constr);
        conexao.Open();
        OleDbCommand cmd = new OleDbCommand();
        cmd.CommandText = "Select * FROM Authors";
        cmd.Connection = conexao;
        OleDbDataReader rd = cmd.ExecuteReader();
        table.Append("<div id='tabelabotoes'><table style='width:100%' class='mdl-data-table mdl-js-data-table mdl-shadow--2dp'");
        table.Append("<tr><th>Id</th><th>Apelido</th><th>Nome</th><th>Telefone</th><th>Cidade</th><th></th>");
        table.Append("</tr>");
        if (rd.HasRows)
        {
            while(rd.Read())
            {
                table.Append("<tr>");
                table.Append("<td>" + rd[0] + "</td>");
                table.Append("<td>" + rd[1] + "</td>");
                table.Append("<td>" + rd[2] + "</td>");
                table.Append("<td>" + rd[3] + "</td>");
                table.Append("<td>" + rd[4] + "</td>");
                table.Append("<td><button class='mdl-button mdl-js-button mdl-button--icon'><i class='material-icons' style='color:black;'>edit</i></button> <button class='mdl-button mdl-js-button mdl-button--icon'><i class='material-icons' style='color:black;'>delete</i></button></td>");
                table.Append("</tr>");
            }
        }
        table.Append("</table></div>");
        PlaceHolder1.Controls.Add(new Literal { Text = table.ToString() });
        rd.Close();
    }
}