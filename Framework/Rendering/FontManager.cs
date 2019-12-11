using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iso.Framework.Rendering
{
    public class FontManager
    {
        private Dictionary<FontType, SpriteFont> _fonts;

        protected FontManager()
        {
            _fonts = new Dictionary<FontType, SpriteFont>();
        }

        public void Initialize(ContentManager content)
        {
            var font = content.Load<SpriteFont>("Fonts/default");
            _fonts.Add(FontType.Default, font);
        }

        public SpriteFont this[FontType type]
        {
            get
            {
                return _fonts[type];
            }
        }

        private static FontManager _instance;
        public static FontManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FontManager();
                }
                return _instance;
            }
        }
    }
}
