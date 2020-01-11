using System;

namespace ProjectOne
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press enter to stop the application...");
            PoBootloader.Instance.LoadAssemblies();
            PoResourceManager.Instance.LoadResources();
            var items = PoUserManager.Instance.GetItems();
            PoLogSource.Default = PoLogSourceConsole.Instance;
            PoAppManager.StartApps();
            PoServerRoot.Instance.Start();

            Console.ReadKey();
            PoServerRoot.Instance.Stop();
            PoAppManager.StopApps();
        }
    }
}
