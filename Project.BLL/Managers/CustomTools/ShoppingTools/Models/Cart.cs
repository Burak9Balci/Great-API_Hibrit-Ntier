﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Project.BLL.Managers.CustomTools.ShoppingTools.Models
{
    [Serializable]
    public class Cart
    {
        [JsonProperty("_myCart")]
        Dictionary<int, CartItem> _myCart;
        public Cart()
        {
            _myCart = new Dictionary<int, CartItem>();
        }
        [JsonProperty("CartItems")]
        public List<CartItem> CartItems
        {
            get
            {
                return _myCart.Values.ToList();
            }
        }
        [JsonProperty("SubTotal")]
        public decimal SubTotal
        {
            get
            {
                return _myCart.Values.Sum(x => x.SubTotal);
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
        public void DeleteFromCart(int id)
        {
            _myCart.Remove(id);
        }
        public void Decrease(int id)
        {
            if (_myCart[id].Amount > 1)
            {
                _myCart[id].Amount--;
            }
            DeleteFromCart(id);
        }

    }
}