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
    public class Rocket : GameBase, IMove
    {
        //properties of rocket
        public Rocket(Point point, ContainerControl container) : base(container)
        {
            Picture = new PictureBox()
            {
                Size = new Size(28, 36),
                Image = Properties.Resources.rocket,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = point
            };
            container.Controls.Add(Picture);
        }
        //direction of rocket
        public void Move(Directions direction)
        {
            if (direction == Directions.Up)
            {
                Picture.Location = new Point()
                {
                    X = Picture.Location.X,
                    Y = Picture.Location.Y - 6
                };
            }
            else
            {
                throw new Exception("Error when rocket going up");
            }
        }
    }
}
