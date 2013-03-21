using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Space_Defender.Repositories
{
    public class TextureRepository : Repository<Texture2D>
    {
        private static readonly string[] searchPattern = new[] {"*.png", "*.jpg"};

        private readonly string contentDirectory;
        public TextureRepository() : this(string.Empty){}

        public TextureRepository(string directory)
        {
            contentDirectory = directory;
        }

        public override void Load(ContentManager contentManager)
        {
            var oldRootDirectory = contentManager.RootDirectory;
            contentManager.RootDirectory = string.IsNullOrEmpty(contentDirectory) ? oldRootDirectory : contentDirectory;
            loadAllTextures(contentManager);
            contentManager.RootDirectory = oldRootDirectory;
        }

        private void loadAllTextures(ContentManager contentManager)
        {
            
            var directory = new DirectoryInfo(contentManager.RootDirectory);
            var xmlDocument = loadTextureMap(directory);
            var xmlTextureElements = getTextureElements(xmlDocument);
            foreach (var xmlTextureElement in xmlTextureElements)
            {
                add(xmlTextureElement.Attribute("key").Value, contentManager.Load<Texture2D>(xmlTextureElement.Attribute("fileName").Value));
            }

            //var fileInfoArray = searchPattern.SelectMany(pattern => directory.GetFiles(pattern, SearchOption.AllDirectories));
            //foreach (var fileInfo in fileInfoArray)
            //{
            //    var name = Path.GetFileNameWithoutExtension(fileInfo.Name);
            //    add(name, contentManager.Load<Texture2D>(name));
            //}
        }

        private XDocument loadTextureMap(DirectoryInfo directory)
        {
            return XDocument.Load(directory.FullName + Path.DirectorySeparatorChar + "TextureMap.xml");
        }

        private IEnumerable<XElement> getTextureElements(XDocument xmlDocument)
        {
            return xmlDocument.Root.Elements();
        }
    }
}
