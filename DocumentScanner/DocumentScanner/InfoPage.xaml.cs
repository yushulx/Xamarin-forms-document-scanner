using DDNXamarin;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DocumentScanner
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoPage : ContentPage
    {
        
        private bool isFront = true;
        private InfoData _frontData = null;
        private InfoData _backData = null;

        public InfoPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, true);
            NavigationPage navigationPage = Application.Current.MainPage as NavigationPage;

            navigationPage.Pushed += NavigationPage_Pushed;

            MessagingCenter.Subscribe<QuadEditorPage, InfoData>(this, "ImageData", (sender, arg) =>
            {
                App.ddn.InitRuntimeSettings(Templates.color);

                NormalizedImageResult normalizedImage = App.ddn.Normalize(arg.imageData, arg.quad);

                if (isFront)
                {
                    _frontData = arg;
                    front_image.Source = normalizedImage.image.ToImageSource();
                    front_image.RotateTo(270);
                    if (Device.RuntimePlatform == Device.iOS)
                    {
                        front_image.RotateTo(normalizedImage.image.orientation);
                    }

                }
                else
                {
                    _backData = arg;
                    back_image.Source = normalizedImage.image.ToImageSource();
                    back_image.RotateTo(normalizedImage.image.orientation);
                    if (Device.RuntimePlatform == Device.iOS)
                    {
                        back_image.RotateTo(normalizedImage.image.orientation);
                    }
                }
            });

            MessagingCenter.Subscribe<CustomRendererPage, InfoData>(this, "ImageData", (sender, arg) =>
            {
                App.ddn.InitRuntimeSettings(Templates.color);

                NormalizedImageResult normalizedImage = App.ddn.Normalize(arg.imageData, arg.quad);

                if (isFront)
                {
                    _frontData = arg;
                    front_image.Source = normalizedImage.image.ToImageSource();
                    front_image.RotateTo(270);
                    if (Device.RuntimePlatform == Device.iOS)
                    {
                        front_image.RotateTo(normalizedImage.image.orientation);
                    }

                }
                else
                {
                    _backData = arg;
                    back_image.Source = normalizedImage.image.ToImageSource();
                    back_image.RotateTo(normalizedImage.image.orientation);
                    if (Device.RuntimePlatform == Device.iOS)
                    {
                        back_image.RotateTo(normalizedImage.image.orientation);
                    }
                }
            });
        }

        async void OnFrontClicked(object sender, EventArgs e)
        {
            isFront = true;
            await Navigation.PushAsync(new CustomRendererPage());
        }

        async void OnBackClicked(object sender, EventArgs e)
        {
            isFront = false;
            await Navigation.PushAsync(new CustomRendererPage());
        }

        async void OnCommitClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private void NavigationPage_Pushed(object sender, NavigationEventArgs e)
        {
           
        }

        private void BackImageTapped(object sender, EventArgs e)
        {
            
            if (_backData != null) {
                DetectedQuadResult result = new DetectedQuadResult();
                result.Location = _backData.quad;
                Navigation.PushAsync(new QuadEditorPage(_backData.imageData,  new DetectedQuadResult[] {result}));
            }
            
        }

        private void FrontImageTapped(object sender, EventArgs e)
        {
            if (_frontData != null)
            {
                DetectedQuadResult result = new DetectedQuadResult();
                result.Location = _frontData.quad;
                Navigation.PushAsync(new QuadEditorPage(_frontData.imageData, new DetectedQuadResult[] { result }));
            }
        }
        void OnUploadClicked(object sender, EventArgs e)
        {
            string value = amount.Text;

            if (string.IsNullOrEmpty(value))
            {
                DisplayAlert("Error", "The amount is empty!", "OK");
                return;
            }

            try
            {
                double number = double.Parse(value);
            }
            catch
            {
                DisplayAlert("Error", "Invalid number!", "OK");
                return;
            }
            

            if (_frontData != null && _backData != null)
            {
                DisplayAlert("Check Submit", "Your mobile check has been submitted.", "OK");
            }
            else
            {
                DisplayAlert("Warning", "Please capture your check!", "OK");
            }
        }
    }
}