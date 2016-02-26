using UnityEngine;
using System.Collections;


public class HeroController : MonoBehaviour {


	// PRIVATE  INSTANCE VARIABLES
	private Animator _animator;
	private float _move;
	private float _jump;


	// Use this for initialization
	void Start () {

	
		this._animator = gameObject.GetComponent<Animator> ();
		this._move = 0f;
		this._jump = 0f;



	
	}
	
	// Update is called once per frame
	void Update () {

		this._move = Input.GetAxis ("Horizontal");
		this._jump = Input.GetAxis ("Vertical");

		if (this._move != 0) {
			this._animator.SetInteger ("Anim_State", 1);
		} else {
			if (this._jump > 0) {
				this._animator.SetInteger ("Anim_State", 2);
			}
			//Set Default Animatation state to Idle
			this._animator.SetInteger ("Anim_State", 0);
		}
			
	}

}


