using OpenQA.Selenium;
using System.Drawing;
using System.Windows.Forms;

namespace Plemiona.Logic.Services.WindowsPosition
{
    public class WindowsPositionService : IWindowsPositionService
    {
        private readonly Rectangle _screenSize;
        private readonly int _halfOfScreenWidth;

        public WindowsPositionService()
        {
            _screenSize = Screen.PrimaryScreen.WorkingArea;
            _halfOfScreenWidth = _screenSize.Width / 2;
        }

        public void SetMainFormWindow(Form mainForm)
        {
            mainForm.Size = new Size(_halfOfScreenWidth, _screenSize.Height);
            mainForm.Location = new Point(_halfOfScreenWidth, 0);
        }

        public void SetBrowserWindow(IWindow browserWindow)
        {
            browserWindow.Size = new Size(_halfOfScreenWidth, _screenSize.Height);
            browserWindow.Position = new Point(0, 0);
        }
    }
}