using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;

// Converts a CSV file into usable Scriptable Objects
public class CSVtoVOSO
{
    // Path to the csv file
    private static string voCSVPath = "/Editor/CSVs/VOCSV.csv";

    /*Function that goes on the Unity toolbar. Used to generate the scriptable objects before runtime*/
    [MenuItem("Utilities/Generate Voice Lines")]
    public static void GenerateVoiceLines()
    {
        // Generates an array of strings, with each item being a new line in the csv file
        string[] allLines = File.ReadAllLines(Application.dataPath + voCSVPath);

        // Create a List
        List<VOLineStruct> voList = new List<VOLineStruct>();

        // A for loop that creates a new scriptable object per line in the array
        foreach(string s in allLines)
        {
            // Separates the individual items from the csv
            string[] splitData = s.Split(',');

            // Creates a scriptable object and sets its data
            //VoiceLines voiceLine = ScriptableObject.CreateInstance<VoiceLines>();
            //voiceLine.FileLoc = splitData[0];
            //voiceLine.Transcription = splitData[1];

            // Adds the scriptable object to a database with a file path that will be saved to the project
            //AssetDatabase.CreateAsset(voiceLine, $"Assets/Scripts/VOScriptableObjects/{voiceLine.Transcription}.asset");

            VOLineStruct voStruct = new VOLineStruct();
            voStruct.FilePath = splitData[0];
            voStruct.Transcription = splitData[1];

            if (voStruct.FilePath == "")
            {
                voList.Add(voStruct);
            }
        }

        Debug.Log(voList[0].Transcription);

        // Saves all of the scriptable objects made above.
        //AssetDatabase.SaveAssets();
    }
}
