using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using ValueToStringExtension;

namespace Assets
{
    class MainCameraConverter : IConverter
    {
        public string Convert(ISerializedData data)
        {
            if (data is null)
            {
                throw new ArgumentNullException(nameof(data), "can not be null");
            }

            var agregator = new StringBuilder();
            string objectName = data.MainCamera.Name;

            agregator.Append($"var {objectName} = new THREE.PerspectiveCamera({data.MainCamera.FieldOfView.ToInvariantString()}, WIDTH/HEIGHT);\n\n") ;
            return agregator.ToString();
        }
    }
}
