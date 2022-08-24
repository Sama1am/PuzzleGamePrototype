using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class startButton : MonoBehaviour
{
    

    public Camera cam;

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




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    private void OnMouseOver()
    {
        gameObject.GetComponent<MeshRenderer>().material = hoverMaterial;

        if (Input.GetMouseButtonDown(0))
        {

            SceneManager.LoadScene(1);
            Debug.Log("WHY NO LOAD SCENE");

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
