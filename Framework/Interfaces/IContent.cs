using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iso.Framework
{
    public interface IContent
    {
        void Load(ContentManager content);

        bool ContentLoaded { get; set; }
    }
}
