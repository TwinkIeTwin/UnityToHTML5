using Assets.Scripts.Interfaces;
using Assets.Scripts.Models;
using System.Collections.Generic;

namespace Assets
{
    /// <summary>
    /// all the scene data serialized in representation that correct fo threeJS.
    /// </summary>
    public interface ISerializedData
    {
        /// <summary>
        /// all the objects that have mesh (key is objectName).
        /// </summary>
        Dictionary<string, MeshObjectModel> MeshObjects { get; set; }

        /// <summary>
        /// all the lights in scene (key is objectName).
        /// </summary>
        Dictionary<string, LightModel> Lights { get; set; }

        /// <summary>
        /// all the objects in scene (key is objectName).
        /// </summary>
        Dictionary<string, IGameObject> GameObjects { get; set; }

        /// <summary>
        /// camera out of which we see the game scene.
        /// </summary>
        MainCameraModel MainCamera {get; set;}
    }
}
