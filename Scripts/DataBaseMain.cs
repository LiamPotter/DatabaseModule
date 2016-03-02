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

    public GameObject dataBaseCanvasInvis;
    public void Start()
    {
        dataBaseCanvasInvis = GameObject.Find("DatabaseUIPanelInvis");
        ResetAllDatabases(dObjectsList, dObjectsFloraList, dObjectsFaunaList, dObjectsMineralList, dataBaseCanvasInvis);
        //Finding all of the DataBaseObjects in the scene
        FindAllDatabaseObjects(dObjectsList);
        //Sorting the List by the oName variable in each DataBaseObject
        SortAllDataBaseObjects(dObjectsList);
        //Adds the objects into various Lists depending on their Type
        AddObjectsToSubLists(dObjectsList, dObjectsFloraList, dObjectsFaunaList, dObjectsMineralList);
        //Removing all duplicates in the list by comparing the oName variables on each DataBaseObject in the List
        RemoveDuplicatesInDataBases(dObjectsList,dObjectsFloraList,dObjectsFaunaList,dObjectsMineralList);
        //Adding all objects in the database to their respective UI elements
        InstantiateUIElements(dObjectsList,dataBaseCanvasInvis);
    }
    public static void ResetAllDatabases(List<DataBaseObject> dObjectsTemp, List<DataBaseObject> dObjectsFloraTemp, List<DataBaseObject> dObjectsFaunaTemp, List<DataBaseObject> dObjectsMineralTemp,GameObject invisCanvas)
    {
        if (invisCanvas == null)
            invisCanvas = GameObject.Find("DatabaseUIPanelInvis");
        for (int i = 0; i < dObjectsTemp.Count; i++)
        {
            dObjectsTemp[i].oIndexNumber = 0;
        }
        dObjectsTemp.Clear();
        dObjectsFloraTemp.Clear();
        dObjectsFaunaTemp.Clear();
        dObjectsMineralTemp.Clear();

        List<GameObject> children = new List<GameObject>();
        foreach (Transform child in invisCanvas.transform) children.Add(child.gameObject);
        children.ForEach(child => DestroyImmediate(child));
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
            dObjectsTemp[i].oIndexNumber = 1+i;
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
    public static void InstantiateUIElements(List<DataBaseObject> dObjectsTemp,GameObject canvas)
    {
        if(canvas==null)
        {
            canvas = GameObject.Find("DatabaseUIPanelInvis");
        }
        int paddingInt = 100;
        for (int i = 0; i < dObjectsTemp.Count; i++)
        {
            if (dObjectsTemp[i].oUIObject == null)
            {
                dObjectsTemp[i].oUIObject = (GameObject)Instantiate(dObjectsTemp[i].oUIPrefab);
                dObjectsTemp[i].oUIObject.transform.SetParent(canvas.transform);
                dObjectsTemp[i].oUIObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1156);
                dObjectsTemp[i].oUIObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 90);
                dObjectsTemp[i].oUIObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                if (dObjectsTemp[i] == dObjectsTemp[0])
                    dObjectsTemp[i].oUIObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-277, -175, 0);
                else
                {
                    dObjectsTemp[i].oUIObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-277, -175-paddingInt*i, 0);
                }
               
                dObjectsTemp[i].oUIObject.name = dObjectsTemp[i].oName + " UI";
                dObjectsTemp[i].oUIObject.GetComponent<UIObjectDropdown>().FindAllNeededUIElements();
                if (dObjectsTemp[i].oUIObject.GetComponent<UIObjectDropdown>().foundAllElements)
                {
                    dObjectsTemp[i].oUIObject.GetComponent<UIObjectDropdown>().uName.text = dObjectsTemp[i].oName;
                    dObjectsTemp[i].oUIObject.GetComponent<UIObjectDropdown>().uIndexNumber.text = dObjectsTemp[i].oIndexNumber.ToString()+" :";
                }
            }
        }
    }
}
