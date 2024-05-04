using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
/// <summary>
/// This class runs the weapon aspect and controls how it moves.
/// This class IS fully functioning, but due to the monster class bugging out recently it only does animations.
/// It is coded to deal damage through the weapon collider class.
/// </summary>
public class WeaponScript : MonoBehaviour
{
    private bool swing = false;
    int degree = 0;
    private float weaponY = -0.4f;
    private float weaponX = 0.3f;
    public float weaponPower = 1.0f;

    Vector3 pos;
    public GameObject player;
    /// <summary>
    /// Update checks every frame to see if the space key is pressed, and executes the rest of the methods depending on the condition
    /// </summary>
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            GetComponent<SpriteRenderer>().enabled = true;
            Attack();
        }
    }
    /// <summary>
    /// Another update class, basically also checks every frame to see if the swing condition is fufilled.
    /// What this does is make a sword animation by rotating it 45 degrees through 9 iterations, creating a relatively smoothe movement.
    /// This only handles animations
    /// </summary>
    private void FixedUpdate()
    {
        if (swing)
        {
            degree -= 5;
            if(degree < -45)
            {
                degree = 0;
                swing = false;
                GetComponent<SpriteRenderer>().enabled = false;
                transform.GetChild(0).gameObject.SetActive(false);
            }
            transform.eulerAngles = Vector3.forward * degree;
        }
    }
    /// <summary>
    /// This method is executed through the Update() method,
    /// after checking to see if the space button was pressed.
    /// 
    /// This method handles the direction the collider is damaging, as the program defaults to facing the right. 
    /// </summary>
    void Attack()
    {
        if (player.GetComponent<PlayerScript>().facingLeft)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            weaponX = -0.3f;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
            weaponX = 0.3f;
        }
        pos = player.transform.position;
        
        pos.x += weaponX;
        pos.y += weaponY;
        
        transform.position = pos;
        
        swing = true;
    }

}
