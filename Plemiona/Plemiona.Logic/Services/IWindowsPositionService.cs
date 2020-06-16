using OpenQA.Selenium;
using System.Windows.Forms;

namespace Plemiona.Logic.Services
{
    public interface IWindowsPositionService
    {
        void SetWindowsPosition(Form mainForm, IWindow browserWindow);       
    }
}