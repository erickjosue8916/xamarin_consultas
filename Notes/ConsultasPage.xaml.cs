using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Notes;
using Tarea.Models;
namespace Tarea
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultasPage : ContentPage
    {
        public ConsultasPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetConsultasAsync();
        }

        async void OnConsultaAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ConsultasEntryPage
            {
                BindingContext = new Consulta()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ConsultasEntryPage
                {
                    BindingContext = e.SelectedItem as Consulta
                });
            }
        }
    }
}