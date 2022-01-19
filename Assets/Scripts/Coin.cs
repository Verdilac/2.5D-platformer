using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField] private  Player Player;


    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Player>();


    }


    private void OnTriggerEnter(Collider other)
    {
        Player.GiveCoin();
        Destroy(this.gameObject);
    }


    void Update()
    {
        
    }
}
