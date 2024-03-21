using System;
using System.Reflection.Metadata.Ecma335;
using Terraria;
using Terraria.ModLoader;

namespace ChileMOD
{
	/// Detecta si es el 18
	class DieciochoFinder
	{
		static bool eighteenPartyMode = false;

		static void Main(string[] args) {
			// Check if it's currently September
			if (DateTime.Now.Month == 9) {
				Console.WriteLine("It's September! Activating 18 party mode...");
				eighteenPartyMode = true;
			}

			// Call other classes' methods based on whether eighteenPartyMode is true or false
			if (eighteenPartyMode) {
				// Call methods for 18 party mode
				//NPC.TownNPC.Huaso.ActivateEighteenPartyMode();
			}
			else {
				// Call regular methods
				//ClassA.RegularMode();
				//ClassB.RegularMode();
			}

			Console.ReadKey();
		}
	}
}

