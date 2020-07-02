using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public static float y;
    public GameObject[] pool;
    private int current;
    private Rigidbody2D rigidbody;
    private GameObject ball;
    private void Awake()
    {

        y = transform.position.y;
    }
    void Start()
    {
        foreach (var p in pool)
        {
            p.transform.position = SetPos();
        }
        StartCoroutine(Launch());
    }

    void Update()
    {


    }
    private IEnumerator Launch()
    {
        for (; ; )
        {
            ball = pool[Random.Range(0, pool.Length)];
            if (!ball.GetComponent<Ball>().isMoving)
            {
                rigidbody = ball.GetComponent<Rigidbody2D>();

                ball.GetComponent<CircleCollider2D>().enabled = true;

                rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;

                rigidbody.AddForce(new Vector2(0, ball.GetComponent<Ball>().SetDims()));
                ball.GetComponent<Ball>().isMoving = true;
            }
            else
            {
                continue;
            }
            yield return new WaitForSeconds(0.7f);
        }
    }
    private Vector3 SetPos()
    {
        return new Vector3(Random.Range(-8.5f, 8.5f), transform.position.y, 1);
    }
}
