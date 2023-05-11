﻿using DDNXamarin;
using System;
using Xamarin.Forms;

namespace DocumentScanner
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void OnCustomRendererButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InfoPage());
        }
    }
}
