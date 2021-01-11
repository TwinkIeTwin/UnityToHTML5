using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    /// <summary>
    /// used for all the objects which can be placed on scene.
    /// </summary>
    public interface IGameObject
    {
        string Name { get; set; }

        /// <summary>
        /// name of parent object.
        /// </summary>
        string ParentName { get; set; }

        /// <summary>
        /// children objects of this object.
        /// </summary>
        List<IGameObject> Children { get; set; }

        /// <summary>
        /// position of the scene object.
        /// </summary>
        Vector3 Position { get; set; }

        /// <summary>
        /// axis around which rotation is happening.
        /// </summary>
        Vector3 RotationAxis { get; set; }

        /// <summary>
        /// count of degrees in rotation.
        /// </summary>
        float RotationAngle { get; set; }

        /// <summary>
        /// scale of the scene object.
        /// </summary>
        Vector3 Scale { get; set; }
    }
}
