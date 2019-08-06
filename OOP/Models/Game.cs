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
    public class Game
    {
        private Timer tmr_Rocket, tmr_Producer, tmr_Airplane, tmr_Control;
        private ContainerControl container;
        public Gun Gun { get; set; }
        public List<Airplane> Airplanes { get; set; } = new List<Airplane>();

        public Game(ContainerControl container)
        {
            this.container = container;
            this.Gun = new Gun(container);

            tmr_Rocket = new Timer()
            {
                Enabled = true,
                Interval = 5
            };

            tmr_Rocket.Tick += Tmr_Rocket_Tick;
            tmr_Producer = new Timer()
            {
                Enabled = true,
                Interval = 1200
            };
            tmr_Producer.Tick += Tmr_Producer_Tick;
            tmr_Airplane = new Timer()
            {
                Enabled = true,
                Interval = 120
            };
            tmr_Airplane.Tick += Tmr_Airplane_Tick;
            tmr_Control = new Timer()
            {
                Enabled = true,
                Interval = 3
            };
            tmr_Control.Tick += Tmr_Control_Tick;
        }

        
        public void Resized(ContainerControl container)
        {
            this.container = container;
            Gun.Container = container;
            foreach (var ucak in Airplanes)
            {
                ucak.Container = container;
            }

            foreach (Rocket roket in Gun.Rockets)
            {
                roket.Container = container;
            }
        }

        private void Tmr_Control_Tick(object sender, EventArgs e)
        {
            foreach (Airplane airplane in Airplanes)
            {
                Rectangle ru = new Rectangle();
                Rectangle rr = new Rectangle();

                if (airplane.Picture.Location.Y + airplane.Picture.Height > container.Height - 70)
                {
                    tmr_Control.Stop();
                    tmr_Airplane.Stop();
                    tmr_Producer.Stop();
                    tmr_Rocket.Stop();
                }

                ru.Location = airplane.Picture.Location;
                ru.Width = airplane.Picture.Width;
                ru.Height = airplane.Picture.Height;
                bool IsShot = false;
                foreach (Rocket rocket in Gun.Rockets)
                {
                    rr.Location = rocket.Picture.Location;
                    rr.Width = rocket.Picture.Width;
                    rr.Height = rocket.Picture.Height;

                 
                    if (rocket.Picture.Bounds.IntersectsWith(airplane.Picture.Bounds))
                    {
                        IsShot = true;
                        container.Controls.Remove(airplane.Picture);
                        container.Controls.Remove(rocket.Picture);
                        Airplanes.Remove(airplane);
                        Gun.Rockets.Remove(rocket);
                        SoundPlayer soundPlayer = new SoundPlayer(Properties.Resources.bomb_small);
                        soundPlayer.Play();
                        break;
                    }
                }
                if (IsShot) break;
            }

            foreach (Rocket rocket in Gun.Rockets)
            {
                if (rocket.Picture.Location.Y < 0)
                {
                    Gun.Rockets.Remove(rocket);
                    this.container.Controls.Remove(rocket.Picture);
                    break;
                }
            }
        }

        Random rnd = new Random();

        private void Tmr_Producer_Tick(object sender, System.EventArgs e)
        {
            Point konum = new Point(rnd.Next(20, container.Width - 70), 20);
            Airplane airplane = new Airplane(konum, this.container);
            Airplanes.Add(airplane);
        }

        private void Tmr_Rocket_Tick(object sender, System.EventArgs e)
        {
            foreach (IMove move in Gun.Rockets)
            {
                move.Move(Directions.Up);
            }
        }

        private void Tmr_Airplane_Tick(object sender, EventArgs e)
        {
            foreach (IMove airplane in Airplanes)
            {
                airplane.Move(Directions.Down);
            }
        }
    }
}
