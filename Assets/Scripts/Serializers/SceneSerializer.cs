using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Serializers
{
    /// <summary>
    /// Serialize all the objects in unity scene.
    /// </summary>
    public sealed class SceneSerializer : ISerializer
    {
        private readonly List<ISerializer> serializers = new List<ISerializer>() 
        {
            new MeshObjectSerializer(),
            new LightSerializer(),
            new MainCameraSerializer(),
            new GameObjectSerializer()
        };

        public void Serialize(ISerializedData data)
        {
            if (data is null)
            {
                throw new ArgumentNullException(nameof(data), "can not be null");
            }

            foreach (var serializer in serializers)
            {
                serializer.Serialize(data);
            }
        }
    }
}
