using Assets.Scripts.Interfaces;
using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Serializers
{
    public sealed class SerializedData : ISerializedData
    {
        public SerializedData()
        {
            MeshObjects = new Dictionary<string, IMeshObject>();

            Lights = new Dictionary<string, ILight>();

            GameObjects = new Dictionary<string, IGameObject>();

            MainCamera = new MainCameraModel();
        }

        public IMainCamera MainCamera { get; set; }
        public Dictionary<string, IMeshObject> MeshObjects { get; set; }
        public Dictionary<string, ILight> Lights { get; set; }
        public Dictionary<string, IGameObject> GameObjects {get; set;}
    }
}
