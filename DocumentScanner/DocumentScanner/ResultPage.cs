using DDNXamarin;
using System.Diagnostics;
using System;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.IO;

namespace DocumentScanner
{
    public class ResultPage : ContentPage
    {
        private NormalizedImageResult normalizedImage;
        public ResultPage(NormalizedImageResult data)
        {
            normalizedImage = data;
            Image image = new Image { Source = normalizedImage.image.ToImageSource()};
            Button button= new Button { Text = "Share"};
            button.Clicked += OnButtonClicked;

            if (Device.RuntimePlatform == Device.iOS)
            {
                image.RotateTo(normalizedImage.image.orientation);
            }
            Content = new StackLayout
            {
                Margin = new Thickness(20),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = {
                    new GestureContainer {
                        Content = image
                    },
                    button
                }
            };
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

        void OnButtonClicked(object sender, EventArgs args)
        {
            Device.BeginInvokeOnMainThread(async () => {
                var result = await this.DisplayAlert("Share", "Do you want to share the image?", "Yes", "No");
                if (result) SaveImage();
            });
        }
    }
}