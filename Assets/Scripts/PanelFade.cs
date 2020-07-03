using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelFade : MonoBehaviour
{
    private Image image;
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (StateManager.isEndGame)
        {
            image.color = Color.Lerp(new Color(0.5f, 0.5f, 0.5f, 0), new Color(0.5f, 0.5f, 0.5f, 0.5f), 1f);
        }
        else
        {
            image.color = new Color(0.5f, 0.5f, 0.5f, 0);
        }

    }
}
