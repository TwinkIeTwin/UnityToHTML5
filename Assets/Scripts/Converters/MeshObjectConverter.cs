using System;
using System.Text;


namespace Assets
{
    class MeshObjectConverter : IHtml5Converter
    {
        public string Convert(ISerializedData data)
        {
            if (data is null)
            {
                throw new ArgumentNullException(nameof(data), "can not be null");
            }

            var agregator = new StringBuilder(1000);

            agregator.Append($"var material = new THREE.MeshPhongMaterial({{color: 0xFFFFFF}});\n");

            foreach (var meshObject in data.MeshObjects)
            {
                string objectName = meshObject.Value.Name;
                string objectGeometryName = $"{objectName}Geometry";

                agregator.Append($"var {objectGeometryName} = new THREE.BoxGeometry(1, 1, 1);\n");
                agregator.Append($"var {objectName} = new THREE.Mesh({objectGeometryName}, material);\n\n");
            }

            return agregator.ToString();
        }
    }
}
