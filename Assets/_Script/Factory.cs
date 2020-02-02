using System.Collections;
using UnityEngine;

public class Factory : MonoBehaviour {
    public Phase phase;

    [SerializeField]
    private float TimeToSecondPhase = 3f;

    [SerializeField]
    private float TimeToThirdPhase = 10f;

    [SerializeField]
    private bool ShouldDestroyOnNatural = false;

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
        parentHex.Status = HexState.Polluted;

        yield return new WaitForSeconds(TimeToSecondPhase);
        var neighbours = SurroundHexes.ActiveateObjectsAroundTheTarget(this.gameObject, HexState.Polluted);
        phase = Phase.Second;
        yield return new WaitForSeconds(TimeToThirdPhase);
        phase = Phase.Third;
        foreach (var neighbour in neighbours) {
            SurroundHexes.ActiveateObjectsAroundTheTarget(neighbour.gameObject, HexState.Polluted);
        }
    }
    
    void Update() {
        if (ShouldDestroyOnNatural && parentHex.Status == HexState.Natural) {
            Destroy(gameObject);
        }
    }
}
