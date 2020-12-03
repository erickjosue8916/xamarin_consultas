using Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tarea
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FiltroPacientes : ContentPage
    {
        public FiltroPacientes()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetConsultasAsync();
        }

        private void OnDateSelected(object sender, DateChangedEventArgs e)
        {

        }

        private async void searchPaciente_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue == "")
            {
                listView.ItemsSource = await App.Database.GetConsultasAsync();
            }
            else
            {
                listView.ItemsSource = await App.Database.GetConsultasFilterAsync(e.NewTextValue);
            }
        }
    }
}