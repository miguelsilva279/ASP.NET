using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactosApp.Class
{
   public class Morada
    {
        private string _id;
        private string _rua;
        private string _CPostal;
        private string _localidade;

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Rua
        {
            get { return _rua; }
            set { _rua = value; }
        }

        public string CPostal
        {
            get { return _CPostal; }
            set { _CPostal = value; }
        }

        public string Localidade
        {
            get { return _localidade; }
            set { _localidade = value; }
        }

        public Morada()
        {
            _id = Guid.NewGuid().ToString();
            _rua = "";
            _CPostal = "";
            _localidade = "";
        }

        public Morada(string b, string c, string d)
        {
            _id = Guid.NewGuid().ToString();
            _rua = b;
            _CPostal = c;
            _localidade = d;
        }
    }
}
