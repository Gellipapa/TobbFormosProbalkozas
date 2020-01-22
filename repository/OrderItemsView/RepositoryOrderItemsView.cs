using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TobbbformosPizzaAlkalmazasTobbTabla.model;
using TobbbformosPizzaAlkalmazasTobbTabla.Model;
using TobbbformosPizzaAlkalmazasTobbTabla.Repository;

namespace TobbbformosPizzaAlkalmazasTobbTabla.repository.OrderItemsView
{
    class RepositoryOrderItemsView
    {
        private List<OrderItemsView2> roiv;
        /// <summary>
        /// Fizetendő végösszeg
        /// </summary>
        private int finalPrice=0; 


        public RepositoryOrderItemsView(int orderNumber, List<Item>items, List<Pizza>pizzas)
        {

            List<Item> iviews = items.FindAll(i => i.getOrderId() == orderNumber);

            foreach(Item i in iviews)
            {
                Pizza pizza = pizzas.Find(p => p.getId() == i.getPizzaId());
                finalPrice = 0;
                finalPrice = finalPrice + i.getPiece() * pizza.getPrice();
                OrderItemsView2 oiv = new OrderItemsView2(
                    orderNumber,
                    i.getPiece(),
                    pizza.getNeme(),
                    pizza.getPrice()
                    );

                roiv.Add(oiv);
            }

        }

        public int getFinalPrice()
        {
            return finalPrice;
        }

        public DataTable getOrderItemsViewDT()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("pizza_nev",typeof(string));
            dt.Columns.Add("mennyiseg",typeof(int));
            dt.Columns.Add("egysegar",typeof(int));
            dt.Columns.Add("tetelar",typeof(int));

            foreach(OrderItemsView2 oiv in roiv)
            {
                dt.Rows.Add(oiv.Name, oiv.Piece, oiv.Price, oiv.Price * oiv.Price);
            }

            return dt;

        }

    }
}
