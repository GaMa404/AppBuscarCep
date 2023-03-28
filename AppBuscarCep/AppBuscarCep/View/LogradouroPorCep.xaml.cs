using AppBuscarCep.Model;
using AppBuscarCep.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBuscarCep.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogradouroPorCep : ContentPage
    {
        public LogradouroPorCep()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                carregando.IsRunning = true;
                Endereco arr_end = await DataService.GetEnderecoByCep(txt_cep.Text);

                lst_enderecos.ItemsSource = arr_end;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops!", ex.Message, "OK");
            }
            finally
            {
                carregando.IsRunning = false;
            }
        }
    }

}