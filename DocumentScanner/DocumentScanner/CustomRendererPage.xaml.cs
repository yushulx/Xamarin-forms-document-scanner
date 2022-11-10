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

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += OnTapGestureRecognizerTapped;
            preview.GestureRecognizers.Add(tapGestureRecognizer);
        }

        void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        {
            App.ddn.EnableReturnImageOnNextCallback();
        }

        public void DetectResultCallback(int id, ImageData imageData, DetectedQuadResult[] quadResults)
        {

            if (imageData != null && quadResults != null)

            {

                Device.BeginInvokeOnMainThread(async () => {
                    await Navigation.PushAsync(new QuadEditorPage(imageData, quadResults));
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