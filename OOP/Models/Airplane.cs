using OOP.Abstracts;
using OOP.Enums;
using OOP.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP.Models
{
    public class Airplane : GameBase, IMove
    {
        //properties of airplane
        public Airplane(Point point,ContainerControl container) : base(container)
        {
            Picture = new PictureBox()
            {
                Size = new Size(52, 44),
                Image = Properties.Resources.airplane,
                SizeMode=PictureBoxSizeMode.StretchImage,
                Location=point
            };
            container.Controls.Add(Picture);

        }
        //direction of airplane
        public void Move(Directions direction)
        {
            if (direction == Directions.Down)
            {
                Picture.Location = new Point()
                {
                    X = Picture.Location.X,
                    Y = Picture.Location.Y+2
                };
            }
            else
            {
                throw new Exception("Error when airplane going down");
            }
        }
    }
}
