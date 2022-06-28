using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public enum ControlType{Mobile, PC};

       [Header("ControlType")]
       public ControlType ControlTypeNow;

    [Header("MovementSettings")]
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private PlayerPreferences _playerPreferences;
    [SerializeField] private HealthBar _healthBar; 
    [SerializeField] private Joystick _movementJoystick;
    [SerializeField] private Joystick _fireJoystick;

    [Header("Weapons")]
    [SerializeField] private GameObject[] _weapons;
    [SerializeField] private GameObject _startWeapon;
    [SerializeField] private GameObject[] _weaponSlots;

    public GameObject Crosshair;

    [HideInInspector] public float _health;
    public float Health
    {
        get{ return _health;}
    }
    [HideInInspector] private float _maxHealth;
    [HideInInspector] private float _speed;   
    [HideInInspector] private Inventory _inventory; 
    [HideInInspector] private int _loopOfweaponSlots;
    [HideInInspector] private bool _facingRight = true;
    [HideInInspector] private Vector2 _moveInput;
    [HideInInspector] private Vector2 _moveInputbullet;
    [HideInInspector] private Vector2 _moveVelocity;
    [HideInInspector] private Animator _animator;

    private void Awake() 
    {
        _maxHealth = _playerPreferences.Health;
        _speed = _playerPreferences.Speed;
        _health = _maxHealth;
    }
    private void Start()
    {
        Time.timeScale = 1f;
        _healthBar.SetNative(_health, _maxHealth);
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _inventory = gameObject.GetComponent<Inventory>();
    }
    private void Update()
    {
        MovementControl();
        WeaponControl();
    }

    private void MovementControl()
    {
        _moveInput = new Vector2(_movementJoystick.Horizontal, _movementJoystick.Vertical);
        _moveInputbullet = new Vector2(_fireJoystick.Horizontal, _fireJoystick.Vertical);

        if(ControlTypeNow == ControlType.Mobile)
        {
                        
        }

        if(ControlTypeNow == ControlType.PC)
        {
            _moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }

        _moveVelocity = _moveInput * _speed;
        if(_moveInput.x == 0)
        {
            _animator.SetBool("isRanning", false);
        }else
        {
            _animator.SetBool("isRanning", true);
        }

        if (Mathf.Abs(_fireJoystick.Horizontal) > 0.01f || Mathf.Abs(_fireJoystick.Vertical) > 0.01f)
        {
            if (!_facingRight && _moveInputbullet.x > 0)
            {
                Flip();
            }

            if (_facingRight && _moveInputbullet.x < 0)
            {
                Flip();
            }            
        }else
        {
            if (!_facingRight && _moveInput.x > 0)
            {
                Flip();
            }

            if (_facingRight && _moveInput.x < 0)
            {
                Flip();
            } 
        }
    }

    private void WeaponControl()
    {
        if(_loopOfweaponSlots >= _weaponSlots.Length)
            _loopOfweaponSlots = 0;

        if(_weaponSlots[_loopOfweaponSlots].transform.childCount <= 0)
        {
            _startWeapon.SetActive(true);

            foreach(GameObject Weapon in _weapons)
            {
                Weapon.SetActive(false);
            }
        }else
        {
            _startWeapon.SetActive(false);   
                 
            foreach(GameObject Weapon in _weapons)
            {
                if(_weaponSlots[_loopOfweaponSlots].transform.GetChild(0).gameObject.name == Weapon.name + "(Clone)" || _weaponSlots[_loopOfweaponSlots].transform.GetChild(0).gameObject.name == Weapon.name)
                    Weapon.SetActive(true);
                else
                    Weapon.SetActive(false);
            }
        }
    }

    public void NextWeaponSlot()
    {
        _loopOfweaponSlots++;
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + _moveVelocity * Time.fixedDeltaTime);
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        _healthBar.TakeDamage(damage);
    }
    public void RestoreHealth(float healAmount)
    {
        _health += healAmount;
        _healthBar.RestoreHealth(healAmount);
    }
}
