using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutEnemy : MonoBehaviour
{
    public Color hoverColor;
    public GameObject fort;
    private Vector3 myPos;
    private Renderer myColor;
    private Color originColor;
    void Start()
    {
        myColor = GetComponent<Renderer>();
        originColor = myColor.material.color;
        myPos = GetComponent<Transform>().position;
        myPos.y += 0.25f;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {   
        /*if(fort != null)
        {
            Debug.Log("A");
            return;
        }*/
        Instantiate(fort, myPos, Quaternion.identity);
    }
    private void OnMouseEnter()
    {
        
        myColor.material.color = hoverColor;
    }
    private void OnMouseExit()
    {
        myColor.material.color = originColor;
        
    }
    
}
