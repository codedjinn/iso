using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iso.Framework
{
    public interface IUpdatable
    {
        bool Enabled { get; set; }

        void Update(GameTime time);
    }
}
