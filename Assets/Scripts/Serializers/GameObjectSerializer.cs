using Assets.Scripts.Interfaces;
using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using ValueToStringExtension;

namespace Assets.Scripts.Serializers
{
    class GameObjectSerializer : ISerializer
    {
        public void Serialize(ISerializedData data)
        {
            if (data is null)
            {
                throw new ArgumentNullException(nameof(data), "can not be null");
            }

            // serialize all the objects in scene
            foreach (var gameObject in SceneManager.GetActiveScene().GetRootGameObjects())
            {
                SerializeAllChilds(gameObject);
            }

            void SerializeAllChilds(GameObject gameObject)
            {
                if (gameObject is null)
                {
                    throw new ArgumentNullException(nameof(gameObject), "can not be null");
                }

                SetGameObjectData(gameObject);

                foreach (Transform child in gameObject.GetComponentInChildren<Transform>())
                {
                    SerializeAllChilds(child.gameObject);
                }
            }

            // finds objects by it's name and sets every property (as IGameObject) to correct representation in threeJS
            void SetGameObjectData(GameObject gameObject)
            {
                if (gameObject is null)
                {
                    throw new ArgumentNullException(nameof(gameObject), "can not be null");
                }

                string name = gameObject.GetVariableName();
                IGameObject gameObjectData = data.GameObjects[name];
                
                gameObjectData.Name = name;
                gameObjectData.ParentName = gameObject.transform.parent != null ? gameObject.transform.parent.gameObject.GetVariableName() : null;

                gameObject.transform.localRotation.ToAngleAxis(out float rotationAngle, out Vector3 rotationAxis);
                gameObjectData.RotationAxis = rotationAxis;
                gameObjectData.RotationAngle = rotationAngle;

                gameObjectData.Position = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
                gameObjectData.Scale = gameObject.transform.localScale;
            }
        }
    }
}
