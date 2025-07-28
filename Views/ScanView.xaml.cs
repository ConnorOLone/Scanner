using System.Runtime.CompilerServices;
using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;

namespace Scanner.Views;

public partial class ScanView : ContentPage
{
    public static ScanView Instance { get; private set; }

    public ScanView()
    {
        InitializeComponent();

        Instance = this;
    }

    protected void BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
    {
        var result = e.Results?.FirstOrDefault();
        if ( result is null )
            return;

        Dispatcher.DispatchAsync(async () =>
        {
            await DisplayAlert("Barcode detected", result.Value, "OK");
        });
    }

    public static void RecreateMainPage()
    {
        if ( Instance is not null )
        {
            ScanView.Instance.Content = null;
            Grid views = new Grid();
            views.VerticalOptions = LayoutOptions.Fill;
            var CameraBarcodeReaderView = new CameraBarcodeReaderView();

            // Fix: Use a local method to handle the event instead of referencing a non-static method directly.
            CameraBarcodeReaderView.BarcodesDetected += (s, e) => Instance.HandleBarcodesDetected(s, e);

            CameraBarcodeReaderView.Options = new BarcodeReaderOptions()
            {
                Formats = BarcodeFormats.OneDimensional,
                AutoRotate = true,
                Multiple = true,
            };
            views.Add(CameraBarcodeReaderView);
            ScanView.Instance.Content = views;
        }
    }

    // Fix: Add a helper method to handle the event and call the instance method.
    private void HandleBarcodesDetected(object sender, BarcodeDetectionEventArgs e)
    {
        BarcodesDetected(sender, e);
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        // Clean up event handlers to prevent memory leaks
        if ( Content is Grid grid )
        {
            foreach ( var child in grid.Children )
            {
                if ( child is CameraBarcodeReaderView cameraView )
                {
                    cameraView.BarcodesDetected -= HandleBarcodesDetected;
                }
            }
        }
    }
}