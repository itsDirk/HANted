using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable
{
    public void Interact();
}

public class Interactor : MonoBehaviour
{
    [SerializeField]
    private Transform InteractorSource;
    [SerializeField]
    private float InteractRange = 1f;

    public void Interact()
    {
        Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
        {
            Debug.Log(hitInfo.collider.name);
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                interactObj.Interact();
            }
        }
    }

    public void MouseInteract()
    {
        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(r, out RaycastHit hitInfo))
        {
            Debug.Log(hitInfo.collider.name);
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                interactObj.Interact();
            }
        }
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            MouseInteract();
            // Interact();
        }
        
    }
}
