using System;
using System.Windows.Forms;

namespace clientGraphic
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            //try to connect to the server
            if (Communicator.Connect("127.0.0.1", 12345))
            {
                //if connection succeeded, run the application
                Application.Run(new MenuForm());
            }
            else
            {
                //if connection to the server failed
                Application.Exit();
            }
        }
    }
}