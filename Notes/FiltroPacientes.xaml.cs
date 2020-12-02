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

        private void OnDateSelected(object sender, DateChangedEventArgs e)
        {

        }

        private void searchPaciente_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}