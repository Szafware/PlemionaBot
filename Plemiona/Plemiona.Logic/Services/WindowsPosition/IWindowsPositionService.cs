using OpenQA.Selenium;
using System.Windows.Forms;

namespace Plemiona.Logic.Services.WindowsPosition
{
    public interface IWindowsPositionService
    {
        void SetMainFormWindow(Form mainForm);

        void SetBrowserWindow(IWindow browserWindow);
    }
}