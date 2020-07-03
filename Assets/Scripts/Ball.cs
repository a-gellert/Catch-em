using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float multiplier;
    public float speed;
    private Rigidbody2D rigidbody;
    public Vector3 scale;
    public bool isMoving = false;
    public int count;
    void Start()
    {
        scale = transform.localScale;
        rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Edge")
        {
            ResBall();
        }
    }
    public float SetDims()
    {
        multiplier = Random.Range(0.5f, 2f);
        transform.localScale = new Vector3(scale.x * multiplier, scale.y * multiplier, 1);
        speed = 50 / multiplier + (200f / (StateManager.time + 1f));
        count = (int)(10 * speed);
        return speed;
    }
    public void ResBall()
    {

        transform.position = new Vector3(Random.Range(-8.5f, 8.5f), BallSpawner.y, 1);
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        rigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
        isMoving = false;
    }
}
