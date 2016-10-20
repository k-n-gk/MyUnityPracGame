using UnityEngine;
using System.Collections;

public class SpriteAction : MonoBehaviour
{
	static int hashSpeed = Animator.StringToHash ("Speed");
	static int hashFallSpeed = Animator.StringToHash ("FallSpeed");
	static int hashGroundDistance = Animator.StringToHash ("GroundDistance");
	static int hashIsCrouch = Animator.StringToHash ("IsCrouch");

	static int hashDamage = Animator.StringToHash ("Damage");
	static int hashIsDead = Animator.StringToHash ("IsDead");

	[SerializeField] private float characterHeightOffset = 0.2f;
	[SerializeField] LayerMask groundMask;

	[SerializeField, HideInInspector] Animator animator;
	[SerializeField, HideInInspector]SpriteRenderer spriteRenderer;
	[SerializeField, HideInInspector]Rigidbody2D rig2d;

	public int hp = 4;

    private int jumpcount = 2;

	void Awake ()
	{
		animator = GetComponent<Animator> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
		rig2d = GetComponent<Rigidbody2D> ();
        
	}

	void Update ()
	{
        

        float axis = Input.GetAxisRaw ("Horizontal");
		bool isDown = Input.GetAxisRaw ("Vertical") < 0;

		if (Input.GetButtonDown ("Jump") && jumpcount > 0) {
			rig2d.velocity = new Vector2 (rig2d.velocity.x, 5);
            jumpcount--;
		}
        
        if (Input.GetButton("Horizontal"))
        {
            rig2d.velocity = new Vector2(Input.GetAxis("Horizontal") * 5,rig2d.velocity.y);
        }

		var distanceFromGround = Physics2D.Raycast (transform.position, Vector3.down, 1, groundMask);

		// update animator parameters
		animator.SetBool (hashIsCrouch, isDown);
		animator.SetFloat (hashGroundDistance, distanceFromGround.distance == 0 ? 99 : distanceFromGround.distance - characterHeightOffset);
		animator.SetFloat (hashFallSpeed, rig2d.velocity.y);
		animator.SetFloat (hashSpeed, Mathf.Abs (axis));
        
        // flip sprite
        if (axis != 0)
			spriteRenderer.flipX = axis < 0;
	}
    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == ("ground"))
            jumpcount = 2;
    }
}
