using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TerraSteal.Common.Players;


namespace TerraSteal.Content.ItemChanges.Weapon
{
	// adding additional data to all items in the game. Here we simply adjust the damage of the Copper Shortsword item, as it is simple to understand. 
	public class TerraBladeMod : GlobalItem
	{
		public override void SetDefaults(Item item)
		{
			if (item.type == ItemID.TerraBlade) // Here we make sure to only change by checking item.type in an if statement
			{
				if (Main.LocalPlayer.TryGetModPlayer(out TrueMeleePlayer modPlayer))
				{
					if (modPlayer.TrueMeleeEquipped) // In case player has item
					{
						item.damage = 100;
						item.useTime = 9;
						item.useAnimation = 9;
						item.knockBack = 4f;
						item.shoot = ProjectileID.None;
					}
					else // In case player do not have item
					{
						item.shoot = ProjectileID.TerraBlade2Shot;
					}
				}
			}
		}
	}
}