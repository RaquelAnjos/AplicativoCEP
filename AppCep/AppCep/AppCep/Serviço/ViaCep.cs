using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using AppCep.Serviço.Modelo;
using Newtonsoft.Json;

namespace AppCep.Serviço
{
    public class ViaCep
    {
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCep(string cep)
        {
            string NovoEnderecoUrL = string.Format(EnderecoURL, cep);

            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(NovoEnderecoUrL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(conteudo) ;

            if (end.cep == null) return null;

            return end;
        }
    }
}
