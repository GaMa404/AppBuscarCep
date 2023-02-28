using System;
using System.Collections.Generic;
using System.Text;

namespace AppBuscarCep.Model
{
    public class Logradouro
    {
        public int id_logradouro { get ; set; }
        public int id_cidade { get; set; }
        public string descricao_bairro { get; set; }
        public string descricao { get; set; }
    }
}
