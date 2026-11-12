using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TerraSteal.Common.Players;

namespace TerraSteal.Content.Items.Accessories
{
	// Showcases a beard vanity item that uses a greyscale sprite which gets its' color from the players' hair
	// Requires ArmorIDs.Beard.Sets.UseHairColor and Item.color to be used properly
	// For a beard with a fixed color, remove the above mentioned code
	public class TrueWarriorEmblem : ModItem
	{
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 14;
			Item.maxStack = 1;
			Item.value = Item.sellPrice(0, 1);
			Item.accessory = true;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.GetDamage(DamageClass.Melee) += 0.1f; // Increase ALL player damage by 100%
			player.GetModPlayer<TrueMeleePlayer>().TrueMeleeEquipped = true;
		}
	}
}