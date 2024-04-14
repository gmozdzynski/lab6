using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab6
{
    public partial class Form2 : Form
    {
        private Form1 form1;
        public Form2(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }
        

        private void label6_Click(object sender, EventArgs e)
        {
            
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            
                if (!int.TryParse(textBox1.Text, out int x) || x < 3 || x > 10)
                {
                    MessageBox.Show("Wprowadziłeś nieprawidłową wartość dla X (dopuszczalne wartości 3-10).", "Błąd wartości", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(textBox2.Text, out int y) || y < 3 || y > 10)
                {
                    MessageBox.Show("Wprowadziłeś nieprawidłową wartość dla Y (dopuszczalne wartości 3-10).", "Błąd wartości", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(textBox3.Text, out int dydelfy) || dydelfy < 1 || dydelfy > 6)
                {
                    MessageBox.Show("Wprowadziłeś nieprawidłową wartość dla dydelfów (dopuszczalne wartości 1-6).", "Błąd wartości", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(textBox4.Text, out int krokodyle) || krokodyle < 0 || krokodyle > 1)
                {
                    MessageBox.Show("Wprowadziłeś nieprawidłową wartość dla krokodyli (dopuszczalne wartości 0-1).", "Błąd wartości", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(textBox5.Text, out int czas) || czas < 10 || czas > 60)
                {
                    MessageBox.Show("Wprowadziłeś nieprawidłową wartość dla czasu (dopuszczalne wartości 10-60 sekund).", "Błąd wartości", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                form1.X = x;
                form1.Y = y;
                form1.czas = czas;
                form1.krokodyle = krokodyle;
                form1.dydelfy = dydelfy;

                this.Close();
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
