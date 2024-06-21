using UnityEngine;

[CreateAssetMenu(fileName ="GameConfig", menuName ="Config/GameConfig")]
public class GameConfig : ScriptableObject
{
    [field: SerializeField] public float interactionRange { get; private set; }
    [field: SerializeField] public float cameraTransitionDuration { get; private set; }
}

