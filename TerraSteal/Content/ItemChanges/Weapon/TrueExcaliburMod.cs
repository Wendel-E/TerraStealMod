using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TerraSteal.Common.Players;


namespace TerraSteal.Content.ItemChanges.Weapon
{
	// adding additional data to all items in the game. Here we simply adjust the damage of the Copper Shortsword item, as it is simple to understand. 
	public class TrueExcaliburMod : GlobalItem
	{
		public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			// Verifica se é a arma vanilla desejada E se o jogador ativou o efeito
			if (item.type == ItemID.TrueExcalibur && player.GetModPlayer<TrueMeleePlayer>().TrueMeleeEquipped)
			{
				// Dispara o novo projétil no lugar do original
				Projectile.NewProjectile(source, position, velocity, ProjectileID.FireArrow, damage, knockback, player.whoAmI);
				
				// Retorna false para cancelar o disparo original do arco
				return false;
			}

			// Mantém o comportamento normal para todas as outras armas
			return base.Shoot(item, player, source, position, velocity, type, damage, knockback);
		}
	}
}