using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurroundHexes : MonoBehaviour
{

    float HexRadius = 0;

    void Awake()
    {
        var hexVector = FindObjectOfType<Hex>().GetComponent<MeshRenderer>().bounds.size;
        for (int i = 0; i < 3; i++)
        {
            if (hexVector[i] > HexRadius)
            {
                HexRadius = hexVector[i];
            }
        }

    }

    public Collider[] ActiveateObjectsAroundTheTarget(GameObject centerHex, HexState state)
    {
        var neighbors = Physics.OverlapSphere(centerHex.transform.position, HexRadius / 1.4f, 1<<9);
        
        foreach (var field in neighbors)
        {
            //print(field.name);

            var fieldhex = field.GetComponent<Hex>();

            if (fieldhex.Status != HexState.NonActive)
            {
                if (state == HexState.Polluted)
                {
                    fieldhex.isPolluted = true;
                    fieldhex.isNatural = false;
                    fieldhex.isNonActive = false;
                }
                else if(state == HexState.Natural)
                {
                    fieldhex.isPolluted = false;
                    fieldhex.isNatural = true;
                    fieldhex.isNonActive = false;
                }

                fieldhex.Status = state;
            }
            else
            {
                continue;
            }

            //print(fieldhex.Status);
        }
        return neighbors;
    }
}
