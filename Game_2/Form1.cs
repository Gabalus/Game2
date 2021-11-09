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
    public partial class Form1 : Form
    {
        



        private Dictionary<int, Color> playersColor = new Dictionary<int, Color> { { 1, Color.DeepSkyBlue }, { 2, Color.Red }, { 3, Color.DarkGreen }, { 4, Color.YellowGreen}, { 5, Color.Violet }, { 6, Color.Brown }, { 7, Color.Orange }, { 8, Color.Gray } };
        private Dictionary<int, string> playersColorRu = new Dictionary<int, string> { { 1, "Синий" }, { 2, "Красный" }, { 3, "Зеленый" }, { 4, "Салатовый" }, { 5, "Фиолетовый" }, { 6, "Коричневый" }, { 7, "Коричневый" }, { 8, "Серый" } };
        private FieldButton[,] field_b;
        private GameSettings gamesettings;
        private GameLogic gamelogic;
        private GameController gamecontroller;

        private GameAI[] gameAIarray;
        
            

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
            gamesettings = GameSettings.instance();

            
            
            

        }
        private void StartGame()
        {

            FormPlayers formPlayers = new FormPlayers();
            if (formPlayers.ShowDialog() == DialogResult.Cancel)
            {
               


                gamelogic = new GameLogic(gamesettings.countPlayers, gamesettings.widthField, gamesettings.heightField);
                gamecontroller = new GameController(gamelogic);
                gameAIarray = new GameAI[9];
                for (int i = 1; i < 9; i++)
                {
                    if (!gamesettings.categoryPlayers[i])
                    {
                        gameAIarray[i] = new GameAI(gamelogic, gamecontroller, i);
                    }
                }
                
                field_b = new FieldButton[gamesettings.widthField, gamesettings.heightField];
                
               
            }
            for (int x = 0; x < gamesettings.widthField; x++)
            {
                for (int y = 0; y < gamesettings.heightField; y++)
                {
                    FieldButton fieldButton = new FieldButton();
                    fieldButton.Location = new Point(x * 30, y * 30 + 30);
                    fieldButton.Size = new Size(30, 30);
                    fieldButton.x = x;
                    fieldButton.y = y;
                    Controls.Add(fieldButton);
                    fieldButton.MouseUp += new MouseEventHandler(FieldButtonClick);
                    field_b[x, y] = fieldButton;
                }
            }
            ShowField(gamesettings.widthField, gamesettings.heightField);
            label1.Text = $"Ходит {playersColorRu[gamecontroller.currentPlayerID]} игрок";
            AiStep();

            if (!gamecontroller.EndGame())
            {
                label1.Text = $"Ходит {playersColorRu[gamecontroller.currentPlayerID]} игрок";
                ShowField(gamesettings.widthField, gamesettings.heightField);
            }
            else
            {
                ShowField(gamesettings.widthField, gamesettings.heightField);
                MessageBox.Show("Game over!");
            }
        

    }

        private void ShowField(int width, int height)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (gamelogic.field.field[i,j] != null )
                    {
                        field_b[i, j].BackColor = playersColor[gamelogic.field.field[i, j].playerID];
                        field_b[i, j].Text = gamelogic.field.field[i, j].weight.ToString();
                    }
                }
            }
        }
        private void FieldButtonClick (object sender, MouseEventArgs e)
        {
            
            FieldButton wasClicked = (FieldButton)sender;
            if (e.Button == MouseButtons.Left)
            {
                if (gamesettings.categoryPlayers[gamecontroller.currentPlayerID])
                {


                    if (!gamecontroller.NextPlayer(wasClicked.x, wasClicked.y, gamecontroller.currentPlayerID))
                    {
                        MessageBox.Show("Ход невозможен");
                    }
                    else
                    {
                        if (!gamecontroller.EndGame())
                        {
                            label1.Text = $"Ходит {playersColorRu[gamecontroller.currentPlayerID]} игрок";
                            ShowField(gamesettings.widthField, gamesettings.heightField);
                        }
                        else
                        {
                            ShowField(gamesettings.widthField, gamesettings.heightField);
                            MessageBox.Show("Game over!");
                        }
                    }
                    
                }
                
            }

            AiStep();

            if (!gamecontroller.EndGame())
            {
                label1.Text = $"Ходит {playersColorRu[gamecontroller.currentPlayerID]} игрок";
                ShowField(gamesettings.widthField, gamesettings.heightField);
            }
            else
            {
                ShowField(gamesettings.widthField, gamesettings.heightField);
                MessageBox.Show("Game over!");
            }
        }
        private void AiStep()
        {
            if (!gamesettings.categoryPlayers[gamecontroller.currentPlayerID])
            {
                MessageBox.Show("Ход ИИ");
                gameAIarray[gamecontroller.currentPlayerID].AICapturing();
                ShowField(gamesettings.widthField, gamesettings.heightField);
            }
        }

        private void X8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gamesettings.widthField = 8;
            gamesettings.heightField = 8;
            размерПоляToolStripMenuItem.Enabled = false;
            количествоИгроковToolStripMenuItem.Visible = true;
        }

        private void X16ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gamesettings.widthField = 16;
            gamesettings.heightField = 16;
            размерПоляToolStripMenuItem.Enabled = false;
            количествоИгроковToolStripMenuItem.Visible = true;
        }

        private void X32ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gamesettings.widthField = 32;
            gamesettings.heightField = 32;
            размерПоляToolStripMenuItem.Enabled = false;
            количествоИгроковToolStripMenuItem.Visible = true;
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            gamesettings.countPlayers = 1;
            количествоИгроковToolStripMenuItem.Visible = false;
            StartGame();
            
        }

        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            gamesettings.countPlayers = 2;
            количествоИгроковToolStripMenuItem.Visible = false;
            StartGame();
        }

        private void ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            gamesettings.countPlayers = 3;
            количествоИгроковToolStripMenuItem.Visible = false;
            StartGame();
        }

        private void ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            gamesettings.countPlayers = 4;
            количествоИгроковToolStripMenuItem.Visible = false;
            StartGame();
        }

        private void ToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            gamesettings.countPlayers = 5;
            количествоИгроковToolStripMenuItem.Visible = false;
            StartGame();
        }

        private void ToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            gamesettings.countPlayers = 6;
            количествоИгроковToolStripMenuItem.Visible = false;
            StartGame();
        }

        private void ToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            gamesettings.countPlayers = 7;
            количествоИгроковToolStripMenuItem.Visible = false;
            StartGame();
        }

        private void ToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            gamesettings.countPlayers = 8;
            количествоИгроковToolStripMenuItem.Visible = false;
            StartGame();
        }
    }
}
