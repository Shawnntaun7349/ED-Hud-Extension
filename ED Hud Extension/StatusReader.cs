using System.Text.Json;
using static Globals;
using static Globals.StatusTags;

public class StatusReader
{
    /*	Summary
     *  2 Enums, Flag1 & Flag2, to use as a reference table for the bit values of the two Flag values in the Status.json file. A looping background
     *  Task to 1). read the Status file and [among other functions] retrieve the current values of the two Flags, 2). compare those values to the values of the 
     *	previous values, 3). if there is a change in either value, reference the aforementioned tables to determine what values changed (i.e. SilentRunning turned on when
     *	it wasn't previously, FsdMassLocked becoming true as a player approaches a station, etc.) and 4). Fire any relevent Events to notify the main process of the changes
     *	to respond accordingly.
     */



    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Destination
    {
        public long System { get; set; }
        public int Body { get; set; }
        public string Name { get; set; }
    }

    public class Fuel
    {
        public double FuelMain { get; set; }
        public double FuelReservoir { get; set; }
    }

    public class Root
    {
        public DateTime timestamp { get; set; }
        public ShipFlag Flags { get; set; }
        public OnFootFlag Flags2 { get; set; }
        public List<int> Pips { get; set; }
        public int FireGroup { get; set; }
        public int GuiFocus { get; set; }
        public Fuel Fuel { get; set; }
        public double Cargo { get; set; }
        public string LegalState { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Heading { get; set; }
        public int Altitude { get; set; }
        public string BodyName { get; set; }
        public double PlanetRadius { get; set; }
        public int Balance { get; set; }
        public Destination Destination { get; set; }
    }


    [Flags]
	public enum ShipFlag : uint
	{
		None = 0,
		Docked = 1,
		Landed = 2,
		GearDown = 4,
		ShieldsUp = 8,
		Supercruise = 16,
		FAOff = 32,
		HardpointsDeployed = 64,
		InWing = 128,
		LightsOn = 256,
		CargoScoopDeployed = 512,
		SilentRunning = 1024,
		ScoopingFuel = 2048,
		SrvHandBrake = 4096,
		SrvTurretView = 8192,
		SrvTurretRetracted = 16384,
		SrvDriveAssist = 32768,
		FsdMassLocked = 65536,
		FsdCharging = 131072,
		FsdCooldown = 262144,
		LowFuel = 524288,
		OverHeating = 1048576,
		HasLatLong = 2097152,
		IsInDanger = 4194304,
		BeingInterdicted = 8388608,
		InMainShip = 16777216,
		InFighter = 33554432,
		InSrv = 67108864,
		HudInAnalysisMode = 134217728,
		NightVision = 268435456,
		AltitudeFromAverageRadius = 536870912,
		FsdJump = 1073741824,
		SrvHighBeam = 2147483648
	}

	[Flags]
	public enum OnFootFlag : uint
	{
		None = 0,
		OnFoot = 1,
		InTaxi = 2,
		InMultiCrew = 4,
		OnFootInStation = 8,
		OnFootOnPlanet = 16,
		AimDownSight = 32,
		LowOxygen = 64,
		LowHealth = 128,
		Cold = 256,
		Hot = 512,
		VeryCold = 1024,
		VeryHot = 2048,
		GlideMode = 4096,
		OnFootInHangar = 8192,
		OnFootSocialSpace = 16384,
		OnFootExterior = 32768,
		BreathableAtmosphere = 63356
    }

    public static void readStatus(string path, ShipFlag currentShip, OnFootFlag currentFoot)
    {
        if (!statusReaderLive) //if it's not live, start the reader
        {
            statusReaderLive = true;
            if (File.Exists(path))
            {
                string sFile = File.ReadAllText(path);
                using JsonDocument doc = JsonDocument.Parse(sFile);

                Root root = JsonSerializer.Deserialize<Root>(doc);
                Fuel fuel = JsonSerializer.Deserialize<Fuel>(doc);
                Destination destination = JsonSerializer.Deserialize<Destination>(doc);

                ShipFlag flag = root.Flags;
                OnFootFlag flag2 = root.Flags2;

                systemPips = root.Pips[0];
                enginePips = root.Pips[1];
                weaponPips = root.Pips[2];

                fireGroup = root.FireGroup;
                guiFocus = root.GuiFocus;

                fuelMain = fuel.FuelMain;
                fuelRes = fuel.FuelReservoir;

                Landed = currentShip.HasFlag(ShipFlag.Landed);
                Docked = currentShip.HasFlag(ShipFlag.Docked);
                GearDown = currentShip.HasFlag(ShipFlag.GearDown);
                ShieldsUp = currentShip.HasFlag(ShipFlag.ShieldsUp);
                Supercruise = currentShip.HasFlag(ShipFlag.Supercruise);
                FAOff = currentShip.HasFlag(ShipFlag.FAOff);
                HardpointsDeployed = currentShip.HasFlag(ShipFlag.HardpointsDeployed);
                InWing = currentShip.HasFlag(ShipFlag.InWing);
                LightsOn = currentShip.HasFlag(ShipFlag.LightsOn);
                CargoScoopDeployed = currentShip.HasFlag(ShipFlag.CargoScoopDeployed);
                SilentRunning = currentShip.HasFlag(ShipFlag.SilentRunning);
                ScoopingFuel = currentShip.HasFlag(ShipFlag.ScoopingFuel);
                SrvHandBrake = currentShip.HasFlag(ShipFlag.SrvHandBrake);
                SrvTurretView = currentShip.HasFlag(ShipFlag.SrvTurretView);
                SrvTurretRetracted = currentShip.HasFlag(ShipFlag.SrvTurretRetracted);
                SrvDriveAssist = currentShip.HasFlag(ShipFlag.SrvDriveAssist);
                FsdMassLocked = currentShip.HasFlag(ShipFlag.FsdMassLocked);
                FsdCharging = currentShip.HasFlag(ShipFlag.FsdCharging);
                FsdCooldown = currentShip.HasFlag(ShipFlag.FsdCooldown);
                OverHeating = currentShip.HasFlag(ShipFlag.OverHeating);
                IsInDanger = currentShip.HasFlag(ShipFlag.IsInDanger);
                InMainShip = currentShip.HasFlag(ShipFlag.InMainShip);
                InFighter = currentShip.HasFlag(ShipFlag.InFighter);
                InSrv = currentShip.HasFlag(ShipFlag.InSrv);
                HudInAnalysisMode = currentShip.HasFlag(ShipFlag.HudInAnalysisMode);
                NightVision = currentShip.HasFlag(ShipFlag.NightVision);
                FsdJump = currentShip.HasFlag(ShipFlag.FsdJump);
                SrvHighBeam = currentShip.HasFlag(ShipFlag.SrvHighBeam);

                OnFoot = currentFoot.HasFlag(OnFootFlag.OnFoot);
                InTaxi = currentFoot.HasFlag(OnFootFlag.InTaxi);
                InMulticrew = currentFoot.HasFlag(OnFootFlag.InMultiCrew);
                OnFootInStation = currentFoot.HasFlag(OnFootFlag.OnFootInStation);
                OnFootOnPlanet = currentFoot.HasFlag(OnFootFlag.OnFootOnPlanet);
                LowOxygen = currentFoot.HasFlag(OnFootFlag.LowOxygen);
                LowHealth = currentFoot.HasFlag(OnFootFlag.LowHealth);
                Hot = currentFoot.HasFlag(OnFootFlag.Hot);
                Cold = currentFoot.HasFlag(OnFootFlag.Cold);
                VeryHot = currentFoot.HasFlag(OnFootFlag.VeryHot);
                VeryCold = currentFoot.HasFlag(OnFootFlag.VeryCold);
                GlideMode = currentFoot.HasFlag(OnFootFlag.GlideMode);
                OnFootInHangar = currentFoot.HasFlag(OnFootFlag.OnFootInHangar);
                OnFootSocialSpace = currentFoot.HasFlag(OnFootFlag.OnFootSocialSpace);
                OnFootExterior = currentFoot.HasFlag(OnFootFlag.OnFootExterior);
                BreathableAtmosphere = currentFoot.HasFlag(OnFootFlag.BreathableAtmosphere);
                AimDownSight = currentFoot.HasFlag(OnFootFlag.AimDownSight);
            }
        }
        else
        {
            return; //if it's already live, fuck off so we dont have 17 readers running at the same time
        }
        //fetch the status file, read it & parse the data
    }

    public static void stopStatusReader()
    {
        if (statusReaderLive)
        {

        }
        else
        {
            return; //do nothing, since there's no reader to stop
        }
    }
}
