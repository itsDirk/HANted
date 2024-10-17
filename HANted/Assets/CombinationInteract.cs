using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationInteract : MonoBehaviour, IInteractable
{
    [SerializeField]
    private int CorrectNumber;
    public int CurrentNumber = 0;

    public void Interact()
    {
        transform.Rotate(0,90f,0);
        CurrentNumber++;
        if ( CurrentNumber == 4 )
        {
            CurrentNumber = 0;
        }
    }

    public bool IsCorrect()
    {
        return CorrectNumber == CurrentNumber;
    }
}
