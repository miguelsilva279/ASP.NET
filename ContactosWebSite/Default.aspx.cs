using ContactosApp.Class;
using ContactosApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    Utilizador user;
    IDAL x = new DataLayer();
    public static string id { set; get; }
    public static string nome { set; get; }
    public static bool admin { set; get; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!x.BDExiste())
            Label1.Text = "Nao tem ligaçao a base de dados";
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
      
        if (!x.ExisteUtilizador())
        {
            user = new Utilizador(TextBox1.Text, TextBox2.Text, true);

            x.InsereUtilizador(user);
            id = user.Id;
            nome = user.Nome;
            admin = user.IsAdmin;
            //fPrincipal = new frmPrincipal();
            //fPrincipal.Show();
            //this.Hide();
        }
        else if ((x.ExisteUserPass(TextBox1.Text, TextBox2.Text) as Utilizador) != null)
        {
            user = x.ExisteUserPass(TextBox1.Text, TextBox2.Text);
            id = user.Id;
            nome = user.Nome;
            admin = user.IsAdmin;
            Label1.Text = "Bem-Vindo "+ nome;
            TextBox1.Text = "";
            //fPrincipal = new frmPrincipal();
            //fPrincipal.Show();
            //this.Hide();

        }
        else
        {
            Label1.Text = "Utilizador ou Palavra-passe invalido. Tente novamente";
            TextBox1.Text = "";
        }
    }

}
