# Xamarin.Forms Document Scanner
The sample demonstrates how to use Xamarin.Forms and [Dynamsoft Document Normalizer SDK](https://www.dynamsoft.com/document-normalizer/docs/introduction/?ver=latest) to build mobile document scanning apps for Android and iOS. The scanned document, passport, ID card images can be saved as JPEG, PNG or PDF files.

## Download Dynamsoft.DocumentNormalizer.Xamarin.Forms
[https://www.nuget.org/packages/Dynamsoft.DocumentNormalizer.Xamarin.Forms](https://www.nuget.org/packages/Dynamsoft.DocumentNormalizer.Xamarin.Forms) 

## Usage
1. Apply for a [30-day free trial license](https://www.dynamsoft.com/customer/license/trialLicense?product=dbr) and update the line.

    ```csharp
    licenseManager.InitLicense("DLS2eyJoYW5kc2hha2VDb2RlIjoiMjAwMDAxLTE2NDk4Mjk3OTI2MzUiLCJvcmdhbml6YXRpb25JRCI6IjIwMDAwMSIsInNlc3Npb25QYXNzd29yZCI6IndTcGR6Vm05WDJrcEQ5YUoifQ==", this);
    ```
2. Import the project to Visual Studio 2022 and build it.
3. Run the app on Android or iOS devices.


**Android**

![Xamarin.Forms document edge detection for Android](https://www.dynamsoft.com/codepool/img/2022/11/xamarin-android-document-edge-edit.jpg)

**iOS**

![Xamarin.Forms document edge detection for iOS](https://www.dynamsoft.com/codepool/img/2022/11/xamarin-ios-document-edge-edit.jpg)