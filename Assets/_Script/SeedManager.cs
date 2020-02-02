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

        zeroPhaseThreetrees = trees.Count(x => x.phase.CompareTo(Phase.Zero)==0);
        firstPhaseThreetrees = trees.Count(x => x.phase.CompareTo(Phase.First)==0);
        secondPhaseThreetrees = trees.Count(x => x.phase.CompareTo(Phase.Second)==0);
        thirdPhaseThreetrees = trees.Count(x => x.phase.CompareTo(Phase.Third)==0);
        print(Seed.Value);


        print("0: "+ zeroPhaseThreetrees);
        print("1: " + firstPhaseThreetrees);
        print("2: " + secondPhaseThreetrees);
        print("3: " + thirdPhaseThreetrees);

    }

    public static void ConvertSeedAmount()
    {
        Seed.Value += (zeroPhaseThreetrees);
        Seed.Value += (firstPhaseThreetrees * 2);
        Seed.Value += (secondPhaseThreetrees * 3);
        Seed.Value += (thirdPhaseThreetrees * 6);
    }
}
