using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Space_Defender.Repositories
{
    public class TextureRepository : Repository<Texture2D>
    {
        private static readonly string[] searchPattern = new[] {"*.png", "*.jpg"};
 
        public override void Load(ContentManager contentManager)
        {
            loadAllTextures(contentManager);
        }

        /// <summary>
        /// Throws exception if name is null or two files have same name, eg pic1.png and pic1.jpg
        /// </summary>
        /// <param name="contentManager"></param>
        private void loadAllTextures(ContentManager contentManager)
        {
            var directory = new DirectoryInfo(contentManager.RootDirectory);
            var fileInfoArray = searchPattern.SelectMany(pattern => directory.GetFiles(pattern, SearchOption.AllDirectories));
            foreach (var fileInfo in fileInfoArray)
            {
                var name = Path.GetFileNameWithoutExtension(fileInfo.Name);
                add(name, contentManager.Load<Texture2D>(name));
            }
        }
    }
}
