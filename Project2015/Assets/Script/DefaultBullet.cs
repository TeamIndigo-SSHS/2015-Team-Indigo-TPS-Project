using UnityEngine;
using System.Collections;

public class DefaultBullet : MonoBehaviour {

	public float AutoDestroyTime=5.0f;
	public LayerMask mask;
	private CircleCollider2D collider;
	private float radius;
	private Rigidbody2D body;

	void Start () {
		mask= -1 - 1<<LayerMask.NameToLayer ("Bullet");
		collider=GetComponent <CircleCollider2D>();
		radius=collider.radius;
		body=GetComponent<Rigidbody2D>();

		Destroy (gameObject,AutoDestroyTime);
	}

	void FixedUpdate () {
		RaycastHit2D hit=Physics2D.Raycast (transform.position,transform.up,Time.fixedDeltaTime*body.velocity.magnitude+radius,mask);
		Debug.DrawRay (transform.position,(Time.fixedDeltaTime*body.velocity.magnitude+radius)*transform.up);
		if(hit.transform!=null){
			Debug.Log ("Hit!");
			if(hit.transform.tag=="Wall"){
				Debug.DrawRay (transform.position,hit.normal,Color.red);
				body.velocity=Vector3.Reflect(body.velocity,hit.normal);
				//transform.rotation=Quaternion.Euler (0,0,-Mathf.Rad2Deg*Mathf.Atan (body.velocity.x/body.velocity.y)+(body.velocity.y<0?180:0));
				//body.velocity=new Vector2(0,0);
			}
		}
	}


}
