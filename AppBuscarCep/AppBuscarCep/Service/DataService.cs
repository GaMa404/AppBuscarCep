using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using AppBuscarCep.Model;
using System.Net.Http;

namespace AppBuscarCep.Service
{
    public class DataService
    {
        // ====== Obtém lista de endereço pelo CEP ======

        public static async Task<Endereco> GetEnderecoByCep(string cep)
        {
            Endereco arr_end;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("http://10.0.2.2:8000/endereco/by-cep?cep=" + cep);

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    arr_end = JsonConvert.DeserializeObject<Endereco>(json);
                }
                else
                {
                    throw new Exception(response.RequestMessage.Content.ToString());
                }
            }

            return arr_end;
        }

        // ====== Obtém lista de bairro pela cidade ======

        public static async Task<List<Bairro>> GetBairrosByCidade(string cidade)
        {
            List<Bairro> arr_bairros = new List<Bairro>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("http://10.0.2.2:8000/bairro/by-cidade?id_cidade=" + cidade);

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    arr_bairros = JsonConvert.DeserializeObject<List<Bairro>>(json);
                }
                else
                {
                    throw new Exception(response.RequestMessage.Content.ToString());
                }
            }

            return arr_bairros;
        }

        // ====== Obtém lista de logradouro pelo bairro e cidade ======

        public static async Task<List<Logradouro>> GetLogradouroByBairroAndCidade(string id_cidade, string bairro)
        {
            List<Logradouro> arr_log = new List<Logradouro>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("http://10.0.2.2:8000/logradouro/by-bairro?id_cidade=" + id_cidade + "&bairro=" + bairro);

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    arr_log = JsonConvert.DeserializeObject<List<Logradouro>>(json);
                }
                else
                {
                    throw new Exception(response.RequestMessage.Content.ToString());
                }
            }

            return arr_log;
        }

        // ====== Obtém lista de CEP pelo logradouro ======

        public static async Task<List<Cep>> GetCepByLogradouro(string logradouro)
        {
            List<Cep> arr_cep = new List<Cep>();

            using (HttpClient client = new HttpClient()) 
            {
                HttpResponseMessage response = await client.GetAsync("http://10.0.2.2:8000/cep/by-logradouro?logradouro=" + logradouro);

                if (response.IsSuccessStatusCode) 
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    arr_cep = JsonConvert.DeserializeObject<List<Cep>>(json);
                }
                else
                {
                    throw new Exception(response.RequestMessage.Content.ToString());
                }
            }

            return arr_cep;
        }

        // ====== Obtém lista de cidades pelo UF (estado ou DF) ======

        public static async Task<List<Cidade>> GetCidadeByUF(string UF)
        {
            List<Cidade> arr_cidade = new List<Cidade>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("http://10.0.2.2:8000/cidade/by-uf?uf=" + UF);

                if (response.IsSuccessStatusCode) 
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    arr_cidade = JsonConvert.DeserializeObject<List<Cidade>>(json);
                }
                else
                {
                    throw new Exception(response.RequestMessage.Content.ToString());
                }
            }

            return arr_cidade;
        }
    }
}
