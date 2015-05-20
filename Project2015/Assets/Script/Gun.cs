using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public Rigidbody2D Bullet;
	public float FireSpeed=10f;
	public float FireDelay=0.5f;
	public bool setRelativeVelocity=false;

	private PlayerControl control;
	private float nextFireTime=0.0f;

	void Start () {
		control=transform.parent.GetComponent<PlayerControl>();
	}

	void Update () {
		if(true && Time.time>nextFireTime){ //bullet shooting condition
			Rigidbody2D bulletInstance = Instantiate (Bullet,transform.parent.position,transform.parent.rotation) as Rigidbody2D;
			bulletInstance.velocity = ( setRelativeVelocity ? control.getVelocity () : Vector3.zero ) + transform.parent.up * FireSpeed;
			nextFireTime=Time.time+FireDelay;
		}
	}
}
