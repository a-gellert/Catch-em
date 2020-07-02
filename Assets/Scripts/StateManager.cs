using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI timer;
    [SerializeField]
    private TextMeshProUGUI current;
    [SerializeField]
    private TextMeshProUGUI record;

    public static int currentCount = 0;
    public static int recordCount = 1999;
    public static int time = 60;
    private void Start()
    {
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    private void Update()
    {
        current.SetText(currentCount.ToString());
        timer.SetText(time.ToString());
        record.SetText(recordCount.ToString());
        if (recordCount < currentCount)
        {
            recordCount = currentCount;
        }
        if (time == 0)
        {
            Time.timeScale = 0;
        }
    }
    private IEnumerator Timer()
    {
        for (; ; )
        {
            time--;
            yield return new WaitForSeconds(1f);
        }
    }
}
