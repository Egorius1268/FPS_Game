using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
    
{
    private void Awake()
    {
        this.enabled = true;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.WakeUp();
        PlayerMovement pm = gameObject.GetComponent<PlayerMovement>();
        pm.enabled = true;
        PlayerCamera cam = gameObject.GetComponent<PlayerCamera>();
        cam.enabled = true;
    }
    
    public Gun gun;
    public Camera playerCamera;
    public float curSpeedX = 0;
    public float startWalkSpeed = 13f;
    public float startRunSpeed = 26f;
    public float walkSpeed = 13f;
    public float runSpeed = 26f;
    public float jumpPower = 7f;
    public float gravity = 10f;
    public float defaultHeight = 2f;
    public float crouchHeight = 1f;
    public float jumpSpeedBoost = 2;
    
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController characterController;
    
    void Start()
    
    {
        characterController = GetComponent<CharacterController>();
        CursorLock();
    }
    
    void Update()

    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        curSpeedX = (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical");
        float curSpeedY =  (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal");
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;

        }

        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        
        if (Input.GetKey(KeyCode.LeftControl))
        {
            characterController.height = crouchHeight;
            walkSpeed = startWalkSpeed / 4;
            runSpeed = startRunSpeed / 4;
        }

        else
        
        {
            characterController.height = defaultHeight;
            walkSpeed = startWalkSpeed;
            runSpeed = startRunSpeed;
        }
        
        characterController.Move(moveDirection * Time.deltaTime);

        if (Input.GetKey(KeyCode.R) && gun.currentAmmo >= 0)
        {
            gun.Reload();
        }
        
    }

    public void CursorLock()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void CursorUnlock()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}