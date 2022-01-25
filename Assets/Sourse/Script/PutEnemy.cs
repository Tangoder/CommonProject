using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * 0.1f, Color.red); //顯示線debug用
    }
    private void OnMouseDown()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up),  0.1f))
        {
            print("can't build more");
            return;
        }
        Instantiate(fort, myPos, Quaternion.identity);
    }
    private void OnMouseEnter()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), 0.1f))
        {
            myColor.material.color = errorColor;
            return;
        }
        myColor.material.color = hoverColor;
    }
    private void OnMouseOver()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), 0.1f))
        {
            myColor.material.color = errorColor;
        }
    }
    private void OnMouseExit()
    {
        myColor.material.color = originColor;
        
    }
    
}
