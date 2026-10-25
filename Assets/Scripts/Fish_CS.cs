// Includes : 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fish_CS : Knockable_CS
{
    // Member Data : 
    public UnityEvent UEvent;

    private void Start()
    {
        if (UEvent == null)
        {
            UEvent = new UnityEvent();
        }
    }

    // Death :
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor") == true && collision.gameObject != Table)
        {
            UEvent.Invoke();
            Destroy(gameObject);
        }
    }
}
