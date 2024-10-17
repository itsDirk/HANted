using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] GameObject flashlight;
    [SerializeField] GameObject flashlightCollider;
    public bool flashlightActive = false;
    // Start is called before the first frame update
    void Start()
    {
        flashlight.gameObject.SetActive(false);
        flashlightCollider.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (flashlightActive == false)
            {
                flashlight.gameObject.SetActive(true);
                flashlightCollider.gameObject.SetActive(true);
                flashlightActive = true;
            }
            else
            {
                flashlight.gameObject.SetActive(false);
                flashlightCollider.gameObject.SetActive(false);
                flashlightActive = false;
            }
        }
    }
}
