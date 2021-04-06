using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;

public class ShipSound : MonoBehaviour
{
    //scripting for 3D sound events. Thank you Scott Game Sounds for your life-saving tutorial

    //lets dev choose the sound event visually rather than hardcoding
    [FMODUnity.EventRef]
    public string eventPath;

    //the event that will be played in code
    FMOD.Studio.EventInstance soundEvent;

    void Start()
    {
        //create an instance for the sound event
        soundEvent = FMODUnity.RuntimeManager.CreateInstance(eventPath);
    }


    // Update is called once per frame
    void Update()
    {
        //on each frame update, play a sound in 3D space relative to position of fmod listener and object that has this script attached
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(soundEvent, GetComponent<Transform>(), GetComponent<Rigidbody>());
        Playsound();
        
    }

    void Playsound()
    {
        //for the ship tilt sound, both Q and E are needed
        if ((Input.GetKeyDown(KeyCode.Q)) || (Input.GetKeyDown(KeyCode.E)))
        {
            soundEvent.start(); //ShipTilt
        }
    }
}
