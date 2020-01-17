using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TobbbformosPizzaAlkalmazasTobbTabla.Model;
using TobbbformosPizzaAlkalmazasTobbTabla.Repository;

namespace TobbformosMvcPizzaTobbTabla
{
    public partial class FormPizzaFutarKft : Form
        
    {
        private bool nincsenekListViewOszlopok= true;


        private void tabPageSzamlak_Click(object sender, EventArgs e)
        {
            beallitSzamlakTabPagetIndulaskor();

        }
        private void tabControlPizzaFutarKFT_Selected(object sender, TabControlEventArgs e)
        {
            beallitSzamlakTabPagetIndulaskor();
            feltoltComboBoxotMegrendelokkel();
        }

        private void feltoltComboBoxotMegrendelokkel()
        {
            comboBoxMegrendelok.DataSource = repo.getCustomersName();
        }

        private void beallitSzamlakTabPagetIndulaskor()
        {
            
            listViewRendelesek.GridLines = true;
            listViewRendelesek.View = View.Details;
            listViewRendelesek.FullRowSelect = true;
            listViewRendelesek.Columns.Add("Azonosító");
            listViewRendelesek.Columns.Add("Futár");
            listViewRendelesek.Columns.Add("Megrendelő");
            listViewRendelesek.Columns.Add("Dátum");
            listViewRendelesek.Columns.Add("idő");
            listViewRendelesek.Columns.Add("Teljesités");
            nincsenekListViewOszlopok = false;
            listViewRendelesek.Visible = false;
            labelRendelesek.Visible = false;
            dataGridViewTetelek.Visible = false;
            labelTetelek.Visible = false;
            listViewRendelesek.Columns[1].TextAlign = HorizontalAlignment.Right;
            listViewRendelesek.Columns[2].TextAlign = HorizontalAlignment.Right;
            listViewRendelesek.Columns[3].TextAlign = HorizontalAlignment.Right;


        }
        private void comboBoxMegrendelok_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridViewTetelek.Visible = false;
            labelTetelek.Visible = false;

            if (comboBoxMegrendelok.SelectedIndex < 0)
            {
                return;
            }
            listViewRendelesek.Visible = true;
            

            string megrendeloNev = comboBoxMegrendelok.Text;
            feltoltListViewAdatokkal(megrendeloNev);

        }

        private void feltoltListViewAdatokkal(string megrendeloNev)
        {
            List<Order> megrendelesek=repo.getOrders(megrendeloNev);
            listViewRendelesek.Items.Clear();

            foreach (Order megrendeles in megrendelesek)
            {
                ListViewItem lvi = new ListViewItem(megrendeles.getOrderId().ToString());
                lvi.SubItems.Add(megrendeles.getCourierId().ToString());
                lvi.SubItems.Add(megrendeles.getCustomerId().ToString());
                lvi.SubItems.Add(megrendeles.getDate().Substring(0,13).ToString());
                lvi.SubItems.Add(megrendeles.getTime().ToString().Replace(',', ':'));
                if (megrendeles.getDone())
                    lvi.SubItems.Add("Teljesítve");
                else
                    lvi.SubItems.Add("Nem teljesítve");

                listViewRendelesek.Items.Add(lvi);

            }

            listViewRendelesek.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewRendelesek.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewRendelesek.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewRendelesek.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewRendelesek.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewRendelesek.AutoResizeColumn(5, ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void listViewRendelesek_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewRendelesek.SelectedItems.Count > 0)
            {
                dataGridViewTetelek.Visible = true;
                labelTetelek.Visible = true;
            }
            else
            {
                dataGridViewTetelek.Visible = false;
                labelTetelek.Visible = false;
            }
            


        }
    }
}
