using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactosApp.Class
{
    public class Empresa
    {
        private string _id;
        private string _nome;
        private string _moradaP;
        private string _nif;

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

        public Empresa()
        {
            _id = Guid.NewGuid().ToString();
            _nome = "";
            _moradaP = "";
            _nif = "";
        }

        public Empresa(string b, string d, string c)
        {
            _id = Guid.NewGuid().ToString();
            _nome = b;
            _moradaP = c;
            _nif = d;
        }
    }
}
