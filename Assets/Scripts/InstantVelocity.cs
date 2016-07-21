using UnityEngine;
using System.Collections;

public class InstantVelocity : MonoBehaviour 
{

    public Vector2 velocity = Vector2.zero;

    private Rigidbody2D rigidbody2D;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rigidbody2D.velocity = velocity;
    }
}
