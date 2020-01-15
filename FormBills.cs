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

        }
        private void comboBoxMegrendelok_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxMegrendelok.SelectedIndex < 0)
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
                lvi.SubItems.Add(megrendeles.getDate().ToString());
                lvi.SubItems.Add(megrendeles.getTime().ToString());
                lvi.SubItems.Add(megrendeles.getDone().ToString());

                listViewRendelesek.Items.Add(lvi);

            }
        }
    }
}
