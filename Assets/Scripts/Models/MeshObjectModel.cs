using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public class MeshObjectModel : GameObjectModel, IGameObject
    {
        public Color Color { get; set; }
        public Mesh Mesh { get; set; }
    }
}
