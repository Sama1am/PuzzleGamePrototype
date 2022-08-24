using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using DG.Tweening;
public class gameManager : MonoBehaviour
{

    public bool hasKey;

    public GameObject[] platforms;
    
    public CinemachineVirtualCamera[] cameras;

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

    Color blue;
    Color grey;

    void Start()
    {
        hasKey = false;
        blue = new Color(0.4392157f, 0.572549f, 0.7843137f, 1f);
        grey = new Color(0.2358491f, 0.2322891f, 0.2322891f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void setBluePlatforms()
    {
        platforms[0].SetActive(true);
        platforms[1].SetActive(true);
        platforms[2].SetActive(false);
        platforms[3].SetActive(false);
        platforms[4].SetActive(false);
        //platforms[5].SetActive(true);
        //platforms[6].SetActive(true);
        platforms[7].SetActive(true);
        platforms[8].SetActive(true);
        //backgroundColor = 1;
        cam.backgroundColor = grey;
    }

    public void setBlackPlatforms()
    {
        platforms[0].SetActive(false);
        platforms[1].SetActive(false);
        platforms[2].SetActive(true);
        platforms[3].SetActive(true);
        platforms[4].SetActive(true);
        //platforms[5].SetActive(false);
        //platforms[6].SetActive(false);
        platforms[7].SetActive(false);
        platforms[8].SetActive(false);
        //backgroundColor = 2;
        cam.backgroundColor = blue;
    }

    public void setGoldPlatform()
    {
        platforms[6].SetActive(true);
        platforms[5].SetActive(true);
        platforms[7].SetActive(true);
    }


    public void switchCam1()
    {
        cameras[0].gameObject.SetActive(false);
        cameras[1].gameObject.SetActive(true);
        cameras[2].gameObject.SetActive(false);
        cameras[3].gameObject.SetActive(false);

    }


    public void switchCam2()
    {
        cameras[0].gameObject.SetActive(false);
        cameras[2].gameObject.SetActive(true);
        cameras[1].gameObject.SetActive(false);
        cameras[3].gameObject.SetActive(false);

    }

    public void switchCam3()
    {
        cameras[0].gameObject.SetActive(false);
        cameras[2].gameObject.SetActive(false);
        cameras[1].gameObject.SetActive(false);
        cameras[3].gameObject.SetActive(true);
    }


    public void quit()
    {
        Application.Quit();
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
