using System;
using Xamarin.Forms;
using Tarea.Models;

namespace Notes
{
    public partial class PacientesPage : ContentPage
    {
        public PacientesPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetPasientesAsync();
        }

        async void OnNoteAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PacientesEntryPage
            {
                BindingContext = new Paciente()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new PacientesEntryPage
                {
                    BindingContext = e.SelectedItem as Paciente
                });
            }
        }
    }
}
