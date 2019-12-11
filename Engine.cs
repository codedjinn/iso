using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iso
{
    public class Engine
    {
        private ContentManager _content;

        public ContentManager Content 
        { 
            get
            {
                return _content;
            }
            set
            {
                if (_content != null)
                {
                    throw new Exception("Content already set");
                }
                _content = value;
            }
        }

        private static Engine _instance;
        public static Engine Instance
        {   get
            {
                if (_instance == null)
                {
                    _instance = new Engine();
                }
                return _instance;
            }
        }
    }
}
