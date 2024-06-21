using DG.Tweening;
using UnityEngine;

public class MonitorComponent : MonoBehaviour
{
    [SerializeField] private GameConfig _config;
    [SerializeField] private MonitorUI _ui;
    [SerializeField] private GlowComponent _cube;
    [SerializeField] private ItemsSpawnerComponent _spawner;

    private Vector3 _originalCubePosition;

    private void Awake()
    {
        _originalCubePosition = _cube.transform.position;

        _cube.isGlowing = !_cube.isGlowing;
        _ui.SetCubeState(_cube.isGlowing);
    }

    private void OnEnable()
    {
        _ui.moveLeftButton.onClick.AddListener(MoveLeft);
        _ui.moveRightButton.onClick.AddListener(MoveRight);
        _ui.toggleButton.onClick.AddListener(ToggleCube);
        _ui.spawnButton.onClick.AddListener(ToggleSpawn);
    }

    private void OnDisable()
    {
        _ui.moveLeftButton.onClick.RemoveListener(MoveLeft);
        _ui.moveRightButton.onClick.RemoveListener(MoveRight);
        _ui.toggleButton.onClick.RemoveListener(ToggleCube);
        _ui.spawnButton.onClick.RemoveListener(ToggleSpawn);
    }

    public void Enable()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void Disable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void ToggleSpawn()
    {
        _spawner.shouldSpawn = !_spawner.shouldSpawn;
    }

    private void ToggleCube()
    {
        _cube.isGlowing = !_cube.isGlowing;
        _ui.SetCubeState(_cube.isGlowing);
    }

    private void MoveRight()
    {
        _cube.transform.DOBlendableMoveBy(Vector3.up * _config.cubeJumpForce, _config.cubeJumpDuration / 2).SetRelative();
        _cube.transform.DOBlendableMoveBy(new Vector3(_config.cubeMoveOffset, 0, 0), _config.cubeJumpDuration / 2).SetRelative()
            .OnComplete(() => _cube.transform.DOMove(_originalCubePosition, _config.cubeJumpDuration / 2));
    }

    private void MoveLeft()
    {
        _cube.transform.DOBlendableMoveBy(Vector3.up * _config.cubeJumpForce, _config.cubeJumpDuration / 2).SetRelative();
        _cube.transform.DOBlendableMoveBy(new Vector3(-_config.cubeMoveOffset, 0, 0), _config.cubeJumpDuration / 2).SetRelative()
            .OnComplete(() => _cube.transform.DOMove(_originalCubePosition, _config.cubeJumpDuration / 2));
    }
}