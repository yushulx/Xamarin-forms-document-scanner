using DDNXamarin;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DocumentScanner
{
    public partial class MainPage : ContentPage, ILicenseVerificationListener
    {
        private bool isButtonEnabled = true;
        private TimeSpan buttonDisableDuration = TimeSpan.FromSeconds(2);
        private ILicenseManager licenseManager;
        private bool isLicenseValid = true;

        public MainPage(ILicenseManager licenseManager)
        {
            InitializeComponent();
            this.licenseManager = licenseManager;
            licenseManager.InitLicense("DLS2eyJoYW5kc2hha2VDb2RlIjoiMjAwMDAxLTE2NDk4Mjk3OTI2MzUiLCJvcmdhbml6YXRpb25JRCI6IjIwMDAwMSIsInNlc3Npb25QYXNzd29yZCI6IndTcGR6Vm05WDJrcEQ5YUoifQ==", this);
        }

        async void OnCustomRendererButtonClicked(object sender, EventArgs e)
        {
            if (isButtonEnabled && isLicenseValid)
            {
                isButtonEnabled = false;
                await Navigation.PushAsync(new InfoPage());
                await Task.Delay(buttonDisableDuration);
                isButtonEnabled = true;
            }
                
        }

        public void LicenseVerificationCallback(bool isSuccess, string msg)
        {
            if (!isSuccess)
            {
                Device.BeginInvokeOnMainThread(async () => {
                    isLicenseValid = false;
                    await DisplayAlert("Error", msg, "OK");
                });
            }
        }
    }
}
