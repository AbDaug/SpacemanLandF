using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{

    //majority of code taken from tutorial on space flight controls (from gamesplusjames)
    public float forwardSpeed = 25f, strafeSpeed = 7.5f, hoverSpeed = 5f;
    private float activeForwardSpeed, activeStrafeSpeed, activeHoverSpeed; //untouchable by anything else, will store the corrected values for speed
    private float forwardAcceleration = 2.5f, strafeAcceleration = 2f, hoverAcceleration = 2f;

    //rotation of ship in relation to mouse position (change variables to slow stuff down, like damn that was fast)
    public float lookRotSpeed = 90f;
    private Vector2 lookInput, screenCenter, mouseDistance;

    //barrel roll variables
    private float rollInput;
    public float rollSpeed = 90f;
    public float rollAcc = 3.5f;

    void Start()
    {
        //calculates center of screen to help with ship rotation/mouse pointer
        screenCenter.x = Screen.width * 0.5f;
        screenCenter.y = Screen.height * 0.5f;

        Cursor.visible = false;
    }

    void Update()
    {

        //rotate the ship according to the mouse placement
        lookInput.x = Input.mousePosition.x;   
        lookInput.y = Input.mousePosition.y;

        mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.x;
        mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;

        //helps regulate the rotation speed so ship does not turn at mach speed constantly
        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

        //all controls described in project settings/input manager
        //calculates the roll direction of the ship (q and e)
        rollInput = Mathf.Lerp(rollInput, Input.GetAxisRaw("Roll"), rollAcc * Time.deltaTime);

        transform.Rotate(mouseDistance.y * lookRotSpeed * Time.deltaTime, mouseDistance.x * lookRotSpeed * Time.deltaTime, rollInput*rollSpeed*Time.deltaTime, Space.Self);

        //general movement of the ship (wasd, space for hover, left ctrl for lower)
        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, Input.GetAxisRaw("Vertical") * forwardSpeed, forwardAcceleration * Time.deltaTime); //moving forward and back (ws)
        activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, Input.GetAxisRaw("Horizontal") * strafeSpeed, strafeAcceleration * Time.deltaTime); //moving sideways/strafing (ad)
        activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxisRaw("Hover") * hoverSpeed, hoverAcceleration * Time.deltaTime); //hover up and down (space/left ctrl)

        transform.position += transform.forward * activeForwardSpeed * Time.deltaTime; //makes forward movement work
        transform.position += transform.right * activeStrafeSpeed * Time.deltaTime; //makes sideways movement work
        transform.position += transform.up * activeHoverSpeed * Time.deltaTime; //makes up and down work
    }

}
