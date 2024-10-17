using UnityEngine;
using Quaternion = System.Numerics.Quaternion;

public class Door : MonoBehaviour
{
    private bool _isOpen;

    private float _closedRotation;
    public float openRotation = 90f;
    private float _openedRotation;

    private void Start()
    {
        _closedRotation = transform.eulerAngles.y;
        _openedRotation = _closedRotation + openRotation;
    }
    
    public void ToggleDoor()
    {
        if (!_isOpen)
        {
            OpenDoor();
        }
        else
        {
            CloseDoor();
        }
    }

    private void OpenDoor()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, _openedRotation, transform.eulerAngles.z);
        
        _isOpen = true;
    }

    private void CloseDoor()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, _closedRotation, transform.eulerAngles.z);

        _isOpen = false;
    }
}
