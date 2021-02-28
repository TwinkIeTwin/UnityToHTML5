using Assets.Scripts.Interfaces;
using Assets.Scripts.Models;
using Assets.Scripts.Serializers;
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
    class MeshObjectSerializer : ISerializer
    {
        public void Serialize(ISerializedData data)
        {
            if (data is null)
            {
                throw new ArgumentNullException(nameof(data), "can not be null");
            }

            foreach (var gameObject in SceneManager.GetActiveScene().GetRootGameObjects())
            {
                AddAllChildrenGameObjects(gameObject);
            }

            void AddAllChildrenGameObjects(GameObject gameObject)
            {
                bool isCamera = gameObject.TryGetComponent(out Camera _);
                bool isLight = gameObject.TryGetComponent(out Light _);

                bool isMeshObject = !isCamera && !isLight;

                if (isMeshObject)
                {
                    var meshObjectData = GetMeshObjectData(gameObject);
                    string name = gameObject.GetVariableName();
                    data.MeshObjects.Add(name, meshObjectData);
                    data.GameObjects.Add(name, meshObjectData);
                }

                foreach (Transform child in gameObject.GetComponentInChildren<Transform>())
                {
                    AddAllChildrenGameObjects(child.gameObject);
                }
            }
        }

        private MeshObjectModel GetMeshObjectData(GameObject gameObject)
            => new MeshObjectModel
            {
                Color = gameObject.GetComponent<MeshRenderer>().sharedMaterial.color,
            };
    }
}
