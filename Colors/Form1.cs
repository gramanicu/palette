using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Colors
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (TextBox t in this.Controls.OfType<TextBox>())      //Adaugam o functie fiecarui textbox din form1 ("this")
            {
                t.TextChanged += Schimba_Culoarea;        //Pentru evenimentul de schimbare a textului, atribuim functia de mai jos
            }
        }

        private void Schimba_Culoarea(object sender, EventArgs e)
        {
            int ok=1;
            int[] c = new int[4];
            foreach (TextBox t in this.Controls.OfType<TextBox>())     //
            {                                                          //
                try                                                    //
                {                                                      //
                    c[t.TabIndex] = Convert.ToInt32(t.Text);           //Incercam sa salvam valorile intr-un vector . Daca esueaza transformarea, inseamna ca valoarea introdusa nu este un numar natural
                }                                                      // 
                catch { ok = 0; }                                      //
                if (c[t.TabIndex] < 0 || c[t.TabIndex] > 255) ok = 0;  //Se verifica daca este un numar valid
            }

            if (ok == 1)
            {
                this.BackColor = System.Drawing.Color.FromArgb(c[1],c[2],c[3]);                        //Setam culoarea backgroundului la cea scrisa din texbox-uri
                label6.Text = ("#" + c[1].ToString("X2") + c[2].ToString("X2") + c[3].ToString("X2")).ToLower();       //Scriem codul hexazecimal al culorii
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(label6.Text);            //Cand apasam pe labelul cu codul hex, culoarea este copiata in clipboard (ca si cum am fi dat copy)
        }

    }
}
