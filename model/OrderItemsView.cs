﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobbbformosPizzaAlkalmazasTobbTabla.model
{
    class OrderItemsView2
    {
        private int orderId;
        private int piece;
        private string name;
        private int price;


        public OrderItemsView(int orderId,int piece,string name,int price)
        {
            this.orderId = orderId;
            this.piece = piece;
            this.name = name;
            this.price = price;
        }
    }
   
}
