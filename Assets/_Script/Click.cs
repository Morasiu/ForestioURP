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
    public GameObject Oak;
    public GameObject Pine;
    public GameObject Bush;
    public GameObject Redwood;
    [HideInInspector] public RaycastHit hitHexa;
    public GameObject World;
    public Camera cam;
    SurroundHexes surroundHexes;
    private Material oldMaterial;

    private void Start()
    {
        surroundHexes = FindObjectOfType<SurroundHexes>();
    }

    public void SetChildren(GameObject tree)
    {
        
        var children = Instantiate(tree, hitHexa.collider.transform, false);
        children.transform.localScale /= 4;

        //To można dodać tylko tam gdzie spawnuje się obiekt wyższy poziomem
        //surroundHexes.ActiveateObjectsAroundTheTarget(children, HexState.Natural);
    }
    void Update()
    {
        var rightClick = Input.GetKeyUp(KeyCode.Mouse1);
        var leftClick = Input.GetKeyUp(KeyCode.Mouse0);

        if ((rightClick) && oldMaterial != null) {
            //if (hitHexa.collider.gameObject.GetComponent<MeshRenderer>().material.Equals(mat))
            hitHexa.collider.gameObject.GetComponent<Hex>().Status = hitHexa.collider.gameObject.GetComponent<Hex>().Status;
        }

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
        hitHexa.collider.GetComponent<MeshRenderer>().material = mat;

        switch (HexaStatus)
        {
            case HexState.Natural:
                //NaturalMenu.SetActive(true);
                break;
            case HexState.Polluted:
                //P.SetActive(true);
                break;
            case HexState.Neutral:
                NeutralMenu.SetActive(true);
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
        oldMaterial = new Material(hitHexa.collider.GetComponent<MeshRenderer>().material);
    }

    #region Natural Menu Actions

    public void OnOakChosen() {
        PlantTree(Oak);
    }

    public void OnBushChosen()
    {
        PlantTree(Bush);
    }
    public void OnPineChosen()
    {
        PlantTree(Pine);
    }
    public void OnRedwoodChosen()
    {
        PlantTree(Redwood);
    }

    #endregion

    private void PlantTree(GameObject tree) {
        Debug.Log("SPAWN: " + tree.name + " at " + hitHexa.collider.name);
        hitHexa.collider.GetComponent<Hex>().Status = HexState.Natural;
        SetChildren(tree);
    }

}
