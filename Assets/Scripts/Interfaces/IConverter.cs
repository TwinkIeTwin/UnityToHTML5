using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets
{
    /// <summary>
    /// Converts serialized data from unity scene to threeJS-HTML5 code.
    /// </summary>
    public interface IConverter
    {
        /// <summary>
        /// Converts serialized data from unity scene to threeJS-HTML5 code.
        /// </summary>
        /// <param name="data">serialized unity scene data.</param>
        /// <returns>threeJS HTML-5 code.</returns>
        string Convert(ISerializedData data);
    }
}
