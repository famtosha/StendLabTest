using UnityEngine;

public class InteractionComponent : MonoBehaviour
{
    [field: SerializeField] public Transform targetCameraPoint { get; private set; }

    [SerializeField] private Outline _outline;

    private void Awake()
    {
        SetOutlineState(false);
    }

    public void SetOutlineState(bool state)
    {
        _outline.enabled = state;
    }
}
