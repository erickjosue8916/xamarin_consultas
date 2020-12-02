using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Tarea.Validaciones
{
    public class NumberValidatorBehavior:Behavior<Entry>
    {
        static readonly BindablePropertyKey IsValidPropertyKey =BindableProperty.CreateReadOnly("Valido", typeof(bool),typeof(NumberValidatorBehavior), false);
        public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;

        public bool Valido
        {
            get { return (bool)base.GetValue(IsValidProperty); }
            private set { base.SetValue(IsValidPropertyKey, value); }
        }

        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }
        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }
        void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            double result;
            Valido = double.TryParse(args.NewTextValue, out result);
            ((Entry)sender).TextColor = Valido ? Color.Default : Color.Red;
            ((Entry)sender).BackgroundColor = Valido ? Color.Default :
           Color.FromHex("#FBC5D0");
        }

    }
}
