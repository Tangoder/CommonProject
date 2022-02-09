using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10.0f;
    private Transform target;
    private int wavepointIndex = 0;

    void Start()
    {
        wavepointIndex = 0;
        target = Waypoint.points[wavepointIndex];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate( dir.normalized * speed * Time.deltaTime , Space.World);

        if(Vector3.Distance(target.position , transform.position) <= 0.1f)
        {
            GoNextPoint();
        }

    }

    void GoNextPoint()
    {
        if (wavepointIndex >= Waypoint.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        wavepointIndex++;
        target = Waypoint.points[wavepointIndex];
    }

}
