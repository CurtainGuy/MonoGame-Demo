using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer2D.Core.Game
{
    public static class MouseHelper
    {
        static PlatformerGame platformerGame;

        public static void Initialize(PlatformerGame game)
        {
            platformerGame = game;
        }

        public static Vector2 TranslateMousePointToGamePosition(MouseState mouseState)
        {
            return Vector2.Transform(mouseState.Position.ToVector2(), platformerGame.globalTransformation);
        }
    }
}
