using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldFrame : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<Player>().LooseLives();
        }
    }

}
