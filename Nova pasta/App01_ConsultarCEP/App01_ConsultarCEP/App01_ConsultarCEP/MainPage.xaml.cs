using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Serviço.Modelo;
using App01_ConsultarCEP.Serviço;


namespace App01_ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Botao.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs args)
        {
            //TODO - Validação
            string cep = CEP.Text.Trim();
            if (isValidCEP(cep)){
                try
                {
                Endereco end = ViaCEPServiço.BuscarEnderecoViaCEP(cep);

                    if(end != null)
                    {
                        RESULTADO.Text = string.Format("Endereço: {3} {0} {1} {2} ", end.localidade, end.uf, end.logradouro, end.bairro);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "O endereço não foi encontrado para o cep informado:" + cep, "OK");
                    }

                RESULTADO.Text = string.Format("Endereço: {3} {0} {1} {2} ", end.localidade, end.uf, end.logradouro, end.bairro);
            }catch(Exception e)
            {
                DisplayAlert("Erro Crítico", e.Message,"OK");
            }
        }
            
        }
        private bool isValidCEP(string cep){

            bool valido = true;

            if(cep.Length != 8) //Validação do tamamho do CEP
            {
                DisplayAlert("ERRO", "CEP Inválido! O CEP deve conter 8 caracteres", "OK");

                valido = false;
            }
            int NovoCEP = 0;
            
            if(!int.TryParse(cep, out NovoCEP))
            {
                DisplayAlert("ERRO", "CEP Inválido O CEP deve ser ser composto apenas por números", "OK");

                valido = false;
            }

            return valido;
        }
    }
}
