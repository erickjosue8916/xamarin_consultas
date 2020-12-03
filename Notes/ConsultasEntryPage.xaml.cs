using Notes;
using System;
using Tarea.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tarea
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultasEntryPage : ContentPage
    {
        public ConsultasEntryPage()
        {
            InitializeComponent();
            
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            pacientesList.ItemsSource = await App.Database.GetPasientesAsync();
            tipoConsultaList.ItemsSource = await App.Database.GetTipoConsultasAsync();
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine(date.Date.ToString());
            var paciente = (Paciente) pacientesList.SelectedItem;
            var tipoConsulta = (TipoConsulta)tipoConsultaList.SelectedItem;
            var consulta = (Consulta)BindingContext;

            consulta.NombrePaciente = paciente.Nombre;
            consulta.NombreTipoConsulta = tipoConsulta.Descripcion;
            consulta.Fecha = date.Date.ToString();
            await App.Database.SaveConsultaAsync(consulta);
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var consulta = (Consulta)BindingContext;
            await App.Database.DeleteConsultaAsync(consulta);
            await Navigation.PopAsync();
        }
    }
}