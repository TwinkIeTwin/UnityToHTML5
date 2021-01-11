using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interfaces
{
    /// <summary>
    /// used for all the objects which can be placed on scene.
    /// </summary>
    public interface IGameObject : IDimensional
    {
        string Name { get; set; }

        /// <summary>
        /// name of parent object.
        /// </summary>
        string ParentName { get; set; }

        /// <summary>
        /// children objects of this object.
        /// </summary>
        List<IGameObject> Children { get; set; }
    }
}
