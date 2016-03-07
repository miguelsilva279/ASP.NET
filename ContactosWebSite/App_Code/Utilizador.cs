using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactosApp.Class
{
    public class Utilizador
    {
        private string _id;
        private string _nome;
        private string _palavraPasse;
        private bool _IsAdmin;
        
        
        

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

        public string PalavraPasse
        {
            get { return _palavraPasse; }
            set { _palavraPasse = value; }
        }

        public bool IsAdmin
        {
            get { return _IsAdmin; }
            set { _IsAdmin = value; }
        }


        public Utilizador()
        {
            _id = Guid.NewGuid().ToString();
            _nome = "";
            _palavraPasse = "";
            _IsAdmin = false;
        }

        public Utilizador(string a, string b, bool c)
        {
            _id = Guid.NewGuid().ToString();
            _nome = a;
            _palavraPasse = b;
            _IsAdmin = c;
        }
    }
}
