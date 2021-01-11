using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Models
{
    class MeshObjectModel : GameObjectModel, IMeshObject
    {
        public Color Color { get; set; }
        public Mesh Mesh { get; set; }
    }
}
