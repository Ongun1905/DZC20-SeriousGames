using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    // Start is called before the first frame update
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity;
    public Camera playerCamera;
    public float lookSpeed; //How fast we can look around
    public float lookXLimit = 45.0f; //How high u can look

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    public Rigidbody playerRb;

    private bool canMove = true;
    public bool reverseG = false;
    void Start()
    {
        characterController = GetComponent<CharacterController>();

        //Lock Cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        //Press left shift to run
        bool isRunning = true;
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if(Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        if(!characterController.isGrounded && !reverseG)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        //Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        if(canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }

    private void FixedUpdate()
    {
        if (reverseG)
        {
            playerRb.AddForce(-1 * Physics.gravity, ForceMode.Acceleration);
            Debug.Log("adding force");
            
        }
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("ReverseG"))
        {
            Debug.Log("gravity reversed");
            playerRb.useGravity = false;
            reverseG = true;
        }

        if(other.gameObject.CompareTag("Gravity"))
        {
            playerRb.useGravity = true;
            Debug.Log("gravity back to normal");
            reverseG = false;
        }
    }
}
