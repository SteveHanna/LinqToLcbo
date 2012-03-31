using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace LinqToLcbo
{
    public class Inventory
    {
        [JsonProperty("product_id")]
        public int ProductId { get; set; }
        [JsonProperty("store_id")]
        public int StoreId { get; set; }
        [JsonProperty("is_dead")]
        public bool IsDead { get; set; }
        [JsonProperty("quantity")]
        public int Quantity{ get; set; }
        [JsonProperty("updated_on")]
        public DateTime? UpdatedQuantityDate { get; set; }
        [JsonProperty("updated_at")]
        public DateTime? UpdatedInventoryTime{ get; set; }
    }
}
