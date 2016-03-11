using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ContactosApp.Class;
using ContactosApp.DAL;

public partial class Default2 : System.Web.UI.Page
{
    Utilizador user;
    IDAL x = new DataLayer();
    public static string id { set; get; }
    public static string nome { set; get; }
    public static bool admin { set; get; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!x.BDExiste())
            Label2.Text = "Nao tem ligaçao a base de dados";
    }

    protected void BotaoLogin_Click(object sender, EventArgs e)
    {
        if (!x.ExisteUtilizador())
        {
            user = new Utilizador(TxtUsername.Text, TxtPassword.Text, true);

            x.InsereUtilizador(user);
            id = user.Id;
            nome = user.Nome;
            admin = user.IsAdmin;
            //fPrincipal = new frmPrincipal();
            //fPrincipal.Show();
            //this.Hide();
        }
        else if ((x.ExisteUserPass(TxtUsername.Text, TxtPassword.Text) as Utilizador) != null)
        {
            user = x.ExisteUserPass(TxtUsername.Text, TxtPassword.Text);
            id = user.Id;
            nome = user.Nome;
            admin = user.IsAdmin;
            //Label2.Text = "Bem-Vindo " + nome;
            Session["nome"] = nome;
            Label2.Text = (string)Session["nome"];
            Response.Redirect("Default3.aspx");
            //TxtUsername = "";
            //fPrincipal = new frmPrincipal();
            //fPrincipal.Show();
            //this.Hide();

        }
        else
        {
            Label2.Text = "Utilizador ou Palavra-passe invalido. Tente novamente";
            //TextBox1.Text = "";
        }
    }
}
