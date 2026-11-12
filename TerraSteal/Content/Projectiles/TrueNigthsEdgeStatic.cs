using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TerraSteal.Content.Projectiles
{
    public class TrueNigthsEdgeStatic : GlobalProjectile
    {
        // Necessário para que a variável seja única para cada projétil criado
        public override bool InstancePerEntity => true;

        public bool FollowPlayer = false;

        public override void PostAI(Projectile projectile)
        {
            if (FollowPlayer)
            {
                Player owner = Main.player[projectile.owner];

                if (owner.active && !owner.dead)
                {
                    // Trava o projétil no centro do jogador e zera o deslocamento
                    projectile.Center = owner.Center;
                    projectile.velocity = Vector2.Zero;
                }
            }
        }
    }
}
