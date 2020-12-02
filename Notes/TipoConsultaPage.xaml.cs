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
    public partial class TipoConsultaPage : ContentPage
    {
        public TipoConsultaPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetTipoConsultasAsync();
        }
        async void OnNoteAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TipoConsultaEntryPage
            {
                BindingContext = new TipoConsulta()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new TipoConsultaEntryPage
                {
                    BindingContext = e.SelectedItem as TipoConsulta
                });
            }
        }
    }
}