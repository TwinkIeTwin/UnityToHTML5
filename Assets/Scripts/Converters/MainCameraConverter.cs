using System;
using System.Text;
using ValueToStringExtension;

namespace Assets
{
    class MainCameraConverter : IHtml5Converter
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
