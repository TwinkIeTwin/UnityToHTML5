using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets
{
    /// <summary>
    /// Serializing unity scene objects in correct for threeJS representation.
    /// </summary>
    public interface ISerializer
    {
        /// <summary>
        /// serializing data in given ISerializedData object.
        /// </summary>
        /// <param name="data">container for serialization.</param>
        void Serialize(ISerializedData data);

    }
}
