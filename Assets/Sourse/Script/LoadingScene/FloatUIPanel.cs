using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatUIPanel : MonoBehaviour
{
    public Image _UI;

    public Canvas _cav;
    void Start()
    {
        
    }

    public void OnMouseDrag()
    {
        Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _cav.transform.position.z);
        _UI.rectTransform.position = pos;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
