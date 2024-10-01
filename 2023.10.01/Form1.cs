using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2023._10._01
{
    public partial class Form1 : Form
    {
        databasehandler db;

        public Form1()
        {
            InitializeComponent();
           
            start();
        }
        void ok()
        {
            label1.Text = "nev";
            label2.Text = "mennyiseg";
            label3.Text = "ár";
        }
        int index;
        void start()
        {
            databasehandler db = new databasehandler();
            db.Readall();
            ok();
            
            foreach (pekaruk item in pekaruk.pekaruks)
            {
                listBox1.Items.Add(item.name);
            }

            listBox1.SelectedIndexChanged += (s, e) =>
            {
                index = listBox1.SelectedIndex;
            };

            button1.Click += (s, e) =>
            {
                pekaruk newaru = new pekaruk();
                newaru.name = textBox1.Text;
                newaru.amount = Convert.ToInt32(textBox2.Text);
                newaru.price = Convert.ToInt32(textBox3.Text);
                db.write(newaru);
              
                listBox1.Items.Add(newaru.name);
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";

            };

            button2.Click += (s, e) =>
            {

                if (listBox1.SelectedIndex >=0)
                {
                    db.delete(pekaruk.pekaruks[index]);
                    listBox1.Items.RemoveAt(index);
                }
               

            };

        }
        
    }
}
