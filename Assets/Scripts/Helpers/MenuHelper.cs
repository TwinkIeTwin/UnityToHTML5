using Assets.Scripts.Serializers;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Helpers
{
    /// <summary>
    /// contains method for unity menu items.
    /// </summary>
    public static class MenuHelper
    {
        /// <summary>
        /// converts current unity scene to threeJS-HTML-5 scene.
        /// </summary>
        [MenuItem("Export/to HTML5")]
        public static void ExportToHtml5()
        {
            var convertManager = new ConvertManager();

            var sceneSerializer = new SceneSerializer();
            var serializedData = new SerializedData();

            sceneSerializer.Serialize(serializedData);

            string sceneCode = convertManager.Convert(serializedData);
            string fullHtmlCode = HTML5Generator.HtmlPageCode(sceneCode, serializedData);

            DirectoryHelper.SaveHtmlScene(fullHtmlCode);

            Debug.Log($"exporting to html 5 complete at: {DirectoryHelper.HtmlFilePath}");
        }
    }
}
