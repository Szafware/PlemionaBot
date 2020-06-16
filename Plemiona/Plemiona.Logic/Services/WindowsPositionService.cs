using OpenQA.Selenium;
using System.Drawing;
using System.Windows.Forms;

namespace Plemiona.Logic.Services
{
    public class WindowsPositionService : IWindowsPositionService
    {
        public void SetWindowsPosition(Form mainForm, IWindow browserWindow)     
        {
            var screenSize = Screen.PrimaryScreen.WorkingArea;

            int halfOfScreenWidth = screenSize.Width / 2;

            browserWindow.Size = new Size(halfOfScreenWidth, screenSize.Height);
            browserWindow.Position = new Point(0, 0);

            mainForm.Location = new Point(300, 20);
        }
    }
}