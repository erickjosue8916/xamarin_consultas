using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Tarea.Models;
using Notes;

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
            var paciente = (Consulta)BindingContext;

            await App.Database.SaveConsultaAsync(paciente);
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (Consulta)BindingContext;
            await App.Database.DeleteConsultaAsync(note);
            await Navigation.PopAsync();
        }
    }
}