using UnityEngine;
using UnityEngine.UI;

public class MonitorUI : MonoBehaviour
{
    [field: SerializeField] public Button moveLeftButton { get; private set; }
    [field: SerializeField] public Button moveRightButton { get; private set; }
    [field: SerializeField] public Button toggleButton { get; private set; }
    [field: SerializeField] public Button spawnButton { get; private set; }

    [field: SerializeField] public GameObject enableLabel { get; private set; }
    [field: SerializeField] public GameObject disableLabe { get; private set; }

    public void SetCubeState(bool isActive)
    {
        enableLabel.gameObject.SetActive(!isActive);
        disableLabe.gameObject.SetActive(isActive);
    }
}
