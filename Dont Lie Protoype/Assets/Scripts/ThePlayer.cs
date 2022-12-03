using UnityEngine;
using System.Collections;
using Photon.Pun;

public class ThePlayer : MonoBehaviour 
{

		private Animator anim;
		private CharacterController controller;
		Rigidbody rb;


		PhotonView PV;

		[SerializeField] float mouseSensitivity, jumpSpeed;
		[SerializeField] GameObject cameraHolder;


		float verticalLookRotation;
		bool grounded;

    	private Vector3 playerVelocity;
   		private bool groundedPlayer;
    	
    	


		public float speed = 600.0f;
		public float turnSpeed = 400.0f;
		private Vector3 moveDirection = Vector3.zero;
		public float gravity = 20.0f;

		void Awake()
		{
			PV = GetComponent<PhotonView>();
			rb = GetComponent<Rigidbody>();
		}

		void Start () 
		{
			if (!PV.IsMine)
			{
				Destroy(GetComponentInChildren<Camera>().gameObject);
				Destroy(rb);
			}

			controller = gameObject.GetComponent<CharacterController>();
			anim = gameObject.GetComponentInChildren<Animator>();
		}

		void Update ()
		{
			

			if ( !PV.IsMine)
			{
				return;
			}

			if (Input.GetKey ("w")) 
			{
				anim.SetInteger ("AnimationPar", 1);
			}  
			else 
			{
				anim.SetInteger ("AnimationPar", 0);
			}

			Look();

			
			if(controller.isGrounded)
			{
				moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;

				
				if ( Input.GetKeyDown(KeyCode.Space) ) // when they are grounded, give ability to jump
				{
					Debug.Log("Player is jumping");
					moveDirection += Vector3.up * jumpSpeed;

				}
			}
			
		

			float turn = Input.GetAxis("Horizontal"); //horizontal means 'a' and 'd' keys
			transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
			moveDirection.y -= gravity * Time.deltaTime; //applies gravity
			controller.Move(moveDirection * Time.deltaTime); //movement


			
			
		
		}

		void Look ()
		{
			transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * mouseSensitivity);
			verticalLookRotation += Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
			verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);

			cameraHolder.transform.localEulerAngles = Vector3.left * verticalLookRotation;
		}

		
}
