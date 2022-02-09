using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PutEnemy : MonoBehaviour
{
    public Color hoverColor;
    public Color errorColor;
    public GameObject fort;
    private Vector3 myPos;
    private Renderer myColor;
    private Color originColor;
    void Start()
    {
        myColor = GetComponent<Renderer>();
        originColor = myColor.material.color;
        myPos = GetComponent<Transform>().position;
        myPos.y += 0.3f;  //reset fort position
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            GameManager.putFort = false;
        }
    }
    private void OnMouseDown()
    {
        if (GameManager.putFort == true )
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), 0.5f))
            {
                print("can't build more");
                return;
            }
            PhotonNetwork.Instantiate(fort.name, myPos, Quaternion.identity);
            GameManager.putFort = false;
        }
        
    }
    private void OnMouseEnter()
    {
        if (GameManager.putFort == true )
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), 0.5f))
            {
                myColor.material.color = errorColor;
                return;
            }
            myColor.material.color = hoverColor;
        }
        
    }
    /*private void OnMouseOver()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), 0.5f))
        {
            myColor.material.color = errorColor;
        }
    }*/
    private void OnMouseExit()
    {
        myColor.material.color = originColor;
        
    }
}
