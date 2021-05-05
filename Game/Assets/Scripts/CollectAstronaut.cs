using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectAstronaut : MonoBehaviour
{

    FMOD.Studio.EventInstance collection;

    private int counter = 0;

    void Start()
    {
        collection = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Astronaut/AstronautCollide");
    }

    void Update()
    {
        //This is here for testing purposes. Doesn't do well for trying to test other things, but at least the counter works as intended
        //Will not stick with Application.Quit(). Will change to enabling a UI element and disabling the game
        //(showing a win-screen and letting the player exit organically)

        /*if(counter == 8)  //probably should not hard-code this number (for future additions). works for now
        {
            Application.Quit();
        }*/

        FMODUnity.RuntimeManager.AttachInstanceToGameObject(collection, GetComponent<Transform>(), GetComponent<Rigidbody>());
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Collectable")
        {
            other.gameObject.SetActive(false);
            counter++;
            collection.setParameterByName("AstrosCollected", counter);  //IT WORKS OH MY GOD. A MIRACLE.
            collection.start();
            Debug.Log("Counter = " + counter);
        }

        //above works very well, astronauts disappear upon collision with ship
        //counter above increments upon touch of a "collectable" tagged object
        //now just need to translate the counter into a visual UI element and end the game once all astros are collected
    }
}
