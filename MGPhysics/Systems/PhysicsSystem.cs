﻿using MGPhysics.Components;
using System;
using System.Collections.Generic;
namespace MGPhysics.Systems
{
    public static class PhysicsSystem
    {
        /// <summary>
        /// Moves an object and checks for collission on it
        /// </summary>
        /// <param name="entityKey">The entity to move</param>
        /// <param name="positions">Dictionary on entity positions</param>
        /// <param name="hitBoxes">Dictionary on entity hit boxes</param>
        /// <param name="velocity">Velocity of the entity</param>
        public static void MoveEntity(int entityKey, IntVector velocity, ref Dictionary<int, IntVector> positions, Dictionary<int, IntVector> hitBoxes)
        {
            IntVector position = positions[entityKey];
            IntVector hitbox = hitBoxes[entityKey];
            IntVector adjustedPosition = positions[entityKey] + velocity;

            foreach (KeyValuePair<int, IntVector> entity in positions)
            {
                if (entity.Key == entityKey)
                    continue;

                if (!hitBoxes.ContainsKey(entity.Key))
                    continue;

                IntVector entityPosition = entity.Value;
                IntVector entityHitBox = hitBoxes[entity.Key];

                if (entityPosition.X + entityHitBox.X / 2 > adjustedPosition.X - hitbox.X / 2
                    && entityPosition.X - entityHitBox.X / 2 < adjustedPosition.X + hitbox.X / 2
                    && entityPosition.Y + entityHitBox.Y / 2 > adjustedPosition.Y - hitbox.Y / 2
                    && entityPosition.Y - entityHitBox.Y / 2 < adjustedPosition.Y + hitbox.Y / 2)
                {
                    int distX = Math.Abs(Math.Abs(position.X) - Math.Abs(entityPosition.X)) - entityHitBox.X / 2;
                    int distY = Math.Abs(Math.Abs(position.Y) - Math.Abs(entityPosition.Y)) - entityHitBox.Y / 2;

                    Console.WriteLine("X_collider: " + positions[entityKey].X + " Y_collider: " + positions[entityKey].Y);
                    Console.WriteLine("X_collided: " + entity.Value.X + " Y_collided: " + entity.Value.Y);
                    Console.WriteLine("distance X: " + distX + " Distance Y: " + distY);

                    if (distX >= distY)
                    {
                        if (velocity.X > 0)
                            adjustedPosition.X = entityPosition.X - entityHitBox.X / 2 - hitbox.X / 2;
                        else
                            adjustedPosition.X = entityPosition.X + entityHitBox.X / 2 + hitbox.X / 2;
                    }

                    if (distX <= distY)
                    {
                        if (velocity.Y > 0)
                            adjustedPosition.Y = entityPosition.Y - entityHitBox.Y / 2 - hitbox.Y / 2;
                        else
                            adjustedPosition.Y = entityPosition.Y + entityHitBox.Y / 2 + hitbox.Y / 2;
                    }
                }
            }
            positions[entityKey] = adjustedPosition;
        }
    }
}
