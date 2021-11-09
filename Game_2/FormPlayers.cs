using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_2
{
    public partial class FormPlayers : Form
    {
        GameSettings gamesettings;
        public FormPlayers()
        {
            InitializeComponent();
        }

        private void FormPlayers_Load(object sender, EventArgs e)
        {
            gamesettings = GameSettings.instance();
            for (int i = 0; i < gamesettings.countPlayers; i++)
            {
                for (int j = 0; j < gBox.Controls.Count; j++)
                {
                    if (gBox.Controls[j].TabIndex == i)
                    {
                        gBox.Controls[j].Enabled = true;
                    }
                }
            }
            
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)

                gamesettings.categoryPlayers[1] = false;

            else
                gamesettings.categoryPlayers[1] = true;
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)

                gamesettings.categoryPlayers[2] = false;

            else
                gamesettings.categoryPlayers[2] = true;
        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)

                gamesettings.categoryPlayers[3] = false;

            else
                gamesettings.categoryPlayers[3] = true;
        }

        private void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)

                gamesettings.categoryPlayers[4] = false;

            else
                gamesettings.categoryPlayers[4] = true;
        }

        private void CheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)

                gamesettings.categoryPlayers[5] = false;

            else
                gamesettings.categoryPlayers[5] = true;
        }

        private void CheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)

                gamesettings.categoryPlayers[6] = false;

            else
                gamesettings.categoryPlayers[6] = true;
        }

        private void CheckBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked)

                gamesettings.categoryPlayers[7] = false;

            else
                gamesettings.categoryPlayers[7] = true;
        }

        private void CheckBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked)

                gamesettings.categoryPlayers[8] = false;

            else
                gamesettings.categoryPlayers[8] = true;
        }
    }
}
