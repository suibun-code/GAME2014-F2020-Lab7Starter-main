﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpossumBehaviour : MonoBehaviour
{
    public float runForce;
    public Rigidbody2D rigidbody2D;
    public Transform lookAheadPoint;
    public LayerMask collisionLayer;
    public bool isGroundAhead;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _LookAhead();
        _Move();
    }

    private void _LookAhead()
    {
        isGroundAhead = Physics2D.Linecast(transform.position, lookAheadPoint.position, collisionLayer);

        Debug.DrawLine(transform.position, lookAheadPoint.position, Color.green);
    }

    private void _Move()
    {
        if (isGroundAhead)
        {
            rigidbody2D.AddForce(Vector2.left * runForce * Time.deltaTime * transform.localScale.x);

            rigidbody2D.velocity *= 0.90f;
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x * -1.0f, transform.localScale.y, transform.localScale.z);
        }
    }
}
