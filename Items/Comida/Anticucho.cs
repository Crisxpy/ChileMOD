using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChileMOD.Items.Comida
{
    public class Anticucho : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Anticucho Dieciochero");
            // Tooltip.SetDefault("{$CommonItemTooltip.MinorStats}\n'Comida empalada miniatura'");

            Main.RegisterItemAnimation(Type, new DrawAnimationVertical(int.MaxValue, 3));

            ItemID.Sets.FoodParticleColors[Item.type] = new Color[3] {
                new Color(204, 186, 47),
                new Color(191, 176, 176),
                new Color(117, 60, 32)
            };
            ItemID.Sets.IsFood[Type] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 32;
            Item.maxStack = 15;
            Item.DefaultToFood(22, 22, BuffID.WellFed, 57600); // 57600 is 16 minutes: 16 * 60 * 60
            Item.value = Item.buyPrice(0, 1);
            Item.rare = ItemRarityID.Blue;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup("Wood", 1)
                .AddRecipeGroup("Ducks", 1)
                .AddIngredient(ItemID.Bunny)
                .AddTile(TileID.Furnaces)
                .Register();
        }
    }
}