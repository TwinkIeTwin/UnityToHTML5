using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using ValueToStringExtension;

namespace Assets.Scripts.Models
{
    class GameObjectModel : IGameObject
    {
        private string name;

        private string parentName;

        public string Name 
        {
            get => name;
            set
            {
                //Make name valid to use as js variable
                name = value?.ToValidVariableName();     
            }
        }

        public string ParentName 
        {
            get => parentName;
            set
            {
                //Make name valid to use as js variable
                parentName = value?.ToValidVariableName();
            }
        }

        public List<IGameObject> Children { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 RotationAxis { get; set; }
        public Vector3 Scale { get; set; }
        public float RotationAngle { get; set; }
    }
}
