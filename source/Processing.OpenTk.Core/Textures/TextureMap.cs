using Processing.OpenTk.Core.Vectors;

namespace Processing.OpenTk.Core.Textures
{
    public class TextureMap
    {
        public readonly Texture2d Texture;
        public readonly PVector3[] UvVerticies;

        public TextureMap(Texture2d texture, PVector3[] uvVerticies)
        {
            Texture = texture;
            UvVerticies = uvVerticies;
        }
    }
}
