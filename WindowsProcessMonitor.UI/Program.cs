
using Serilog;
using System;
using WindowsProcessMonitor.UI.DependencyInjector;
using WindowsProcessMonitor.UI.SerilogConfiguration;
using Unity;

namespace WindowsProcessMonitor.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SeriLogger.InitializeSeriLog();

                var container = UnityContainerConfig.Container;
                Application_Start app = container.Resolve<Application_Start>();

                Log.Information("Application started");
                Console.WriteLine("Application started\n");

                Console.WriteLine("Press key 'q' to quit the program\n");

                if (args.Length == 3)
                {
                    app.Run(args[0], args[1], args[2]);
                }
                else
                {
                    Console.WriteLine("Applicaition Accepts only command line parameters\nPlease call this apllication in the following formats below:\nApplicationName ProcessName Lifetime(in minute) Frequency(in minute)");
                }
                
                while (true)
                {      
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true); 
                    if (keyInfo.Key == ConsoleKey.Q)
                    { 
                        break;
                    }
                }

                Environment.Exit(0);
            }
            catch(Exception ex)
            {
                Log.Error($"Error while application start. Error : {ex}");
            }
        }
    }
}
