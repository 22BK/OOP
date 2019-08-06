using OOP.Enums;
using OOP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Game game;
       
        private void Form1_Resize(object sender, EventArgs e)
        {
            game?.Resized(this);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && game == null)
                game = new Game(this);
            else if (e.KeyCode == Keys.Left)
                game?.Gun.Move(Directions.Left);
            else if (e.KeyCode == Keys.Right)
                game?.Gun.Move(Directions.Rigth);
            else if (e.KeyCode == Keys.Space)
                game?.Gun.Fire();
        }
    }
}
