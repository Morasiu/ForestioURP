﻿using System;
using System.Collections;
using UnityEngine;

public class ItemTree : MonoBehaviour {
    private const float getSeedFrequency = 3f;
    public Phase phase = Phase.Zero;

    [SerializeField]
    private float TimeToSecondPhase = 10f;

    [SerializeField]
    private float TimeToThirdPhase = 30f;

    [SerializeField]
    private bool ShouldDestroyOnPolluted = false;

    private SurroundHexes SurroundHexes;
    private Hex parentHex;

    [SerializeField] float TimeToFirstPhase = 3;

    void Start() {
        parentHex = transform.parent.GetComponent<Hex>();
        SurroundHexes = FindObjectOfType<SurroundHexes>();
        StartCoroutine(OnStart());
        phase = Phase.Zero;
    }

    // Start is called before the first frame update
    IEnumerator OnStart() {
        StartCoroutine(ProduceSeed());

        yield return new WaitForSeconds(TimeToFirstPhase);
        phase = Phase.First;
        yield return new WaitForSeconds(TimeToSecondPhase);
        var neighbours = SurroundHexes.ActiveateObjectsAroundTheTarget(this.gameObject, HexState.Natural);
        phase = Phase.Second;
        yield return new WaitForSeconds(TimeToThirdPhase);
        phase = Phase.Third;
        foreach (var neighbour in neighbours) {
            SurroundHexes.ActiveateObjectsAroundTheTarget(neighbour.gameObject, HexState.Natural);
        }

    }

    private IEnumerator ProduceSeed() {
        while(true) {
            yield return new WaitForSeconds(getSeedFrequency);
            SendSeedInfo();
        }
    }

    void Update() {
        if (ShouldDestroyOnPolluted && parentHex.Status == HexState.Polluted) {
            Destroy(gameObject);
        }
        //balns czestotliwosci pobierania nasion
    }

    void SendSeedInfo()
    {
        switch (phase)
        {
            case Phase.Zero:
                Seed.Value += (int)(Phase.Zero);
                break;
            case Phase.First:
                print($"wysylam seeda 1");
                Seed.Value += (int)(Phase.First);
                break;
            case Phase.Second:
                print($"wysylam seeda 2");
                Seed.Value += (int)(Phase.Second) * 2;
                break;
            case Phase.Third:
                print($"wysylam seeda 3");
                Seed.Value += (int)(Phase.Third) * 3;
                break;
        }

    }

}

