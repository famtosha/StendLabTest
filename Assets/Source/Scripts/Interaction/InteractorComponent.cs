using DG.Tweening;
using UnityEngine;

public class InteractorComponent : MonoBehaviour
{
    [SerializeField] private GameConfig _config;

    [SerializeField] private FirstPersonController _controller;
    [SerializeField] private InteractionUI _ui;

    private InteractionComponent _activeInteraction;
    private InteractionComponent _pointedInteraction;

    private bool interactionButtonPressed => Input.GetMouseButtonDown(0);
    private bool exitButtonPressed => Input.GetKeyDown(KeyCode.Space);

    private Vector3 _originalCameraLocalPosition;
    private Vector3 _lastCameraRotation;

    private void Awake()
    {
        _originalCameraLocalPosition = _controller.playerCamera.transform.localPosition;
    }

    private void Update()
    {
        if (_activeInteraction == null) FindInteraction();
        TryInteract();
        _ui.Redraw(_pointedInteraction != null && _activeInteraction == null, _activeInteraction != null);
    }

    private void TryInteract()
    {
        if (_activeInteraction == null)
        {
            if (_pointedInteraction != null && interactionButtonPressed)
            {
                _activeInteraction = _pointedInteraction;
                _activeInteraction.SetOutlineState(false);
                _controller.enabled = false;
                _controller.playerCamera.transform.DoTransform(_activeInteraction.targetCameraPoint, _config.cameraTransitionDuration);
                _lastCameraRotation = _controller.playerCamera.transform.localRotation.eulerAngles;
            }
        }
        else
        {
            if (exitButtonPressed)
            {
                _controller.playerCamera.transform.DOLocalRotate(_lastCameraRotation, _config.cameraTransitionDuration);
                _controller.playerCamera.transform
                    .DOLocalMove(_originalCameraLocalPosition, _config.cameraTransitionDuration)
                    .OnComplete(() =>
                    {
                        _activeInteraction.SetOutlineState(true);
                        _activeInteraction = null;
                        _controller.enabled = true;
                    });
            }
        }
    }

    private void FindInteraction()
    {
        var cameraTransform = _controller.playerCamera.transform;
        var origin = cameraTransform.position;
        var direction = cameraTransform.forward;

        if (Physics.Raycast(origin, direction, out var hit, _config.interactionRange) &&
            hit.collider.gameObject.TryGetComponent(out InteractionComponent currentInteraction))
        {
            if (_pointedInteraction != currentInteraction)
            {
                _pointedInteraction = currentInteraction;
                _pointedInteraction.SetOutlineState(true);
            }
        }
        else
        {
            if (_pointedInteraction != null)
            {
                _pointedInteraction.SetOutlineState(false);
                _pointedInteraction = null;
            }
        }
    }
}
