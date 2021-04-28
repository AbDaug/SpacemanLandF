using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectAstronaut : MonoBehaviour
{

    private float counter = 0;

    void Update()
    {
        //This is here for testing purposes. Doesn't do well for trying to test other things, but at least the counter works as intended
        //Will not stick with Application.Quit(). Will change to enabling a UI element and disabling the game
        //(showing a win-screen and letting the player exit organically)

        /*if(counter == 8)  //probably should not hard-code this number (for future additions). works for now
        {
            Application.Quit();
        }*/
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Collectable")
        {
            other.gameObject.SetActive(false);
            counter++;
            Debug.Log("Counter = " + counter);
        }

        //above works very well, astronauts disappear upon collision with ship
        //counter above increments upon touch of a "collectable" tagged object
        //now just need to translate the counter into a visual UI element and end the game once all astros are collected
    }
}
