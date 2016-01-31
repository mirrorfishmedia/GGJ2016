using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

	public UnitRenderer render{get; private set;}
	public PlayerHealth health{get; private set;}
	public ScaleSpring spring;


	public virtual void Awake(){
		health = GetComponent<PlayerHealth>();
		spring = GetComponent<ScaleSpring>();
	}
	public void Init(UnitColor color){
		render = UnitRenderer.New(color);
		render.transform.SetParentZeroed(this.transform);
		render.GetComponent<ScaleSpring>().target = Vector3.one * .3f;
		render.transform.rotation = CameraControl.rot;
		health.OnTakeDamage += Health_OnTakeDamage;;
		health.OnDie += Health_OnDie;
	}

	void Health_OnDie (object sender, System.EventArgs e){
		CameraShake.main.microShakeDuration = 1.5f;
	}

	public virtual void Health_OnTakeDamage (object sender, System.EventArgs e){
//		Debug.Log("Took damage " + this.gameObject.name);
		render.hsm.SetHealth((sender as PlayerHealth).currentHealth);
		spring.velocity += new Vector3(-5f, 0f, -5f);
		CameraShake.main.microShakeDuration = .5f;
		this.render.spr.color = Color.red;
	}
}
