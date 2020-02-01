using System.Collections;
using UnityEngine;

public class ItemTree : MonoBehaviour {
    public Phase phase = Phase.Zero;

    [SerializeField]
    private float TimeToSecondPhase = 3f;

    [SerializeField]
    private float TimeToThirdPhase = 10f;

    // Start is called before the first frame update
    IEnumerator Start() {
        if (phase == Phase.Zero) {
            phase = Phase.First;
            yield return new WaitForSeconds(TimeToSecondPhase);
            phase = Phase.Second;
            yield return new WaitForSeconds(TimeToThirdPhase);
            phase = Phase.Third;
        }
    }
    
}

