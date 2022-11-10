using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DDNXamarin;

namespace DocumentScanner
{
    public partial class App : Application, ILicenseVerificationListener
    {
        public static ICameraEnhancer dce;
        public static IDocumentNormalizer ddn;
        public static ILicenseManager licenseManager;
        public static double ScreenWidth;
        public static double ScreenHeight;

        public App(ICameraEnhancer enhancer, IDocumentNormalizer normalizer, ILicenseManager manager)
        {
            InitializeComponent();

            dce = enhancer;
            ddn = normalizer;

            licenseManager = manager;

            licenseManager.InitLicense("DLS2eyJoYW5kc2hha2VDb2RlIjoiMjAwMDAxLTE2NDk4Mjk3OTI2MzUiLCJvcmdhbml6YXRpb25JRCI6IjIwMDAwMSIsInNlc3Npb25QYXNzd29yZCI6IndTcGR6Vm05WDJrcEQ5YUoifQ==", this);
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        public void LicenseVerificationCallback(bool isSuccess, string msg)
        {

        }
    }
}
