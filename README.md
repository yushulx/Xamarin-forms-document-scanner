# Mobile Check Capture
The sample demonstrates how to use Xamarin.Forms and [Dynamsoft Document Normalizer SDK](https://www.dynamsoft.com/document-normalizer/docs/introduction/?ver=latest) to build a mobile check capture app for Android and iOS. 

https://github.com/yushulx/Xamarin-forms-document-scanner/assets/2202306/7330eaea-7207-484b-a955-df110a4a88e6

## Download Dynamsoft.DocumentNormalizer.Xamarin.Forms
[https://www.nuget.org/packages/Dynamsoft.DocumentNormalizer.Xamarin.Forms](https://www.nuget.org/packages/Dynamsoft.DocumentNormalizer.Xamarin.Forms) 

## Usage
1. Apply for a [30-day free trial license](https://www.dynamsoft.com/customer/license/trialLicense?product=ddn) and then update the following line in `MainPage.xaml.cs`:

    ```csharp
    licenseManager.InitLicense("DLS2eyJoYW5kc2hha2VDb2RlIjoiMjAwMDAxLTE2NDk4Mjk3OTI2MzUiLCJvcmdhbml6YXRpb25JRCI6IjIwMDAwMSIsInNlc3Npb25QYXNzd29yZCI6IndTcGR6Vm05WDJrcEQ5YUoifQ==", this);
    ```
2. Open the project in Visual Studio 2022.
3. Build and run the app on Android or iOS devices.

    ![Xamarin.Forms document edge detection for iOS](https://www.dynamsoft.com/codepool/img/2023/05/check-submit.jpg)