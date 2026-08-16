using System;

internal class Functions
{
	public Functions()
	{

	}
	
	public static void simulateCombat(bool inCombat, string tName, string tShip, float tShield, float tHull)
	{
		//a function to retrieve scan data from the player journal and store them for display. setup is mildly redundant at the moment but will make more sense once journal integration is done.

		Globals.inCombat = inCombat;
		Globals.targetName = tName;
		Globals.targetShip = tShip;
		Globals.targetShield = tShield;
		Globals.targetHull = tHull;
	}
	
}

