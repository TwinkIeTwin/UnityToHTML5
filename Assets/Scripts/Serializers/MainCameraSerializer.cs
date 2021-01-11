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
    class MainCameraSerializer : ISerializer
    {
        public void Serialize(ISerializedData data)
        {
            if (data is null)
            {
                throw new ArgumentNullException(nameof(data), "can not be null");
            }

            string name = Camera.main.gameObject.GetVariableName();
            data.MainCamera.FieldOfView = Camera.main.fieldOfView;

            data.GameObjects.Add(name, data.MainCamera);
        }
    }
}
