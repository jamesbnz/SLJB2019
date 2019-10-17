using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chairlift : MonoBehaviour
{
    public Rigidbody player;
    public GameObject chairTop;

    void OnTriggerEnter(Collider trigger) 
    {
    player.transform.position = chairTop.transform.position;
    player.transform.rotation = chairTop.transform.rotation;
    }

}
