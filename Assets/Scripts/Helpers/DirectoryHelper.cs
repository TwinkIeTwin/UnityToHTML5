using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Helpers
{
    /// <summary>
    /// contains methods to work with files and directories.
    /// </summary>
    public static class DirectoryHelper
    {
        private static string outputPath;

        private static string htmlFilePath;

        /// <summary>
        /// path of the output directory.
        /// </summary>
        public static string OutputPath
        {
            get
            {
                if (outputPath is null)
                {
                    outputPath = GetOutputPath();
                }

                return outputPath;
            }
        }
        /// <summary>
        /// path of result output html file.
        /// </summary>
        public static string HtmlFilePath
        {
            get
            {
                if (htmlFilePath is null)
                {
                    htmlFilePath = System.IO.Path.Combine(outputPath, "index.html");
                }

                return htmlFilePath;
            }
        }

        /// <summary>
        /// deletes outputfiles if they already exist.
        /// </summary>
        public static void ClearOutputDirectory()
        {
            if (File.Exists(HtmlFilePath))
            {
                File.Delete(htmlFilePath);
            }
        }

        /// <summary>
        /// creates output directory.
        /// </summary>
        public static void CreateOutputDirectory()
        {
            string path = OutputPath;

            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }

            ClearOutputDirectory();
        }

        /// <summary>
        /// saves all given data in output html file.
        /// </summary>
        /// <param name="fullHtmlCode">data to save.</param>
        public static void SaveHtmlScene(string fullHtmlCode)
        {
            if (fullHtmlCode is null)
            {
                throw new ArgumentNullException(nameof(fullHtmlCode), "can not be null");
            }

            CreateOutputDirectory();

            using (var outputFile = new System.IO.StreamWriter(System.IO.File.Create(htmlFilePath)))
            {
                outputFile.WriteLine(fullHtmlCode);
            }
        }

        private static string GetOutputPath()
            => new System.IO.DirectoryInfo(Application.dataPath).CreateSubdirectory($"{SceneManager.GetActiveScene().name} - HTML5").FullName;

    }
}
