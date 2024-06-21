using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Config/GameConfig")]
public class GameConfig : ScriptableObject
{
    [field: Header("Monitor")]
    [field: SerializeField] public float interactionRange { get; private set; }
    [field: SerializeField] public float cameraTransitionDuration { get; private set; }

    [field: Header("Cube interaction")]
    [field: SerializeField] public float cubeJumpForce { get; private set; }
    [field: SerializeField] public float cubeMoveOffset { get; private set; }
    [field: SerializeField] public float cubeJumpDuration { get; private set; }

    [field: Header("Items spawn")]
    [field: SerializeField] public Vector2 objectSizeRange { get; private set; }
    [field: SerializeField] public float spawnDelay { get; private set; }
    [field: SerializeField] public List<GameObject> objectsToSpawn { get; private set; }
}

