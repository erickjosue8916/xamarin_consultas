using System;
using Xamarin.Forms;
using Tarea.Models;

namespace Notes
{
    public partial class PacientesEntryPage : ContentPage
    {
        public PacientesEntryPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var paciente = (Paciente)BindingContext;
            
            await App.Database.SavePacienteAsync(paciente);
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (Paciente)BindingContext;
            await App.Database.DeletePacienteAsync(note);
            await Navigation.PopAsync();
        }
    }
}
