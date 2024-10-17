using UnityEngine;

public class ExitDoor : MonoBehaviour, IInteractable
{
    private bool _isOpen;

    private float _closedRotation;
    public float openRotation = 90f;
    private float _openedRotation;
    private GameObject controller;

    private void Start()
    {
        _closedRotation = transform.eulerAngles.y;
        _openedRotation = _closedRotation + openRotation;
    }
    
    public void Interact()
    {
        if (!_isOpen && controller != null)
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
