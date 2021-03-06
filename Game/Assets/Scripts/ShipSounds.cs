using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;

public class ShipSounds : MonoBehaviour
{
    //scripting for 3D sound events. Thank you Scott Game Sounds for your life-saving tutorial

    //lets dev choose the sound event visually rather than hardcoding
    [FMODUnity.EventRef]
    public string tiltPlay;
    [FMODUnity.EventRef]
    public string forwardPlay;
    [FMODUnity.EventRef]
    public string backwardPlay;
    [FMODUnity.EventRef]
    public string sidePlay;

    //the event that will be played in code
    FMOD.Studio.EventInstance tiltEvent;
    FMOD.Studio.EventInstance forwardEvent;
    FMOD.Studio.EventInstance backwardEvent;
    FMOD.Studio.EventInstance sideEvent;

    void Start()
    {
        //create an instance for the sound event(s)
        tiltEvent = FMODUnity.RuntimeManager.CreateInstance(tiltPlay);
        forwardEvent = FMODUnity.RuntimeManager.CreateInstance(forwardPlay);
        backwardEvent = FMODUnity.RuntimeManager.CreateInstance(backwardPlay);
        sideEvent = FMODUnity.RuntimeManager.CreateInstance(sidePlay);
    }


    // Update is called once per frame
    void Update()
    {
        //on each frame update, play a sound in 3D space relative to position of fmod listener and object that has this script attached
        //from what I have found, one instance must be described for each sound event
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(tiltEvent, GetComponent<Transform>(), GetComponent<Rigidbody>());
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(forwardEvent, GetComponent<Transform>(), GetComponent<Rigidbody>());
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(backwardEvent, GetComponent<Transform>(), GetComponent<Rigidbody>());
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(sideEvent, GetComponent<Transform>(), GetComponent<Rigidbody>());

        //method that controls which sound is played according to key presses (for now)
        Playsound();
        
    }

    //bit of a messy method, but it gets the point across for now. certain keys up and down trigger different sound events and options
    //TODO is probably a cleaner way to do this rather than a dozen if statements
    void Playsound()
    {
        //for the ship tilt sound, both Q and E are needed
        if ((Input.GetKeyDown(KeyCode.Q)) || (Input.GetKeyDown(KeyCode.E)))
        {
            tiltEvent.start(); //ShipTilt
        }
        if ((Input.GetKeyUp(KeyCode.Q)) || (Input.GetKeyUp(KeyCode.E)))
        {
            tiltEvent.stop(STOP_MODE.ALLOWFADEOUT); //ShipTilt
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            forwardEvent.start(); //ShipForward
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            forwardEvent.stop(STOP_MODE.ALLOWFADEOUT); //a little short, perhaps needs better fadeout
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            backwardEvent.start(); //ShipBackward
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            backwardEvent.stop(STOP_MODE.ALLOWFADEOUT); //a little short, perhaps needs better fade
        }

        if ((Input.GetKeyDown(KeyCode.A)) || (Input.GetKeyDown(KeyCode.D)))
        {
            sideEvent.start();
        }
        if ((Input.GetKeyUp(KeyCode.A)) || (Input.GetKeyUp(KeyCode.D)))
        {
            sideEvent.stop(STOP_MODE.ALLOWFADEOUT);
        }
    }
}
