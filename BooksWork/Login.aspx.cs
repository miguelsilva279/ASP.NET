using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    User user;
    IDAL x = new DataLayer();
    public static string id { set; get; }
    public static string nome { set; get; }
    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!x.BDExiste())
            lbl.Text = "Nao tem ligaçao a base de dados";
    }

    protected void BotaoLogin_Click(object sender, EventArgs e)
    {
        if (!x.ExisteUtilizador())
        {
            user = new User(TxtUsername.Text, TxtPassword.Text);

            x.CreateUser(user);
            id = user.Id;
            nome = user.Name;
          
           }
        else if ((x.ExisteUserPass(TxtUsername.Text, TxtPassword.Text) as User) != null)
        {
            user = x.ExisteUserPass(TxtUsername.Text, TxtPassword.Text);
            id = user.Id;
            nome = user.Name;
            
           
            Session["nome"] = nome;
            lbl.Text = (string)Session["nome"];
            Response.Redirect("BookAdmin.aspx");
            

        }
        else
        {
            lbl.Text = "Utilizador ou Palavra-passe invalido. Tente novamente";
            //TextBox1.Text = "";
        }
    }
}