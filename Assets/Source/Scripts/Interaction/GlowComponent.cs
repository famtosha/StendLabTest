using UnityEngine;

public class GlowComponent : MonoBehaviour
{
    [SerializeField] private MeshRenderer _targetRenderer;

    private Material _material;

    private int _emmisionID = Shader.PropertyToID("_EmissionColor");

    private Color _originalColor;

    private bool _isGlowing;
    public bool isGlowing
    {
        get => _isGlowing;
        set
        {
            _isGlowing = value;
            _material.SetColor(_emmisionID, value ? _originalColor : Color.black);
        }
    }

    private void Awake()
    {
        _material = _targetRenderer.material;
        _originalColor = _material.GetColor(_emmisionID);
        isGlowing = true;
    }
}
