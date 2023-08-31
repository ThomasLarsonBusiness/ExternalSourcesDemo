using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct VOLineStruct
{
    // Fields
    private string filePath;
    private string transcription;

    // Properties
    public string FilePath
    {
        get { return filePath; }
        set { filePath = value; }
    }

    public string Transcription
    {
        get { return transcription; }
        set { transcription = value; }
    }
}


