using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AppCep.Serviço.Modelo;
using AppCep.Serviço;

namespace AppCep
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BUSCARCEP;
        }

        private void BUSCARCEP(Object sender, EventArgs args)
        {
            string cep = CEPENTRY.Text.Trim();

            if (isValedCEP(cep))
            {
                try
                {

                    Endereco end = ViaCep.BuscarEnderecoViaCep(cep);

                    if (end != null)
                    {

                        RESULTADO.Text = string.Format("Endereço : {0},{1} {2} {3}", end.logradouro, end.bairro, end.localidade, end.uf);
                    }
                    else
                    {
                        DisplayAlert("Erro", "O endereço não foi encontrado para o Cep informado:"+ cep, "OK");
                    }

                }catch(Exception ex)
                {
                    DisplayAlert("Erro Crítico", ex.Message, "OK");
                }
            }
            
        }


        private bool isValedCEP(string cep)
        {
            bool valido = true;

            if(cep.Length != 8)
            {
                DisplayAlert("Erro", "Cep invalido !", "O CEP deve conter 8 caracter", "OK");
                valido = false;
            }

            int NovoCep = 0;

            if(!int.TryParse(cep,out NovoCep))
            {
                DisplayAlert("Erro", "Cep invalido !", "O CEP deve conter apenas números", "OK");
                valido = false;
            }
            return valido;
        }
    }
}
