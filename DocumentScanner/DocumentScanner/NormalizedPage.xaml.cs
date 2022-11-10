using DDNXamarin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DocumentScanner
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NormalizedPage : ContentPage
    {
        private NormalizedImageResult normalizedImage;
        public NormalizedPage(NormalizedImageResult data)
        {
            normalizedImage = data;

            InitializeComponent();

            image.Source = normalizedImage.image.ToImageSource();
            if (Device.RuntimePlatform == Device.iOS)
            {
                image.RotateTo(normalizedImage.image.orientation);
            }
        }

        void OnShareClicked(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () => {
                var result = await this.DisplayAlert("Share", "Do you want to share the image?", "Yes", "No");
                if (result) SaveImage();
            });
        }

        private void SaveImage()
        {
            if (normalizedImage != null)
            {
                try
                {
                    //string savePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/normalized.pdf";
                    string file = Path.Combine(FileSystem.CacheDirectory, "normalized.pdf");

                    //if (File.Exists(savePath))
                    //{
                    //    File.Delete(savePath);
                    //}
                    App.ddn.SaveToFile(normalizedImage, file);
                    Device.BeginInvokeOnMainThread(async () => {

                        await Share.RequestAsync(new ShareFileRequest
                        {
                            Title = Title,
                            File = new ShareFile(file),
                            PresentationSourceBounds = DeviceInfo.Platform == DevicePlatform.iOS && DeviceInfo.Idiom == DeviceIdiom.Tablet
                            ? new System.Drawing.Rectangle(0, 20, 0, 0)
                            : System.Drawing.Rectangle.Empty
                        });
                    });

                }
                catch (Exception e)
                {
                    Device.BeginInvokeOnMainThread(async () => {
                        await DisplayAlert("Error", e.ToString(), "OK");
                    });
                }
            }

        }
    }
}