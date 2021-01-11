using Assets.Scripts.Interfaces;
using System;
using System.Text;
using ValueToStringExtension;

namespace Assets.Scripts.Converters
{
    class GameObjectConverter : IHtml5Converter
    {
        public string Convert(ISerializedData data)
        {
            if (data is null)
            {
                throw new ArgumentNullException(nameof(data), "can not be null");
            }

            var agregator = new StringBuilder(10000);

            foreach (var gameObject in data.GameObjects)
            {
                IGameObject value = gameObject.Value;
                string objectName = gameObject.Value.Name;
                string parentObjectName = value.ParentName is null ? "scene" : value.ParentName;

                AddPositionCode(value, agregator);
                AddRotationCode(value, agregator);
                agregator.Append($"{objectName}.scale.set({value.Scale.x.ToInvariantString()}, {value.Scale.y.ToInvariantString()}, {value.Scale.z.ToInvariantString()});\n");
                agregator.Append($"{parentObjectName}.add({objectName});\n\n");
            }

            return agregator.ToString();
        }

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

            string axisRotationName = $"{gameObject.Name}RotationAxis";
            string convertedAxisRotationName = $"{gameObject.Name}ConvertedRotationAxis";

            agregator.Append($"\nvar {axisRotationName} = new THREE.Vector3({gameObject.RotationAxis.x.ToInvariantString()}, {gameObject.RotationAxis.y.ToInvariantString()}, {gameObject.RotationAxis.z.ToInvariantString()});\n");
            agregator.Append($"var {convertedAxisRotationName} = convertUnityRotationAxis({axisRotationName});\n");

            agregator.Append($"{gameObject.Name}.rotateOnWorldAxis({convertedAxisRotationName}, convertUnityAngle({gameObject.RotationAngle.ToInvariantString()}));\n");
        }

        private void AddPositionCode(IGameObject gameObject, StringBuilder agregator)
        {
            if (gameObject is null)
            {
                throw new ArgumentNullException(nameof(gameObject), "can not be null");
            }

            if (agregator is null)
            {
                throw new ArgumentNullException(nameof(agregator), "can not be null");
            }

            string unityPositionName = $"{gameObject.Name}UnityPosition";
            string convertedPositionName = $"{gameObject.Name}ConvertedPosition";

            agregator.Append($"\nvar {unityPositionName} = new THREE.Vector3({gameObject.Position.x.ToInvariantString()}, {gameObject.Position.y.ToInvariantString()}, {gameObject.Position.z.ToInvariantString()});\n"); ;
            agregator.Append($"var {convertedPositionName} = convertUnityPosition({unityPositionName});\n");
            agregator.Append($"{gameObject.Name}.position.set({convertedPositionName}.x, {convertedPositionName}.y, {convertedPositionName}.z);\n");
        }
    }
}
