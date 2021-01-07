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
    /// used for containing camera out of which we see the scene.
    /// </summary>
    public interface IMainCamera : IGameObject
    {
        /// <summary>
        /// field of view (in rads)
        /// </summary>
        float FieldOfView { get; set; }
    }
}
