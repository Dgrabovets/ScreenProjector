using System.Diagnostics;

namespace TwoScreensOneCup
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            Thread Thread;

            Thread = new Thread(OpenForm);
            Thread.SetApartmentState(ApartmentState.STA);
            Thread.Start();
        }

        static void OpenForm(object obj)
        {
            WideForm wideForm = new WideForm();

            Screen[] screens = Screen.AllScreens;

            wideForm.SetBounds(screens[0].Bounds.X, screens[0].Bounds.Y, screens[0].Bounds.Width, screens[0].Bounds.Height);
            wideForm.StartPosition = FormStartPosition.Manual;

            Application.Run(wideForm);
        }
    }
}