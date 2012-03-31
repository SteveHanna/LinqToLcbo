using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace LinqToLcbo
{
    public class Product
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("alcohol_content")]
        public int AlcoholContent { get; set; }

        [JsonProperty("bonus_reward_miles")]
        public int? BonusRewardMiles { get; set; }

        [JsonProperty("bonus_reward_miles_ends_on")]
        public DateTime? BonusRewardMilesEndingDate { get; set; }

        [JsonProperty("limited_time_offer_savings_in_cents")]
        public int? LimitedTimeOffer { get; set; }

        [JsonProperty("limited_time_offer_ends_on")]
        public DateTime? LimitedTimeOfferEndingDate { get; set; }

        [JsonProperty("value_added_promotion_description")]
        public string ValueAddedPromotionDescription { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedDate { get; set; }

        [JsonProperty("total_package_units")]
        public int TotalPackageUnits { get; set; }

        [JsonProperty("tasting_note")]
        public string TastingNote { get; set; }

        [JsonProperty("tags")]
        public string Tags { get; set; }

        [JsonProperty("sugar_content")]
        public string SugarContent { get; set; }

        [JsonProperty("stock_type")]
        public string StockType { get; set; }

        [JsonProperty("image_thumb_url")]
        public string ImageThumbUrl { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("serving_suggestion")]
        public string ServingSuggestion { get; set; }

        [JsonProperty("secondary_category")]
        public string SecondaryCategory { get; set; }

        [JsonProperty("released_on")]
        public DateTime? ReleasedDate { get; set; }

        [JsonProperty("regular_price_in_cents")]
        public int RegularPrice { get; set; }

        [JsonProperty("producer_name")]
        public string ProducerName { get; set; }

        [JsonProperty("primary_category")]
        public string PrimaryCategory { get; set; }

        [JsonProperty("price_per_liter_of_alcohol_in_cents")]
        public int PricePerLiterOfAlcohol { get; set; }

        [JsonProperty("price_per_liter_in_cents")]
        public int PricePerLiter { get; set; }

        [JsonProperty("price_in_cents")]
        public int Price { get; set; }

        [JsonProperty("package_unit_volume_in_milliliters")]
        public int PackageUnitVolume { get; set; }

        [JsonProperty("package_unit_type")]
        public string PackageUnitType { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("package")]
        public string Package { get; set; }

        [JsonProperty("origin")]
        public string Origin { get; set; }

        [JsonProperty("volume_in_milliliters")]
        public int Volume { get; set; }

        public LcboStoreProvider Stores { get { return new LcboStoreProvider("products", Id); } }
        public LcboInventoryProvider Inventories { get { return new LcboInventoryProvider("products", Id); } }
    }
}