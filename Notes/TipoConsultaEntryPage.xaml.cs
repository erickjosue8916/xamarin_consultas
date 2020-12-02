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
    public partial class TipoConsultaEntryPage : ContentPage
    {
        public TipoConsultaEntryPage()
        {
            InitializeComponent();
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var tipoConsulta = (TipoConsulta)BindingContext;

            await App.Database.SaveTipoConsultaAsync(tipoConsulta);
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var tipoConsulta = (TipoConsulta)BindingContext;
            await App.Database.DeleteTipoConsultaAsync(tipoConsulta);
            await Navigation.PopAsync();
        }
    }
}