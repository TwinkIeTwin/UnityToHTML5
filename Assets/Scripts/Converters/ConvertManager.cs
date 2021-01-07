using Assets;
using Assets.Scripts.Converters;
using Assets.Scripts.Helpers;
using Assets.Scripts.Serializers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConvertManager : MonoBehaviour, IConverter
{
    private readonly List<IConverter> converters = new List<IConverter>()
    {
        new MeshObjectConverter(),
        new LightConverter(),
        new MainCameraConverter(),
        new GameObjectConverter(),
    };

    /// <summary>
    /// converts current unity scene to threeJS-HTML-5 scene.
    /// </summary>
    [MenuItem("Export/to HTML5")]
    public static void ConvertToHtml5()
    {
        var convertManager = new ConvertManager();

        var sceneSerialer = new SceneSerializer();
        var serializedData = new SerializedData();
      
        sceneSerialer.Serialize(serializedData);
        string sceneObjectsCode = convertManager.GetSceneObjectsCode(serializedData);

        string fullHtmlCode = convertManager.GetFullHtmlCode(sceneObjectsCode, serializedData);
        DirectoryHelper.SaveHtmlScene(fullHtmlCode);

        Debug.Log($"exporting to html 5 complete at: {DirectoryHelper.HtmlFilePath}");
    }

    public string Convert(ISerializedData data)
    {
        if (data is null)
        {
            throw new ArgumentNullException(nameof(data), "can not be null");
        }

        StringBuilder agregator = new StringBuilder(10000);
        foreach (var converter in converters)
        {
            agregator.Append(converter.Convert(data));
        }

        return agregator.ToString();
    }

    private string GetFullHtmlCode(string sceneCode, ISerializedData data)
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

    private string GetSceneObjectsCode(ISerializedData data)
    {
        if (data is null)
        {
            throw new ArgumentNullException(nameof(data), "can not be null");
        }

        StringBuilder agregator = new StringBuilder(10000);
        foreach (var converter in converters)
        {
            agregator.Append(converter.Convert(data));
        }

        return agregator.ToString();
    }
}
