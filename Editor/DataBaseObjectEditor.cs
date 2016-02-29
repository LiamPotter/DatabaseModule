using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(DataBaseObject))]
public class DataBaseObjectEditor : Editor {

    //This is the Editor Script for the DataBaseObject script
    //Creating this Editor Script allows for more flexibility in code
    //and makes it easier to quickly add new objects

    private int dietIndex;
    private int behaviourIndex;
  
    //Will hide the Fauna options if 0, will display if 1
    private int hidingFuanaInt;
    //The three Object Types
    private string[] objectTypes = new string[] { "Flora", "Fuana", "Mineral" };
    //This int will be 0 for Flora, 1 for Fuana and 2 for Mineral
    private int selectedObjectType;
    //The three different Diet Options 
    private string[] dietOptions = new string[] {"Omnivore","Herbivore","Carnivore"};
    //The three different Behaviour Options
    private string[] behaviourOptions = new string[] { "Passive", "Aggressive", "Docile" };
    public override void OnInspectorGUI()
    {
        DataBaseObject thisDataBaseObject = (DataBaseObject)target;
        thisDataBaseObject.oName=EditorGUILayout.TextField("Name",thisDataBaseObject.oName);
        thisDataBaseObject.oDescription = EditorGUILayout.TextField("Description", thisDataBaseObject.oDescription);
        selectedObjectType = EditorGUILayout.Popup("Object Type", selectedObjectType, objectTypes);
        
        //Sets the various bools based on the SelectedObjectType variable
        if (selectedObjectType == 0)
            thisDataBaseObject.oFlora = true;
        else thisDataBaseObject.oFlora = false;
        if (selectedObjectType == 1)
            thisDataBaseObject.oFuana = true;
        else thisDataBaseObject.oFuana = false;
        if (selectedObjectType == 2)
            thisDataBaseObject.oMineral = true;
        else thisDataBaseObject.oMineral = false;
        Debug.Log(hidingFuanaInt);
        //This will hide the Diet Popup if the object is a plant, because plants do eat things... usually
        if (thisDataBaseObject.oFlora||thisDataBaseObject.oMineral)
        {
            hidingFuanaInt = 0;
        }
        else hidingFuanaInt = 1;
        if (EditorGUILayout.BeginFadeGroup(hidingFuanaInt))
        {
            dietIndex = EditorGUILayout.Popup("Diet", dietIndex, dietOptions);
            behaviourIndex = EditorGUILayout.Popup("Behaviour", behaviourIndex, behaviourOptions);
        }
        EditorGUILayout.EndFadeGroup();
        thisDataBaseObject.oDiet = dietIndex;
        thisDataBaseObject.oBehaviourNumber = behaviourIndex;
        //This is SUPPOSSED to make the bools toggle eachother, but only by toggling flora will make it work right now
        if (thisDataBaseObject.oFlora == true)
            thisDataBaseObject.oFuana = false;   
        if (thisDataBaseObject.oFlora == false)
            thisDataBaseObject.oFuana = true;
     
        EditorGUILayout.LabelField("Index Number", thisDataBaseObject.oIndexNumber.ToString());
        thisDataBaseObject.oSeenByPlayer = EditorGUILayout.Toggle("Seen By Player?", thisDataBaseObject.oSeenByPlayer);
        base.OnInspectorGUI();
    }
   
}
