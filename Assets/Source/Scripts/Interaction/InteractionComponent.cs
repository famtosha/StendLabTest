using UnityEngine;

public class InteractionComponent : MonoBehaviour
{
    [field: SerializeField] public Transform targetCameraPoint { get; private set; }

    [SerializeField] private Outline _outline;

    [SerializeField] private MonitorComponent _monitor;

    private void Awake()
    {
        SetOutlineState(false);
        SetState(false);
    }

    public void SetOutlineState(bool state)
    {
        _outline.enabled = state;
    }

    public void SetState(bool state)
    {
        if (state)
        {
            _monitor.Enable();
        }
        else
        {
            _monitor.Disable();
        }
    }
}
