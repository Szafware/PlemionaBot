using OpenQA.Selenium;
using Plemiona.Core.Interfaces.Steps;
using Plemiona.Core.Models.Gui;
using Plemiona.Core.Steps.Services.Delay.Step;
using Plemiona.Core.Steps.Steps.Base;
using Plemiona.Core.Steps.WebDriverBase;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.GuiSteps
{
    public class GetVillageRowsStep : StandardStepBase, IStep
    {
        public GetVillageRowsStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService)
            : base(webDriverBaseMethodsService, stepDelayService)
        {
        }

        public object Execute(object parameter)
        {
            List<ProfileVillageRow> profileVillageRows = new List<ProfileVillageRow>();

            var villagesTable = _webDriverBaseMethodsService.GetBy(By.XPath("//table[@id='villages_list']/tbody"));

            var villageTableRows = villagesTable.FindElements(By.XPath("tr"));

            foreach (var villageTableRow in villageTableRows)
            {
                var profileVillageRow = new ProfileVillageRow();

                var tableRowCells = villageTableRow.FindElements(By.XPath("td"));
                var villageNameCell = tableRowCells[0];
                var villageLocationCell = tableRowCells[1];
                var villagePointsCell = tableRowCells[2];

                string villageName = villageNameCell.FindElement(By.XPath("table/tbody/tr/td/span/a")).Text;

                int villageLocationX = Convert.ToInt32(villageLocationCell.Text.Substring(0, 3));
                int villageLocationY = Convert.ToInt32(villageLocationCell.Text.Substring(4, 3));
                var villageLocation = new Point(villageLocationX, villageLocationY);

                int villagePoints = Convert.ToInt32(villagePointsCell.Text);

                profileVillageRow.Name = villageName;
                profileVillageRow.Location = villageLocation;
                profileVillageRow.Points = villagePoints;

                profileVillageRows.Add(profileVillageRow);
            }

            return profileVillageRows;
        }
    }
}