using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace Space_Defender.Repositories
{
    public abstract class Repository<T>
    {
        private readonly Dictionary<string, T> contentDictionary = new Dictionary<string, T>(); 
        
        public T this[string id]
        {
            get
            {
                return contentDictionary[id];
            }
        }

        protected void add(string key, T value)
        {
            contentDictionary.Add(key, value);
        }

        public abstract void Load(ContentManager contentManager);
    }
}
