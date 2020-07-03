using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI timer;
    [SerializeField]
    private TextMeshProUGUI current;
    [SerializeField]
    private TextMeshProUGUI record;
    public static int currentCount = 0;
    public static int recordCount;
    public static int time;
    public static bool isEndGame;
    private void Start()
    {
        isEndGame = false;
        time = 60;
        SaveLoad.LoadFile();
        StartCoroutine(Timer());
    }

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
            StopCoroutine(Timer());
            timer.enabled = false;
            current.enabled = false;
            SaveLoad.SaveFile();
            isEndGame = true;
        }
    }
    public void Restart()
    {
        isEndGame = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private IEnumerator Timer()
    {
        for (; ; )
        {
            if (isEndGame)
            {
                yield break;
            }
            time--;
            yield return new WaitForSeconds(1f);
        }
    }
}
