using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class Timer : MonoBehaviour
{
    public int sec = 0;
    public TMP_Text Text;
    public int endOfTime;

    public event Action timerIsStoped;
    public Figure figure;

    void Start()
    {
        figure.figureIsDone += StopTimer;
        StartCoroutine(nameof(TimerInSec));
    }

    public IEnumerator TimerInSec()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            if (sec >= endOfTime)
            {
                timerIsStoped?.Invoke();
                yield return new WaitForSeconds(1.0f);
                yield break;
            }
            sec++;
            Text.text = sec.ToString();
            yield return null;
        }
    }

    public void StopTimer()
    {
        StopCoroutine(nameof(TimerInSec));
    }
}
