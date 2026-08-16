namespace ED_Hud_Extension
{
    internal static class Program
    {
        ///<summary>
        /// The main entry point for the application.
        ///</summary>
        [STAThread]
        static void Main()
        {
            //To customize application configuration such as set high DPI settings or default font,
            //see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());

            //declaring variables to be retrieved from the Journal File
            //display data
            string targetName = ""; //pilot
            string targetShip = ""; //ship
            string targetRank = ""; //combat rank
            string targetFaction = ""; //local faction
            string targetPower = ""; //powerplay faction
            string targetWanted = ""; //legal status
            string targetBounty = ""; //local bounty
            string targetExtendedBounty = ""; //galactic bounty
            float targetShields = 0; //shield health
            float targetHull = 0; //hull health

            //events what for flagging and such
            bool targetDestroyed = false; //flag for when the player achieves a kill
            bool inCombat = false; //flag for when the player is engaged in combat [under_attack or weapons_fired flags]
            bool isTargeting = false; //flag for checking if the player has targetted anything/one
        }
    }
            
}