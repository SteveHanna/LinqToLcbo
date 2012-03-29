using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqToLcbo
{
    public class ProductWhere
    {
        public ProductWhere()
        {
            SearchQuery = new StringSearchQueryProperty("searchQuery");
            StoreId = new IntProperty("storeId");
            IsDiscontinued = new BoolProperty("is_discontinued");
            IsDead = new BoolProperty("is_dead");
            HasValueAddedPromotion = new BoolProperty("has_value_added_promotion");
            HasLimitedTimeOffer = new BoolProperty("has_limited_time_offer");
            HasBonusRewardMiles = new BoolProperty("has_bonus_reward_miles");
            IsSeasonal = new BoolProperty("is_seasonal");
            IsVqa = new BoolProperty("is_vqa");
            IsKosher = new BoolProperty("is_kosher");
        }

        public StringSearchQueryProperty SearchQuery { get; set; }
        public IntProperty StoreId { get; set; }
        public BoolProperty IsDead { get; set; }
        public BoolProperty IsDiscontinued { get; set; }
        public BoolProperty HasValueAddedPromotion { get; set; }
        public BoolProperty HasLimitedTimeOffer { get; set; }
        public BoolProperty HasBonusRewardMiles { get; set; }
        public BoolProperty IsSeasonal { get; set; }
        public BoolProperty IsVqa { get; set; }
        public BoolProperty IsKosher { get; set; }
    }
}
