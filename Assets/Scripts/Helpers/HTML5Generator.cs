using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Helpers
{
    /// <summary>
    /// contains method for creating HTML5 output file.
    /// </summary>
    public static class HTML5Generator
    {
        /// <summary>
        /// creates output html5 page.
        /// </summary>
        /// <param name="sceneCode">threeJS code.</param>
        /// <param name="data">data with scene objects.</param>
        /// <returns>code of html5 generated page.</returns>
        public static string HtmlPageCode(string sceneCode, ISerializedData data)
            => "<!DOCTYPE html>\n" +
                "<html>\n" +
                "<head>\n" +
                "<meta charset = \"utf-8\">\n" +
                "<title>Luna playable v 0.00001</title>\n" +
                "<style>\n" +
                "body { margin: 0; padding: 0; }\n" +
                "canvas { width: 100 %; height: 100 %; }\n" +
                "</style>\n" +
                "</head>\n" +
                "<body>\n" +
                "<script src = \"https://threejs.org/build/three.min.js\" ></script>\n" +
                "<script src = \"https://raw.githack.com/TwinkIeTwin/UnityDataToThreeJS/main/unityDataToThreeJSConverter.js\" ></script>\n" +
                "<script>\n" +
                "var WIDTH = window.innerWidth;\n" +
                "var HEIGHT = window.innerHeight;\n" +
                "var renderer = new THREE.WebGLRenderer({ antialias:true });\n" +
                "renderer.setSize(WIDTH, HEIGHT);\n" +
                "renderer.setClearColor(0x000000, 1);\n" +
                "document.body.appendChild(renderer.domElement);\n" +
                "var scene = new THREE.Scene();\n\n" +
                $"{sceneCode}" +
                "function render() {\n" +
                "\trequestAnimationFrame(render);\n" +
                $"\trenderer.render(scene, {data.MainCamera.Name});\n" +
                "}\n" +
                "render();\n" +
                "</script>\n" +
                "</body>\n" +
                "</html>\n";
    }
}
