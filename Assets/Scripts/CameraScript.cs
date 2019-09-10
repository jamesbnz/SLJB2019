using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public float cameraMoveSpeed = 12000.0f;
    public GameObject cameraFollowObj;
    Vector3 followPOS;
    public float clampAngle = 80.0f;
    public float inputSensitivity = 150.0f;
    public GameObject cameraObj;
    public GameObject playerObj;
    public float camDistX;
    public float camDistY;
    public float camDistZ;
    public float mouseX;
    public float mouseY;
    public float smoothX;
    public float smoothY;
    private float rotX = 0.0f;
    private float rotY = 0.0f;

    void Start() 
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotX = rot.x;
        rotY = rot.y;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    
    private void Update() 
    {
        mouseX = Input.GetAxis ("Mouse X");
        mouseY = Input.GetAxis ("Mouse Y");

        rotY += mouseX * inputSensitivity * Time.deltaTime;
        rotX += mouseY * inputSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp (rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler (rotX, rotY, 0.0f);
        transform.rotation = localRotation;


    }

    void LateUpdate() 
    {
        CameraUpdater ();
    }

    void CameraUpdater()
    {
        Transform target = cameraFollowObj.transform;
        
        float step = cameraMoveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards (transform.position, target.position, step);

    }

}
