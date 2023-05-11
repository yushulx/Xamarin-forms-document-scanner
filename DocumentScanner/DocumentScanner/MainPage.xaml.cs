using DDNXamarin;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DocumentScanner
{
    public partial class MainPage : ContentPage
    {
        private bool isButtonEnabled = true;
        private TimeSpan buttonDisableDuration = TimeSpan.FromSeconds(2);

        public MainPage()
        {
            InitializeComponent();
        }

        async void OnCustomRendererButtonClicked(object sender, EventArgs e)
        {
            if (isButtonEnabled)
            {
                isButtonEnabled = false;
                await Navigation.PushAsync(new InfoPage());
                await Task.Delay(buttonDisableDuration);
                isButtonEnabled = true;
            }
                
        }
    }
}
