using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBall : MonoBehaviour
{
    public float mass = 10;
    public float lifeTime = 15;

    private Vector3 _impulse;
    private Vector3 _force;
    private Vector3 _gravity;
    private Vector3 _acceleration;
    private Vector3 _velocity;

    private void Awake()
    {
    }

    void Start()
    {
        _gravity = Vector3.down * 9.81f;
    }
    
    void FixedUpdate()
    {
        lifeTime -= Time.deltaTime;
        BehaveAsCanonBall();
        //BehaveAsMissile();
        if (lifeTime < 0 || transform.position.y < 0.45)
        {
            Debug.Log("BOOM");
            Destroy(gameObject);
        }
    }

    //Behaves like a CanonBall
    void BehaveAsCanonBall()
    {
        _acceleration = _force / mass;
        _velocity += _gravity * Time.deltaTime;
        transform.position += _velocity * Time.deltaTime;
        
        Debug.DrawLine(transform.position, transform.position + _acceleration, Color.green);
        Debug.DrawLine(transform.position, transform.position + _velocity, Color.blue);
        Debug.DrawLine(transform.position + _acceleration, transform.position + _acceleration + _gravity, Color.red);
    }

    void Impulse()
    {
        _impulse = _acceleration;
        _velocity = _impulse;
    }

    void BehaveAsMissile()
    {
        _acceleration = _force / mass;
        _velocity += (_acceleration +  _gravity) * Time.deltaTime;
        transform.position += _velocity * Time.deltaTime;
        
        Debug.DrawLine(transform.position, transform.position + _acceleration, Color.green);
        Debug.DrawLine(transform.position, transform.position + _velocity, Color.blue);
        Debug.DrawLine(transform.position + _acceleration, transform.position + _acceleration + _gravity, Color.red);
    }
    
    public void SetValues(Vector3 dir, float force)
    {
        _force = dir * force; //merge both values to a vector3
        _acceleration = _force / mass;
        
        //UnComment this for Canonball mode
        Impulse();
    }
}
