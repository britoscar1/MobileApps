using Demo_FinalProject.ViewModels;
using ZXing.Net.Maui;

namespace Demo_FinalProject.Views;

public partial class EscanerPage : ContentPage
{
    private readonly EscanerViewModel _viewModel;

    public EscanerPage(EscanerViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        _viewModel = viewModel;

        BarcodeReader.Options = new BarcodeReaderOptions
        {
            Formats = BarcodeFormat.QrCode,
            AutoRotate = true,
            Multiple = false
        };
    }

    private void OnBarcodesDetected(object? sender, BarcodeDetectionEventArgs e)
    {
        var first = e.Results.FirstOrDefault();
        if (first is null) return;

        MainThread.BeginInvokeOnMainThread(async () =>
        {
            await _viewModel.ProcesarQrCommand.ExecuteAsync(first.Value);
        });
    }
}
