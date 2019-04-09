using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MOVIES_DAL;

namespace _70322_Lutsko.Models
{
    public class Cart
    {
        Dictionary<int, CartItem> cartItems;
        public Cart()
        {
            cartItems = new Dictionary<int, CartItem>();
        }
        /// <summary> 
        /// Добавить в корзину 
        /// </summary> 
        /// <param name="dish">объект для добавления</param> 
        public void AddItem(Movie movie)
        {
            if (cartItems.ContainsKey(movie.MovieId))
                cartItems[movie.MovieId].Quantity += 1;
            else cartItems.Add(movie.MovieId, 
            new CartItem { Movie = movie, Quantity = 1 });
        }
        /// <summary> 
        /// Удалить из корзины 
        /// </summary> 
        /// <param name="dish">Объект для удаления</param> 
        public void RemoveItem(Movie movie)
        {
            if (cartItems[movie.MovieId].Quantity == 1)
                cartItems.Remove(movie.MovieId);
            else cartItems[movie.MovieId].Quantity -= 1;
        }
        /// <summary> 
        /// Очистить корзину
        /// </summary
        public void Clear()
        {
            cartItems.Clear();
        }
        /// <summary>
        /// Получение суммы  
        /// </summary> 
        /// <returns></returns> 
        public int GetTotal()
        {
            return cartItems.Values.Sum(i => i.Movie.Price * i.Quantity);
        }
        /// <summary> 
        /// Получение содержимого корзины 
        /// </summary> 
        /// <returns></returns> 
        public IEnumerable<CartItem> GetItems()
        {
            return cartItems.Values;
        }
    }
}
