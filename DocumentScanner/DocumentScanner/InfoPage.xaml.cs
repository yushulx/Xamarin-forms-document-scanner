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
    public partial class InfoPage : ContentPage
    {
        
        private bool isFront = true;
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
                    front_image.Source = normalizedImage.image.ToImageSource();
                    front_image.RotateTo(270);
                    //if (normalizedImage.image.width > normalizedImage.image.height)

                }
                else
                {
                    back_image.Source = normalizedImage.image.ToImageSource();
                    back_image.RotateTo(normalizedImage.image.orientation);
                    //if (normalizedImage.image.width > normalizedImage.image.height)
                    //    back_image.RotateTo(normalizedImage.image.orientation);
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
    }
}