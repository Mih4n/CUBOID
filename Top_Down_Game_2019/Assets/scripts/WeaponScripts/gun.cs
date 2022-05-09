using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{

    [Header("GunSettings")]
    [SerializeField] private float _offset;
    [SerializeField] public GameObject _bullet;
    [SerializeField] private Transform _shotPoint;
    [SerializeField] private float _startToShotTime;
    [SerializeField] bool _isEnemyGun;

    [Header("CrosshairSettings")]
    [SerializeField] private float _distance;

    [HideInInspector] private GameObject _myPlayer;
    [HideInInspector] private GameObject _crosshairTexture;
    [HideInInspector] private Joystick _fireJoystick;
    [HideInInspector] private Joystick _movementJoystick;
    [HideInInspector] private float _toShotTime;
    [HideInInspector] private float _rotZ;
    [HideInInspector] private Vector3 _difference;
    [HideInInspector] private PlayerMovement _player;

    private void Start()
    {
        _player = FindObjectOfType<PlayerMovement>();
        _myPlayer = GameObject.FindGameObjectWithTag("Player");
        _fireJoystick = GameObject.FindGameObjectWithTag("WeaponController").GetComponent<DynamicJoystick>();
        _movementJoystick = GameObject.FindGameObjectWithTag("MotionController").GetComponent<DynamicJoystick>();
        _crosshairTexture = _myPlayer.GetComponent<PlayerMovement>().Crosshair;          
    }
    private void Update()
    {
        if(_isEnemyGun == false)
        {       
            if (Mathf.Abs(_fireJoystick.Horizontal) > 0.01f || Mathf.Abs(_fireJoystick.Vertical) > 0.01f)
            {
                _rotZ = Mathf.Atan2(_fireJoystick.Vertical, _fireJoystick.Horizontal) * Mathf.Rad2Deg;  
                _crosshairTexture.SetActive(true);          
            }
            else
            {
                _crosshairTexture.SetActive(false);
                if (Mathf.Abs(_movementJoystick.Horizontal) > 0.01f || Mathf.Abs(_movementJoystick.Vertical) > 0.01f)
                    _rotZ = Mathf.Atan2(_movementJoystick.Vertical, _movementJoystick.Horizontal) * Mathf.Rad2Deg;            
            } 
            _crosshairTexture.transform.rotation = Quaternion.Euler(0f, 0f, _rotZ + _offset);
            _crosshairTexture.transform.position = new Vector2(_myPlayer.transform.position.x, _myPlayer.transform.position.y) + new Vector2(_fireJoystick.Horizontal, _fireJoystick.Vertical) * _distance;         
        }else
        {
            _difference = _player.transform.position - transform.position;
            _rotZ = Mathf.Atan2(_difference.y, _difference.x) * Mathf.Rad2Deg;
        }
        transform.rotation = Quaternion.Euler(0f, 0f, _rotZ + _offset);

        Vector3 LocalScale = Vector3.one;

        if (_rotZ > 90 || _rotZ < -90)
        {
            LocalScale.y = -1f;
        }else
        {
            LocalScale.y = +1f;
        }
        transform.localScale = LocalScale;

        if (_toShotTime <= 0)
        {
            if(!_isEnemyGun)
            {
                if (_fireJoystick.Horizontal != 0 || _fireJoystick.Vertical != 0)
                {
                    Shoot();
                }    
                if(Input.GetMouseButtonDown(0))
                {
                    Shoot();
                }            
            }else
            {
                Shoot();
            }
        }
        else
        {
            _toShotTime -= Time.deltaTime;
        }
    }
    public void Shoot()
    {
        GameObject bullet;
        bullet = Instantiate(_bullet, _shotPoint.position, _shotPoint.rotation) as GameObject;
        _toShotTime = _startToShotTime;
    }
}