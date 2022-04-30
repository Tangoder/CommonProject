using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookforCamera : MonoBehaviour
{
    // Start is called before the first frame   
    public GameObject _camera;
    void Start()
    {
        _camera = GameObject.FindGameObjectWithTag("GPS");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_camera.transform);
    }
}
