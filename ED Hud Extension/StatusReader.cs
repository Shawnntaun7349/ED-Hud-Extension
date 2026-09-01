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
        public uint Flags { get; set; }
        public uint Flags2 { get; set; }
        public double? Oxygen { get; set; }
        public double? Health { get; set; }
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
        statusReaderLive = true;
        if (File.Exists(path))
        {
            string sFile = File.ReadAllText(path);
            using JsonDocument doc = JsonDocument.Parse(sFile);

            string timeStamp = doc.RootElement.GetProperty("timestamp").ToString();
            DateTime statusTS = DateTime.Parse(timeStamp);

            int status = Int32.Parse(doc.RootElement.GetProperty("Flags").ToString());
            if (status == 0) { doc.Dispose(); return; } //if the Flags vale uf ot the status file is 0, we're in the main menu or the game isnt running
            else
            {
                Root? root = JsonSerializer.Deserialize<Root>(doc);
                Fuel? fuel = JsonSerializer.Deserialize<Fuel>(doc);
                Destination? destination = JsonSerializer.Deserialize<Destination>(doc);

                ShipFlag flag = (ShipFlag)root.Flags;
                OnFootFlag flag2 = (OnFootFlag)root.Flags2;

                if (flag2 == 0)
                {
                    systemPips = root.Pips[0];
                    enginePips = root.Pips[1];
                    weaponPips = root.Pips[2];

                    fireGroup = root.FireGroup;
                    guiFocus = root.GuiFocus;

                    fuelMain = fuel.FuelMain;
                    fuelRes = fuel.FuelReservoir;
                }

                if (flag2 != 0)
                {
                    double? health = root.Health*100;
                    double? oxygen = root.Oxygen*100;
                    pFootHealth = (int)health;
                    pFootOxygen = (int)oxygen;
                }

                Landed = flag.HasFlag(ShipFlag.Landed);
                Docked = flag.HasFlag(ShipFlag.Docked);
                GearDown = flag.HasFlag(ShipFlag.GearDown);
                ShieldsUp = flag.HasFlag(ShipFlag.ShieldsUp);
                Supercruise = flag.HasFlag(ShipFlag.Supercruise);
                FAOff = flag.HasFlag(ShipFlag.FAOff);
                HardpointsDeployed = flag.HasFlag(ShipFlag.HardpointsDeployed);
                InWing = flag.HasFlag(ShipFlag.InWing);
                LightsOn = flag.HasFlag(ShipFlag.LightsOn);
                CargoScoopDeployed = flag.HasFlag(ShipFlag.CargoScoopDeployed);
                SilentRunning = flag.HasFlag(ShipFlag.SilentRunning);
                ScoopingFuel = flag.HasFlag(ShipFlag.ScoopingFuel);
                SrvHandBrake = flag.HasFlag(ShipFlag.SrvHandBrake);
                SrvTurretView = flag.HasFlag(ShipFlag.SrvTurretView);
                SrvTurretRetracted = flag.HasFlag(ShipFlag.SrvTurretRetracted);
                SrvDriveAssist = flag.HasFlag(ShipFlag.SrvDriveAssist);
                FsdMassLocked = flag.HasFlag(ShipFlag.FsdMassLocked);
                FsdCharging = flag.HasFlag(ShipFlag.FsdCharging);
                FsdCooldown = flag.HasFlag(ShipFlag.FsdCooldown);
                OverHeating = flag.HasFlag(ShipFlag.OverHeating);
                IsInDanger = flag.HasFlag(ShipFlag.IsInDanger);
                InMainShip = flag.HasFlag(ShipFlag.InMainShip);
                InFighter = flag.HasFlag(ShipFlag.InFighter);
                InSrv = flag.HasFlag(ShipFlag.InSrv);
                HudInAnalysisMode = flag.HasFlag(ShipFlag.HudInAnalysisMode);
                NightVision = flag.HasFlag(ShipFlag.NightVision);
                FsdJump = flag.HasFlag(ShipFlag.FsdJump);
                SrvHighBeam = flag.HasFlag(ShipFlag.SrvHighBeam);

                OnFoot = flag2.HasFlag(OnFootFlag.OnFoot);
                InTaxi = flag2.HasFlag(OnFootFlag.InTaxi);
                InMulticrew = flag2.HasFlag(OnFootFlag.InMultiCrew);
                OnFootInStation = flag2.HasFlag(OnFootFlag.OnFootInStation);
                OnFootOnPlanet = flag2.HasFlag(OnFootFlag.OnFootOnPlanet);
                LowOxygen = flag2.HasFlag(OnFootFlag.LowOxygen);
                LowHealth = flag2.HasFlag(OnFootFlag.LowHealth);
                Hot = flag2.HasFlag(OnFootFlag.Hot);
                Cold = flag2.HasFlag(OnFootFlag.Cold);
                VeryHot = flag2.HasFlag(OnFootFlag.VeryHot);
                VeryCold = flag2.HasFlag(OnFootFlag.VeryCold);
                GlideMode = flag2.HasFlag(OnFootFlag.GlideMode);
                OnFootInHangar = flag2.HasFlag(OnFootFlag.OnFootInHangar);
                OnFootSocialSpace = flag2.HasFlag(OnFootFlag.OnFootSocialSpace);
                OnFootExterior = flag2.HasFlag(OnFootFlag.OnFootExterior);
                BreathableAtmosphere = flag2.HasFlag(OnFootFlag.BreathableAtmosphere);
                AimDownSight = flag2.HasFlag(OnFootFlag.AimDownSight);
            }
        }
    }
}
