﻿using Microsoft.VisualBasic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace ChileMOD.NPC.Critter
{
    public class BunnyHuaso : ModNPC 
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Conejo Huasito");
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.Bunny];
        }
        public override void SetDefaults()
        {
            NPC.lifeMax = 5;
            NPC.width = 18;
            NPC.height = 20;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.aiStyle = 7; 
            
            AIType = NPCID.Bunny;
            AnimationType = NPCID.Bunny;
        }
		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			if (DateAndTime.Now.Month == 9) {
				return SpawnCondition.OverworldDay.Chance;
			}
			return 0;
		}  
    }
}