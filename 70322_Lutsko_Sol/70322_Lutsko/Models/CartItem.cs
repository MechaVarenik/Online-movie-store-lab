using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MOVIES_DAL;

namespace _70322_Lutsko.Models
{
    public class CartItem
    {
        public Movie Movie { get; set; }
        public int Quantity { get; set; }
    }
}