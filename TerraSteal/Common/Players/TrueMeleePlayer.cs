using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerraSteal.Common.Players
{
    public class TrueMeleePlayer : ModPlayer
	{
		// Here we declare the FrostBurnSummon variable which will represent whether this player has the effect or not.
		public bool TrueMeleeEquipped;

		// ResetEffects is used to reset effects back to their default value. Terraria resets all effects every frame back to defaults so we will follow this design. (You might think to set a variable when an item is equipped and un-assign the value when the item in unequipped, but Terraria is not designed that way.)
		public override void Initialize() {
			TrueMeleeEquipped = true;
		}

		public override void ResetEffects() {
			TrueMeleeEquipped = false;
		}
    }
}