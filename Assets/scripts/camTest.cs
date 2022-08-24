using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class camTest : MonoBehaviour
{
    public Transform target;
    float speed = 5.0f;
    public CinemachineVirtualCamera[] cameras;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.LookAt(target);
            transform.RotateAround(target.position, Vector3.up, Input.GetAxis("Mouse X") * speed);
        }

        if (Input.GetMouseButtonDown(1))
        {
            cameras[0].gameObject.SetActive(true);
            cameras[1].gameObject.SetActive(false);
            Debug.Log("I DONT KNOW ANYMORE!");
           
        }
    }


}
