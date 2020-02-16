﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MGPhysics.Components;

namespace MGPhysics.Systems
{
    public static class RenderSystem
    {
        public static void RenderSprites(Dictionary<int, Sprite> sprites, Dictionary<int, IntVector> positions, Dictionary<int, IntVector> sizes, SpriteBatch spriteBatch)
        {
            foreach(KeyValuePair<int, Sprite> sprite in sprites)
            {
                IntVector position = new IntVector(0, 0);
                IntVector size = new IntVector(sprite.Value.Texture.Width, sprite.Value.Texture.Height);
                if (positions.ContainsKey(sprite.Key))
                    position = positions[sprite.Key];
                if (sizes.ContainsKey(sprite.Key))
                    size = sizes[sprite.Key];
                spriteBatch.Draw(sprite.Value.Texture, new Rectangle(position.X - size.X/2, position.Y - size.Y/2, size.X, size.Y), sprite.Value.ColorMask);
            }
        }
    }
}
