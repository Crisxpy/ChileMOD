using ChileMOD.Items.Comida;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.Personalities;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Utilities;

namespace ChileMOD.NPC.TownNPC
{
	// [AutoloadHead] and NPC.townNPC are extremely important and absolutely both necessary for any Town NPC to work at all.
	[AutoloadHead]
	public class Huaso : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[Type] = 25; // The amount of frames the NPC has
            int examplePersonType = ModContent.NPCType<NPC.TownNPC.Huaso>(); // Get ExamplePerson's type
            var guideHappiness = NPCHappiness.Get(NPCID.Guide); // Get the key into The Guide's happiness

            guideHappiness.SetNPCAffection(examplePersonType, AffectionLevel.Love); // Make the Guide love ExamplePerson!

            NPCID.Sets.ExtraFramesCount[Type] = 9; // Generally for Town NPCs, but this is how the NPC does extra things such as sitting in a chair and talking to other NPCs.
			NPCID.Sets.AttackFrameCount[Type] = 4;
			NPCID.Sets.DangerDetectRange[Type] = 800; // The amount of pixels away from the center of the npc that it tries to attack enemies.
			NPCID.Sets.AttackType[Type] = 0;
			NPCID.Sets.AttackTime[Type] = 90; // The amount of time it takes for the NPC's attack animation to be over once it starts.
			NPCID.Sets.AttackAverageChance[Type] = 50;
			NPCID.Sets.HatOffsetY[Type] = 4; // For when a party is active, the party hat spawns at a Y offset.

			// Set Example Person's biome and neighbor preferences with the NPCHappiness hook. You can add happiness text and remarks with localization (See an example in ExampleMod/Localization/en-US.lang).
			// NOTE: The following code uses chaining - a style that works due to the fact that the SetXAffection methods return the same NPCHappiness instance they're called on.
			NPC.Happiness
				.SetBiomeAffection<ForestBiome>(AffectionLevel.Love) // Example Person prefers the forest.
				.SetBiomeAffection<SnowBiome>(AffectionLevel.Like) // Example Person dislikes the snow.
				.SetBiomeAffection<DesertBiome>(AffectionLevel.Hate)
				.SetNPCAffection(NPCID.Dryad, AffectionLevel.Love) // Loves living near the dryad.
				.SetNPCAffection(NPCID.Guide, AffectionLevel.Like) // Likes living near the guide.
				.SetNPCAffection(NPCID.Merchant, AffectionLevel.Dislike) // Dislikes living near the merchant.
			;
        }
        public override void SetDefaults()
		{
			NPC.townNPC = true; // Sets NPC to be a Town NPC
			NPC.friendly = true; // NPC Will not attack player
			NPC.width = 18;
			NPC.height = 40;
			NPC.aiStyle = 7;
			NPC.damage = 10;
			NPC.defense = 15;
			NPC.lifeMax = 250;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
            NPC.aiStyle = 7;
            NPC.knockBackResist = 0.5f;
			AnimationType = NPCID.Merchant;
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			// We can use AddRange instead of calling Add multiple times in order to add multiple items at once
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the preferred biomes of this town NPC listed in the bestiary.
				// With Town NPCs, you usually set this to what biome it likes the most in regards to NPC happiness.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,

				// Sets your NPC's flavor text in the bestiary.
				new FlavorTextBestiaryInfoElement("Directo de los campos Chilenos, representante de las costumbres Chilenas, todos somos un poco como durante el 18"),
			});
		}

		// The PreDraw hook is useful for drawing things before our sprite is drawn or running code before the sprite is drawn
		// Returning false will allow you to manually draw your NPC

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{ // Requirements for the town NPC to spawn.
			for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];
				if (!player.active)
				{
					continue;
				}
				if (DateTime.Now.Month == 9) {
					return true;
				}

				// Jugador debe tener almenos un Choripan o Anticucho
				if (player.inventory.Any(item => item.type == ModContent.ItemType<Anticucho>() || item.type == ModContent.ItemType<Choripan>()))
				{
					return true;
				}
			}

			return false;
		}



		public override List<string> SetNPCNameList()
		{
			return new List<string>() {
				"Pancho",
				"Juan",
				"Pablo",
				"Galindo",
				"Humberto",
				"Tranquilino"
			};
		}

		public override string GetChat()
		{
			WeightedRandom<string> chat = new WeightedRandom<string>();
			chat.Add("Tengo que decir..... Viva Chile mierda!");
			chat.Add("Me falta un corderito al palo....");
			chat.Add("La mejor epoca del año, es cuando puedo tomar Terremoto de almuerzo once y cena");
			chat.Add("Quisiera que esta chicha, me durara toda la vida");
			chat.Add("Este 18, brindemos por los que estan y los que faltan!");
			return chat; // chat is implicitly cast to a string.
		}
		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = "Shop"; 
		}
		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
			{
				shop = true;
			}
		}
		public override void SetupShop(Chest shop, ref int nextSlot)
        {
            base.SetupShop(shop, ref nextSlot);
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Choripan>());
			nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Anticucho>());
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Terremoto>());
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Empanada>());
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Piscola>());
            nextSlot++;
        }
		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Choripan>()));
		}

		// Make this Town NPC teleport to the King and/or Queen statue when triggered.
		public override bool CanGoToStatue(bool toKingStatue) => true;

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 20;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 30;
			randExtraCooldown = 30;
		}

		 public override void TownNPCAttackProj(ref int projType, ref int attackDelay) {
		 	projType = ProjectileID.CannonballFriendly;
		 	attackDelay = 3;
		 }

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
			randomOffset = 2f;
		}

		internal static void ActivateEighteenPartyMode() {
		}
	}


}