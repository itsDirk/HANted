using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInteraction : MonoBehaviour, IInteractable
{
    public bool HasController = false;
    public void Interact()
    {
        HasController = true;
        gameObject.SetActive(false);
    }
}
