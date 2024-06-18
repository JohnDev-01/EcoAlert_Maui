using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoAlert_Maui.VisualElement
{
    public class Hyperlink : Label
    {
        public static readonly BindableProperty UrlProperty =
            BindableProperty.Create(nameof(Url), typeof(string), typeof(Hyperlink));

        public string Url
        {
            get { return (string)GetValue(UrlProperty); }
            set { SetValue(UrlProperty, value); }
        }
        public Hyperlink()
        {
            TextDecorations = TextDecorations.Underline;
            TextColor = Color.FromHex("#2AABFF");
            GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () => await Launcher.OpenAsync(Url))
            });
        }
    }
}
