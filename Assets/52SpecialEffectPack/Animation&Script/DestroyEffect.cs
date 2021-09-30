/*
 * This script destorys the game object after five seconds 
 */

using UnityEngine;
using System.Collections;

public class DestroyEffect : MonoBehaviour 
{

	void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.C))
        {
            Destroy(gameObject);
        }
        Destroy(gameObject, 5);
	}
}
