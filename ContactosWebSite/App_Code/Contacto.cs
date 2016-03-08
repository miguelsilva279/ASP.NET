using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactosApp.Class
{
    public class Contacto
    {
        private string _id;
        private string _nome;
        private string _titulo;
        private string _moradaP;
        private string _nif;
        private List<Empresa> _empresas = new List<Empresa>();
        private List<Contactos> _contactosP= new List<Contactos>();
        private bool _IsPublic;
        private string _criador;

        public List<Empresa> getEmpresa()
        {
            return _empresas;
        }

        public List<Contactos> getContactos()
        {
            return _contactosP;
        }

        public void addEmpresa(Empresa a)
        {
            _empresas.Add(a);
        }

        public void addEmpresa(Contactos a)
        {
            _contactosP.Add(a);
        }
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }

        public string MoradaP
        {
            get { return _moradaP; }
            set { _moradaP = value; }
        }

        public string Nif
        {
            get { return _nif; }
            set { _nif = value; }
        }


        public bool IsPublic
        {
            get { return _IsPublic; }
            set { _IsPublic = value; }
        }

        public string Criador
        {
            get { return _criador; }
            set { _criador = value; }
        }

        public Contacto()
        {
            _id = Guid.NewGuid().ToString();
            _nome = "";
            _titulo = "";
            _moradaP = "";
            _nif = "";
            //_empresas = null;
            //_contactosP = null;
            _IsPublic = false;
            _criador = "";
        }

        public Contacto(string b, string c, string d, string e, bool h, string i)
        {
            _id = Guid.NewGuid().ToString();
            _nome = b;
            _titulo = c;
            _moradaP = d;
            _nif = e;
            //_empresas = f;
            //_contactosP = g;
            _IsPublic = h;
            _criador = i;
        }
        public string ImprimeNome()
        {
            return _nome;
        }
    }

   
    
}
