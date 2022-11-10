using DDNXamarin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        ImageData imageData;
        private Quadrilateral quadrilateral;
        public NormalizedPage(ImageData data, Quadrilateral quad)
        {
            imageData = data;
            quadrilateral = quad;

            InitializeComponent();

            UpdateNormalizedImage(Templates.binary);
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
                    string file = Path.Combine(FileSystem.CacheDirectory, "normalized.png");

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

        private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            RadioButton button = sender as RadioButton;
            if (button != null)
            {
                if (button.Content.Equals("Binary") && button.IsChecked)
                {
                    UpdateNormalizedImage(Templates.binary);
                }
                if (button.Content.Equals("Color") && button.IsChecked)
                {
                    UpdateNormalizedImage(Templates.color);
                }
                if (button.Content.Equals("Grayscale") && button.IsChecked)
                {
                    UpdateNormalizedImage(Templates.grayscale);
                }
            }
        }

        private void UpdateNormalizedImage(string template)
        {
            App.ddn.InitRuntimeSettings(template);
            normalizedImage = App.ddn.Normalize(imageData, quadrilateral);

            Image image = gestureView.getImage();

            image.Source = normalizedImage.image.ToImageSource();
            if (Device.RuntimePlatform == Device.iOS)
            {
                image.RotateTo(normalizedImage.image.orientation);
            }
        }

    }
}