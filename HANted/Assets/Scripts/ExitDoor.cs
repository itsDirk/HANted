using UnityEngine;

public class ExitDoor : MonoBehaviour, IInteractable
{
    private bool _isOpen;

    private float _closedRotation;
    public float openRotation = 90f;
    private float _openedRotation;
    [SerializeField]
    private ControllerInteraction controller;

    private void Start()
    {
        _closedRotation = transform.eulerAngles.y;
        _openedRotation = _closedRotation + openRotation;
    }
    
    public void Interact()
    {
        if (!_isOpen && controller.HasController)
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, _openedRotation, transform.eulerAngles.z);
        
        _isOpen = true;
    }
}
