using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{

    GameObject NaturalMenu;
    public GameObject NeutralMenu;
    GameObject PollutedMenu;

    public Material mat;
    public GameObject childrenOfHexa;
    [HideInInspector] public RaycastHit hitHexa;
    public GameObject World;
    public Camera cam;
    SurroundHexes surroundHexes;

    private void Start()
    {
        surroundHexes = FindObjectOfType<SurroundHexes>();
    }

    public void SetChildren(GameObject tree)
    {
        
        var children = Instantiate(tree, hitHexa.collider.transform, false);
        children.transform.localScale /= 4;

        //To można dodać tylko tam gdzie spawnuje się obiekt wyższy poziomem
        surroundHexes.ActiveateObjectsAroundTheTarget(children, HexState.Natural);

        
    }
    void Update()
    {
        var rightClick = Input.GetKeyDown(KeyCode.Mouse1);
        var leftClick = Input.GetKeyDown(KeyCode.Mouse0);
        if (rightClick)
        {
            DetectPosition();
            SetTargetMenu();
        }
    }

    IEnumerator DisapearTab()
    {
        yield return new WaitForSeconds(.2f);
        NeutralMenu.SetActive(false);
    }

    private void SetTargetMenu()
    {
        if (hitHexa.collider == null)
            return;
        var HexaStatus = hitHexa.collider.gameObject.GetComponent<Hex>().Status;
        Debug.Log($"Hit: {HexaStatus} ");
        
        switch (HexaStatus)
        {
            case HexState.Natural:
                    NaturalMenu.SetActive(true);
                    break;
            case HexState.Polluted:
                    PollutedMenu.SetActive(true);
                break;
            case HexState.Neutral:
                NeutralMenu.SetActive(true);
                hitHexa.collider.GetComponent<MeshRenderer>().material = mat;
                break;
            case HexState.NonActive:
                Debug.Log("trafiles w nieaktywne pole");
                break;
            default:
                DisapearTab();
                Debug.LogError("Uderzony Hex nie ma wartosci state");    
                break;

        }
    }

    private void DetectPosition()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hitHexa, Mathf.Infinity, 1 << 9);
        
    }

    #region Natural Menu Actions

    public void OnOakChosen()
    {
        hitHexa.collider.GetComponent<Hex>().Status = HexState.Natural;
        SetChildren(childrenOfHexa);
    }
    public void OnBushChosen()
    {
        hitHexa.collider.GetComponent<Hex>().Status = HexState.Natural;
    }
    public void OnPineChosen()
    {
        hitHexa.collider.GetComponent<Hex>().Status = HexState.Natural;
    }
    public void OnRedwoodChosen()
    {
        hitHexa.collider.GetComponent<Hex>().Status = HexState.Natural;
    }

    #endregion 


}
