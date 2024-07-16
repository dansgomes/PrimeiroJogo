using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public bool isPaused;

    [SerializeField]private float speed;
    [SerializeField]private float runSpeed;
    [SerializeField] private float rollSpeed;

    private Rigidbody2D rig;
    private PlayerItems playerItems;

    private float InitialSpeed;
    private bool _isRunning;
    private bool _isRolling;
    private bool _isCutting;
    private bool _isDigging;
    private bool _isWatering;

    private Vector2 _direction;

    [HideInInspector]public int handlingObj;

    public Vector2 direction
    {
        get { return _direction; }
        set { _direction = value; }
    }

    public bool isRunning
    {
        get { return _isRunning; }
        set { _isRunning = value; }
    }

    public bool isRolling
    {
        get { return _isRolling; }
        set { _isRolling = value; }
    }

    public bool IsCutting 
    {
        get => _isCutting; 
        set => _isCutting = value; 
    }

    public bool IsDigging
    {
        get => _isDigging;
        set => _isDigging = value;
    }

    public bool IsWatering
    {
        get => _isWatering;
        set => _isWatering = value;
    }

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        playerItems = GetComponent<PlayerItems>();
        InitialSpeed = speed;
    }

    private void Update()
    {
        if(!isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                handlingObj = 0;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                handlingObj = 1;
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                handlingObj = 2;
            }

            OnInput();
            OnRun();
            OnRolling();
            OnCutting();
            OnDig();
            OnWatering();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("teste");
        }
    }

    private void FixedUpdate()
    {
        if (!isPaused)
        {
            OnMove();
        }
        
    }

    #region Movement

    void OnWatering()
    {
        if (handlingObj == 2)
        {
            if (Input.GetMouseButtonDown(0) && playerItems.currentWater > 0)
            {
                IsWatering = true;
                speed = 0;
            }

            if (Input.GetMouseButtonUp(0) || playerItems.currentWater < 0)
            {
                IsWatering = false;
                speed = InitialSpeed;
            }

            if (IsWatering)
            {
                playerItems.currentWater -= 0.01f;
            }
        }
        else
        {
            IsWatering = false;
        }
    }
    void OnDig()
    {
        if(handlingObj == 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                IsDigging = true;
                speed = 0;
            }

            if (Input.GetMouseButtonUp(0))
            {
                IsDigging = false;
                speed = InitialSpeed;
            }
        }
        else
        {
            IsDigging = false;
        }

    }

    void OnCutting()
    {
        if(handlingObj == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                IsCutting = true;
                speed = 0;
            }

            if (Input.GetMouseButtonUp(0))
            {
                IsCutting = false;
                speed = InitialSpeed;
            }
        }
        else
        {
            IsCutting = false;
        }
        
    }

    void OnInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void OnMove()
    {
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
    }

    void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            _isRunning = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = InitialSpeed;
            _isRunning = false;
        }
    }

    void OnRolling()
    {
        if (Input.GetMouseButtonDown(1))
        {
            speed = rollSpeed;
            _isRolling = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            speed = InitialSpeed;
            _isRolling = false;
        }
    }

    #endregion
}
