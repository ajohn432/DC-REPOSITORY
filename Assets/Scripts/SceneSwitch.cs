using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
public class SceneSwitch : MonoBehaviour
{
    /// <summary>
    /// This method simply switches to the victory screen when a player finds a ladder. The future plan is to generate more dungeon levels
    /// with the method, as it is setup to easily take in more possible options, or even a random factor.
    /// </summary>
    /// <param name="collision"></param>
    public void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        SceneManager.LoadScene(3);
    }
}
