using UnityEngine;
using System.Collections;

public class DataBaseObject:MonoBehaviour{
    [HideInInspector]
    public bool oFlora;
    [HideInInspector]
    public bool oFuana;
    [HideInInspector]
    public bool oMineral;
    [HideInInspector]
    public string oName;
    [HideInInspector]
    public string oDescription;
    [HideInInspector]
    public int oIndexNumber;//Number in the database in alphabetical order
    [HideInInspector]
    public int oDiet;//0 for Omnivore, 1 for Herbivore, 2 for Carnivore
    [HideInInspector]
    public int oBehaviourNumber;//0 for Passive, 1 for Aggressive, 2 for Docile
    [HideInInspector]
    public bool oSeenByPlayer;//Whether or not the player has 'scanned' the object

  //  public struct objStruct
  //  {
  //      public string name;
  //      public string scientificName;
  //  }
   
   
  
}
