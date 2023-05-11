using DDNXamarin;
using System;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DocumentScanner
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuadEditorPage : ContentPage
    {
        private bool isButtonEnabled = true;
        private TimeSpan buttonDisableDuration = TimeSpan.FromSeconds(2);
        private ImageData data;
        private DetectedQuadResult[] results;

        public QuadEditorPage(ImageData imageData, DetectedQuadResult[] results)
        {
            InitializeComponent();
            data = imageData;
            this.results = results;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (data != null)
            {
                imageEditor.OriginalImage = data;
            }
            if (results != null)
            {
                imageEditor.DetectedQuadResults = results;
            }
        }

        async void OnNormalizeClicked(object sender, EventArgs e)
        {
            if (isButtonEnabled)
            {
                isButtonEnabled = false;
                try
                {
                    var quad = imageEditor.getSelectedQuadResult();
                    if (quad != null)
                    {
                        InfoData data = new InfoData();
                        data.imageData = this.data;
                        data.quad = quad;
                        MessagingCenter.Send(this, "ImageData", data);
                        if (Navigation.NavigationStack.Count == 4)
                        {
                            Navigation.RemovePage(Navigation.NavigationStack[2]);
                        }

                        await Navigation.PopAsync();
                    }
                }
                catch (Exception exception)
                {
                    Device.BeginInvokeOnMainThread(async () => {
                        await DisplayAlert("Error", exception.ToString(), "OK");
                    });
                }
                await Task.Delay(buttonDisableDuration);
                isButtonEnabled = true;
            }

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}