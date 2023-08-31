using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExternalSourcesTest : MonoBehaviour
{
    // Fields
    /*These are Scriptable Objects that store data. In this case, 
     the data they are storing is the filepath the source file*/
    [SerializeField] private VoiceLines vl1;
    [SerializeField] private VoiceLines vl2;

    /*A test event for testing efficiency values*/
    //public AK.Wwise.Event inSourceEvent;

    /*Wwise data types that hold the information so the computer knows what Wwise source and sound file to use*/
    AkExternalSourceInfoArray sources1;
    AkExternalSourceInfoArray sources2;

    /*A variable to store the ID of the game object so wwise can call it*/
    ulong gameObjectID;

    // Calls when the script is first made
    void Awake()
    {
        /*
         Sets up all of the data needed to reference and external source
         LINE1: Actually instantiates the wwise data type. In this case, we had it create 1 internal item. We could have it generate more, 
            allowing us to call sequences of external sources.
         LINE2: Gets the id for the external source from wwise. This is essentially assigning which external source to use.
         LINE3: This sets the file location. It is a file path starting from the GeneratedSoundbanks folder. In this example, this info is
            stored in the scriptable object.
         LINE4: This sets the codec to use. In this case, the codec should match whatever codec used to compress the file, based on the 
            conversion settings.
        */
        // Update the sources information
        sources1 = new AkExternalSourceInfoArray(1);
        sources1[0].iExternalSrcCookie = AkSoundEngine.GetIDFromString("External_Source");
        sources1[0].szFile = vl1.FileLoc;
        sources1[0].idCodec = AkSoundEngine.AKCODECID_ADPCM;

        // Update the sources information
        sources2 = new AkExternalSourceInfoArray(1);
        sources2[0].iExternalSrcCookie = AkSoundEngine.GetIDFromString("External_Source");
        sources2[0].szFile = vl2.FileLoc;
        sources2[0].idCodec = AkSoundEngine.AKCODECID_ADPCM;

        /*This is an ID used to tell wwise which game object to eminate the sound from*/
         gameObjectID = (ulong)gameObject.GetInstanceID();
    }

    // Update is called once per frame
    void Update()
    {
        //EffeciencyTest();
        //EffeciencyTest2();
        //EffeciencyTest3();

        // Triggers when the player presses the 1 key
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            /*
            Calls the event in wwise and sets the external sources
            Argument1: The name of the event to post to.
            Argument2: The gameObjectID of the game object we want the sound to eminate from
            Argument3: Callback Flags (just set to zero)
            Argument4: Callback Function (just set to null)
            Argument5: Callback cookie that is sent to the callback function (Since no callback, can set to 0)
            Argument6: Number of sources we are setting up. In this example it is only 1 source, but if we had a
                sequence container with multiple sources, we could set up multiple sources up simultaneously
            Argument7: The AkExternalSourceInfoArray we set the info for above. Will need a number of items equal to 
                the number set in Argument6          
             Based on what I have seen, for use we will only be modifying Arguments 1, 2, 6, and 7 
            */
            AkSoundEngine.PostEvent("ExtSourceTestEvent", gameObjectID, 0, null, 0, 1, sources1);
            
        }

        // Triggers when the player presses the 2 key
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            /*
            Calls the event in wwise and sets the external sources
            Argument1: The name of the event to post to.
            Argument2: The gameObjectID of the game object we want the sound to eminate from
            Argument3: Callback Flags (just set to zero)
            Argument4: Callback Function (just set to null)
            Argument5: Callback cookie that is sent to the callback function (Since no callback, can set to 0)
            Argument6: Number of sources we are setting up. In this example it is only 1 source, but if we had a
                sequence container with multiple sources, we could set up multiple sources up simultaneously
            Argument7: The AkExternalSourceInfoArray we set the info for above. Will need a number of items equal to 
                the number set in Argument6          
             Based on what I have seen, for use we will only be modifying Arguments 1, 2, 6, and 7 
            */
            // Calls the external source event and sends the necessary information
            AkSoundEngine.PostEvent("ExtSourceTestEvent", (ulong)gameObject.GetInstanceID(), 0, null, 0, 1, sources2);
        }
    }


    /* These were all for effeciency testing, you can ignore these
    void EffeciencyTest()
    {
        AkSoundEngine.PostEvent("ExtSourceTestEvent", gameObjectID, 0, null, 0, 1, sources1);
        AkSoundEngine.PostEvent("ExtSourceTestEvent", gameObjectID, 0, null, 0, 1, sources1);
        AkSoundEngine.PostEvent("ExtSourceTestEvent", gameObjectID, 0, null, 0, 1, sources1); // Benchmark 60B
    }

    void EffeciencyTest2()
    {
        Transform transTemp = (Transform)this.GetComponent("Transform");
        Transform transTemp1 = (Transform)this.GetComponent("Transform"); // Benchmark 0B
    }


    void EffeciencyTest3()
    {
        inSourceEvent.Post(gameObject);
        inSourceEvent.Post(gameObject);
        inSourceEvent.Post(gameObject); // Benchmark 0B
    }
    */
}
