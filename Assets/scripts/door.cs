using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class door : MonoBehaviour
{
  
    gameManager GM;

    public Transform doorTrans;
    public Transform doorTarget;

    [SerializeField]
    protected Ease easeType;

    [SerializeField]
    protected float moveTime = 1f;

    [SerializeField]
    protected float waitTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("Game_Manager").GetComponent<gameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(doorOpen == true)
        //{
            //anim.SetBool("doorState", true);
        //}
    }

    private void OnCollisionEnter(Collision col)
    {
        
            if (GM.hasKey == true)
            {
                openDoor();
                Debug.Log("DOOR SHOULD OPEM");
            }
        
    }

    public void openDoor()
    {
        Vector3 orignalPos = doorTrans.position;
        Sequence sequence = DOTween.Sequence();
        sequence.SetEase(easeType);
        sequence.Append(doorTrans.DOScaleZ(1.5f, moveTime));
        sequence.Join(doorTrans.DOMove(doorTarget.position, moveTime));
    }
}
