using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
	[SerializeField] private float JumpForce = 400f;							
	[Range(0, 1)] [SerializeField] private float CrouchSpeed = .36f;			
	[Range(0, .3f)] [SerializeField] private float MovementSmoothing = .05f;	
	[SerializeField] private bool AirControl = false;							
	[SerializeField] private LayerMask WhatIsGround;							
	[SerializeField] private Transform GroundCheck;							
	[SerializeField] private Transform CeilingCheck;							
					

	const float GroundedRadius = .2f;
	private bool Grounded;           
	const float CeilingRadius = .2f; 
	private Rigidbody2D Rigidbody2D;
	private bool FacingRight = true; 
	private Vector3 Velocity = Vector3.zero;

	

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	
	

	private void Awake()
	{
		Rigidbody2D = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();

		
	}

	private void FixedUpdate()
	{
		bool wasGrounded = Grounded;
		Grounded = false;

		
		Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheck.position, GroundedRadius, WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				Grounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
	}


	public void Move(float move, bool crouch, bool jump)
	{
	

		
		if (Grounded || AirControl)
		{

			
			Vector3 targetVelocity = new Vector2(move * 10f, Rigidbody2D.velocity.y);
			
			Rigidbody2D.velocity = Vector3.SmoothDamp(Rigidbody2D.velocity, targetVelocity, ref Velocity, MovementSmoothing);

			
			if (move > 0 && !FacingRight)
			{
				
				Flip();
			}
			
			else if (move < 0 && FacingRight)
			{
				
				Flip();
			}
		}
		
		if (Grounded && jump)
		{
			
			Grounded = false;
			Rigidbody2D.AddForce(new Vector2(0f, JumpForce));
		}
	}


	private void Flip()
	{
		
		FacingRight = !FacingRight;

		
		transform.Rotate(0f, 180f, 0f);
	}
}
