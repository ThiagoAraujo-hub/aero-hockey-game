using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    void GoBall()
    {
        float rand = Random.Range(0, 4);

        if (rand < 1)
            rb2d.AddForce(new Vector2(30, -20));
        else if (rand < 2)
            rb2d.AddForce(new Vector2(-30, 20));
        else if (rand < 3)
            rb2d.AddForce(new Vector2(30, 20));
        else
            rb2d.AddForce(new Vector2(-30, -20));
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke(nameof(GoBall), 2);
    }

    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player1") || coll.collider.CompareTag("Player2"))
        {
            Vector2 vel;
            vel.x = rb2d.velocity.x;
            vel.y = (rb2d.velocity.y / 2) + (coll.collider.attachedRigidbody.velocity.y / 3);
            rb2d.velocity = vel;
        }
    }

    void ResetBall()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    void RestartGame()
    {
        ResetBall();
        Invoke(nameof(GoBall), 1);
    }

}
