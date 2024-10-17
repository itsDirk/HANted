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
        _playerAimRay.origin = transform.position;

        if (Input.GetKeyDown(KeyCode.E))
        {
            DetectDoor();
        }
    }

    private void DetectDoor()
    {
       
        if(Physics.Raycast(_playerAimRay, out RaycastHit hit, canOpenRadius))
        {
            Debug.Log("Hit: ");

            if (hit.transform.tag.Equals("Door"))
            {
                if (hit.transform.GetComponent<Door>() != null)
                {
                    Debug.Log("Door is not null");
                    hit.transform.GetComponent<Door>().ToggleDoor();
                }
                else { 
                    Debug.Log("Door is null");
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 direction = transform.TransformDirection(Vector3.forward) * canOpenRadius;
        Gizmos.DrawRay(transform.position, direction);
    }
}
