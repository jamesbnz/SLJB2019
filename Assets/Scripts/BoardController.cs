using System;
using UnityEngine;

public class BoardController : MonoBehaviour {
    public float boardShuffle;
    public float jumpForce;
    public float rotateSpeed;
    public float boardSpeed;
    public float baseSpeed;
    public float airRotate;

    private GameObject testBoard;
    private Vector3 moveDirection = Vector3.back;
    private Vector2 input;
    private Rigidbody rb;
    private bool jumpRequested;
    private bool isShuffle;
    private bool isJumping;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Rotate();


        if (!isJumping && Input.GetButtonDown("Jump")) {
            jumpRequested = true;
        }

        if (!isJumping && Input.GetButtonDown("Vertical") && Input.GetAxisRaw("Vertical") > 0) {
            isShuffle = true;
        }
    }

    private void FixedUpdate() {
        if (jumpRequested) {
            rb.AddRelativeForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = true;
        } else if (isShuffle) {
            rb.AddRelativeForce(moveDirection * boardShuffle, ForceMode.Impulse);
        }

        Carve();

        jumpRequested = false;
        isShuffle = false;
    }


    private void Rotate() {
        // TODO: inputs for carving
        
        float rotationValue = isJumping ? airRotate : rotateSpeed;
        transform.Rotate(0, input.x * rotationValue * Time.deltaTime, 0);
    }


    private void Carve() {
        // TODO: handle force during turns.
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Ground")) {
            isJumping = false;
        }
    }
}