using System;
using FloreaCristinaProiect.Data;
using System.IO;
namespace FloreaCristinaProiect
{
    public partial class App : Application
    {
        static PastriesListDataBase database;
        public static PastriesListDataBase Database
        {
            get
            {
                if(database==null)
                {
                    database = new PastriesListDataBase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PastriesList.db3"));

                }
                return database; 
            }
        }
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}