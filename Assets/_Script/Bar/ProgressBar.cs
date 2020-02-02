using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Image o2Bar;

    public float targetPercentage;
    float changeValue;
    float actualPercentage;

    private void Update()
    {
        SetTargetValue();
        AnimateProgressBar();
        actualPercentage = o2Bar.rectTransform.sizeDelta.x;
    }

    public void SetTargetValue()
    {
        if (actualPercentage < targetPercentage)
        {
            changeValue = 1f;
        }
        else if(actualPercentage > targetPercentage)
        {
            changeValue = -1f;
        }
        else if(Math.Abs(actualPercentage - targetPercentage)<o2Bar.rectTransform.sizeDelta.x/50)  
        {

            changeValue = 0;
            actualPercentage = targetPercentage;
        }
    }

    public void AnimateProgressBar()
    {
        var temporaryValue = actualPercentage + changeValue;
        o2Bar.rectTransform.sizeDelta = new Vector2(temporaryValue, o2Bar.rectTransform.sizeDelta.y);
    }

}
