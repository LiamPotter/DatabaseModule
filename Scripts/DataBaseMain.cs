using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class DataBaseMain : MonoBehaviour {
    //This list hold the gameobjects that are scanned from the scene
    [HideInInspector]
    public List<DataBaseObject> dObjectsList;

    public List<DataBaseObject> dObjectsFloraList;

    public List<DataBaseObject> dObjectsFaunaList;

    public List<DataBaseObject> dObjectsMineralList;
    public void Start()
    {
        //Finding all of the DataBaseObjects in the scene
        FindAllDatabaseObjects(dObjectsList);
        //Sorting the List by the oName variable in each DataBaseObject
        SortAllDataBaseObjects(dObjectsList);
        //Adds the objects into various Lists depending on their Type
        AddObjectsToSubLists(dObjectsList, dObjectsFloraList, dObjectsFaunaList, dObjectsMineralList);
        //Removing all duplicates in the list by comparing the oName variables on each DataBaseObject in the List
        RemoveDuplicatesInDataBases(dObjectsList,dObjectsFloraList,dObjectsFaunaList,dObjectsMineralList);
      

    }
    public static void FindAllDatabaseObjects(List<DataBaseObject> dObjectsTemp)
    {
        
        for (int i = 0; i < FindObjectsOfType<DataBaseObject>().Length; i++)
        {
            dObjectsTemp.Add(FindObjectsOfType<DataBaseObject>()[i]);
        }
        Debug.Log("FindingObjects");
    }
    public static void SortAllDataBaseObjects(List<DataBaseObject> dObjectsTemp)
    {
        dObjectsTemp.Sort(delegate (DataBaseObject x, DataBaseObject y)
        {
            if (x.oName == null && y.oName == null) return 0;
            else if (x.oName == null) return -1;
            else if (y.oName == null) return 1;
            else return x.oName.CompareTo(y.oName);
        });
    }  
    public static void AddObjectsToSubLists(List<DataBaseObject> dObjectsTemp, List<DataBaseObject> dObjectsFloraTemp, List<DataBaseObject> dObjectsFaunaTemp, List<DataBaseObject> dObjectsMineralTemp)
    {
        for (int i = 0; i < dObjectsTemp.Count; i++)
        {
            if (dObjectsTemp[i].oObjectType == 0)
            {
                dObjectsFloraTemp.Add(dObjectsTemp[i]);
            }
            if (dObjectsTemp[i].oObjectType == 1)
            {
                dObjectsFaunaTemp.Add(dObjectsTemp[i]);
            }
            if (dObjectsTemp[i].oObjectType == 2)
            {
                dObjectsMineralTemp.Add(dObjectsTemp[i]);
            }
            dObjectsTemp[i].oIndexNumber = i;
        }
    }
    public static void RemoveDuplicatesInDataBases(List<DataBaseObject> dObjectsTemp, List<DataBaseObject> dObjectsFloraTemp, List<DataBaseObject> dObjectsFaunaTemp, List<DataBaseObject> dObjectsMineralTemp)
    {
        short indexO = 0;
        while (indexO < dObjectsTemp.Count - 1)
        {
            if (dObjectsTemp[indexO].oName == dObjectsTemp[indexO + 1].oName)
                dObjectsTemp.RemoveAt(indexO);
            else
                indexO++;
        }
        short indexFlo = 0;
        while (indexFlo < dObjectsFloraTemp.Count - 1)
        {
            if (dObjectsFloraTemp[indexFlo].oName == dObjectsFloraTemp[indexFlo + 1].oName)
                dObjectsFloraTemp.RemoveAt(indexFlo);
            else
                indexFlo++;
        }
        short indexFau = 0;
        while (indexFau < dObjectsFaunaTemp.Count - 1)
        {
            if (dObjectsFaunaTemp[indexFau].oName == dObjectsFaunaTemp[indexFau + 1].oName)
                dObjectsFaunaTemp.RemoveAt(indexFau);
            else
                indexFau++;
        }
        short indexMin = 0;
        while (indexMin < dObjectsMineralTemp.Count - 1)
        {
            if (dObjectsMineralTemp[indexMin].oName == dObjectsMineralTemp[indexMin + 1].oName)
                dObjectsMineralTemp.RemoveAt(indexMin);
            else
                indexMin++;
        }
    }
}
