using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using ValueToStringExtension;

namespace Assets
{
    class MeshObjectConverter : IConverter
    {
        public string Convert(ISerializedData data)
        {
            if (data is null)
            {
                throw new ArgumentNullException(nameof(data), "can not be null");
            }

            var agregator = new StringBuilder(1000);

            foreach (var meshObject in data.MeshObjects)
            {
                IMeshObject value = meshObject.Value;
                string objectName = meshObject.Value.Name;
                string objectGeometryName = $"{objectName}Geometry";
                string objectMaterialName = $"{objectName}Material";

                agregator.Append($"var {objectGeometryName} = new THREE.BoxGeometry(1, 1, 1);\n");
                agregator.Append($"var {objectMaterialName} = new THREE.MeshPhongMaterial({{color: 0x{ColorUtility.ToHtmlStringRGB(value.Color)}}});\n");
                agregator.Append($"var {objectName} = new THREE.Mesh({objectGeometryName}, {objectMaterialName});\n\n");
            }

            return agregator.ToString();
        }
    }
}
