using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disappear : MonoBehaviour
{
    public void ToggleVisibility()
    {
        Renderer rend = gameObject.GetComponent<Renderer>();
        if (Rocket.lives == 3)
        {
            print("dead");
            rend.enabled = false;
        }
    }
}
