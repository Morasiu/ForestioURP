using System;
using System.Collections;
using UnityEngine;

public class ItemTree : MonoBehaviour {
    public Phase phase = Phase.Zero;

    [SerializeField]
    private float TimeToSecondPhase = 3f;

    [SerializeField]
    private float TimeToThirdPhase = 10f;

    [SerializeField]
    private bool ShouldDestroyOnPolluted = false;
    
    private SurroundHexes SurroundHexes;
    private Hex parentHex;
    void Start() {
        parentHex = transform.parent.GetComponent<Hex>();
        SurroundHexes = FindObjectOfType<SurroundHexes>();
        StartCoroutine(OnStart());
    }

    // Start is called before the first frame update
    IEnumerator OnStart() {
        phase = Phase.First;
        transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(TimeToSecondPhase);
        var neighbours = SurroundHexes.ActiveateObjectsAroundTheTarget(this.gameObject, HexState.Natural);
        phase = Phase.Second;
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSeconds(TimeToThirdPhase);
        phase = Phase.Third;
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(true);
        foreach (var neighbour in neighbours) {
            SurroundHexes.ActiveateObjectsAroundTheTarget(neighbour.gameObject, HexState.Natural);
        }

        StartCoroutine(ProduceSeed());
    }

    private IEnumerator ProduceSeed() {
        while(true) {
            yield return new WaitForSeconds(1.5f);
            Seed.Value += 1;
        }
    }

    void Update() {
        if (ShouldDestroyOnPolluted && parentHex.Status == HexState.Polluted) {
            Destroy(gameObject);
        }
    }

}

