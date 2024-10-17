using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChurrosInteraction : MonoBehaviour, IInteractable
{
    [SerializeField]
    private FirstPersonController playerController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        Debug.Log("Churros Interact");
        Destroy(gameObject);
        playerController.ResetStamina();
    }
}
