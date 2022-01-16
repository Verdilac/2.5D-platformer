using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private CharacterController _controller;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
