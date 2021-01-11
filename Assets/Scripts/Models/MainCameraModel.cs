using Assets.Scripts.Interfaces;

namespace Assets.Scripts.Models
{
    public class MainCameraModel : GameObjectModel, IGameObject
    {
        public float FieldOfView { get; set; }
    }
}
