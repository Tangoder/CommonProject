using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIColdDownManager : MonoBehaviour
{
    public float coldTime;

    private float timer;

    public Image filledImg;

    private bool isStartTime;
    
    void Start()
    {
        filledImg.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStartTime)
        {
            timer += Time.deltaTime;
            filledImg.fillAmount = (coldTime - timer) / coldTime;
            if (timer >= coldTime)
            {
                filledImg.fillAmount = 0;
                timer = 0;
                isStartTime = false;
                GetComponent<Button>().interactable = true;
            }
        }
    }

    public void OnClickSummon()
    {
        GetComponent<Button>().interactable = false;
        isStartTime = true;
    }
}
