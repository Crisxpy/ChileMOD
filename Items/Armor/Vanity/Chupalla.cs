﻿using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChileMOD.Items.Armor.Vanity
{
    // The AutoloadEquip attribute automatically attaches an equip texture to this item.
    // Providing the EquipType.Head value here will result in TML expecting a X_Head.png file to be placed next to the item's main texture.
    [AutoloadEquip(EquipType.Head)]
    public class Chupalla : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Tipica Indumentaria de Huaso Chileno");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
            ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true; // Dibuja el item como "sombrero", con un poco de pelo por debajo, estilo mago
        }

        public override void SetDefaults()
        {
            Item.width = 34; // Width of the item
            Item.height = 34; // Height of the item
            Item.value = Item.sellPrice(silver: 50); // How many coins the item is worth
            Item.rare = Terraria.ID.ItemRarityID.Blue; // The rarity of the item
            Item.defense = 2; // The amount of defense the item will give when equipped
        }

        // IsArmorSet determines what armor pieces are needed for the setbonus to take effect
        //public override bool IsArmorSet(Item head, Item body, Item legs) {
        //	return body.type == ModContent.ItemType<ExampleBreastplate>() && legs.type == ModContent.ItemType<ExampleLeggings>();
        //}

        // UpdateArmorSet allows you to give set bonuses to the armor.
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increases dealt damage by 20%"; // This is the setbonus tooltip
            player.GetDamage(DamageClass.Generic) += 0.2f; // Increase dealt damage for all weapon classes by 20%
        }

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Hay, 10)
                .Register();
        }
    }
}
