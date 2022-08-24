using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class camButton : MonoBehaviour
{
    public float whatButton;
    gameManager Gm;


    public Transform buttonTrans;

    public Transform buttonTarget;

    [SerializeField]
    protected Material hoverMaterial;

    [SerializeField]
    protected Material OGMaterial;


    [SerializeField]
    protected Ease easeType;

    [SerializeField]
    protected float moveTime = 1f;

    [SerializeField]
    protected float waitTime = 1f;


    // Start is called before the first frame update
    void Start()
    {
        Gm = GameObject.FindGameObjectWithTag("Game_Manager").GetComponent<gameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        gameObject.GetComponent<MeshRenderer>().material = hoverMaterial;

        if (Input.GetMouseButtonDown(0))
        {
            switch (whatButton)
            {
                case 1f:
                    Gm.switchCam1();
                    Debug.Log("I DONT WANNA SAY THAT ");
                    break;
                case 2f:
                    Gm.switchCam2();
                    break;
                case 3f:
                    Gm.switchCam3();
                    break;

            }

            clickAnim();
        }
    }

    private void OnMouseExit()
    {
        gameObject.GetComponent<MeshRenderer>().material = OGMaterial;
    }


    private void clickAnim()
    {
        Vector3 orignalPos = buttonTrans.position;
        Sequence sequence = DOTween.Sequence();
        sequence.SetEase(easeType);
        sequence.Append(buttonTrans.DOMove(buttonTarget.position, moveTime));
        sequence.AppendInterval(waitTime);
        sequence.Append(buttonTrans.DOMove(orignalPos, moveTime));
    }
}
