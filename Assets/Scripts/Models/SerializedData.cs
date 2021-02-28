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
            MeshObjects = new Dictionary<string, MeshObjectModel>();

            Lights = new Dictionary<string, LightModel>();

            GameObjects = new Dictionary<string, IGameObject>();

            MainCamera = new MainCameraModel();
        }

        public MainCameraModel MainCamera { get; set; }
        public Dictionary<string, MeshObjectModel> MeshObjects { get; set; }
        public Dictionary<string, LightModel> Lights { get; set; }
        public Dictionary<string, IGameObject> GameObjects {get; set;}
    }
}
