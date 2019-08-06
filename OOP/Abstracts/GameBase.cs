using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP.Abstracts
{
    public abstract class GameBase
    {
        public PictureBox Picture { get; set; } = new PictureBox();
        public ContainerControl Container { get; set; }

        protected readonly ContainerControl container;

        protected GameBase(ContainerControl container)
        {
            this.container = container;
            this.Container = container;
        }
    }
}
