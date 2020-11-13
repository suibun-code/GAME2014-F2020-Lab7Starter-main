using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpossumBehaviour : MonoBehaviour
{
    public float runForce;
    public Rigidbody2D rigidbody2D;
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _Move();
    }

    private void _Move()
    {
        rigidbody2D.AddForce(Vector2.left * runForce * Time.deltaTime);

        rigidbody2D.velocity *= 0.90f;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platforms"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platforms"))
        {
            isGrounded = false;
        }
    }
}
