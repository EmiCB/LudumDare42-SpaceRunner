using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public GameController gc;

    private Rigidbody2D _rb2d;
    private Collider2D _cldr;
    private Animator _anim;

    public LayerMask ground;

    [SerializeField]
    private float _speed = 7.5f;    //movement
    private float _speedStart;      //stores starting speed
    [SerializeField]
    private float _speedMultiplier = 1.1f;
    private float _speedIncreaseMilestone = 100;
    private float _speedIncreaseMilestoneStart;
    private float _milestoneCount;
    private float _milestoneCountStart;
    [SerializeField]
    private float _force = 10;      //jump
    [SerializeField]
    private float _jumpTime;
    private float _jumpTimeCounter;
    [SerializeField]
    private float _slideTime;
    private float _slideTimeCounter;

    private Vector2 _cldrNorm;
    private Vector2 _cldrNormOff;

    [SerializeField]
    private bool _isGrounded;
    [SerializeField]
    private bool _isSliding;
    

	void Start(){
        _rb2d = GetComponent<Rigidbody2D>();
        _cldr = GetComponent<CapsuleCollider2D>();
        _anim = GetComponent<Animator>();

        _cldrNorm = new Vector2(GetComponent<CapsuleCollider2D>().size.x, GetComponent<CapsuleCollider2D>().size.y);
        _cldrNormOff = new Vector2(GetComponent<CapsuleCollider2D>().offset.x, GetComponent<CapsuleCollider2D>().offset.y);

        _milestoneCount = _speedIncreaseMilestone;

        _speedStart = _speed;
        _milestoneCountStart = _milestoneCount;
        _speedIncreaseMilestoneStart = _speedIncreaseMilestone;

        _jumpTimeCounter = _jumpTime;
	}
	void Update(){
        Movement();

        //checks if player is on ground
        _isGrounded = Physics2D.IsTouchingLayers(_cldr, ground);

        //animation conditions
        _anim.SetFloat("Speed", _rb2d.velocity.x);
        _anim.SetBool("Grounded", _isGrounded);
        _anim.SetBool("Sliding", _isSliding);
	}

    void Movement(){
        //accelerations
        if(transform.position.x > _milestoneCount)
        {
            _milestoneCount += _speedIncreaseMilestone;
            _speedIncreaseMilestone += _speedIncreaseMilestone * _speedMultiplier;
            _speed = _speed * _speedMultiplier;
        }

        //move forward
        _rb2d.velocity = new Vector2(_speed, _rb2d.velocity.y);

        //better jumping
        if (Input.GetKey(KeyCode.Space))
        {
            if(_jumpTimeCounter > 0)
            {
                _rb2d.velocity = new Vector2(_rb2d.velocity.x, _force);
                _jumpTimeCounter -= Time.deltaTime;
            }
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            _jumpTimeCounter = 0;
        }
        if(_isGrounded)
        {
            _jumpTimeCounter = _jumpTime;
        }

        //sliding
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (_slideTimeCounter > 0)
            {
                _isSliding = true;
                _slideTimeCounter -= Time.deltaTime;
                GetComponent<CapsuleCollider2D>().size = new Vector2(GetComponent<CapsuleCollider2D>().size.x, 0.5f);
                GetComponent<CapsuleCollider2D>().offset = new Vector2(0, 0.38f);
            }
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            _slideTimeCounter = 0;
            _isSliding = false;
            GetComponent<CapsuleCollider2D>().size = _cldrNorm;
            GetComponent<CapsuleCollider2D>().offset = _cldrNormOff;
        }
        if (!_isSliding)
        {
            _slideTimeCounter = _slideTime;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "killbox")
        {
            gc.RestartGame();
            _speed = _speedStart;
            _milestoneCount = _milestoneCountStart;
            _speedIncreaseMilestone = _speedIncreaseMilestoneStart;
        }
    }

}
