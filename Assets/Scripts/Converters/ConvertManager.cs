using Assets;
using Assets.Scripts.Converters;
using System;
using System.Collections.Generic;
using System.Text;

public class ConvertManager: IHtml5Converter
{
    private readonly List<IHtml5Converter> converters = new List<IHtml5Converter>()
    {
        new MeshObjectConverter(),
        new LightConverter(),
        new MainCameraConverter(),
        new GameObjectConverter(),
    };

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

        string sceneObjectsCode = agregator.ToString();

        return sceneObjectsCode;
    }
}
