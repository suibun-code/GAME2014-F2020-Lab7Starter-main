using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpossumBehaviour : MonoBehaviour
{
    public float runForce;
    public Rigidbody2D rigidbody2D;
    public Transform wallCastPoint;
    public Transform rampCastPoint;
    public LayerMask wallLayer;
    public LayerMask rampLayer;
    public bool isGroundAhead;
    public bool onRamp;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _LookBelow();
        _LookAhead();
        _Move();
    }

    private void _LookBelow()
    {
        var groundHit = Physics2D.Linecast(transform.position, rampCastPoint.position, rampLayer);

        if (groundHit)
        {
            if (groundHit.collider.CompareTag("Ramps"))
                onRamp = true;
            else
                onRamp = false;
        }
        else
            onRamp = false;

        Debug.DrawLine(transform.position, rampCastPoint.position, Color.green);
    }

    private void _LookAhead()
    {
        var groundHit = Physics2D.Linecast(transform.position, wallCastPoint.position, wallLayer);

        if (groundHit)
        {
            if (groundHit.collider.CompareTag("InvisWalls"))
                isGroundAhead = true;
            else
                isGroundAhead = false;
        }
        else
            isGroundAhead = false;

        Debug.DrawLine(transform.position, wallCastPoint.position, Color.red);
    }

    private void _Move()
    {
        if (!isGroundAhead)
        {
            rigidbody2D.AddForce(Vector2.left * runForce * Time.deltaTime * transform.localScale.x);

            if (onRamp)
            {
                rigidbody2D.AddForce(Vector2.up * runForce * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0.0f, 0.0f, -36.0f);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            }

            rigidbody2D.velocity *= 0.90f;
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x * -1.0f, transform.localScale.y, transform.localScale.z);
        }
    }
}
