using OOP.Abstracts;
using OOP.Enums;
using OOP.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP.Models
{
    public class Gun : GameBase, IMove, IFire
    {
        private const int unit=20;
        //properties of gun
        public Gun(ContainerControl container) : base(container)
        {
            Picture = new PictureBox()
            {
                Size = new Size(83, 83),
                Image = Properties.Resources.gun,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = new System.Drawing.Point(container.Size.Width / 2 -41, container.Size.Height-125)
            };
            container.Controls.Add(Picture);

        }

        // rockets of gun
        public List<Rocket> Rockets { get; set; } = new List<Rocket>();
        public void Fire()
        {
            Point point = new Point()
            {
                X = Picture.Location.X + 30,
                Y = Picture.Location.Y - 30
            };
            Rocket rocket = new Rocket(point, base.container);
            Rockets.Add(rocket);
            SoundPlayer soundPlayer = new SoundPlayer(Properties.Resources.AWP_Ates);
            soundPlayer.Play();
        }

        //directions of gun
        public void Move(Directions direction)
        {
            switch (direction)
            {
                case Directions.Left:
                    if (Picture.Location.X > 20)
                        Picture.Location = new Point(Picture.Location.X - unit, Picture.Location.Y);
                    break;
                case Directions.Rigth:
                    if (Picture.Location.X < container.Size.Width - 120)
                        Picture.Location = new Point(Picture.Location.X + unit, Picture.Location.Y);
                    break;
                default:
                    SystemSounds.Beep.Play();
                    throw new Exception("Gun can only moving rigth or left");
            }
        }
    }
}
