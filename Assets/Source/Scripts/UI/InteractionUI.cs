using UnityEngine;

public class InteractionUI : MonoBehaviour
{
    [SerializeField] private GameObject _interactRoot;
    [SerializeField] private GameObject _exitRoot;

    public void Redraw(bool canInteract, bool canExit)
    {
        _interactRoot.gameObject.SetActive(canInteract);
        _exitRoot.gameObject.SetActive(canExit);
    }
}
