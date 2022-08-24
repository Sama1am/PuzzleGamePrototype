using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    Vector3 _Movement;

    private float moveSpeed = 10; // move speed
    
    private float lerpSpeed = 10; // smoothing speed
    private float gravity = 10; // gravity acceleration
    private bool isGrounded;
    private float deltaGround = 0.2f; // character is grounded up to this distance
    private float turnSpeed = 250;

    private Vector3 surfaceNormal; // current surface normal
    private Vector3 myNormal; // character normal
    private float distGround; // distance from character position to ground
    private float turnSmoothVel;

    private Transform myTransform;

    public BoxCollider boxCollider; // drag BoxCollider ref in editor
    public Rigidbody rigidbody;
    public float turnSmoothTime = 0.1f;
    public Transform cam;



    public Vector2 turn;


    void Start()
    {
        myNormal = transform.up; // normal starts as character up direction
        myTransform = transform;
        rigidbody.freezeRotation = true; // disable physics rotation
                                         // distance from transform.position to ground
        distGround = boxCollider.extents.y - boxCollider.center.y;

        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        // apply constant weight force according to character normal:
        rigidbody.AddForce(-gravity * rigidbody.mass * myNormal);
    }

    void Update()
    {
        
        _movement();
    }

    void _movement()
    {
        Ray ray;
        RaycastHit hit;



        // movement code - turn left/right with Horizontal axis:

        //float xpos;
        float zpos;
        zpos = Input.GetAxisRaw("Vertical");
        _Movement = new Vector3(0f, 0f, zpos);
        _Movement *= (moveSpeed * Time.deltaTime);
        myTransform.Translate(_Movement);

        myTransform.Rotate(0, Input.GetAxis("Mouse X") * turnSpeed * Time.deltaTime, 0);
        //myTransform.Rotate(0, Input.GetAxis("Mouse Y") * turnSpeed * Time.deltaTime, 0);
        // update surface normal and isGrounded:
        ray = new Ray(myTransform.position, -myNormal); // cast ray downwards
        if (Physics.Raycast(ray, out hit))
        { // use it to update myNormal and isGrounded
            isGrounded = hit.distance <= distGround + deltaGround;
            surfaceNormal = hit.normal;
        }
        else
        {
            isGrounded = false;
            // assume usual ground normal to avoid "falling forever"
            surfaceNormal = Vector3.up;
        }

        


        myNormal = Vector3.Lerp(myNormal, surfaceNormal, lerpSpeed * Time.deltaTime);
        // find forward direction with new myNormal
        Vector3 myForward = Vector3.Cross(myTransform.right, myNormal);
        // align character to the new myNormal while keeping the forward direction
        Quaternion targetRot = Quaternion.LookRotation(myForward, myNormal);
        myTransform.rotation = Quaternion.Lerp(myTransform.rotation, targetRot, lerpSpeed * Time.deltaTime);


      
       
        //myTransform.Translate(0, 0, Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);

    }

   
 

   
}
