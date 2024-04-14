using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab6
{
    


    public partial class Form3 : Form
    {

        private List<GameField> gameFields = new List<GameField>();
        private int fieldsX;
        private int fieldsY;
        private int numberCrocodile;
        private int numberDydelfs;
        private int seconds = 0;

        public Form3(int czas3, int x, int y, int crocodile, int dydelf)
        {
            InitializeComponent();
            timer1.Interval = czas3;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer2.Tick += new EventHandler(timer2_Tick);
            fieldsX = x;
            fieldsY = y;
            numberCrocodile = crocodile;
            numberDydelfs = dydelf;

            CreateGameBoard(x, y);
            timer1.Start();
            timer2.Start();

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            seconds++;
            label1.Text = $"Czas: {seconds}s";
        }

        private void CreateGameBoard(int x, int y)
        {
            int size = 50; 
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    var pic = new PictureBox
                    {
                        Width = size,
                        Height = size,
                        BorderStyle = BorderStyle.FixedSingle,
                        Location = new Point(j * size, i * size),
                        BackColor = Color.Gray,
                        SizeMode = PictureBoxSizeMode.StretchImage
                    };
                    pic.Click += Pic_Click;
                    this.Controls.Add(pic);

                    var field = new GameField
                    {
                        PictureBox = pic,
                        Content = FieldContent.Empty  
                    };
                    gameFields.Add(field);
                }
            }

            RandomlyAssignImages();
        }

        private void RandomlyAssignImages()
        {
            Random rand = new Random();

            for (int i = 0; i < numberDydelfs; i++) 
            {
                int index = rand.Next(gameFields.Count);
                gameFields[index].Content = FieldContent.Image1;
            }


            if (numberCrocodile == 1)
            {
                int bombIndex = rand.Next(gameFields.Count);
                gameFields[bombIndex].Content = FieldContent.Image2;
            }
        }

        private void Pic_Click(object sender, EventArgs e)
        {
            var picBox = sender as PictureBox;
            var field = gameFields.Find(f => f.PictureBox == picBox);

            if (field.Content == FieldContent.Image1)
            {
                picBox.Image = Properties.Resources.Image1;  
                picBox.Enabled = false;
            }
            else if (field.Content == FieldContent.Image2)
            {
                picBox.Image = Properties.Resources.Image2;  
                MessageBox.Show("Krokodyl!!!!! Przegrales.");
                timer1.Stop();
                timer2.Stop();
                this.Close();
            }
            else
            {
                picBox.BackColor = Color.White;  
            }

            CheckForWin();
        }

        private void CheckForWin()
        {
            if (gameFields.All(f => f.Content != FieldContent.Image1 || !f.PictureBox.Enabled))
            {
                MessageBox.Show("Brawooo!");
                timer1.Stop();
                timer2.Stop();
                this.Close();
            }
        }
    

    private void timer1_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("Koniec czasu!");
            timer1.Stop();
            timer2.Stop();
            this.Close();  
        }



    }

    public enum FieldContent
    {
        Empty,
        Image1,
        Image2
    }

    public class GameField
    {
        public PictureBox PictureBox { get; set; }
        public FieldContent Content { get; set; }
    }
}
