using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class onClick : MonoBehaviour
{
    gameManager Gm;
    public float tol = 5;
   
    public float whatButton;

    [SerializeField]
    protected Material hoverMaterial;

    [SerializeField]
    protected Material OGMaterial;

    public Transform buttonTrans;

    public Transform buttonTarget;

    [SerializeField]
    protected Ease easeType;

    [SerializeField]
    protected float moveTime = 1f;

    [SerializeField]
    protected float waitTime = 1f;


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
                    Gm.setBluePlatforms();
                    break;
                case 2f:
                    Gm.setBlackPlatforms();
                    break;
                case 3f:
                    Gm.setGoldPlatform();
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
