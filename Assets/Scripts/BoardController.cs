using UnityEngine;
using System.Collections;

// This script moves the character controller forward
// and sideways based on the arrow keys.
// It also jumps when pressing space.
// Make sure to attach a character controller to the same game object.
// It is recommended that you make only one call to Move or SimpleMove per frame.

public class BoardController : MonoBehaviour
{
    public float boardShuffle;
    public float jumpForce;
    public float rotateSpeed = 3.0f;
    public float boardSpeed;


    private GameObject testBoard;

    private Vector3 moveDirection = Vector3.back;
    private Rigidbody myBody;
    

    private bool isJumping;

    void Start()
    {
        myBody = GetComponent<Rigidbody>();
    }
    void Update()
    {

        transform.Rotate(0, Input.GetAxis("Rotate") * rotateSpeed * Time.deltaTime, 0);
        //transform.Rotate(0, 0, Input.GetAxis("Roll") * turnSpeed * Time.deltaTime);
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            myBody.AddRelativeForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = true;

        }

        if (Input.GetButtonDown("Forward") && !isJumping)
        {
            myBody.AddRelativeForce(Vector3.back * boardShuffle, ForceMode.Impulse);
        }

        if (Input.GetButton("TurnLeft") && !isJumping)
        {
            myBody.AddRelativeForce(Vector3.right * boardSpeed, ForceMode.Acceleration);
        }

        if (Input.GetButton("TurnRight") && !isJumping)
        {
            myBody.AddRelativeForce(Vector3.left * boardSpeed, ForceMode.Acceleration);
        }

        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}