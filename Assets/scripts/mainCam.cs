using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCam : MonoBehaviour
{

    public Transform camTrans;

    private float turnSpeed = 200;

    gameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        GM = GameObject.FindGameObjectWithTag("Game_Manager").GetComponent<gameManager>();
    }

    void Update()
    {
        rotateCam();
    }

    void rotateCam()
    {
        camTrans.Rotate(-Input.GetAxis("Mouse Y") * turnSpeed * Time.deltaTime, 0f, 0f);
    }

    void startPos()
    {
        camTrans.Rotate(0f, 90, 0f);
    }

}
