﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

//using System.IO.Ports;


public class Controller : MonoBehaviour
{
    float tilt;
    public AudioSource _boardNoise, _windNoise;

    public float turnStrength = .1f;

    Vector3 velocity;
    Vector3 localVel;
    float curDir = 0f;
    Vector3 curNormal = Vector3.up;
    float distGround, distGroundL, distGroundR;
    float boardDeltaY;
    public float jumpForce;
    public float shuffleForce;
    public float airRotateX;
    public float airRotateY;
    Vector3 forwardvector;
    private Vector2 input;
    public float rotationValue;


    Rigidbody rg;
    public ParticleSystem ps;
    ParticleSystem.EmissionModule pe;
    public Transform R, L;
    public Trail prefabTrail;
    public float trailWidth = 0.3f;

    int lastTrailId = -1;
    Trail trail;
    
    private void Start()
    {
        pe = ps.emission;
        curDir = transform.rotation.eulerAngles.y;
        rg = GetComponent<Rigidbody>();
        trail = Instantiate(prefabTrail, Vector3.zero, Quaternion.identity);
    }

    Vector3 normalGround, posGround;

    Vector3 localRot;
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.P)) Application.CaptureScreenshot(System.DateTime.Now.Date.Minute+".png",4);

        forwardvector = Vector3.forward;

        tilt = Input.GetAxis("Horizontal");

        if (Physics.Raycast(L.position, -curNormal, out hit))
        {
            posGround = hit.point;
            distGroundL = hit.distance;
            normalGround = hit.normal;
        }
        if (Physics.Raycast(R.position, -curNormal, out hit))
        {
            posGround = (posGround + hit.point) / 2f;
            if (hit.point.y > posGround.y)
                posGround.y = hit.point.y;
            distGroundR = hit.distance;
        }


        distGround = (distGroundL + distGroundR) / 2f;
        SnowTrail();
        SnowParticle();

       

    }

    public Transform snowParticle;
    Vector3 offsetSnowParticle = new Vector3(0, 20, 0);
    void SnowParticle()
    {
        snowParticle.position = transform.position + offsetSnowParticle;
    }

    void SnowTrail()
    {
        if (distGround < 0.3f)
        {
            _boardNoise.volume = magnitude / 50f;
            lastTrailId = trail.AddSkidMark(posGround, normalGround, trailWidth, lastTrailId);
            pe.rateOverTime = magnitude * 20 - 20;
            localRot = transform.localRotation.eulerAngles;
            localRot.z = (distGroundR - distGroundL) * 100;
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(localRot), Time.deltaTime * 10);
        }
        else
        {
            _boardNoise.volume = 0;
            lastTrailId = -1;
            pe.rateOverTime = 0;
        }
    }

    float pitch;
    RaycastHit hit;
    float magnitude;
    Vector3 ang;
    void FixedUpdate()
    {
        boardDeltaY = 0;
        boardDeltaY += (float)(tilt * (1 + velocity.magnitude / 50f));
        ang = transform.eulerAngles;
        ang.y += boardDeltaY;
        transform.eulerAngles = ang;
        velocity = rg.velocity;
        localVel = transform.InverseTransformDirection(velocity);
        localVel.x -= localVel.x * turnStrength;

        //Simulate friction by increasing the drag depending of the speed
        magnitude = velocity.magnitude;
        if (magnitude < 3)
            rg.drag = 0;
        else
            rg.drag = magnitude / 200f;

        _windNoise.volume = 0.2f + magnitude / 40f;
        pitch = 0.8f + magnitude / 40f;
        _windNoise.pitch = pitch;

        rg.angularVelocity = Vector3.zero;
        if (distGround > 0.2f)
        {
        
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Rotate();

                        
        }
        else
        {

            if (Input.GetButtonUp("Jump"))
            {
                rg.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }

            if (Input.GetButtonUp("Vertical"))
            {
                rg.AddForce(rg.velocity * shuffleForce, ForceMode.Impulse);
            }


            //On the ground/snow
            rg.velocity = transform.TransformDirection(localVel);
        }


    }
    
    private void Rotate() {
        // TODO: inputs for carving
        
        transform.Rotate(0, input.x * rotationValue * Time.deltaTime, 0);
    }
}
