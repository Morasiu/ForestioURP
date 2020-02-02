using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class Timer : MonoBehaviour
{
    bool shouldRestart = true;
    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(5);
        SeedManager.ConvertSeedAmount();
        shouldRestart = true;
    }
    void Update()
    {
        if (shouldRestart)
        {
            shouldRestart = false;
            StartCoroutine(CountDown());

        }

    }
}
