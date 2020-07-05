using OpenQA.Selenium;
using Plemiona.Core.Models.Gui;
using Plemiona.Core.Services.BotCheckDetect;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Services.WebDriverBase;
using Plemiona.Core.Steps.Steps.Base;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.GuiSteps.VillageInformation
{
    public class GetVillageRowsStep : StandardStepBase
    {
        public GetVillageRowsStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService,
            IBotCheckDetectService botCheckDetectService)
            : base(webDriverBaseMethodsService, stepDelayService, botCheckDetectService)
        {
        }

        public override object Execute(object parameter)
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

                string villagePointsNummber = string.Join(string.Empty, villagePointsCell.Text.Where(c => char.IsNumber(c)));

                int villagePoints = Convert.ToInt32(villagePointsNummber);

                profileVillageRow.Name = villageName;
                profileVillageRow.Location = villageLocation;
                profileVillageRow.Points = villagePoints;

                profileVillageRows.Add(profileVillageRow);
            }

            return profileVillageRows;
        }
    }
}