using Plemiona.Core.Enums;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Plemiona.DestopApp.Services
{
    public class PlemionaFeaturesDiagnosticsService
    {
        private readonly RichTextBox _tbxDiagnostics;
        private readonly Color _featureColor = Color.DarkBlue;
        private readonly Color _stepColor = Color.CornflowerBlue;
        private readonly Color _delayColor = Color.CadetBlue;
        private readonly Color _valuesColor = Color.MediumVioletRed;

        private readonly Color _successColor = Color.LimeGreen;
        private readonly Color _plemionaErrorColor = Color.Goldenrod;
        private readonly Color _botCheckColor = Color.Goldenrod;
        private readonly Color _unexpectedColor = Color.Red;

        private int _delay = -1;

        public PlemionaFeaturesDiagnosticsService(RichTextBox tbxDiagnostics)
        {
            _tbxDiagnostics = tbxDiagnostics;
        }

        public void LogStepDelay(int milliseconds)
        {
            _delay = milliseconds;

            _tbxDiagnostics.Invoke(new Action(() =>
            {
                AppendText("      Delay: ", _delayColor);
                AppendLine($"{milliseconds}[ms]", _valuesColor, 1);
                ScrollDown();
            }));
        }

        public void LogStepStart(string stepName, DateTime dateStart)
        {
            _tbxDiagnostics.Invoke(new Action(() =>
            {
                AppendText($"      Step: {stepName} starting at ", _stepColor);
                AppendLine($"{dateStart:HH:mm:ss}", _valuesColor, 1);
                ScrollDown();
            }));
        }

        public void LogStepEnd(string stepName, DateTime dateEnd, long duration, bool stepSuccess)
        {
            _tbxDiagnostics.Invoke(new Action(() =>
            {
                AppendText($"      Step: {stepName} ending at ", _stepColor);
                AppendText($"{dateEnd:HH:mm:ss}", _valuesColor);
                AppendText(" and lasted for: ", _stepColor);

                long realDuration = duration;

                if (_delay != -1)
                {
                    realDuration -= _delay;
                    _delay = -1;
                }

                AppendText($"{realDuration}[ms]", _valuesColor);

                if (!stepSuccess)
                {
                    AppendText(" [", _valuesColor); 
                    AppendText("Error", _unexpectedColor); 
                    AppendLine("]", _valuesColor, 1); 
                }
                else
                {
                    AppendLine(string.Empty, _stepColor, 1);
                }

                ScrollDown();
            }));
        }

        public void LogFeatureStart(string featureName, DateTime dateStart)
        {
            _tbxDiagnostics.Invoke(new Action(() =>
            {
                string text = $"Feature: {featureName} starting at {dateStart:HH:mm:ss}";
                AppendText($"Feature: {featureName} starting at ", _featureColor);
                AppendLine($"{dateStart:HH:mm:ss}", _valuesColor, 1);
                ScrollDown();
            }));
        }

        public void LogFeatureEnd(string featureName, DateTime dateEnd, long duration, FeatureResults featureResult)
        {
            _tbxDiagnostics.Invoke(new Action(() =>
            {
                string text = $"Feature: {featureName} ending at {dateEnd:HH:mm:ss} and lasted for: {duration}[ms]";
                AppendText($"Feature: {featureName} ending at ", _featureColor);
                AppendText($"{dateEnd:HH:mm:ss}", _valuesColor);
                AppendText(" and lasted for: ", _featureColor);
                AppendText($"{duration}[ms] ", _valuesColor);
                AppendText($"[", _valuesColor);
                var featureResultColor = featureResult == FeatureResults.Success ? _successColor :
                (featureResult == FeatureResults.BotCheck ? _botCheckColor :
                (featureResult == FeatureResults.PlemionaError ? _plemionaErrorColor : _unexpectedColor));
                AppendText($"{featureResult}", featureResultColor);
                AppendLine($"]", _valuesColor, 2);
                ScrollDown();
            }));
        }

        private void AppendLine(string text, Color color, int newLineCharacterCount)
        {
            string newLineCharacters = string.Empty;

            for (int i = 0; i < newLineCharacterCount; i++)
            {
                newLineCharacters += Environment.NewLine;
            }

            AppendText(text + newLineCharacters, color);
        }

        private void AppendText(string text, Color color)
        {
            _tbxDiagnostics.SelectionStart = _tbxDiagnostics.TextLength;
            _tbxDiagnostics.SelectionLength = 0;

            _tbxDiagnostics.SelectionColor = color;
            _tbxDiagnostics.AppendText(text);
            _tbxDiagnostics.SelectionColor = _tbxDiagnostics.ForeColor;
        }

        private void ScrollDown()
        {
            _tbxDiagnostics.SelectionStart = _tbxDiagnostics.Text.Length;
            _tbxDiagnostics.ScrollToCaret();
        }
    }
}