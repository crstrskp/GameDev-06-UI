using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class RadialElement : MonoBehaviour
{
    [SerializeField] private TMP_Text queueText;
    [SerializeField] private Image progressFill;

    [SerializeField] private int inQueue = 5;
    [SerializeField] private int maxQueue = 5;
    [SerializeField] private int currentProgress = 100;
    [SerializeField] private int buildTime = 100;

    private void FixedUpdate()
    {
        UpdateQueue();

        UpdateUI();
    }

    private void UpdateUI()
    {
        queueText.text = inQueue.ToString();
        progressFill.fillAmount = (float)currentProgress / buildTime;
    }

    private void UpdateQueue()
    {
        if (currentProgress > 0)
        {
            currentProgress--;
        }
        else 
        {
            if (inQueue > 0)
            {
                inQueue--;
                currentProgress = buildTime;
            }
        }
    }

    public void Enqueue()
    {
        if (inQueue < maxQueue)
        {
            inQueue++;
        }
    }
}
