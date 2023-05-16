# Mobile Check Capture
The sample demonstrates how to use Xamarin.Forms and [Dynamsoft Document Normalizer SDK](https://www.dynamsoft.com/document-normalizer/docs/introduction/?ver=latest) to build a mobile check capture app for Android and iOS. 

https://private-user-images.githubusercontent.com/2202306/237867823-2f51c1e9-6381-4c44-8c68-c7209062f65a.mp4?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJrZXkiOiJrZXkxIiwiZXhwIjoxNjg0MjAxNjczLCJuYmYiOjE2ODQyMDEzNzMsInBhdGgiOiIvMjIwMjMwNi8yMzc4Njc4MjMtMmY1MWMxZTktNjM4MS00YzQ0LThjNjgtYzcyMDkwNjJmNjVhLm1wND9YLUFtei1BbGdvcml0aG09QVdTNC1ITUFDLVNIQTI1NiZYLUFtei1DcmVkZW50aWFsPUFLSUFJV05KWUFYNENTVkVINTNBJTJGMjAyMzA1MTYlMkZ1cy1lYXN0LTElMkZzMyUyRmF3czRfcmVxdWVzdCZYLUFtei1EYXRlPTIwMjMwNTE2VDAxNDI1M1omWC1BbXotRXhwaXJlcz0zMDAmWC1BbXotU2lnbmF0dXJlPTk0MjFmMGRkMjlkOGM3ZmM4ZjBjN2Y0Y2U4MDE2Zjk5YzMyMzQ0ZDcyNTBhNmUzZmI2MDhjNTJkOWU1NDZlMmQmWC1BbXotU2lnbmVkSGVhZGVycz1ob3N0In0.SWF_Psp5OVLGnJ0aDDgRLXbBBHHLPTfUdRSb-YJWduU

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