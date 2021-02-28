using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using ValueToStringExtension;

namespace Assets
{
    class LightSerializer : ISerializer
    {
        public void Serialize(ISerializedData data)
        {
            if (data is null)
            {
                throw new ArgumentNullException(nameof(data), "can not be null");
            }

            foreach (var gameObject in SceneManager.GetActiveScene().GetRootGameObjects())
            {
                AddAllChildrenLights(gameObject);
            }

            void AddAllChildrenLights(GameObject gameObject)
            {
                (bool isLight, LightModel lightData) = TryGetLightData(gameObject);

                if (isLight)
                {
                    string name = gameObject.GetVariableName();
                    data.Lights.Add(name, lightData);
                    data.GameObjects.Add(name, lightData);
                }

                foreach (Transform child in gameObject.GetComponentInChildren<Transform>())
                {
                    AddAllChildrenLights(child.gameObject);
                }
            }
        }

        private (bool isLight, LightModel lightData) TryGetLightData(GameObject gameObject)
        {
            if (gameObject is null)
            {
                throw new ArgumentNullException(nameof(gameObject), "can not be null");
            }

            bool isLight = gameObject.TryGetComponent(out Light light);

            return isLight ? (true, GetLightData(light)) : (false, null);
        }
        
        private LightModel GetLightData(Light light)
            => new LightModel()
            {
                LightType = light.type,
                Color = light.color,
                Intensity = light.intensity,
                Angle = light.spotAngle * Mathf.Deg2Rad,
                Height = light.areaSize.x,
                Width = light.areaSize.y,
                Distance = light.range,
            };
    }
}
