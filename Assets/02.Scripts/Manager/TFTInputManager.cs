using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TFTInputManager : MonoSingleton<TFTInputManager>
{
    //map script
    public Map map;


    public LayerMask triggerLayer;

    //declare ray starting position var
    private Vector3 rayCastStartPosition;

    // Start is called before the first frame update
    void Start()
    {
        //set position of ray starting point to trigger objects
        rayCastStartPosition = new Vector3(0, 20, 0);
    }

    //to store mouse position
    private Vector3 mousePosition;


    [HideInInspector]
    public TriggerInfo triggerInfo = null;

    /// Update is called once per frame
    void Update()
    {
        triggerInfo = null;
        map.resetIndicators();

        //declare rayhit
        RaycastHit hit;

        //convert mouse screen position to ray
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //if ray hits something
        if (Physics.Raycast(ray, out hit, 100f, triggerLayer, QueryTriggerInteraction.Collide))
        {
            //get trigger info of the  hited object
            triggerInfo = hit.collider.gameObject.GetComponent<TriggerInfo>();

            //this is a trigger
            if (triggerInfo != null)
            {
                //get indicator
                GameObject indicator = map.GetIndicatorFromTriggerInfo(triggerInfo);

                //set indicator color to active
                indicator.GetComponent<MeshRenderer>().material.color = map.indicatorActiveColor;
            }
            else
                map.resetIndicators(); //reset colors
        }


        if (Input.GetMouseButtonDown(0)) StartDrag();

        if (Input.GetMouseButtonUp(0)) StopDrag();

        mousePosition = Input.mousePosition;
    }

    public void StartDrag()
    {
        TriggerInfo triggerinfo = triggerInfo;

        if (triggerinfo != null)
        {
            GridManager.Inst.dragStartTrigger = triggerinfo;

            GameObject championGO = GridManager.Inst.GetChampionFromTriggerInfo(triggerinfo);

            if (championGO != null)
            {
                //show indicators
                map.ShowIndicators();

                GridManager.Inst.draggedChampion = championGO;

                //isDragging = true;

                championGO.GetComponent<ChampionController>().IsDragged = true;
                //Debug.Log("STARTDRAG");
            }

        }
    }

    public void StopDrag()
    {
        //hide indicators
        map.HideIndicators();

        int championsOnField = GridManager.Inst.GetChampionCountOnHexGrid();


        if (GridManager.Inst.draggedChampion != null)
        {
            //set dragged
            GridManager.Inst.draggedChampion.GetComponent<ChampionController>().IsDragged = false;

            //get trigger info
            TriggerInfo triggerinfo = triggerInfo;

            //if mouse cursor on trigger
            if (triggerinfo != null)
            {
                //get current champion over mouse cursor
                GameObject currentTriggerChampion = GridManager.Inst.GetChampionFromTriggerInfo(triggerinfo);

                //there is another champion in the way
                if (currentTriggerChampion != null)
                {
                    //store this champion to start position
                    GridManager.Inst.StoreChampionInArray(GridManager.Inst.dragStartTrigger.gridType, GridManager.Inst.dragStartTrigger.gridX, GridManager.Inst.dragStartTrigger.gridZ, currentTriggerChampion);

                    //store this champion to dragged position
                    GridManager.Inst.StoreChampionInArray(triggerinfo.gridType, triggerinfo.gridX, triggerinfo.gridZ, GridManager.Inst.draggedChampion);
                }
                else
                {
                    //we are adding to combat field
                    if (triggerinfo.gridType == Map.GRIDTYPE_HEXA_MAP)
                    {
                        //only add if there is a free spot or we adding from combatfield
                        if (championsOnField < InfoManager.Inst.currentInfo.currentChampionLimit || GridManager.Inst.dragStartTrigger.gridType == Map.GRIDTYPE_HEXA_MAP)
                        {
                            //remove champion from dragged position
                            GridManager.Inst.RemoveChampionFromArray(GridManager.Inst.dragStartTrigger.gridType, GridManager.Inst.dragStartTrigger.gridX, GridManager.Inst.dragStartTrigger.gridZ);

                            //add champion to dragged position
                            GridManager.Inst.StoreChampionInArray(triggerinfo.gridType, triggerinfo.gridX, triggerinfo.gridZ, GridManager.Inst.draggedChampion);

                            if (GridManager.Inst.dragStartTrigger.gridType != Map.GRIDTYPE_HEXA_MAP)
                                championsOnField++;
                        }
                    }
                    else if (triggerinfo.gridType == Map.GRIDTYPE_OWN_INVENTORY)
                    {
                        //remove champion from dragged position
                        GridManager.Inst.RemoveChampionFromArray(GridManager.Inst.dragStartTrigger.gridType, GridManager.Inst.dragStartTrigger.gridX, GridManager.Inst.dragStartTrigger.gridZ);

                        //add champion to dragged position
                        GridManager.Inst.StoreChampionInArray(triggerinfo.gridType, triggerinfo.gridX, triggerinfo.gridZ, GridManager.Inst.draggedChampion);

                        if (GridManager.Inst.dragStartTrigger.gridType == Map.GRIDTYPE_HEXA_MAP)
                            championsOnField--;
                    }



                }




            }

            InfoManager.Inst.currentInfo.currentChampionCount = GridManager.Inst.GetChampionCountOnHexGrid();

            GridManager.Inst.draggedChampion = null;
        }


    }
}
