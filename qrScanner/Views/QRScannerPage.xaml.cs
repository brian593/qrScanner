using qrScanner.ViewModels;
using ZXing.Net.Maui;

namespace qrScanner.Views;

public partial class QRScannerPage : ContentPage
{
    QRScannerViewModel viewModel;

    public QRScannerPage()
	{

		InitializeComponent();
         viewModel = new QRScannerViewModel(App.Database);
        BindingContext = viewModel;

    }
    private void OnBarcodesDetected(object sender, BarcodeDetectionEventArgs e)
    {
        // Solo procesamos el primer código detectado
        var barcode = e.Results.FirstOrDefault();
        if (barcode != null)
        {
            // Llamamos al método del ViewModel para procesar el código escaneado
            viewModel.ScanCodeCommand.Execute(barcode);
        }
    }
}
