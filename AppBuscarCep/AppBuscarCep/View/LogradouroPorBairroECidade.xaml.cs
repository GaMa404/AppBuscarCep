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
    public partial class LogradouroPorBairroECidade : ContentPage
    {
        ObservableCollection<Cidade> lista_cidades = new ObservableCollection<Cidade>();
        ObservableCollection<Bairro> lista_bairros = new ObservableCollection<Bairro>();
        ObservableCollection<Logradouro> lista_log = new ObservableCollection<Logradouro>();

        public LogradouroPorBairroECidade()
        {
            InitializeComponent();

            pck_cidade.ItemsSource = lista_cidades;
            pck_bairro.ItemsSource = lista_bairros;
            lst_log.ItemsSource = lista_log;
        }

        private async void pck_estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
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
        }

        private async void pck_cidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                carregando.IsRunning = true;

                Picker disparador = sender as Picker;

                Cidade cidade_selecionada = disparador.SelectedItem as Cidade;

                List<Bairro> arr_bairros = await DataService.GetBairrosByCidade(cidade_selecionada.id_cidade);

                lista_bairros.Clear();

                arr_bairros.ForEach(i => lista_bairros.Add(i));
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

        /*private async void pck_bairro_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                carregando.IsRunning = true;

                Picker disparador = sender as Picker;

                Cidade bairro_selecionado = disparador.SelectedItem as Cidade;

                List<Logradouro> arr_log = await DataService.GetLogradouroByBairroAndCidade(bairro_selecionado.id_cidade);

                lista_bairros.Clear();

                arr_bairros.ForEach(i => lista_bairros.Add(i));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops!", ex.Message, "Ok");
            }
            finally
            {
                carregando.IsRunning = false;
            }
        }*/
    }
}