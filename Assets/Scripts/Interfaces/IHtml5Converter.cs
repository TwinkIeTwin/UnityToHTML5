namespace Assets
{
    /// <summary>
    /// Converts serialized data from unity scene to threeJS-HTML5 code.
    /// </summary>
    public interface IHtml5Converter
    {
        /// <summary>
        /// Converts serialized data from unity scene to threeJS-HTML5 code.
        /// </summary>
        /// <param name="data">serialized unity scene data.</param>
        /// <returns>threeJS HTML-5 code.</returns>
        string Convert(ISerializedData data);
    }
}
