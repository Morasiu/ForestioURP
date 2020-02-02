using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SeedManager : MonoBehaviour
{
    [SerializeField]
    private Text SeedText;


    List<ItemTree> trees;

    static int  zeroPhaseThreetrees;
    static int  firstPhaseThreetrees;
    static int  secondPhaseThreetrees;
    static int  thirdPhaseThreetrees;

    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        SeedText.text = Seed.Value.ToString();

        trees = FindObjectsOfType<ItemTree>().ToList();

        zeroPhaseThreetrees = trees.Sum(x => x.phase.CompareTo(Phase.Zero));
        firstPhaseThreetrees = trees.Sum(x => x.phase.CompareTo(Phase.First));
        secondPhaseThreetrees = trees.Sum(x => x.phase.CompareTo(Phase.Second));
        thirdPhaseThreetrees = trees.Sum(x => x.phase.CompareTo(Phase.Third));
        print(Seed.Value);

    }

    public static void ConvertSeedAmount()
    {
        Seed.Value += (zeroPhaseThreetrees);
        Seed.Value += (firstPhaseThreetrees * 2);
        Seed.Value += (secondPhaseThreetrees * 3);
        Seed.Value += (thirdPhaseThreetrees * 6);
    }
}
