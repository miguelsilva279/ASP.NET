using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactosApp.Class
{
    public class Contactos
    {
        private string _id;
        private TipoC _tipo;
        private string _valor;

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public TipoC Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        public string Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }

        public Contactos()
        {
            _id = Guid.NewGuid().ToString();
            _tipo = 0;
            _valor = "";
        }
        public Contactos(TipoC a, string b)
        {
            _id = Guid.NewGuid().ToString();
            _tipo = a;
            _valor = b;
        }
        
    }

    public enum TipoC
    {
        DEFAULT = 0,
        EMAIL,
        TELEFONE,
        TELEMOVEL,
        FAX
    };
}
