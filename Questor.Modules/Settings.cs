﻿// ------------------------------------------------------------------------------
//   <copyright from='2010' to='2015' company='THEHACKERWITHIN.COM'>
//     Copyright (c) TheHackerWithin.COM. All Rights Reserved.
// 
//     Please look in the accompanying license.htm file for the license that 
//     applies to this source code. (a copy can also be found at: 
//     http://www.thehackerwithin.com/license.htm)
//   </copyright>
// -------------------------------------------------------------------------------
namespace Questor.Modules
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Xml.Linq;

    public class Settings
    {
        /// <summary>
        ///   Singleton implementation
        /// </summary>
        public static Settings Instance = new Settings();

        public string _characterName;
        private DateTime _lastModifiedDate;
        private Random ramdom = new Random();

        public int ramdom_number()
        {
            return ramdom.Next(10, 35);
        }

        public Settings()
        {
            Ammo = new List<Ammo>();
            ItemsBlackList = new List<int>();
            WreckBlackList = new List<int>();
            AgentsList = new List<AgentsList>();
            FactionFitting = new List<FactionFitting>();
            MissionFitting = new List<MissionFitting>();
            Blacklist = new List<string>();
            FactionBlacklist = new List<string>();
            UseFittingManager = true;
            DefaultFitting = new FactionFitting();
        }

        public bool AtLoginScreen { get; set; }
        
        public bool DebugStates { get; set; }
        public bool DebugPerformance { get; set; }

        public string CharacterMode { get; set; }

        public bool AutoStart { get; set; }

        public bool SaveConsoleLog { get; set; }

        public int maxLineConsole { get; set; }

		public bool waitDecline { get; set; }

        public bool Disable3D { get; set; }

        public int MinimumDelay { get; set; }

        public int RandomDelay { get; set; }
		public float minStandings { get; set; }
        public bool UseGatesInSalvage { get; set; }

        public bool UseLocalWatch { get; set; }
        public int LocalBadStandingPilotsToTolerate { get; set; }
        public double LocalBadStandingLevelToConsiderBad { get; set; }

        public int BattleshipInvasionLimit { get; set; }
        public int BattlecruiserInvasionLimit { get; set; }
        public int CruiserInvasionLimit { get; set; }
        public int FrigateInvasionLimit { get; set; }
        public int InvasionMinimumDelay { get; set; }
        public int InvasionRandomDelay { get; set; }

        public bool EnableStorylines { get; set; }

        public string CombatShipName { get; set; }
        public string SalvageShipName { get; set; }
        public string TransportShipName { get; set; }
        public bool MultiAgentSupport { get; private set; }

        public string LootHangar { get; set; }
        public string AmmoHangar { get; set; }
        public string BookmarkHangar { get; set; }
		public string LootContainer { get; set; }

        public bool CreateSalvageBookmarks { get; set; }
        public bool SalvageMultpleMissionsinOnePass { get; set; }
        public string BookmarkPrefix { get; set; }
        public string UndockPrefix { get; set; }
        public int UndockDelay { get; set; }
        public int MinimumWreckCount { get; set; }
        public bool AfterMissionSalvaging { get; set; }
        public bool UnloadLootAtStation { get; set; }

        //public string AgentName { get; set; }

        public string bookmarkWarpOut { get; set; }

        public string MissionsPath { get; set; }
        public bool LowSecMissions { get; set; }

        public int walletbalancechangelogoffdelay { get; set; }
        public string walletbalancechangelogoffdelayLogofforExit { get; set; }

        public Int64 EVEProcessMemoryCeiling { get; set; }
        public string EVEProcessMemoryCeilingLogofforExit { get; set; }

        public bool CloseQuestorCMDUplinkInnerspaceProfile { get; set; }
        public bool CloseQuestorCMDUplinkIsboxerCharacterSet { get; set; }
        public bool DontShootFrigatesWithSiegeorAutoCannons { get; set; }

        //public int missionbookmarktoagentloops { get; set; }  //not yet used - although it is likely a good ide to fix it so it is used - it would eliminate going back and fourth to the same mission over and over
        public string missionName { get; set; }

        public int MaximumHighValueTargets { get; set; }
        public int MaximumLowValueTargets { get; set; }

        public List<Ammo> Ammo { get; private set; }
        public List<int> ItemsBlackList { get; set; }
        public List<int> WreckBlackList { get; set; }
        public bool WreckBlackListSmallWrecks { get; set; }
        public bool WreckBlackListMediumWrecks { get; set; }

        public string logpath { get; set; }

        public bool   SessionsLog { get; set; }
        public string SessionsLogPath { get; set; }
        public string SessionsLogFile { get; set; }
        public bool   ConsoleLog { get; set; }
        public string ConsoleLogPath { get; set; }
        public string ConsoleLogFile { get; set; }
        public bool   DroneStatsLog { get; set; }
        public string DroneStatsLogPath { get; set; }
        public string DroneStatslogFile { get; set; }
        public bool   WreckLootStatistics { get; set; }
        public string WreckLootStatisticsPath { get; set; }
        public string WreckLootStatisticsFile { get; set; }
        public bool   MissionStats1Log { get; set; }
        public string MissionStats1LogPath { get; set; }
        public string MissionStats1LogFile { get; set; }
        public bool   MissionStats2Log { get; set; }
        public string MissionStats2LogPath { get; set; }
        public string MissionStats2LogFile { get; set; }
        public bool   MissionStats3Log { get; set; }
        public string MissionStats3LogPath { get; set; }
        public string MissionStats3LogFile { get; set; }
        public bool   PocketStatistics { get; set; }
        public string PocketStatisticsPath { get; set; }
        public string PocketStatisticsFile { get; set; }
        public bool PocketStatsUseIndividualFilesPerPocket = true;

        public List<FactionFitting> FactionFitting { get; private set; }
        public List<AgentsList> AgentsList { get; set; }
        public List<MissionFitting> MissionFitting { get; private set; }
        public bool UseFittingManager { get; set; }
        public FactionFitting DefaultFitting { get; set; }

        public int MinimumAmmoCharges { get; set; }

        public int WeaponGroupId { get; set; }

        public int ReserveCargoCapacity { get; set; }

        public int MaximumWreckTargets { get; set; }

        public bool SpeedTank { get; set; }
        public int OrbitDistance { get; set; }
        public int OptimalRange { get; set; }
        public int NosDistance { get; set; }
        public int MinimumPropulsionModuleDistance { get; set; }
        public int MinimumPropulsionModuleCapacitor { get; set; }

        public int ActivateRepairModules { get; set; }
        public int DeactivateRepairModules { get; set; }

        public int MinimumShieldPct { get; set; }
        public int MinimumArmorPct { get; set; }
        public int MinimumCapacitorPct { get; set; }
        public int SafeShieldPct { get; set; }
        public int SafeArmorPct { get; set; }
        public int SafeCapacitorPct { get; set; }
        
        public bool LootEverything { get; set; }
        public double IskPerLP { get; set; }

        private bool _UseDrones;

        public bool UseDrones
        {
            get
            {
                if (Cache.Instance.MissionUseDrones != null)
                    return (bool)Cache.Instance.MissionUseDrones;
                else return _UseDrones;
            }
            set
            {
                _UseDrones = value;
            }
        }
        public int DroneTypeId { get; set; }
        public int DroneControlRange { get; set; }
        public int DroneMinimumShieldPct { get; set; }
        public int DroneMinimumArmorPct { get; set; }
        public int DroneMinimumCapacitorPct { get; set; }
        public int DroneRecallShieldPct { get; set; }
        public int DroneRecallArmorPct { get; set; }
        public int DroneRecallCapacitorPct { get; set; }
        public int LongRangeDroneRecallShieldPct { get; set; }
        public int LongRangeDroneRecallArmorPct { get; set; }
        public int LongRangeDroneRecallCapacitorPct { get; set; }

        public int MaterialsForWarOreID { get; set; }
        public int MaterialsForWarOreQty { get; set; }

        public List<string> Blacklist { get; private set; }
        public List<string> FactionBlacklist { get; private set; }

        public int? WindowXPosition { get; set; }
        public int? WindowYPosition { get; set; }

        public string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public string characterName { get; private set; }
        public string settingsPath { get; private set; }
        public event EventHandler<EventArgs> SettingsLoaded;

        public void LoadSettings()
        {
            var repairstopwatch = new Stopwatch();
            Settings.Instance.characterName = Cache.Instance.DirectEve.Me.Name;
            Settings.Instance.settingsPath = Path.Combine(Settings.Instance.path, Cache.Instance.FilterPath(Settings.Instance.characterName) + ".xml");
            var reloadSettings = Settings.Instance.characterName != Cache.Instance.DirectEve.Me.Name;
            if (File.Exists(Settings.Instance.settingsPath))
                reloadSettings = _lastModifiedDate != File.GetLastWriteTime(Settings.Instance.settingsPath);

            if (!reloadSettings)
                return;

            _lastModifiedDate = File.GetLastWriteTime(settingsPath);

            if (!File.Exists(Settings.Instance.settingsPath)) //if the settings file does not exist initialize these values. Should we not halt when missing the settings XML?
            {
                // Clear settings
                //AgentName = string.Empty;

                CharacterMode = "dps";

                AutoStart = false;

                SaveConsoleLog = true;

                maxLineConsole = 1000;

                waitDecline = false;

                Disable3D = false;

                RandomDelay = 0;

                minStandings = 10;

                MinimumDelay = 0;

                minStandings = 10;

                WindowXPosition = null;
                WindowYPosition = null;

                LootHangar = string.Empty;
                AmmoHangar = string.Empty;
                BookmarkHangar = string.Empty;
                LootContainer = string.Empty;

                MissionsPath = Path.Combine(path, "Missions");

                bookmarkWarpOut = string.Empty;

                MaximumHighValueTargets = 0;
                MaximumLowValueTargets = 0;

                Ammo.Clear();
                ItemsBlackList.Clear();
                WreckBlackList.Clear();
                FactionFitting.Clear();
                AgentsList.Clear();
                MissionFitting.Clear();

                MinimumAmmoCharges = 0;

                WeaponGroupId = 0;

                ReserveCargoCapacity = 0;

                MaximumWreckTargets = 0;

                SpeedTank = false;
                OrbitDistance = 0;
                OptimalRange = 0;
                NosDistance = 38000;
                MinimumPropulsionModuleDistance = 3000;
                MinimumPropulsionModuleCapacitor = 35;

                ActivateRepairModules = 0;
                DeactivateRepairModules = 0;

                MinimumShieldPct = 0;
                MinimumArmorPct = 0;
                MinimumCapacitorPct = 0;
                SafeShieldPct = 0;
                SafeArmorPct = 0;
                SafeCapacitorPct = 0;

                UseDrones = false;
                DroneTypeId = 0;
                DroneControlRange = 0;
                DroneMinimumShieldPct = 0;
                DroneMinimumArmorPct = 0;
                DroneMinimumCapacitorPct = 0;
                DroneRecallCapacitorPct = 0;
                LongRangeDroneRecallCapacitorPct = 0;

                UseGatesInSalvage = false;

                Blacklist.Clear();
                FactionBlacklist.Clear();

                missionName = null;
                //missionbookmarktoagentloops = 0;
                return;
            }

            var xml = XDocument.Load(Settings.Instance.settingsPath).Root;
            //
            // these are listed by feature and should likely be re-ordered to reflect that
            //
            DebugStates = (bool?) xml.Element("debugStates") ?? false;                                           //enables more console logging having to do with the sub-states within each state
            DebugPerformance = (bool?) xml.Element("debugPerformance") ?? false;                                 //enabled more console logging having to do with the time it takes to execute each state

            CharacterMode = (string) xml.Element("characterMode") ?? "dps";                                      //other option is "salvage"

            AutoStart = (bool?) xml.Element("autoStart") ?? false;                                               // auto Start enabled or disabled by default?

            SaveConsoleLog = (bool?)xml.Element("saveLog") ?? true;                                              // save the console log to file
            maxLineConsole = (int?)xml.Element("maxLineConsole") ?? 1000;                                        // maximum console log lines to show in the GUI
                        
            Disable3D = (bool?)xml.Element("disable3D") ?? false;                                                // Disable3d graphics while in space

            RandomDelay = (int?) xml.Element("randomDelay") ?? 0;
            MinimumDelay = (int?)xml.Element("minimumDelay") ?? 0;

            minStandings = (float?) xml.Element("minStandings") ?? 10;
            waitDecline = (bool?)xml.Element("waitDecline") ?? false;

            UseGatesInSalvage = (bool?)xml.Element("useGatesInSalvage") ?? false;                               // if our mission does not despawn (likely someone in the mission looting our stuff?) use the gates when salvaging to get to our bookmarks

            UseLocalWatch = (bool?)xml.Element("UseLocalWatch") ?? true;
            LocalBadStandingPilotsToTolerate = (int?)xml.Element("LocalBadStandingPilotsToTolerate") ?? 1;
            LocalBadStandingLevelToConsiderBad = (double?)xml.Element("LocalBadStandingLevelToConsiderBad") ?? -0.1;

            BattleshipInvasionLimit = (int?)xml.Element("battleshipInvasionLimit") ?? 0;                        // if this number of battleships lands on grid while in a mission we will enter panic
            BattlecruiserInvasionLimit = (int?)xml.Element("battlecruiserInvasionLimit") ?? 0;                  // if this number of battlecruisers lands on grid while in a mission we will enter panic
            CruiserInvasionLimit = (int?)xml.Element("cruiserInvasionLimit") ?? 0;                              // if this number of cruisers lands on grid while in a mission we will enter panic
            FrigateInvasionLimit = (int?)xml.Element("frigateInvasionLimit") ?? 0;                              // if this number of frigates lands on grid while in a mission we will enter panic
            InvasionRandomDelay = (int?)xml.Element("invasionRandomDelay") ?? 0;                                // random relay to stay docked
            InvasionMinimumDelay = (int?)xml.Element("invasionMinimumDelay") ?? 0;                              // minimum delay to stay docked

            EnableStorylines = (bool?) xml.Element("enableStorylines") ?? false; 
            IskPerLP = (double?)xml.Element("IskPerLP") ?? 600;                                                 //used in value calculations

            UndockDelay = (int?)xml.Element("undockdelay") ?? 10;                                               //Delay when undocking - not in use
            UndockPrefix = (string) xml.Element("undockprefix") ?? "Insta";                                     //Undock bookmark prefix - used by traveler - not in use
            WindowXPosition = (int?) xml.Element("windowXPosition") ?? 1600;                                    //windows position (needs to be changed, default is off screen)
            WindowYPosition = (int?)xml.Element("windowYPosition") ?? 1050;                                     //windows position (needs to be changed, default is off screen)

            CombatShipName = (string) xml.Element("combatShipName") ?? "";
            SalvageShipName = (string) xml.Element("salvageShipName") ?? "";
            TransportShipName = (string)xml.Element("transportShipName") ?? "";

            LootHangar = (string) xml.Element("lootHangar");
            AmmoHangar = (string) xml.Element("ammoHangar");
            BookmarkHangar = (string)xml.Element("bookmarkHangar");
            LootContainer = (string)xml.Element("lootContainer");

            CreateSalvageBookmarks = (bool?) xml.Element("createSalvageBookmarks") ?? false;
            BookmarkPrefix = (string) xml.Element("bookmarkPrefix") ?? "Salvage:";
            MinimumWreckCount = (int?) xml.Element("minimumWreckCount") ?? 1;
            AfterMissionSalvaging = (bool?) xml.Element("afterMissionSalvaging") ?? false;
            SalvageMultpleMissionsinOnePass = (bool?)xml.Element("salvageMultpleMissionsinOnePass") ?? false;
            UnloadLootAtStation = (bool?) xml.Element("unloadLootAtStation") ?? false;

            //AgentName = (string) xml.Element("agentName");

            bookmarkWarpOut = (string)xml.Element("bookmarkWarpOut") ?? "";

            EVEProcessMemoryCeiling = (int?)xml.Element("EVEProcessMemoryCeiling") ?? 900;
            EVEProcessMemoryCeilingLogofforExit = (string)xml.Element("EVEProcessMemoryCeilingLogofforExit") ?? "exit";

            DontShootFrigatesWithSiegeorAutoCannons = (bool?)xml.Element("DontShootFrigatesWithSiegeorAutoCannons") ?? false;
            //Assume InnerspaceProfile
            CloseQuestorCMDUplinkInnerspaceProfile = (bool?)xml.Element("CloseQuestorCMDUplinkInnerspaceProfile") ?? true;
            CloseQuestorCMDUplinkIsboxerCharacterSet = (bool?)xml.Element("CloseQuestorCMDUplinkIsboxerCharacterSet") ?? false;


            walletbalancechangelogoffdelay = (int?)xml.Element("walletbalancechangelogoffdelay") ?? 30;
            walletbalancechangelogoffdelayLogofforExit = (string)xml.Element("walletbalancechangelogoffdelayLogofforExit") ?? "exit";

            SessionsLog = (bool?)xml.Element("SessionsLog") ?? true;
            DroneStatsLog = (bool?)xml.Element("DroneStatsLog") ?? true;
            WreckLootStatistics = (bool?)xml.Element("WreckLootStatistics") ?? true;
            MissionStats1Log = (bool?)xml.Element("MissionStats1Log") ?? true;
            MissionStats2Log = (bool?)xml.Element("MissionStats2Log") ?? true;
            MissionStats3Log = (bool?)xml.Element("MissionStats3Log") ?? true;
            PocketStatistics = (bool?)xml.Element("PocketStatistics") ?? true;
            PocketStatsUseIndividualFilesPerPocket = (bool?)xml.Element("PocketStatsUseIndividualFilesPerPocket") ?? true;

            var missionsPath = (string) xml.Element("missionsPath");
            MissionsPath = !string.IsNullOrEmpty(missionsPath) ? Path.Combine(path, missionsPath) : Path.Combine(path, "Missions");
            LowSecMissions = (bool?)xml.Element("LowSecMissions") ?? false;

            MaximumHighValueTargets = (int?) xml.Element("maximumHighValueTargets") ?? 2;
            MaximumLowValueTargets = (int?) xml.Element("maximumLowValueTargets") ?? 2;

            Ammo.Clear();
            var ammoTypes = xml.Element("ammoTypes");
            if (ammoTypes != null)
                foreach (var ammo in ammoTypes.Elements("ammoType"))
                    Ammo.Add(new Ammo(ammo));

            MinimumAmmoCharges = (int?) xml.Element("minimumAmmoCharges") ?? 0;

            UseFittingManager = (bool?)xml.Element("UseFittingManager") ?? true;
            //agent list
            AgentsList.Clear();
            var agentList = xml.Element("agentsList");
            if(agentList != null)
            {
                if (agentList.HasElements)
                {
                   
                    int i = 0;
                    foreach (var agent in agentList.Elements("agentList"))
                    {
                        AgentsList.Add(new AgentsList(agent));
                        i++;
                    }
                    if (i >= 2)
                    {
                        MultiAgentSupport = true;
                        Logging.Log("Settings: Found more than one agent in your character XML: MultiAgentSupport is true");
                    }
                    else
                    {
                        MultiAgentSupport = false;
                        Logging.Log("Settings: Found only one agent in your character XML: MultiAgentSupport is false");
                    }
                }
                else
                {
                    Logging.Log("Settings: agentList exists in your characters config but no agents were listed.");
                }
            }
            else
                Logging.Log("Settings: Error! No Agents List specified.");

            FactionFitting.Clear();
            var factionFittings = xml.Element("factionfittings");
            if (UseFittingManager)
            {
                if (factionFittings != null)
                {
                    foreach (var factionfitting in factionFittings.Elements("factionfitting"))
                        FactionFitting.Add(new FactionFitting(factionfitting));
                    if (FactionFitting.Exists(m => m.Faction.ToLower() == "default"))
                    {
                        DefaultFitting = FactionFitting.Find(m => m.Faction.ToLower() == "default");
                        if ((DefaultFitting.Fitting == "") || (DefaultFitting.Fitting == null))
                        {
                            UseFittingManager = false;
                            Logging.Log("Settings: Error! No default fitting specified or fitting is incorrect.  Fitting manager will not be used.");
                        }
                        Logging.Log("Settings: Faction Fittings defined. Fitting manager will be used when appropriate.");
                    }
                    else
                    {
                        UseFittingManager = false;
                        Logging.Log("Settings: Error! No default fitting specified or fitting is incorrect.  Fitting manager will not be used.");
                    }
                }
                else
                {
                    UseFittingManager = false;
                    Logging.Log("Settings: No faction fittings specified.  Fitting manager will not be used.");
                }
            }

            MissionFitting.Clear();
            var missionFittings = xml.Element("missionfittings");
            if (UseFittingManager)
            {
                if (missionFittings != null)
                    foreach (var missionfitting in missionFittings.Elements("missionfitting"))
                        MissionFitting.Add(new MissionFitting(missionfitting));
            }
            WeaponGroupId = (int?) xml.Element("weaponGroupId") ?? 0;

            ReserveCargoCapacity = (int?) xml.Element("reserveCargoCapacity") ?? 0;

            MaximumWreckTargets = (int?) xml.Element("maximumWreckTargets") ?? 0;

            SpeedTank = (bool?) xml.Element("speedTank") ?? false;
            OrbitDistance = (int?) xml.Element("orbitDistance") ?? 0;
            OptimalRange = (int?)xml.Element("optimalRange") ?? 0;
            NosDistance = (int?)xml.Element("NosDistance") ?? 38000;
            MinimumPropulsionModuleDistance = (int?) xml.Element("minimumPropulsionModuleDistance") ?? 5000;
            MinimumPropulsionModuleCapacitor = (int?)xml.Element("minimumPropulsionModuleCapacitor") ?? 0;

            ActivateRepairModules = (int?) xml.Element("activateRepairModules") ?? 65;
            DeactivateRepairModules = (int?) xml.Element("deactivateRepairModules") ?? 95;

            MinimumShieldPct = (int?) xml.Element("minimumShieldPct") ?? 100;
            MinimumArmorPct = (int?) xml.Element("minimumArmorPct") ?? 100;
            MinimumCapacitorPct = (int?) xml.Element("minimumCapacitorPct") ?? 50;
            SafeShieldPct = (int?)xml.Element("safeShieldPct") ?? 0;
            SafeArmorPct = (int?)xml.Element("safeArmorPct") ?? 0;
            SafeCapacitorPct = (int?)xml.Element("safeCapacitorPct") ?? 0;

            LootEverything = (bool?) xml.Element("lootEverything") ?? true;

            UseDrones = (bool?) xml.Element("useDrones") ?? true;
            DroneTypeId = (int?) xml.Element("droneTypeId") ?? 0;
            DroneControlRange = (int?) xml.Element("droneControlRange") ?? 0;
            DroneMinimumShieldPct = (int?) xml.Element("droneMinimumShieldPct") ?? 50;
            DroneMinimumArmorPct = (int?) xml.Element("droneMinimumArmorPct") ?? 50;
            DroneMinimumCapacitorPct = (int?) xml.Element("droneMinimumCapacitorPct") ?? 0;
            DroneRecallShieldPct = (int?) xml.Element("droneRecallShieldPct") ?? 0;
            DroneRecallArmorPct = (int?) xml.Element("droneRecallArmorPct") ?? 0;
            DroneRecallCapacitorPct = (int?) xml.Element("droneRecallCapacitorPct") ?? 0;
            LongRangeDroneRecallShieldPct = (int?) xml.Element("longRangeDroneRecallShieldPct") ?? 0;
            LongRangeDroneRecallArmorPct = (int?) xml.Element("longRangeDroneRecallArmorPct") ?? 0;
            LongRangeDroneRecallCapacitorPct = (int?) xml.Element("longRangeDroneRecallCapacitorPct") ?? 0;

            MaterialsForWarOreID = (int?)xml.Element("MaterialsForWarOreID") ?? 20;
            MaterialsForWarOreQty = (int?)xml.Element("MaterialsForWarOreQty") ?? 8000;

            Blacklist.Clear();
            var blacklist = xml.Element("blacklist");
            if (blacklist != null)
                foreach (var mission in blacklist.Elements("mission"))
                    Blacklist.Add((string) mission);

            FactionBlacklist.Clear();
            var factionblacklist = xml.Element("factionblacklist");
            if (factionblacklist != null)
                foreach (var faction in factionblacklist.Elements("faction"))
                    FactionBlacklist.Add((string) faction);
            WreckBlackListSmallWrecks = (bool?) xml.Element("WreckBlackListSmallWrecks") ?? false;
            WreckBlackListMediumWrecks = (bool?) xml.Element("WreckBlackListMediumWrecks") ?? false;


            //
            // if enabled the following would keep you from looting (or salvaging?) small wrecks
            //
            //list of small wreck
            if (WreckBlackListSmallWrecks)
            {
                WreckBlackList.Add(26557);
                WreckBlackList.Add(26561);
                WreckBlackList.Add(26564);
                WreckBlackList.Add(26567);
                WreckBlackList.Add(26570);
                WreckBlackList.Add(26573);
                WreckBlackList.Add(26576);
                WreckBlackList.Add(26579);
                WreckBlackList.Add(26582);
                WreckBlackList.Add(26585);
                WreckBlackList.Add(26588);
                WreckBlackList.Add(26591);
                WreckBlackList.Add(26594);
                WreckBlackList.Add(26935);
            }

            //
            // if enabled the following would keep you from looting (or salvaging?) medium wrecks
            //
            //list of medium wreck
            if (WreckBlackListMediumWrecks)
            {
                WreckBlackList.Add(26558);
                WreckBlackList.Add(26562);
                WreckBlackList.Add(26568);
                WreckBlackList.Add(26574);
                WreckBlackList.Add(26580);
                WreckBlackList.Add(26586);
                WreckBlackList.Add(26592);
                WreckBlackList.Add(26934);
            }

            logpath = (Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\log\\" + Cache.Instance.DirectEve.Me.Name + "\\");
            //logpath_s = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\log\\";
            ConsoleLogPath = Path.Combine(logpath + "Console\\");
            ConsoleLogFile = Path.Combine(ConsoleLogPath + string.Format("{0:MM-dd-yyyy}", DateTime.Today) + "-" + Cache.Instance.DirectEve.Me.Name + "-" + "console" + ".log");
            SessionsLogPath = Path.Combine(logpath);
            SessionsLogFile = Path.Combine(SessionsLogPath + Cache.Instance.DirectEve.Me.Name + ".Sessions.log");
            DroneStatsLogPath = Path.Combine(logpath);
            DroneStatslogFile = Path.Combine(DroneStatsLogPath + Cache.Instance.DirectEve.Me.Name + ".DroneStats.log");
            WreckLootStatisticsPath = Path.Combine(logpath);
            WreckLootStatisticsFile = Path.Combine(WreckLootStatisticsPath + Cache.Instance.DirectEve.Me.Name + ".WreckLootStatisticsDump.log");
            MissionStats1LogPath = Path.Combine(logpath, "missionstats\\");
            MissionStats1LogFile = Path.Combine(MissionStats1LogPath +  Cache.Instance.DirectEve.Me.Name + ".Statistics.log");
            MissionStats2LogPath = Path.Combine(logpath, "missionstats\\");
            MissionStats2LogFile = Path.Combine(MissionStats2LogPath + Cache.Instance.DirectEve.Me.Name + ".DatedStatistics.log");
            MissionStats3LogPath = Path.Combine(logpath, "missionstats\\");
            MissionStats3LogFile = Path.Combine(MissionStats3LogPath + Cache.Instance.DirectEve.Me.Name + ".CustomDatedStatistics.csv");
            PocketStatisticsPath = Path.Combine(logpath, "pocketstats\\");
            PocketStatisticsFile = Path.Combine(PocketStatisticsPath + Cache.Instance.DirectEve.Me.Name + "pocketstats-combined.csv");
            //create all the logging directories even if they aren't configured to be used - we can adjust this later if it really bugs people to have some potentially empty directories. 
            Directory.CreateDirectory(logpath);

            Directory.CreateDirectory(ConsoleLogPath); 
            Directory.CreateDirectory(SessionsLogPath);
            Directory.CreateDirectory(DroneStatsLogPath);
            Directory.CreateDirectory(WreckLootStatisticsPath);
            Directory.CreateDirectory(MissionStats1LogPath);
            Directory.CreateDirectory(MissionStats2LogPath);
            Directory.CreateDirectory(MissionStats3LogPath);
            Directory.CreateDirectory(PocketStatisticsPath);
            
            if (SettingsLoaded != null)
                SettingsLoaded(this, new EventArgs());
        }
    }
}