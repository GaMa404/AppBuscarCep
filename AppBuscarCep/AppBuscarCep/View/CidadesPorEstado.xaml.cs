using AppBuscarCep.Model;
using AppBuscarCep.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBuscarCep.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CidadesPorEstado : ContentPage
    {
        ObservableCollection<Cidade> lista_cidades = new ObservableCollection<Cidade>();
        public CidadesPorEstado()
        {
            InitializeComponent();

            lst_cidades.ItemsSource = lista_cidades;
        }

        private async void pck_estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                carregando.IsRunning = true;

                Picker disparador = sender as Picker;

                string estado_selecionado = disparador.SelectedItem as string;

                List<Cidade> arr_cidades = await DataService.GetCidadeByUF(estado_selecionado);

                lista_cidades.Clear();

                arr_cidades.ForEach(i => lista_cidades.Add(i));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops!", ex.Message, "Ok");
            }
            finally
            {
                carregando.IsRunning = false;
            }
        }
    }
}