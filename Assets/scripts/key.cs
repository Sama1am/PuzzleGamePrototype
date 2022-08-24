using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class key : MonoBehaviour
{

    gameManager GM;

    private void Awake()
    {
        
    }


    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("Game_Manager").GetComponent<gameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(GM.hasKey == true)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            GM.hasKey = true;
        }
        else
        {
            GM.hasKey = false;
        }
    }


    
}
