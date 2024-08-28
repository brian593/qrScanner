using qrScanner.Services;
namespace qrScanner;

public partial class App : Application
{

    static QRCodeDatabase database;

    public static QRCodeDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new QRCodeDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "QRCodes.db3"));
            }
            return database;
        }
    }


    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
    }
}

