using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public class LightModel : GameObjectModel, IGameObject
    {
        public Color Color { get; set; }
        public LightType LightType { get; set; }
        public float Intensity { get; set; }
        public float Distance { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float Angle { get ; set; }
    }
}
