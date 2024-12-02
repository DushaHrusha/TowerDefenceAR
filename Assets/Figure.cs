using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figure : MonoBehaviour
{
    public List<TriggerScript> triggerBoxes = new List<TriggerScript>();

    [SerializeField] public Dictionary<string, TriggerScript> equalsCube = new Dictionary<string, TriggerScript>();

    public int i = 0;
    public event Action cheakCubeTrigger;
    public event Action figureIsDone;

    void OnEnable()
    {
        foreach (TriggerScript t in triggerBoxes)
        {
            t.onTriggerEnter += cheakName;
            t.onTriggerExit += deletName;

        }
    }

    void OnDisable()
    {
        foreach (TriggerScript t in triggerBoxes)
        {
            t.onTriggerEnter -= cheakName;
            t.onTriggerExit -= deletName;
        }
    }

    private void cheakName(string name, TriggerScript script)
    {
        i++;
        Debug.Log("Добавил объект ----/" + equalsCube.Count + "/" + triggerBoxes.Count);

        try
        {
            equalsCube.Add(name, script);
        }
        catch (Exception e)
        {
            Debug.LogWarning(name + " уже существует");
        }

        if (triggerBoxes.Count == equalsCube.Count)
        {
            Debug.Log("Побуда");
            figureIsDone?.Invoke();
        }
    }
    private void deletName()
    {
        i--;
        Debug.Log("Удалил объект " + i);
    }

}
