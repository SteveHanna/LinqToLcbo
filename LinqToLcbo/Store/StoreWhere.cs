using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqToLcbo
{
    public class StoreWhere
    {
        public StoreWhere()
        {
            SearchQuery = new StringSearchQueryProperty("searchQuery");
            Geolocation = new StringSearchQueryProperty("geo");
            ProductId = new IntProperty("productId");
            IsDead = new BoolProperty("is_dead");
            HasWheelchairAccessability = new BoolProperty("has_wheelchair_accessability");
            HasBilingualServices = new BoolProperty("has_bilingual_services");
            HasProductConsultant = new BoolProperty("has_product_consultant");
            HasTastingBar = new BoolProperty("has_tasting_bar");
            HasBeerColdRoom = new BoolProperty("has_beer_cold_room");
            HasSpecialOccasionPermits = new BoolProperty("has_special_occasion_permits");
            HasVintageCorner = new BoolProperty("has_vintages_corner");
            HasParking = new BoolProperty("has_parking");
            HasTransitAccess = new BoolProperty("has_transit_access");
        }

        public IntProperty ProductId { get; set; }
        public StringSearchQueryProperty Geolocation { get; set; }
        public StringSearchQueryProperty SearchQuery { get; set; }
        public BoolProperty IsDead { get; set; }
        public BoolProperty HasWheelchairAccessability { get; set; }
        public BoolProperty HasBilingualServices { get; set; }
        public BoolProperty HasProductConsultant { get; set; }
        public BoolProperty HasSpecialOccasionPermits { get; set; }
        public BoolProperty HasTastingBar { get; set; }
        public BoolProperty HasBeerColdRoom { get; set; }
        public BoolProperty HasVintageCorner { get; set; }
        public BoolProperty HasParking { get; set; }
        public BoolProperty HasTransitAccess { get; set; }
    }
}
