using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace LinqToLcbo
{
    public class Store
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("address_line_1")]
        public string StreetAddress { get; set; }
        [JsonProperty("address_line_2")]
        public string StreetAddress2 { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("fax")]
        public string Fax { get; set; }
        [JsonProperty("has_beer_cold_room")]
        public bool HasBeerColdRoom { get; set; }
        [JsonProperty("has_bilingual_services")]
        public bool HasBilingualServices { get; set; }
        [JsonProperty("has_parking")]
        public bool HasParking { get; set; }
        [JsonProperty("has_product_consultant")]
        public bool HasProductConsultant { get; set; }
        [JsonProperty("has_special_occasion_permits")]
        public bool HasSpecialOccasionPermits { get; set; }
        [JsonProperty("has_tasting_bar")]
        public bool HasTastingBar { get; set; }
        [JsonProperty("has_transit_access")]
        public bool HasTransitAccess { get; set; }
        [JsonProperty("has_vintages_corner")]
        public bool HasVintageCorner { get; set; }
        [JsonProperty("has_wheelchair_accessability")]
        public bool HasWheelchairAccessability { get; set; }
        [JsonProperty("inventory_count")]
        public int InventoryCount { get; set; }
        [JsonProperty("inventory_price_in_cents")]
        public int InventoryPrice { get; set; }
        [JsonProperty("inventory_volume_in_milliliters")]
        public int InventoryVolume { get; set; }
        [JsonProperty("is_dead")]
        public bool IsDead { get; set; }
        [JsonProperty("latitude")]
        public double Latitude { get; set; }
        [JsonProperty("longitude")]
        public double Longitude { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }
        [JsonProperty("products_count")]
        public int ProductsCount { get; set; }
        [JsonProperty("tags")]
        public string Tags { get; set; }
        [JsonProperty("telephone")]
        public string Telephone { get; set; }
        [JsonProperty("updated_at")]
        public DateTime? UpdatedDate { get; set; }

        public LcboProductProvider Products { get { return new LcboProductProvider("stores", Id); } }
    }
}