using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqToLcbo
{
    public class ProductOrderBy
    {
        public ProductOrderBy()
        {
            Id = new OrderByFilter("id");
            Price = new OrderByFilter("price_in_cents");
            RegularPrice = new OrderByFilter("regular_price_in_cents");
            LimitedTimeOfferSavings = new OrderByFilter("limited_time_offer_savings_in_cents");
            LimitedTimeOfferEndingDate = new OrderByFilter("limited_time_offer_ends_on");
            BonusRewardMiles = new OrderByFilter("bonus_reward_miles");
            BonusRewardMilesEndingDate = new OrderByFilter("bonus_reward_miles_ends_on");
            PackageUnitVolume = new OrderByFilter("package_unit_volume_in_milliliters");
            TotalPackageUnits = new OrderByFilter("total_package_units");
            TotalPackageVolume = new OrderByFilter("total_package_volume_in_milliliters");
            Volume = new OrderByFilter("volume_in_milliliters");
            AlcoholContent = new OrderByFilter("alcohol_content");
            PricePerLiter = new OrderByFilter("price_per_liter_in_cents");
            PricePerLiterOfAlcohol = new OrderByFilter("price_per_liter_of_alcohol_in_cents");
            InventoryCount = new OrderByFilter("inventory_count");
            InventoryVolume = new OrderByFilter("inventory_volume_in_milliliters");
            InventoryPrice = new OrderByFilter("inventory_price_in_cents");
            ReleasedDate = new OrderByFilter("released_on");
        }

        public OrderByFilter Id { get; set; }
        public OrderByFilter RegularPrice { get; set; }
        public OrderByFilter LimitedTimeOfferSavings { get; set; }
        public OrderByFilter LimitedTimeOfferEndingDate { get; set; }
        public OrderByFilter ReleasedDate { get; set; }
        public OrderByFilter Price { get; set; }
        public OrderByFilter BonusRewardMiles { get; set; }
        public OrderByFilter BonusRewardMilesEndingDate { get; set; }
        public OrderByFilter PackageUnitVolume { get; set; }
        public OrderByFilter TotalPackageUnits { get; set; }
        public OrderByFilter TotalPackageVolume { get; set; }
        public OrderByFilter Volume { get; set; }
        public OrderByFilter AlcoholContent { get; set; }
        public OrderByFilter PricePerLiterOfAlcohol { get; set; }
        public OrderByFilter PricePerLiter { get; set; }
        public OrderByFilter InventoryCount { get; set; }
        public OrderByFilter InventoryVolume { get; set; }
        public OrderByFilter InventoryPrice { get; set; }
    }
}
