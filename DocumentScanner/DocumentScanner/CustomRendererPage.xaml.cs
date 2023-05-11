using DDNXamarin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DocumentScanner
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomRendererPage : ContentPage, IDetectResultListener
    {
        public static ICameraEnhancer dce;
        public static IDocumentNormalizer ddn;


        public CustomRendererPage()
        {
            InitializeComponent();
            App.ddn.SetCameraEnhancer(App.dce);
            App.ddn.AddResultListener(this);
        }

        public void DetectResultCallback(int id, ImageData imageData, DetectedQuadResult[] quadResults)
        {

            if (imageData != null && quadResults != null)
            {
                
                Device.BeginInvokeOnMainThread(async () => {
                    ImageData data = new ImageData();
                    data.imageSource = imageData.imageSource;
                    data.bytes = new List<byte>(imageData.bytes);
                    data.width = imageData.width;
                    data.height = imageData.height;
                    data.stride = imageData.stride;
                    data.format = imageData.format;
                    data.orientation = imageData.orientation;

                    //await Navigation.PushAsync(new QuadEditorPage(data, quadResults));

                    InfoData info = new InfoData();
                    info.imageData = data;
                    info.quad = quadResults[0].Location;
                    MessagingCenter.Send(this, "ImageData", info);

                    await Navigation.PopAsync();

                });
            }
        }

        protected override void OnAppearing()
        {

            base.OnAppearing();
            App.dce.Open();
            App.ddn.StartDetecting();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            App.dce.Close();
            App.ddn.StopDetecting();

        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            App.ddn.EnableReturnImageOnNextCallback();
        }

    }
}