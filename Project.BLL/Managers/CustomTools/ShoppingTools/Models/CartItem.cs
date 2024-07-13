using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Managers.CustomTools.ShoppingTools.Models
{
    [Serializable]
    public class CartItem
    {
        public CartItem()
        {
            Amount++;
        }
        [JsonProperty("ID")]
        public int ID { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Amount")]
        public int Amount { get; set; }
        [JsonProperty("UnitPrice")]
        public decimal UnitPrice { get; set; }
        [JsonProperty("SubTotal")]
        public decimal SubTotal
        {
            get
            {
                return Amount * UnitPrice;
            }
        }
        [JsonProperty("CategoryID")]
        public int? CategoryID { get; set; }
        
       
    }
}
