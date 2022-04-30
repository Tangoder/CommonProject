using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject _UI;

    public void OnClickCanel()
    {
        _UI.SetActive(true);
        gameObject.SetActive(false);
    }
}
