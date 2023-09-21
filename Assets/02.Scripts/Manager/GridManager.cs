using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoSingleton<GridManager>
{
    [HideInInspector] public GameObject[] ownChampionInventoryArray;
    [HideInInspector] public GameObject[] oponentChampionInventoryArray;
    [HideInInspector] public GameObject[,] gridChampionsArray;
    public GameObject draggedChampion = null;
    public TriggerInfo dragStartTrigger = null;
    private void Start()
    {
        ownChampionInventoryArray = new GameObject[Map.inventorySize];
        oponentChampionInventoryArray = new GameObject[Map.inventorySize];
        gridChampionsArray = new GameObject[Map.hexMapSizeX, Map.hexMapSizeZ / 2];
    }

    public GameObject GetChampionFromTriggerInfo(TriggerInfo triggerinfo)
    {
        GameObject championGO = null;

        if (triggerinfo.gridType == Map.GRIDTYPE_OWN_INVENTORY)
        {
            championGO = ownChampionInventoryArray[triggerinfo.gridX];
        }
        else if (triggerinfo.gridType == Map.GRIDTYPE_OPONENT_INVENTORY)
        {
            championGO = oponentChampionInventoryArray[triggerinfo.gridX];
        }
        else if (triggerinfo.gridType == Map.GRIDTYPE_HEXA_MAP)
        {
            championGO = gridChampionsArray[triggerinfo.gridX, triggerinfo.gridZ];
        }

        return championGO;
    }

    public void StoreChampionInArray(int gridType, int gridX, int gridZ, GameObject champion)
    {
        //assign current trigger to champion
        ChampionController championController = champion.GetComponent<ChampionController>();
        championController.SetGridPosition(gridType, gridX, gridZ);

        if (gridType == Map.GRIDTYPE_OWN_INVENTORY)
        {
            ownChampionInventoryArray[gridX] = champion;
        }
        else if (gridType == Map.GRIDTYPE_HEXA_MAP)
        {
            gridChampionsArray[gridX, gridZ] = champion;
        }
    }

    public void RemoveChampionFromArray(int type, int gridX, int gridZ)
    {
        if (type == Map.GRIDTYPE_OWN_INVENTORY)
        {
            ownChampionInventoryArray[gridX] = null;
        }
        else if (type == Map.GRIDTYPE_HEXA_MAP)
        {
            gridChampionsArray[gridX, gridZ] = null;
        }
    }

    public int GetChampionCountOnHexGrid()
    {
        int count = 0;
        for (int x = 0; x < Map.hexMapSizeX; x++)
        {
            for (int z = 0; z < Map.hexMapSizeZ / 2; z++)
            {
                //there is a champion
                if (gridChampionsArray[x, z] != null)
                {
                    count++;
                }
            }
        }

        return count;
    }
}
