using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TerraSteal.Common.Players;
using TerraSteal.Content.Projectiles;

namespace TerraSteal.Content.ItemChanges.Weapon
{
    public class TrueNightsEdgeMod : GlobalItem
    {
        // Garante que cada instância do item tenha seus próprios atributos
        public override bool InstancePerEntity => true;

        public override void HoldItem(Item item, Player player)
        {
            if (item.type == ItemID.TrueNightsEdge)
            {
                bool flagAtiva = player.GetModPlayer<TrueMeleePlayer>().TrueMeleeEquipped;

                if (flagAtiva)
                {
                    // Altera os atributos em tempo real
                    item.useTime = 15;
                    item.useAnimation = 15;
                    item.scale = 1.4f;
                }
                else
                {
                    // Restaura os valores originais da Verdadeira Lâmina da Noite
                    item.useTime = 32;
                    item.useAnimation = 32;
                    item.scale = 1.0f;
                }
            }
        }

        // Opcional: Use ModifyWeaponDamage para alterar o dano de forma segura com outros bônus
        public override void ModifyWeaponDamage(Item item, Player player, ref StatModifier damage)
        {
            if (item.type == ItemID.TrueNightsEdge && player.GetModPlayer<TrueMeleePlayer>().TrueMeleeEquipped)
            {
                damage += 0.25f; // Aumenta o dano em 25%
            }
        }

        public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (item.type == ItemID.TrueNightsEdge && player.GetModPlayer<TrueMeleePlayer>().TrueMeleeEquipped)
            {
                // Cria o projétil com velocidade zero (estático em relação ao mundo)
                int projIndex = Projectile.NewProjectile(source, player.Center, Vector2.Zero, type, damage, knockback, player.whoAmI, player.direction, player.itemAnimationMax);
                
                // Ativa a marcação no GlobalProjectile para que ele siga o jogador
                if (Main.projectile.IndexInRange(projIndex))
                {
                    Main.projectile[projIndex].GetGlobalProjectile<TrueNigthsEdgeStatic>().FollowPlayer = true;
                }

                // Cancela o disparo padrão para não sair dois projéteis
                return false;
            }

            return base.Shoot(item, player, source, position, velocity, type, damage, knockback);
        }
    }
}
