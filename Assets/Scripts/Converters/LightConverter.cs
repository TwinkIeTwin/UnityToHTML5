using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using ValueToStringExtension;

namespace Assets
{
    class LightConverter : IConverter
    {
        public string Convert(ISerializedData data)
        {
            if (data is null)
            {
                throw new ArgumentNullException(nameof(data), "can not be null");
            }

            var agregator = new StringBuilder(1000);
            foreach (var light in data.Lights.Select(u => u.Value))
            {
                switch (light.LightType)
                {
                    case LightType.Directional:
                        agregator.Append($"var {light.Name} = new THREE.DirectionalLight( 0x{ColorUtility.ToHtmlStringRGB(light.Color)}, {light.Intensity.ToInvariantString()} );\n\n");
                        agregator.Append($"setLightDirection({light.Name}, new THREE.Vector3({light.RotationAxis.x}, {light.RotationAxis.y}, {light.RotationAxis.z}))");
                        break;
                    case LightType.Point:
                        agregator.Append($"var {light.Name} = new THREE.PointLight( 0x{ColorUtility.ToHtmlStringRGB(light.Color)}, {light.Intensity.ToInvariantString()}, {light.Distance.ToInvariantString()}, 3);\n\n");
                        break;
                    case LightType.Area:
                        agregator.Append($"var {light.Name} = new THREE.RectAreaLight( 0x{ColorUtility.ToHtmlStringRGB(light.Color)}, {light.Intensity.ToInvariantString()}, {light.Width.ToInvariantString()}, {light.Height.ToInvariantString()} );\n\n");
                        break;
                    case LightType.Spot:
                        agregator.Append($"var {light.Name} = new THREE.SpotLight( 0x{ColorUtility.ToHtmlStringRGB(light.Color)}, {light.Intensity.ToInvariantString()}, {light.Distance.ToInvariantString()}, {light.Angle.ToInvariantString()}, 0.5, 3 );\n\n");
                        break;
                }
            }
            return agregator.ToString();
        }
    }
}
