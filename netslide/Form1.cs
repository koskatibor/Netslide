using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using netslide.Properties;

namespace netslide
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //items
            pictureBox1.Image = Image.FromFile(@"pics\7.png");
            pictureBox2.Image = Image.FromFile(@"pics\9.png");
            pictureBox3.Image = Image.FromFile(@"pics\4.png");
            pictureBox4.Image = Image.FromFile(@"pics\3.png");
            pictureBox5.Image = Image.FromFile(@"pics\11.png");
            pictureBox6.Image = Image.FromFile(@"pics\2.png");
            pictureBox7.Image = Image.FromFile(@"pics\5.png");
            pictureBox8.Image = Image.FromFile(@"pics\0.png");
            pictureBox9.Image = Image.FromFile(@"pics\2.png");
            comboBox1.SelectedIndex = 7;
            comboBox2.SelectedIndex = 9;
            comboBox3.SelectedIndex = 4;
            comboBox4.SelectedIndex = 3;
            comboBox5.SelectedIndex = 11;
            comboBox6.SelectedIndex = 2;
            comboBox7.SelectedIndex = 5;
            comboBox8.SelectedIndex = 0;
            comboBox9.SelectedIndex = 2;

            pictureBox22.Visible = true;

            pictureBox10.Visible = true;
            pictureBox16.Visible = true;
            pictureBox13.Visible = true;
            pictureBox19.Visible = true;
            comboBox10.SelectedIndex = 1;
            comboBox11.SelectedIndex = 2;
            comboBox12.SelectedIndex = 1;
            comboBox13.SelectedIndex = 0;
            comboBox14.SelectedIndex = 0;
            comboBox15.SelectedIndex = 1;
            comboBox16.SelectedIndex = 0;
            comboBox17.SelectedIndex = 0;

            checkBox1.Checked = true;
            checkBox1.Visible = false;
            label5.Visible = false;

        }

        int[] square_combobox_indexes;
        int middle;
        int[] wall_combobox_indexes = new int[8];
        Boolean wall_around;

        Node root;
        private void button1_Click(object sender, EventArgs e)
        {
            square_combobox_indexes = new int[]{ comboBox1.SelectedIndex, comboBox2.SelectedIndex, comboBox3.SelectedIndex,
                 comboBox4.SelectedIndex, comboBox6.SelectedIndex, comboBox7.SelectedIndex,
                  comboBox8.SelectedIndex, comboBox9.SelectedIndex };

            middle = comboBox5.SelectedIndex;

            wall_combobox_indexes = new int[]{ comboBox10.SelectedIndex, comboBox11.SelectedIndex, comboBox12.SelectedIndex,
                comboBox13.SelectedIndex, comboBox14.SelectedIndex, comboBox15.SelectedIndex, comboBox16.SelectedIndex
            ,comboBox17.SelectedIndex};

            wall_around = checkBox1.Checked ? true : false;

            try
            {
                //items
                pictureBox1.Image = Image.FromFile(@"pics\" + comboBox1.SelectedIndex + ".png");
                pictureBox2.Image = Image.FromFile(@"pics\" + comboBox2.SelectedIndex + ".png");
                pictureBox3.Image = Image.FromFile(@"pics\" + comboBox3.SelectedIndex + ".png");
                pictureBox4.Image = Image.FromFile(@"pics\" + comboBox4.SelectedIndex + ".png");
                pictureBox5.Image = Image.FromFile(@"pics\" + comboBox5.SelectedIndex + ".png");
                pictureBox6.Image = Image.FromFile(@"pics\" + comboBox6.SelectedIndex + ".png");
                pictureBox7.Image = Image.FromFile(@"pics\" + comboBox7.SelectedIndex + ".png");
                pictureBox8.Image = Image.FromFile(@"pics\" + comboBox8.SelectedIndex + ".png");
                pictureBox9.Image = Image.FromFile(@"pics\" + comboBox9.SelectedIndex + ".png");

                //walls
                switch (comboBox10.SelectedIndex)
                {
                    case 0: { pictureBox10.Visible = false; pictureBox12.Visible = false; break; }
                    case 1: { pictureBox10.Visible = true; pictureBox12.Visible = false; break; }
                    case 2: { pictureBox12.Visible = true; pictureBox10.Visible = false; break; }
                }

                switch (comboBox11.SelectedIndex)
                {
                    case 0: { pictureBox11.Visible = false; pictureBox13.Visible = false; break; }
                    case 1: { pictureBox11.Visible = true; pictureBox13.Visible = false; break; }
                    case 2: { pictureBox13.Visible = true; pictureBox11.Visible = false; break; }
                }

                switch (comboBox12.SelectedIndex)
                {
                    case 0: { pictureBox14.Visible = false; pictureBox16.Visible = false; break; }
                    case 1: { pictureBox16.Visible = true; pictureBox14.Visible = false; break; }
                    case 2: { pictureBox14.Visible = true; pictureBox16.Visible = false; break; }
                }

                switch (comboBox13.SelectedIndex)
                {
                    case 0: { pictureBox15.Visible = false; pictureBox17.Visible = false; break; }
                    case 1: { pictureBox17.Visible = true; pictureBox15.Visible = false; break; }
                    case 2: { pictureBox15.Visible = true; pictureBox17.Visible = false; break; }
                }

                switch (comboBox14.SelectedIndex)
                {
                    case 0: { pictureBox18.Visible = false; break; }
                    case 1: { pictureBox18.Visible = true; break; }
                }

                switch (comboBox15.SelectedIndex)
                {
                    case 0: { pictureBox19.Visible = false; break; }
                    case 1: { pictureBox19.Visible = true; break; }
                }

                switch (comboBox16.SelectedIndex)
                {
                    case 0: { pictureBox20.Visible = false; break; }
                    case 1: { pictureBox20.Visible = true; break; }
                }

                switch (comboBox17.SelectedIndex)
                {
                    case 0: { pictureBox21.Visible = false; break; }
                    case 1: { pictureBox21.Visible = true; break; }
                }

                pictureBox22.Visible = checkBox1.Checked ? true : false;
            }
            catch(Exception)
            {
                ;
            }
            root = new Node(square_combobox_indexes, null);
            root.NewGame();
            label3.Text = "Új játék létrehozva!";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Node Perfect_State;
            label3.Text = "Lépés-fa felépítése...";
            label3.Refresh();

            //Fa felépítése
            root.Difficulty(wall_combobox_indexes);
            root.BuildTree();

            label3.Text = "A fa felépült. Megoldás keresése...";
            label3.Refresh();
            
            Perfect_State = root.SolveIt(wall_around, middle, wall_combobox_indexes);
                Console.WriteLine(Perfect_State.id);
                label5.Text = "Keresés által átnézett Node-ok: " + Perfect_State.getLepesek();
                label5.Visible = true;
            if (Perfect_State == null)
            {
                label3.Text = "Nem találtam megoldást.";
            }
            else
            {                
                label3.Text = "Megoldva.";
            }

            try
            {
                //items
                pictureBox1.Image = Image.FromFile(@"pics\" + Perfect_State.state[0] + ".png");
                pictureBox2.Image = Image.FromFile(@"pics\" + Perfect_State.state[1] + ".png");
                pictureBox3.Image = Image.FromFile(@"pics\" + Perfect_State.state[2] + ".png");
                pictureBox4.Image = Image.FromFile(@"pics\" + Perfect_State.state[3] + ".png");
                pictureBox6.Image = Image.FromFile(@"pics\" + Perfect_State.state[4] + ".png");
                pictureBox7.Image = Image.FromFile(@"pics\" + Perfect_State.state[5] + ".png");
                pictureBox8.Image = Image.FromFile(@"pics\" + Perfect_State.state[6] + ".png");
                pictureBox9.Image = Image.FromFile(@"pics\" + Perfect_State.state[7] + ".png");
            }
            catch
            {
                ;
            }
        }
    }
}
