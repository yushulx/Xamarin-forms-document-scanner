using DDNXamarin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DocumentScanner
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuadEditorPage : ContentPage
    {
        ImageData data;
        DetectedQuadResult[] results;
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

        void OnNormalizeClicked(object sender, EventArgs e)
        {
            try
            {
                var quad = imageEditor.getSelectedQuadResult();
                if (quad != null)
                {
                    //Navigation.PushAsync(new NormalizedPage(data, quad));
                    InfoData data = new InfoData();
                    data.imageData = this.data;
                    data.quad = quad;
                    MessagingCenter.Send(this, "ImageData", data);
                    Navigation.RemovePage(Navigation.NavigationStack[2]);
                    Navigation.PopAsync();
                }
            }
            catch (Exception exception)
            {
                Device.BeginInvokeOnMainThread(async () => {
                    await DisplayAlert("Error", exception.ToString(), "OK");
                });
            }

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}