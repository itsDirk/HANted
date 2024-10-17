using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockHandler : MonoBehaviour
{
    private bool Open = false;
    private bool DoOnce = true;

    [SerializeField]
    GameObject Shaft;

    [SerializeField]
    List<CombinationInteract> NumberLocks; 

    // Update is called once per frame
    void Update()
    {
        foreach (CombinationInteract Lock in NumberLocks)
        {
            Open = true;
            if (!Lock.IsCorrect())
            {
                Open = false;
                break;
            }
        }
        if (Open && DoOnce)
        {
            Shaft.transform.Rotate(0,-90f,0);
            DoOnce = false;
        }
    }
}
