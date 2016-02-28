using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class DataBaseMain : MonoBehaviour {
    public List<DataBaseObject> dObjectsList;
    
    public void Start()
    {
        
        //Finding all of the DataBaseObjects in the scene
        for (int i = 0; i < FindObjectsOfType<DataBaseObject>().Length; i++)
        {
            dObjectsList.Add(FindObjectsOfType<DataBaseObject>()[i]);
        }  
        //Sorting the List by the oName variable in each DataBaseObject
        dObjectsList.Sort(delegate (DataBaseObject x, DataBaseObject y)
        {
            if (x.oName == null && y.oName == null) return 0;
            else if (x.oName == null) return -1;
            else if (y.oName == null) return 1;
            else return x.oName.CompareTo(y.oName);
        });
        //Removing all duplicates in the list by comparing the oName variables on each DataBaseObject in the List
        short index = 0;
        while (index < dObjectsList.Count - 1)
        {
            if (dObjectsList[index].oName == dObjectsList[index + 1].oName)
                dObjectsList.RemoveAt(index);
            else
                index++;
        }
        for (int i = 0; i < dObjectsList.Count; i++)
        {
            dObjectsList[i].oIndexNumber = i;
        }



    }
	
}
