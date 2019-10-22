﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Bunni.Resources.Modules
{
    public class Entity
    {
        private List<Component> Components = new List<Component>();
        private List<Property> Properties = new List<Property>();

        public bool OnScreen { get; set; }
        public bool Active { get; set; } = true;
        public bool Visible { get; set; } = true;
        
        /// <summary>
        /// Used to add a component to an entity
        /// </summary>
        /// <param name="component">The component to add</param>
        public void AddComponent(Component component)
        {
            Components.Add(component);
            component.ComponentAdded();
        }

        /// <summary>
        /// Used to remove a component from the entity. This will delete the component.
        /// </summary>
        /// <param name="component">The component to remove</param>
        public void RemoveComponent(Component component)
        {
            Components.Remove(component);
        }

        /// <summary>
        /// Returns component that belongs to entity of given type
        /// </summary>
        /// <typeparam name="T">The type of component to get</typeparam>
        /// <returns>The component if it exists, else it returns false</returns>
        public T GetComponent<T>() where T : Component
        {
            foreach(var c in Components)
            {
                if(c is T)
                {
                    return c as T;
                }
            }
            return null;
        }

        /// <summary>
        /// Adds propery to entity
        /// </summary>
        /// <param name="p">The property to add</param>
        public void AddProperty(Property p)
        {
            Properties.Add(p);
            p.PropertyAdded();
        }

        /// <summary>
        /// Removes property from entity
        /// </summary>
        /// <param name="p">The property to remove</param>
        public void RemoveProperty(Property p)
        {
            Properties.Remove(p);
        }

        /// <summary>
        /// Returns property that belongs to entity of given type
        /// </summary>
        /// <typeparam name="T">The type of property to get</typeparam>
        /// <returns>The property if it exists, else it returns false</returns>
        public T GetProperty<T>() where T : Property
        {
            foreach(var p in Properties)
            {
                if(p is T)
                {
                    return p as T;
                }
            }
            return null;
            
        }

        /// <summary>
        /// Fired before Update
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void PreUpdate(GameTime gameTime, Scene scene)
        {
            foreach (Component component in Components)
            {
                component.PreUpdate(gameTime, scene);
            }
        }

        /// <summary>
        /// Fire after PreUpdate but before PostUpdate. Do all main logic here
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Update(GameTime gameTime, Scene scene)
        {
            foreach (Component component in Components)
            {
                component.Update(gameTime, scene);
            }
        }

        /// <summary>
        /// Fired after Update
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void PostUpdate(GameTime gameTime, Scene scene)
        {
            foreach (Component component in Components)
            {
                component.PostUpdate(gameTime, scene);
            }
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (Component component in Components)
            {
                component.Draw(gameTime, spriteBatch);
            }
        }
    }
}
