using Plemiona.Core.Enums;
using Plemiona.Core.Exceptions;
using Plemiona.Core.Interfaces.Features;
using Plemiona.Core.Models;
using Plemiona.Core.Models.Features;
using Plemiona.Core.Services.FeatureLogging;
using Plemiona.Core.Steps.Services.StepExecution;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace Plemiona.Core.Features
{
    public class PlemionaDefaultFeaturesDiagnostics : IPlemionaFeaturesDiagnostics
    {
        private readonly PlemionaDefaultFeatures _plemionaDefaultFeatures;

        public event Action<int> OnStepDelay;
        public event Action<string, DateTime> OnStepStart;
        public event Action<string, DateTime, long, bool> OnStepEnd;
        public event Action<string, DateTime> OnFeatureStart;
        public event Action<string, DateTime, long, FeatureResults> OnFeatureEnd;

        public PlemionaDefaultFeaturesDiagnostics(
            IStepExecutionService stepExecutionService,
            IFeatureLoggingService featureLoggingService
            )
        {
            _plemionaDefaultFeatures = new PlemionaDefaultFeatures(stepExecutionService, featureLoggingService);

            stepExecutionService.OnDelay += stepDelayMilliseconds => OnStepDelay?.Invoke(stepDelayMilliseconds);
            stepExecutionService.OnStepExecutionStart += (stepName, dateStart) => OnStepStart?.Invoke(stepName, dateStart);
            stepExecutionService.OnStepExecutionEnd += (stepName, dateEnd, duration, stepSuccess) => OnStepEnd?.Invoke(stepName, dateEnd, duration, stepSuccess);
        }

        public void SignIn(string username, string password, int worldNumber)
        {
            var stopwatch = Stopwatch.StartNew();
            var featureResults = FeatureResults.Success;

            try
            {
                OnFeatureStart?.Invoke(MethodBase.GetCurrentMethod().Name, DateTime.Now);
                _plemionaDefaultFeatures.SignIn(username, password, worldNumber);
            }
            catch (BotCheckException)
            {
                featureResults = FeatureResults.BotCheck;
                throw;
            }
            catch (FeatureException fe)
            {
                featureResults = fe.PlemionaError ? FeatureResults.PlemionaError : FeatureResults.UnexpectedError;
                throw;
            }
            finally
            {
                OnFeatureEnd?.Invoke(MethodBase.GetCurrentMethod().Name, DateTime.Now, stopwatch.ElapsedMilliseconds, featureResults);
                stopwatch.Stop();
            }
        }

        public void SwitchToVillage(string villageName)
        {
            var stopwatch = Stopwatch.StartNew();
            var featureResults = FeatureResults.Success;

            try
            {
                OnFeatureStart?.Invoke(MethodBase.GetCurrentMethod().Name, DateTime.Now);
                _plemionaDefaultFeatures.SwitchToVillage(villageName);
            }
            catch (BotCheckException)
            {
                featureResults = FeatureResults.BotCheck;
                throw;
            }
            catch (FeatureException fe)
            {
                featureResults = fe.PlemionaError ? FeatureResults.PlemionaError : FeatureResults.UnexpectedError;
                throw;
            }
            finally
            {
                OnFeatureEnd?.Invoke(MethodBase.GetCurrentMethod().Name, DateTime.Now, stopwatch.ElapsedMilliseconds, featureResults);
                stopwatch.Stop();
            }
        }

        public void RecruitTroops(Troops troops)
        {
            var stopwatch = Stopwatch.StartNew();
            var featureResults = FeatureResults.Success;

            try
            {
                OnFeatureStart?.Invoke(MethodBase.GetCurrentMethod().Name, DateTime.Now);
                _plemionaDefaultFeatures.RecruitTroops(troops);
            }
            catch (BotCheckException)
            {
                featureResults = FeatureResults.BotCheck;
                throw;
            }
            catch (FeatureException fe)
            {
                featureResults = fe.PlemionaError ? FeatureResults.PlemionaError : FeatureResults.UnexpectedError;
                throw;
            }
            finally
            {
                OnFeatureEnd?.Invoke(MethodBase.GetCurrentMethod().Name, DateTime.Now, stopwatch.ElapsedMilliseconds, featureResults);
                stopwatch.Stop();
            }
        }

        public void RecruitKnight(string knightName)
        {
            var stopwatch = Stopwatch.StartNew();
            var featureResults = FeatureResults.Success;

            try
            {
                OnFeatureStart?.Invoke(MethodBase.GetCurrentMethod().Name, DateTime.Now);
                _plemionaDefaultFeatures.RecruitKnight(knightName);
            }
            catch (BotCheckException)
            {
                featureResults = FeatureResults.BotCheck;
                throw;
            }
            catch (FeatureException fe)
            {
                featureResults = fe.PlemionaError ? FeatureResults.PlemionaError : FeatureResults.UnexpectedError;
                throw;
            }
            finally
            {
                OnFeatureEnd?.Invoke(MethodBase.GetCurrentMethod().Name, DateTime.Now, stopwatch.ElapsedMilliseconds, featureResults);
                stopwatch.Stop();
            }
        }

        public void ReviveKnight()
        {
            var stopwatch = Stopwatch.StartNew();
            var featureResults = FeatureResults.Success;

            try
            {
                OnFeatureStart?.Invoke(MethodBase.GetCurrentMethod().Name, DateTime.Now);
                _plemionaDefaultFeatures.ReviveKnight();
            }
            catch (BotCheckException)
            {
                featureResults = FeatureResults.BotCheck;
                throw;
            }
            catch (FeatureException fe)
            {
                featureResults = fe.PlemionaError ? FeatureResults.PlemionaError : FeatureResults.UnexpectedError;
                throw;
            }
            finally
            {
                OnFeatureEnd?.Invoke(MethodBase.GetCurrentMethod().Name, DateTime.Now, stopwatch.ElapsedMilliseconds, featureResults);
                stopwatch.Stop();
            }
        }

        public void SendTroops(Troops troops, int coordinateX, int coordinateY, TroopsIntentions troopsIntentions, SendingTroopsInfo sendingTroopsInfo = null)
        {
            var stopwatch = Stopwatch.StartNew();
            var featureResults = FeatureResults.Success;

            try
            {
                OnFeatureStart?.Invoke(MethodBase.GetCurrentMethod().Name, DateTime.Now);
                _plemionaDefaultFeatures.SendTroops(troops, coordinateX, coordinateY, troopsIntentions, sendingTroopsInfo);
            }
            catch (BotCheckException)
            {
                featureResults = FeatureResults.BotCheck;
                throw;
            }
            catch (FeatureException fe)
            {
                featureResults = fe.PlemionaError ? FeatureResults.PlemionaError : FeatureResults.UnexpectedError;
                throw;
            }
            finally
            {
                OnFeatureEnd?.Invoke(MethodBase.GetCurrentMethod().Name, DateTime.Now, stopwatch.ElapsedMilliseconds, featureResults);
                stopwatch.Stop();
            }
        }

        public Resources GetResources()
        {
            var stopwatch = Stopwatch.StartNew();
            var featureResults = FeatureResults.Success;

            try
            {
                OnFeatureStart?.Invoke(MethodBase.GetCurrentMethod().Name, DateTime.Now);
                var resources = _plemionaDefaultFeatures.GetResources();
                return resources;
            }
            catch (BotCheckException)
            {
                featureResults = FeatureResults.BotCheck;
                throw;
            }
            catch (FeatureException fe)
            {
                featureResults = fe.PlemionaError ? FeatureResults.PlemionaError : FeatureResults.UnexpectedError;
                throw;
            }
            finally
            {
                OnFeatureEnd?.Invoke(MethodBase.GetCurrentMethod().Name, DateTime.Now, stopwatch.ElapsedMilliseconds, featureResults);
                stopwatch.Stop();
            }
        }

        public Buildings GetBuildings()
        {
            var stopwatch = Stopwatch.StartNew();
            var featureResults = FeatureResults.Success;

            try
            {
                OnFeatureStart?.Invoke(MethodBase.GetCurrentMethod().Name, DateTime.Now);
                var buildings = _plemionaDefaultFeatures.GetBuildings();
                return buildings;
            }
            catch (BotCheckException)
            {
                featureResults = FeatureResults.BotCheck;
                throw;
            }
            catch (FeatureException fe)
            {
                featureResults = fe.PlemionaError ? FeatureResults.PlemionaError : FeatureResults.UnexpectedError;
                throw;
            }
            finally
            {
                OnFeatureEnd?.Invoke(MethodBase.GetCurrentMethod().Name, DateTime.Now, stopwatch.ElapsedMilliseconds, featureResults);
                stopwatch.Stop();
            }
        }

        public void ChangeVillageName(string villageName)
        {
            var stopwatch = Stopwatch.StartNew();
            var featureResults = FeatureResults.Success;

            try
            {
                OnFeatureStart?.Invoke(MethodBase.GetCurrentMethod().Name, DateTime.Now);
                _plemionaDefaultFeatures.ChangeVillageName(villageName);
            }
            catch (BotCheckException)
            {
                featureResults = FeatureResults.BotCheck;
                throw;
            }
            catch (FeatureException fe)
            {
                featureResults = fe.PlemionaError ? FeatureResults.PlemionaError : FeatureResults.UnexpectedError;
                throw;
            }
            finally
            {
                OnFeatureEnd?.Invoke(MethodBase.GetCurrentMethod().Name, DateTime.Now, stopwatch.ElapsedMilliseconds, featureResults);
                stopwatch.Stop();
            }
        }

        public IEnumerable<Village> GetNerbaryVillages(int radiusFields)
        {
            var stopwatch = Stopwatch.StartNew();
            var featureResults = FeatureResults.Success;

            try
            {
                OnFeatureStart?.Invoke(MethodBase.GetCurrentMethod().Name, DateTime.Now);
                var villages = _plemionaDefaultFeatures.GetNerbaryVillages(radiusFields);
                return villages;
            }
            catch (BotCheckException)
            {
                featureResults = FeatureResults.BotCheck;
                throw;
            }
            catch (FeatureException fe)
            {
                featureResults = fe.PlemionaError ? FeatureResults.PlemionaError : FeatureResults.UnexpectedError;
                throw;
            }
            finally
            {
                OnFeatureEnd?.Invoke(MethodBase.GetCurrentMethod().Name, DateTime.Now, stopwatch.ElapsedMilliseconds, featureResults);
                stopwatch.Stop();
            }
        }

        public Village GetVillage(int coordinateX, int coordinateY)
        {
            var stopwatch = Stopwatch.StartNew();
            var featureResults = FeatureResults.Success;

            try
            {
                OnFeatureStart?.Invoke(MethodBase.GetCurrentMethod().Name, DateTime.Now);
                var village = _plemionaDefaultFeatures.GetVillage(coordinateX, coordinateY);
                return village;
            }
            catch (BotCheckException)
            {
                featureResults = FeatureResults.BotCheck;
                throw;
            }
            catch (FeatureException fe)
            {
                featureResults = fe.PlemionaError ? FeatureResults.PlemionaError : FeatureResults.UnexpectedError;
                throw;
            }
            finally
            {
                OnFeatureEnd?.Invoke(MethodBase.GetCurrentMethod().Name, DateTime.Now, stopwatch.ElapsedMilliseconds, featureResults);
                stopwatch.Stop();
            }
        }

        public void AddBuildingToQueue(BuildingTypes building)
        {
            var stopwatch = Stopwatch.StartNew();
            var featureResults = FeatureResults.Success;

            try
            {
                OnFeatureStart?.Invoke(MethodBase.GetCurrentMethod().Name, DateTime.Now);
                _plemionaDefaultFeatures.AddBuildingToQueue(building);
            }
            catch (BotCheckException)
            {
                featureResults = FeatureResults.BotCheck;
                throw;
            }
            catch (FeatureException fe)
            {
                featureResults = fe.PlemionaError ? FeatureResults.PlemionaError : FeatureResults.UnexpectedError;
                throw;
            }
            finally
            {
                OnFeatureEnd?.Invoke(MethodBase.GetCurrentMethod().Name, DateTime.Now, stopwatch.ElapsedMilliseconds, featureResults);
                stopwatch.Stop();
            }
        }

        public OwnPlayer GetOwnPlayer()
        {
            var stopwatch = Stopwatch.StartNew();
            var featureResults = FeatureResults.Success;

            try
            {
                OnFeatureStart?.Invoke(MethodBase.GetCurrentMethod().Name, DateTime.Now);
                var ownPlayer = _plemionaDefaultFeatures.GetOwnPlayer();
                return ownPlayer;
            }
            catch (BotCheckException)
            {
                featureResults = FeatureResults.BotCheck;
                throw;
            }
            catch (FeatureException fe)
            {
                featureResults = fe.PlemionaError ? FeatureResults.PlemionaError : FeatureResults.UnexpectedError;
                throw;
            }
            finally
            {
                OnFeatureEnd?.Invoke(MethodBase.GetCurrentMethod().Name, DateTime.Now, stopwatch.ElapsedMilliseconds, featureResults);
                stopwatch.Stop();
            }
        }

        public Player GetPlayer(string playerName)
        {
            var stopwatch = Stopwatch.StartNew();
            var featureResults = FeatureResults.Success;

            try
            {
                OnFeatureStart?.Invoke(MethodBase.GetCurrentMethod().Name, DateTime.Now);
                var player = _plemionaDefaultFeatures.GetPlayer(playerName);
                return player;
            }
            catch (BotCheckException)
            {
                featureResults = FeatureResults.BotCheck;
                throw;
            }
            catch (FeatureException fe)
            {
                featureResults = fe.PlemionaError ? FeatureResults.PlemionaError : FeatureResults.UnexpectedError;
                throw;
            }
            finally
            {
                OnFeatureEnd?.Invoke(MethodBase.GetCurrentMethod().Name, DateTime.Now, stopwatch.ElapsedMilliseconds, featureResults);
                stopwatch.Stop();
            }
        }

        public void SignOut()
        {
            var stopwatch = Stopwatch.StartNew();
            var featureResults = FeatureResults.Success;

            try
            {
                OnFeatureStart?.Invoke(MethodBase.GetCurrentMethod().Name, DateTime.Now);
                _plemionaDefaultFeatures.SignOut();
            }
            catch (BotCheckException)
            {
                featureResults = FeatureResults.BotCheck;
                throw;
            }
            catch (FeatureException fe)
            {
                featureResults = fe.PlemionaError ? FeatureResults.PlemionaError : FeatureResults.UnexpectedError;
                throw;
            }
            finally
            {
                OnFeatureEnd?.Invoke(MethodBase.GetCurrentMethod().Name, DateTime.Now, stopwatch.ElapsedMilliseconds, featureResults);
                stopwatch.Stop();
            }
        }
    }
}