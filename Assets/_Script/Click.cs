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
    public LayerMask layer;
    GameObject TargetMenu;
    
    Vector3 hitHexaPosition;
    Vector3 hitBarPosition;
    RaycastHit hitHexa;
    RaycastHit hitBar;

    bool ShouldInstantiate = true;
    void Update()
    {
        var rightClick = Input.GetKeyDown(KeyCode.Mouse1);
        var leftClick = Input.GetKeyDown(KeyCode.Mouse0);
        CastABarRay();
        print(TargetMenu);
        if (rightClick || leftClick || Input.GetKey(KeyCode.Mouse2))
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

                    ShouldInstantiate = false;
                }
                else
                {
                    Destroy(TargetMenu);
                    ShouldInstantiate = true;
                    return;
                }
                

        if (rightClick)
        {
            DetectPosition();
            SetTargetMenu();

            try
            {
                //wyswietl menu zwiazne z danym polem
                
            }
            catch(Exception ex)
            {
                Debug.LogError($"Error: {ex.Message}");
                return;
            }
        }
        else if (leftClick)
        {
            try
            {
                //zatwierdz akcje
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error: {ex.Message}");
                return;
            }
           
        }
            
    }

    private void SetTargetMenu()
    {
        if (hitHexa.collider == null)
            return;
        var HexaStatus = hitHexa.collider.gameObject.GetComponent<Hex>().HexState;
        Debug.Log($"Hit: {HexaStatus} ");
        
        switch (HexaStatus)
        {
            case HexState.Natural:
                //var HexaHasTree = (hit.collider.gameObject.GetComponentInChildren<ItemTree>() != null);
                //if (HexaHasTree)
                    //TargetMenu = Instantiate(NaturalMenu, new Vector3(hitPosition.x, hitPosition.y, 5f), Quaternion.identity);
                //else
                if(ShouldInstantiate)
                    TargetMenu = Instantiate(NeutralMenu, new Vector3(hitHexaPosition.x, hitHexaPosition.y, 5f), Quaternion.identity);
                break;
            case HexState.Polluted:
                if (ShouldInstantiate)
                    TargetMenu = Instantiate(PollutedMenu, new Vector3(hitHexaPosition.x, hitHexaPosition.y, 5f), Quaternion.identity);
                break;
            case HexState.Neutral:
                if (ShouldInstantiate)
                    TargetMenu = Instantiate(NeutralMenu,new Vector3(hitHexaPosition.x, hitHexaPosition.y,5f), Quaternion.identity);
                hitHexa.collider.GetComponent<MeshRenderer>().material = mat;
                break;

            default:
                Debug.LogError("Uderzony Hex nie ma wartosci state");    
                break;

        }
    }

    private void DetectPosition()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hitHexa, Mathf.Infinity, 1 << 9))
        {
            hitHexaPosition = hitHexa.point * 5;
        }

    }

    private void CastABarRay()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hitBar, Mathf.Infinity, 1 << 5))
        {
            hitBarPosition = hitBar.point;
            print("trafiam w bara");
        }

        if (hitBar.collider != null)
            print(hitBar.collider.name);
    }

    #region Natural Menu Actions

    public void OnOakChosen()
    {
        print("Oak !!!!");
    }
    public void OnBushChosen()
    {
        print("Bush !!!!");

    }
    public void OnPineChosen()
    {
        print("Pine !!!!");

    }
    public void OnRedwoodChosen()
    {
        print("Redwood !!!!");

    }

    #endregion 


}
