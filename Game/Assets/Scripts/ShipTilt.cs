using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;

public class ShipTilt : MonoBehaviour
{
    //scripting for 3D sound events. Thank you Scott Game Sounds for your life-saving tutorial

    //lets dev choose the sound event visually rather than hardcoding
    [FMODUnity.EventRef]
    public string tiltPlay;
    [FMODUnity.EventRef]
    public string forwardPlay;

    //the event that will be played in code
    FMOD.Studio.EventInstance tiltEvent;
    FMOD.Studio.EventInstance forwardEvent;

    void Start()
    {
        //create an instance for the sound event(s)
        tiltEvent = FMODUnity.RuntimeManager.CreateInstance(tiltPlay);
        forwardEvent = FMODUnity.RuntimeManager.CreateInstance(forwardPlay);
    }


    // Update is called once per frame
    void Update()
    {
        //on each frame update, play a sound in 3D space relative to position of fmod listener and object that has this script attached
        //from what I have found, one instance must be described for each sound event
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(tiltEvent, GetComponent<Transform>(), GetComponent<Rigidbody>());
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(forwardEvent, GetComponent<Transform>(), GetComponent<Rigidbody>());

        //method that controls which sound is played according to key presses (for now)
        Playsound();
        
    }

    //bit of a messy method, but it gets the point across for now. certain keys up and down trigger different sound events and options
    void Playsound()
    {
        //for the ship tilt sound, both Q and E are needed
        if ((Input.GetKeyDown(KeyCode.Q)) || (Input.GetKeyDown(KeyCode.E)))
        {
            tiltEvent.start(); //ShipTilt
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            forwardEvent.start(); //Test right now, sound not quite done
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            forwardEvent.stop(STOP_MODE.ALLOWFADEOUT); //a little short, needs better fade
        }
    }
}
