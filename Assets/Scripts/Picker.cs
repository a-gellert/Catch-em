using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picker : MonoBehaviour
{
    public AudioSource chpockSound;
    void Update()
    {
        if (!StateManager.isEndGame && Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (hit.collider != null && hit.collider.tag == "Ball")
            {
                chpockSound.Play();
                hit.collider.gameObject.GetComponent<Ball>().ResBall();
                StateManager.currentCount += hit.collider.gameObject.GetComponent<Ball>().count;
            }
            else
            {
                Debug.Log("Miss");
            }
        }
    }
}
