using System.Security.Cryptography.X509Certificates;

namespace lab6
{
    public partial class Form1 : Form
    {
        public int X = 5;
        public int Y = 5;
        public int czas = 30;
        public int krokodyle = 1;
        public int dydelfy = 5;
        public Form1()
        {
            
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(czas * 1000, X, Y, krokodyle, dydelfy);
            form3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            

            
            
                this.Close();  
            
        }
    }
}
