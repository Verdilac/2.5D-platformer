using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private CharacterController _controller;
    [SerializeField] private float _speed = 7.0f;
    [SerializeField] private float gravity = 0.7f;
    [SerializeField] private float _jumpHeight = 20.0f;
    [SerializeField] private float  _cachedY;
    private bool _canDoubleJump = false ;
    [SerializeField] private int _playerCoins;
    private UIManager _uiManager;


    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        Vector3 velocity = direction * _speed;

       if(_controller.isGrounded == true )
        {
          
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _cachedY = _jumpHeight;
                _canDoubleJump = true;
            }


            
        }
        else
        {

            if (       Input.GetKeyDown(KeyCode.Space)  && _canDoubleJump == true    )
            {
                _cachedY += _jumpHeight * 1.2f ;
                _canDoubleJump = false;
            }


                _cachedY -= gravity;

        

        }

        velocity.y = _cachedY; 

        _controller.Move(velocity*Time.deltaTime);
    }


    public void GiveCoin()
    {
        _playerCoins += 1;
        _uiManager.UpdateCoincount(_playerCoins);
        Debug.Log(_playerCoins);
    }


}
