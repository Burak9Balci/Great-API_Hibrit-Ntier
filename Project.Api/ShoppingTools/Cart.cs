using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Project.Api.ShoppingTools
{
    [Serializable]
    public class Cart
    {
        [JsonProperty("_myCart")]
        Dictionary<int, CartItem> _myCart;
        public Cart()
        {
            _myCart = new Dictionary<int,CartItem>();
        }
        [JsonProperty("CartItems")]
        public List<CartItem> CartItems
        {
            get
            {
                return _myCart.Values.ToList();
            }    
        }
        public void AddToCart(CartItem item)
        {
            if (_myCart.ContainsKey(item.ID))
            {
                item.Amount++;
                return;
            }
            _myCart.Add(item.ID, item);
        }
        public void Decrease(int id)
        {
            _myCart[id].Amount--;
            if (_myCart[id].Amount == 0)
            {
                _myCart.Remove(id);
            }
        }
        public void DeleteFromCart(int id)
        {
            _myCart.Remove(id);
        }
        [JsonProperty("TotalPrice")]
        public decimal TotalPrice
        {
            get
            {
                return _myCart.Values.Sum(x => x.SubTotal);
            }
        }

    }
}
