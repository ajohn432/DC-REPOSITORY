using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class manages the weaponcollider in Unity, and checks to see if it is in contact with an enemy.
/// Unfortunately my slime class broke, so this is unused at the moment.
/// </summary>
public class WeaponColliderScript : MonoBehaviour
{
    public GameObject player;
    private float weaponDamage = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        weaponDamage = transform.parent.gameObject.GetComponent<WeaponScript>().weaponPower;
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyScript>().TakeDamage(weaponDamage);
        }
    }
}