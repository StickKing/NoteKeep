using SQLite;

namespace NoteKeep;

public partial class App : Application
{

    public const SQLiteOpenFlags Flags =
        // open the database in read/write mode
        SQLiteOpenFlags.ReadWrite |
        // create the database if it doesn't exist
        SQLiteOpenFlags.Create |
        // enable multi-threaded database access
        SQLiteOpenFlags.SharedCache;

    //public static string PathDB = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "NoteDB.db");
    public static string PathDB = Android.App.Application.Context.GetExternalFilesDir(Android.OS.Environment.DirectoryDocuments).AbsolutePath;
    public static SQLiteConnection SQLworker = new SQLiteConnection(PathDB + "/NoteKeep.db");



    public App()
	{
		InitializeComponent();


        SQLworker.Execute("CREATE TABLE IF NOT EXISTS Note (" +
                "id INTEGER PRIMARY KEY AUTOINCREMENT not null," +
                "title varchar," +
                "text TEXT)");

        MainPage = new Menu();
	}

}

