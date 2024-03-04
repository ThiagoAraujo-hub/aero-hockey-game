using UnityEngine;

public class Player1Controls : MonoBehaviour
{
    private readonly Vector2 InitialPosition = new(-5, 0);

    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveRight = KeyCode.D;

    public float boundY = 3.4f;

    public float boundPosX = -0.9f;
    public float boundNegX = -6.85f;

    public float speed = 8.0f;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        VelX();
        VelY();

        BoundX();
        BoundY();
    }

    void VelX(){
        var vel = rb2d.velocity;

        if (Input.GetKey(moveLeft))
            vel.x = -speed;
        else if (Input.GetKey(moveRight))
            vel.x = speed;
        else
            vel.x = 0;

        rb2d.velocity = vel;
    }

    void VelY(){
        var vel = rb2d.velocity;

        if (Input.GetKey(moveUp))
            vel.y = speed;
        else if (Input.GetKey(moveDown))
            vel.y = -speed;
        else
            vel.y = 0;

        rb2d.velocity = vel;
    }

    void BoundY(){
        var pos = transform.position;

        if (pos.y > boundY)
            pos.y = boundY;
        else if (pos.y < -boundY)
            pos.y = -boundY;

        transform.position = pos;
    }

    void BoundX(){
        var pos = transform.position;

        if (pos.x > boundPosX)
            pos.x = boundPosX;
        else if (pos.x < boundNegX)
            pos.x = boundNegX;

        transform.position = pos;
    }

    void ResetPlayerPosition(){
        rb2d.position = InitialPosition;
    }

    void OnRestartGame(){
        ResetPlayerPosition();
    }
}
