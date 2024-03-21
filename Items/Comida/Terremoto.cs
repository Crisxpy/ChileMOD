using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChileMOD.Items.Comida
{
    internal class Terremoto : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Terremoto");
            // Tooltip.SetDefault("{$CommonItemTooltip.MinorStats}\n'Chicha con helado de piña pa el calor!'");

            Main.RegisterItemAnimation(Type, new DrawAnimationVertical(int.MaxValue, 3));
            ItemID.Sets.FoodParticleColors[Item.type] = new Color[3]
            {
                new Color(212, 154, 121),
                new Color(201, 197, 198),
                new Color(201, 195, 191)

            };
            ItemID.Sets.IsFood[Type] = true;
        }
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 32;
            Item.maxStack = 15;
            Item.DefaultToFood(22, 22, BuffID.WellFed, 57600);
            Item.UseSound = SoundID.Item3;
            Item.value = Item.buyPrice(0, 1);
            Item.rare = ItemRarityID.Blue;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Glass, 5)
                .AddCondition(Condition.NearWater)
                .Register();
        }
        public override void OnConsumeItem(Player player)
        {
            player.AddBuff(BuffID.Tipsy, 60 * 15);
            base.OnConsumeItem(player);
        }
    }
}
