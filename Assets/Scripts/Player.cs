using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    private CharacterController _controller;
    [SerializeField] private float _speed = 7.0f;
    [SerializeField] private float gravity = 0.7f;
    [SerializeField] private float _jumpHeight = 20.0f;
    [SerializeField] private float  _cachedY;
    private bool _canDoubleJump = false ;
    [SerializeField] private int _playerCoins;
    [SerializeField] private int _playerLives = 3;
    private UIManager _uiManager;
    [SerializeField] private GameObject _respawnPoint;




    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        

        if(_uiManager == null)
        {
            Debug.Log("The reference instantiation failed: UIManager");
        }

        if (_controller == null)
        {
            Debug.Log("The reference instantiation failed: Controller");
        }

        

        _uiManager.UpdateLives(_playerLives);

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


    public void LooseLives()
    {
        
        _controller.enabled = false;
        _playerLives--;
        _uiManager.UpdateLives(_playerLives);
        this.gameObject.transform.position = _respawnPoint.transform.position;

        StartCoroutine(ControllerEnableRoutine());
       

        if(_playerLives < 1)
        {
            SceneManager.LoadScene(0);
        }
    }


    IEnumerator ControllerEnableRoutine()
    {
        yield return  new  WaitForSeconds(0.5f);
        _controller.enabled = true;

    }


}
