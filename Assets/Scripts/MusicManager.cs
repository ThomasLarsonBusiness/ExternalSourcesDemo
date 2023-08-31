using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AK.Wwise.Event musicEvent;
    public AK.Wwise.Event stopMusicEvent;

    public AK.Wwise.State loudState;
    public AK.Wwise.State softState;

    // Start is called before the first frame update
    void Start()
    {
        musicEvent.Post(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            loudState.SetValue();
        }

        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            softState.SetValue();
        }
    }

    private void OnDestroy()
    {
        stopMusicEvent.Post(gameObject);
    }
}
