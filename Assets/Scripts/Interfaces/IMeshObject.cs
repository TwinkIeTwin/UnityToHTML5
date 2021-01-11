using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    /// <summary>
    /// used for scene objects that have mesh.
    /// </summary>
    public interface IMeshObject : IGameObject
    {
        /// <summary>
        /// color of material.
        /// </summary>
        Color Color { get; set; }
    }
}
