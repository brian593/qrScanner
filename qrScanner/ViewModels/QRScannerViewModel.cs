using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;



using qrScanner.Models;
using qrScanner.Services;

using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ZXing.Net.Maui;

namespace qrScanner.ViewModels
{
    public partial class QRScannerViewModel : ObservableObject
    {
        private readonly QRCodeDatabase _database;

        public ObservableCollection<QRCode> QRCodeHistory { get; set; } = new ObservableCollection<QRCode>();

        public QRScannerViewModel(QRCodeDatabase database)
        {
            _database = database;
            LoadHistoryCommand.Execute(null);
        }

        [RelayCommand]
        public async Task LoadHistoryAsync()
        {
            var codes = await _database.GetQRCodesAsync();
            QRCodeHistory.Clear();
            foreach (var code in codes)
            {
                QRCodeHistory.Add(code);
            }
        }

        [RelayCommand]
        public async Task ScanCode(BarcodeResult? result)
        {
            var qrCode = new QRCode
            {
                Code = result.Value,
                DateScanned = DateTime.Now
            };

            await _database.SaveQRCodeAsync(qrCode);
            QRCodeHistory.Add(qrCode);
        }

        [RelayCommand]
        public void CopyToClipboard(QRCode code)
        {
            if (code != null)
            {
                Clipboard.SetTextAsync(code.Code);
            }
        }
    }
}

