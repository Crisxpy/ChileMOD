using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ChileMOD.Items.muebles
{
	// Simple 3x3 tile that can be placed on a wall
	public class Bandera : ModTile
	{
		public override void SetStaticDefaults()
        {
            TileObjectData.newTile.CopyFrom(TileObjectData.GetTileData(TileID.WarTableBanner,TileID.WarTableBanner));

            Main.tileFrameImportant[Type] = true;
			Main.tileLavaDeath[Type] = true;
			Main.windPhysics = true;
			TileID.Sets.FramesOnKillWall[Type] = true;

            TileObjectData.newTile.Height = 3; // because the template is for 1x2 not 1x3
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 }; // because height changed
            TileObjectData.newTile.Origin = new Point16(0, 0);
            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width,0);
            TileObjectData.newTile.AnchorBottom = AnchorData.Empty;


            TileObjectData.addTile(Type);



            AddMapEntry(new Color(120, 85, 60), Language.GetText("MapObject.Trophy"));
			DustType = 7;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 32, ModContent.ItemType<Items.Placeables.BanderaItem>());
		}
	}
}
