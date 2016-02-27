using UnityEngine;
using System.Collections;


// Velocity Range Utility Class.
[System.Serializable]
public class VelocityRange {
	// PUBLIC INSTANCE VARIABLES 
	public float minimum;
	public float maximum;

	// CONSTRUCTOR
	public VelocityRange(float minimum, float maximum) {
		this.minimum = minimum;
		this.maximum = maximum;
	}
}


public class HeroController : MonoBehaviour {

	//Public instance Variables
	public VelocityRange velocityRange;
	public float moveForce;
	public float jumpForce;
//	public Transform groundCheck;
//	public Transform camera;
//	public GameController gameController;

	// PRIVATE  INSTANCE VARIABLES
	private Animator _animator;
	private float _move;
	private float _jump;
	private bool _facingRight;
	private Transform _transform;
	private Rigidbody2D _rigidBody2D;
	private bool _isGrounded;



	// Use this for initialization
	void Start () {
		//Intialize public Instance Variable
		this.velocityRange = new VelocityRange(300f,1000f);
		this.moveForce = 50f;
		this.jumpForce = 500f;




		//Intialize Private Instance Variable
		this._transform = gameObject.GetComponent<Transform> ();
		this._animator = gameObject.GetComponent<Animator> ();
		this._rigidBody2D = gameObject.GetComponent<Rigidbody2D> ();
		this._move = 0f;
		this._jump = 0f;
		this._facingRight = true;


	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		float forceX = 0f;
		float forceY = 0f;

		//Get absolute value of velocity
		float absVelX = Mathf.Abs (this._rigidBody2D.velocity.x);
		float absVelY = Mathf.Abs (this._rigidBody2D.velocity.y);

		//Get a number between -1 to 1
		this._move = Input.GetAxis ("Horizontal");
		this._jump = Input.GetAxis ("Vertical");

		if (this._move != 0) {
			this._animator.SetInteger ("Anim_State", 1);

			if (this._move > 0) {
				this._facingRight = true;
				this._flip ();
			}
			if (this._move < 0) {
				this._facingRight = false;
				this._flip ();
			}
		} else {
			
			//Set Default Animatation state to Idle
			this._animator.SetInteger ("Anim_State", 0);
		}
			
		if (this._jump > 0) {
			//Jump Animation
			this._animator.SetInteger ("Anim_State", 2);
		}
	}

	//PRIVATE Methods
	private void _flip(){
		if (this._facingRight) {
			this._transform.localScale = new Vector2 (1, 1);
		} else {
			this._transform.localScale = new Vector2 (-1, 1);
		}
	}
}


