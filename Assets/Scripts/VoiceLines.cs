using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Voice Line", menuName = "Assets/Scripts/VOScriptableObjects")]
public class VoiceLines : ScriptableObject
{
    // Fields
    /*String of the file path that points to the source file*/
    [SerializeField]private string fileLoc;
    /*A transcription of the voice lines, in case we decide to go with subtitles*/
    [SerializeField]private string transcription;

    // Properties
    /*These simply allow other files to modify the variables. This lets us instantiate them
     in another script*/
    public string FileLoc
    {
        get { return fileLoc; }
        set { fileLoc = value; }
    }

    public string Transcription
    {
        get { return transcription; }
        set { transcription = value; }
    }

}
