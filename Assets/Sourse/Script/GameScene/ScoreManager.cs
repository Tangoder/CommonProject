using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int monsterScore = 0;

    public static int monsterPoint = 100;

    public static int fortScore = 0;

    public static int fortPoint = 100;

    private void Start()
    {
        monsterScore = 0;

        monsterPoint = 100;

        fortScore = 0;

        fortPoint = 100;
    }
}
