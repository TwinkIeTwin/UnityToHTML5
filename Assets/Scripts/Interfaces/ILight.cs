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
    /// used for lighting scene objects.
    /// </summary>
    public interface ILight : IGameObject
    {
        /// <summary>
        /// color of light.
        /// </summary>
        Color Color { get; set; }

        /// <summary>
        /// type of light.
        /// </summary>
        LightType LightType { get; set; }

        /// <summary>
        /// how strong light is, value is beetween 0 and 1.
        /// </summary>
        float Intensity { get; set; }

        /// <summary>
        /// how far light can shine.
        /// </summary>
        float Distance { get; set; }

        /// <summary>
        /// width of rectangle light (for area light only).
        /// </summary>
        float Width { get; set; }

        /// <summary>
        /// height of rectangle light (for area light only).
        /// </summary>
        float Height { get; set; }

        /// <summary>
        /// angle (in rads) of lighting shine (for spot light only).
        /// </summary>
        float Angle { get; set; }
    }
}
