using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        Dictionary<string, IMeshObject> MeshObjects { get; set; }

        /// <summary>
        /// all the lights in scene (key is objectName).
        /// </summary>
        Dictionary<string, ILight> Lights { get; set; }

        /// <summary>
        /// all the objects in scene (key is objectName).
        /// </summary>
        Dictionary<string, IGameObject> GameObjects { get; set; }

        /// <summary>
        /// camera out of which we see the game scene.
        /// </summary>
        IMainCamera MainCamera {get; set;}
    }
}
