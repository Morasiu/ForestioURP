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
    RaycastHit hitHexa;
    RaycastHit hitBar;
    public GameObject World;
    public Camera cam;


    public void SetChildren(GameObject tree)
    {
        
        var children = Instantiate(tree, hitHexa.collider.transform, false);
        children.transform.localScale /= 4;
    }
    void Update()
    {
        var rightClick = Input.GetKeyDown(KeyCode.Mouse1);
        var leftClick = Input.GetKeyDown(KeyCode.Mouse0);
        CastABarRay();

        #region niedziala
        /*if (rightClick || leftClick || Input.GetKey(KeyCode.Mouse2))
            if (TargetMenu != null)
                if (hitBar.collider != null)
                {
                    if (Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Mouse1))
                    {

                        if (hitBar.collider.name.CompareTo("Oak") == 0)
                            OnOakChosen();
                        if (hitBar.collider.name.CompareTo("Bush") == 0)
                            OnBushChosen();
                        if (hitBar.collider.name.CompareTo("Pine") == 0)
                            OnPineChosen();
                        if (hitBar.collider.name.CompareTo("RedWood") == 0)
                            OnRedwoodChosen();
                        print($"bar uderza w {hitBar.collider.name}");
                    }
                    else
                    {
                        NaturalMenu.SetActive(false);
                        NeutralMenu.SetActive(false);
                        PollutedMenu.SetActive(false);
                        ShouldInstantiate = true;
                        return;
                    }

                    ShouldInstantiate = false;
                }
                else
                {

                    NaturalMenu.SetActive(false);
                    NeutralMenu.SetActive(false);
                    PollutedMenu.SetActive(false);
                    ShouldInstantiate = true;
                    return;
                }*/
        #endregion

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
                Debug.LogError("Uderzony Hex nie ma wartosci state");    
                break;

        }
    }

    private void DetectPosition()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        Physics.Raycast(ray, out hitHexa, Mathf.Infinity, 1 << 9);
    }

    private void CastABarRay()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        Physics.Raycast(ray, out hitBar, Mathf.Infinity, 1 << 5);

        if (hitBar.collider != null)
            print(hitBar.collider.name);
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
