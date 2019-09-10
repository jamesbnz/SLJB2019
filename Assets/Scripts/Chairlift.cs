using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chairlift : MonoBehaviour
{
    public Rigidbody player;
    
private void OnTriggerEnter(Collider trigger) 
{
    player.transform.position = new Vector3(4060, 1286, 3630);
    Debug.Log("Test");
}

}
