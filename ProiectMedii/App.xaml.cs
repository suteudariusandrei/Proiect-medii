using System;
using ProiectMedii.Data;
using System.IO;

namespace ProiectMedii
{
    public partial class App : Application
    {
        static MechanicListDatabase database;
        public static MechanicListDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new
                   MechanicListDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                   LocalApplicationData), "MechanicList.db3"));
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
}