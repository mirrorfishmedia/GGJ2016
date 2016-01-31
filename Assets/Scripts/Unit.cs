using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

	public UnitRenderer render{get; private set;}
	public PlayerHealth health{get; private set;}


	public virtual void Awake(){
		health = GetComponent<PlayerHealth>();
	}
	public void Init(UnitColor color){
		render = UnitRenderer.New(color);
		render.transform.SetParentZeroed(this.transform);
		render.transform.localScale = new Vector3(.3f,.3f,.3f);
		render.transform.rotation = CameraControl.rot;
		health.OnTakeDamage += Health_OnTakeDamage;;
	}

	public virtual void Health_OnTakeDamage (object sender, System.EventArgs e){
		Debug.Log("Took damage " + this.gameObject.name);
		render.hsm.SetHealth((sender as PlayerHealth).currentHealth);
	}
}
