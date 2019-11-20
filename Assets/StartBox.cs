using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBox : MonoBehaviour
{
    public Rigidbody player;
    public GameObject racetimer;

    private void OnTriggerEnter(Collider trigger)
    {
        racetimer.SetActive(true); 
    }
}
