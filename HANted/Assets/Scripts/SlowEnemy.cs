using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out EnemyScript interactObj))
            {
                print("I entered the collider");
                interactObj.SlowDown();
            }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out EnemyScript interactObj))
        {
            print("I exited out of the collider");
            interactObj.DeSLow();
        }
    }
}
