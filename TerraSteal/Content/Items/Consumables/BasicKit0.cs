using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerraSteal.Content.Items.Consumables
{
	// Basic code for a fishing crate
	// The catch code is in a separate ModPlayer class (ExampleFishingPlayer)
	// The placed tile is in a separate ModTile class
	public class BasicKit0 : ModItem
	{
		public override void SetStaticDefaults() {
			// Disclaimer for both of these sets (as per their docs): They are only checked for vanilla item IDs, but for cross-mod purposes it would be helpful to set them for modded crates too
			ItemID.Sets.IsFishingCrate[Type] = true;
			//ItemID.Sets.IsFishingCrateHardmode[Type] = true; // This is a crate that mimics a pre-hardmode biome crate, so this is commented out
			ItemID.Sets.OpenableBag[Type] = true;

			Item.ResearchUnlockCount = 3;
		}

		public override void SetDefaults() {
			Item.rare = ItemRarityID.Orange;
			Item.value = Item.sellPrice(0, 2);
		}

		public override void ModifyResearchSorting(ref ContentSamples.CreativeHelper.ItemGroup itemGroup) {
			itemGroup = ContentSamples.CreativeHelper.ItemGroup.Crates;
		}

		public override bool CanRightClick() {
			return true;
		}

		public override void ModifyItemLoot(ItemLoot itemLoot) {
			// Drop a special weapon/accessory etc. specific to this crate's theme (i.e. Sky Crate dropping Fledgling Wings or Starfury)
			/* int[] themedDrops = [
				ModContent.ItemType<Accessories.ExampleBeard>(),
				ModContent.ItemType<Accessories.ExampleStatBonusAccessory>()
			];
			itemLoot.Add(ItemDropRule.OneFromOptionsNotScalingWithLuck(1, themedDrops)); */

			IItemDropRule[] pickaxe = [
				ItemDropRule.Common(ItemID.LeadPickaxe, 1, 1, 1),
			];
			itemLoot.Add(new OneFromRulesRule(1, pickaxe));

			IItemDropRule[] axe = [
				ItemDropRule.Common(ItemID.LeadAxe, 1, 1, 1),
			];
			itemLoot.Add(new OneFromRulesRule(1, axe));

			IItemDropRule[] hammer = [
				ItemDropRule.Common(ItemID.LeadHammer, 1, 1, 1),
			];
			itemLoot.Add(new OneFromRulesRule(1, hammer));

			IItemDropRule[] sword = [
				ItemDropRule.Common(ItemID.LeadBroadsword, 1, 1, 1),
			];
			itemLoot.Add(new OneFromRulesRule(1, sword));

			IItemDropRule[] bow = [
				ItemDropRule.Common(ItemID.LeadBow, 1, 1, 1),
			];
			itemLoot.Add(new OneFromRulesRule(1, bow));

			IItemDropRule[] head = [
				ItemDropRule.Common(ItemID.LeadHelmet, 1, 1, 1),
			];
			itemLoot.Add(new OneFromRulesRule(1, head));

			IItemDropRule[] body = [
				ItemDropRule.Common(ItemID.LeadChainmail, 1, 1, 1),
			];
			itemLoot.Add(new OneFromRulesRule(1, body));

			IItemDropRule[] legs = [
				ItemDropRule.Common(ItemID.LeadGreaves, 1, 1, 1),
			];
			itemLoot.Add(new OneFromRulesRule(1, legs));
		}
	}
}