using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueToStringExtension;

namespace Assets.Scripts.Converters
{
    class GameObjectConverter : IConverter
    {
        private const string rotationMethod =   "\nfunction rotateAroundWorldAxis(object, axis, radians) {\n" +
                                                "\trotWorldMatrix = new THREE.Matrix4();\n" +
                                                "\trotWorldMatrix.makeRotationAxis(axis.normalize(), radians);\n" +
                                                "\trotWorldMatrix.multiply(object.matrix);\n" +
                                                "\tobject.matrix = rotWorldMatrix;\n" +
                                                "\tobject.rotation.setFromRotationMatrix(object.matrix);\n" +
                                                "}\n" +
                                                "var xAxis = new THREE.Vector3(1, 0, 0);\n" +
                                                "var yAxis = new THREE.Vector3(0, 1, 0);\n" +
                                                "var zAxis = new THREE.Vector3(0, 0, 1);\n\n";
        public string Convert(ISerializedData data)
        {
            if (data is null)
            {
                throw new ArgumentNullException(nameof(data), "can not be null");
            }

            var agregator = new StringBuilder(10000);

            agregator.Append(rotationMethod);

            foreach (var gameObject in data.GameObjects)
            {
                IGameObject value = gameObject.Value;
                string objectName = gameObject.Value.Name;
                string parentObjectName = value.ParentName is null ? "scene" : value.ParentName;

                agregator.Append($"{objectName}.position.set({value.Position.x.ToInvariantString()}, {value.Position.y.ToInvariantString()}, {value.Position.z.ToInvariantString()});\n");
                AddRotationCode(value, agregator);
                agregator.Append($"{objectName}.scale.set({value.Scale.x.ToInvariantString()}, {value.Scale.y.ToInvariantString()}, {value.Scale.z.ToInvariantString()});\n");
                agregator.Append($"{parentObjectName}.add({objectName});\n\n");
            }

            return agregator.ToString();
        }

        // rotation in threeJS is not around global axis as in unity, but around local, so we need to rotate them with out special method
        // to get result as in unity.
        private void AddRotationCode(IGameObject gameObject, StringBuilder agregator)
        {
            if (gameObject is null)
            {
                throw new ArgumentNullException(nameof(gameObject), "can not be null");
            }

            if (agregator is null)
            {
                throw new ArgumentNullException(nameof(agregator), "can not be null");
            }

            agregator.Append($"rotateAroundWorldAxis({ gameObject.Name}, xAxis, { gameObject.Rotation.x.ToInvariantString()});\n");
            agregator.Append($"rotateAroundWorldAxis({ gameObject.Name}, yAxis, { gameObject.Rotation.y.ToInvariantString()});\n");
            agregator.Append($"rotateAroundWorldAxis({ gameObject.Name}, zAxis, { gameObject.Rotation.z.ToInvariantString()});\n");
        }
    }
}
