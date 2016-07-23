using UnityEngine;
using System.Collections;

public class InputState : MonoBehaviour 
{
    public bool actionButton;
    public float absVelX = 0f;
    public float absVelY = 0f;
    public bool standing;
    public float standingThreshold = 1f;

    private Rigidbody2D rigidbody2D;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        actionButton = Input.anyKeyDown;
    }

    void FixedUpdate()
    {
        absVelX = System.Math.Abs(rigidbody2D.velocity.x);
        absVelY = System.Math.Abs(rigidbody2D.velocity.y);

        standing = absVelY <= standingThreshold;
    }

}
