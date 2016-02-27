using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(DataBaseObject))]
public class DataBaseObjectEditor : Editor {

    //This is the Editor Script for the DataBaseObject script
    //Creating this Editor Script allows for more flexibility in code
    //and makes it easier to quickly add new objects

    private int dietIndex;
    //Will hide the Fauna options if 0, will display if 1
    private int hidingFuanaInt;
    //The three different Diet Options 
    private string[] dietOptions = new string[] {"Omnivore","Herbivore","Carnivore"};
    public override void OnInspectorGUI()
    {
        DataBaseObject thisDataBaseObject = (DataBaseObject)target;
        thisDataBaseObject.oName=EditorGUILayout.TextField("Name",thisDataBaseObject.oName);
        thisDataBaseObject.oDescription = EditorGUILayout.TextField("Description", thisDataBaseObject.oDescription);
        thisDataBaseObject.oFlora = EditorGUILayout.Toggle("Flora", thisDataBaseObject.oFlora);
        thisDataBaseObject.oFuana = EditorGUILayout.Toggle("Fuana", thisDataBaseObject.oFuana);

        //This will hide the Diet Popup if the object is a plant, because plants do eat things... usually
        if (thisDataBaseObject.oFlora)
        {
            hidingFuanaInt = 0;
        }
        else hidingFuanaInt = 1;
        if (EditorGUILayout.BeginFadeGroup(hidingFuanaInt))
        {
            dietIndex = EditorGUILayout.Popup("Diet", dietIndex, dietOptions);
        }
        EditorGUILayout.EndFadeGroup();
        thisDataBaseObject.oDiet = dietIndex;
        //This is SUPPOSSED to make the bools toggle eachother, but only by toggling flora will make it work right now
        if (thisDataBaseObject.oFlora == true)
            thisDataBaseObject.oFuana = false;   
        if (thisDataBaseObject.oFlora == false)
            thisDataBaseObject.oFuana = true;
     

        EditorGUILayout.LabelField("Index Number", thisDataBaseObject.oIndexNumber.ToString());
        base.OnInspectorGUI();
    }
   
}
