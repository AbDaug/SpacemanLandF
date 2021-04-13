using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;

public class MainMenuSounds : MonoBehaviour
{
    //scripting for 3D sound events. Thank you Scott Game Sounds for your life-saving tutorial

    //lets dev choose the sound event visually rather than hardcoding
    [FMODUnity.EventRef]
    public string startPlay;
    [FMODUnity.EventRef]
    public string ambiencePlay;

    //the event that will be played in code
    FMOD.Studio.EventInstance startEvent;
    FMOD.Studio.EventInstance ambienceEvent;

    void Start()
    {
        //create an instance for the sound event(s)
        startEvent = FMODUnity.RuntimeManager.CreateInstance(startPlay);
        ambienceEvent = FMODUnity.RuntimeManager.CreateInstance(ambiencePlay);
    }


    // Update is called once per frame
    void Update()
    {
        //on each frame update, play a sound in 3D space relative to position of fmod listener and object that has this script attached
        //from what I have found, one instance must be described for each sound event
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(startEvent, GetComponent<Transform>(), GetComponent<Rigidbody>());
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(ambienceEvent, GetComponent<Transform>(), GetComponent<Rigidbody>());

        //method that controls which sound is played according to key presses (for now)
        Playsound();

    }

    //bit of a messy method, but it gets the point across for now. certain keys up and down trigger different sound events and options
    //TODO is probably a cleaner way to do this rather than a dozen if statements
    void Playsound()
    {
        //for the ship tilt sound, both Q and E are needed
        if (Input.GetKeyDown(KeyCode.Return))
        {
            startEvent.start(); //ShipTilt
        }
    }
}
