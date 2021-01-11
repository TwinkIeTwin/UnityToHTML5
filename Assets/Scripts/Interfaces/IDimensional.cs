using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    /// <summary>
    /// used for objects which can be placed in space.
    /// </summary>
    public interface IDimensional
    {
        /// <summary>
        /// position of the scene object.
        /// </summary>
        Vector3 Position { get; set; }

        /// <summary>
        /// rotation of the scene object.
        /// </summary>
        Vector3 Rotation { get; set; }

        /// <summary>
        /// scale of the scene object.
        /// </summary>
        Vector3 Scale { get; set; }
    }
}
