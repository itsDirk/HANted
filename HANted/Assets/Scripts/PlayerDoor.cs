using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoor : MonoBehaviour
{
    [Header("Radius")]
    public float canOpenRadius = .8f;

    private Ray _playerAimRay;
    private PlayerDoorGenerated _playerDoorGenerated;

    private void OnEnable()
    {
        _playerDoorGenerated = new PlayerDoorGenerated();
        _playerDoorGenerated.Enable();
    }
    
    private void OnDisable()
    {
        _playerDoorGenerated.Disable();
    }

    void Start()
    {
        _playerAimRay = new Ray(transform.position, transform.forward);
    }
    
    void Update() 
    {
        if (CanOpenDoor())
        {
            Debug.Log("opening door");
        }
    }

    private bool CanOpenDoor()
    {
        if(Physics.Raycast(_playerAimRay, out RaycastHit hit, canOpenRadius) && _playerDoorGenerated.PlayerDoor.PlayerDoor.triggered)
        {
            if (hit.transform.tag.Equals("Door"))
            {
                return true;
            }
        }

        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 direction = transform.TransformDirection(Vector3.forward) * canOpenRadius;
        Gizmos.DrawRay(transform.position, direction);
    }
}
