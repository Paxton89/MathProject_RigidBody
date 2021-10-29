using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    public CanonBall canonBall;
    public float force;

    private Transform _spawnTransform;
    private Vector3 _launchDirection;

    private void Awake()
    {

    }

    void Start()
    {
        _spawnTransform = GameObject.Find("Origin").transform;
    }
    
    void Update()
    {
        _launchDirection = transform.TransformVector(Vector3.up).normalized;
        Debug.DrawRay(_spawnTransform.position, _launchDirection, Color.yellow);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("FIRE");
            CanonBall newBall = Instantiate(canonBall);
            newBall.transform.position = _spawnTransform.position + _spawnTransform.TransformVector(Vector3.up) * 15;
            newBall.SetValues(_launchDirection, force);
        }    
    }
}
