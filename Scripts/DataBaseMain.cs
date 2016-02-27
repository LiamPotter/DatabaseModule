using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class DataBaseMain : MonoBehaviour {
    public List<DataBaseObject> dObjectsListRaw;
    
    public void Start()
    {
        
        //Finding all of the DataBaseObjects in the scene
        for (int i = 0; i < FindObjectsOfType<DataBaseObject>().Length; i++)
        {
            dObjectsListRaw.Add(FindObjectsOfType<DataBaseObject>()[i]);
        }  
        //Sorting the List by the oName variable in each DataBaseObject
        dObjectsListRaw.Sort(delegate (DataBaseObject x, DataBaseObject y)
        {
            if (x.oName == null && y.oName == null) return 0;
            else if (x.oName == null) return -1;
            else if (y.oName == null) return 1;
            else return x.oName.CompareTo(y.oName);
        });
        //Removing all duplicates in the list by comparing the oName variables on each DataBaseObject in the List
        short index = 0;
        while (index < dObjectsListRaw.Count - 1)
        {
            if (dObjectsListRaw[index].oName == dObjectsListRaw[index + 1].oName)
                dObjectsListRaw.RemoveAt(index);
            else
                index++;
        }



    }
	
}
