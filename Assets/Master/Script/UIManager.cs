using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    WaitForSeconds Seconds = new WaitForSeconds(1);
    int timer;
    [SerializeField]
    Text _timeText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SystemTime");
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator SystemTime()
    {
        //Debug.Log("timer: " + timer);
        _timeText.text = "0:" + timer.ToString("D2");
        yield return Seconds;

        timer++;
        if (timer == 60)
        {
            _timeText.text = "1:00";
            timer = 0;
            Debug.Log("End");
            yield return null;
        }
        else
        {
            yield return SystemTime();
        }
        
    }
}
