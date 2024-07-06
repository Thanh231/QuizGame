using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeToAnswer;
    public float timeToShowAnswer;
    public float timeValue;
    public bool isAnswering;
    public bool loadNextQuestion;
    public float fillFraction;
    // Update is called once per frame
    void Update()
    {
        timeValue -= Time.deltaTime;
        if(isAnswering)
        {
            if (timeValue > 0)
            {
                fillFraction = timeValue/ timeToAnswer;
            }
            else
            {
                timeValue = timeToShowAnswer;
                isAnswering = false;
            }
        }
        else
        {
            if (timeValue > 0)
            {
                fillFraction = timeValue / timeToShowAnswer;
            }
            else
            {
                loadNextQuestion = true;
                timeValue = timeToAnswer;
                isAnswering = true;
            }
        }
    }
    public void CancelTimer()
    {
        timeValue = 0;
    }
}
