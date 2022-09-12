using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VacuumClean : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cheese"))
        {
            other.gameObject.GetComponent<CheeseDestroy>().DestroyCheese();
        }
   
    }
}
