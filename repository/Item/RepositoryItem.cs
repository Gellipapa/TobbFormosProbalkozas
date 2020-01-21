using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using TobbbformosPizzaAlkalmazasTobbTabla.Model;

namespace TobbbformosPizzaAlkalmazasTobbTabla.Repository
{
    partial class Repository
    {
        List<Item> items;

        public List<Item> getItems()
        {
            return items;
        }

        public void setItem(List<Item> items)
        {
            this.items = items;
        }


   
        public DataTable getItemDataTableFromList()
        {
            DataTable itemDT = new DataTable();
            itemDT.Columns.Add("razon", typeof(int));
            itemDT.Columns.Add("pazon", typeof(int));
            itemDT.Columns.Add("db", typeof(int));
            foreach (Item i in items)
            {
                itemDT.Rows.Add(i.getOrderId(),i.getPizzaId(),i.getPiece());
            }
            return itemDT;
        }

       
    }
}
