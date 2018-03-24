using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour    
{

    public float moveSpeed;
    private Rigidbody myRigidBody;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    private Camera mainCamera;

    public GunController myGunController;
    
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
        mainCamera = Camera.main;        
    }
    
    void Update()
    {
        //Player Movement
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;

        //Look at mouse
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }

        if (Input.GetMouseButtonDown(0))
        {
            myGunController.isFiring = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            myGunController.isFiring = false;
        }

    }

    void FixedUpdate()
    {
        //Apply movement to rigidbody
        myRigidBody.velocity = moveVelocity;
    }
}
