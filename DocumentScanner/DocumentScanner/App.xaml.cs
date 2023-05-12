using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DDNXamarin;

namespace DocumentScanner
{
    public partial class App : Application
    {
        public static ICameraEnhancer dce;
        public static IDocumentNormalizer ddn;
        
        public static double ScreenWidth;
        public static double ScreenHeight;

        public App(ICameraEnhancer enhancer, IDocumentNormalizer normalizer, ILicenseManager manager)
        {
            InitializeComponent();

            dce = enhancer;
            ddn = normalizer;

            MainPage = new NavigationPage(new MainPage(manager));
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

        
    }
}
