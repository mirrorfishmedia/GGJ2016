using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {
	public static CameraShake main;

	public float shakeDuration = 0;
	public float shakeAmplitude = .1f;

	public float microShakeDuration = 0;

	private Vector3 velocity = Vector3.zero;
	private Vector3 targetPosition;

	private Quaternion targetRotation;
	private float fovVelocity;

	private float rotation = 0f;
	private float rotationVelocity = 0f;

	private Transform microShaker;

	private FloatDamper microShakeDamper;

	void Awake(){
		main = this;
		microShaker = transform.GetChild(0);
		microShakeDamper = new FloatDamper(0f, .01f);
	}

	void Start(){
	}

	public void Shake(Vector3 force){
		velocity += force;
	}

	public void Shake(float duration, float strength){
		strength *= .9f;
		if (shakeDuration < duration)
			shakeDuration = duration;
		if (shakeAmplitude < strength)
			shakeAmplitude = strength;
		fovVelocity -= Mathf.Pow(strength, 1.5f) * 145f;
		rotationVelocity += (Random.value > .5f?shakeAmplitude:-shakeAmplitude)*110f;
	}

	public void LateUpdate(){
		targetRotation = Quaternion.identity;
		if (shakeDuration > 0){
			targetPosition = Vector3.zero;
			velocity += GetRandomVec() * 1500f * Time.deltaTime;
			shakeDuration -= Time.deltaTime;

			shakeAmplitude -= Time.deltaTime;
		}

		if (shakeDuration <= 0){
			targetPosition = Vector3.zero;
			shakeAmplitude = 0;
			targetRotation = Quaternion.identity;
		}

//		if (Vector3.Distance(transform.localPosition, targetPosition) > .01f)
		transform.localPosition = Utilities.SimpleHarmonicMotion(transform.localPosition, targetPosition, ref velocity, Mathf.Lerp(4, 36f, velocity.magnitude/52f), .8f);


//		float angle = Quaternion.Angle(transform.localRotation, targetRotation);
		float roty = transform.localRotation.eulerAngles.y;
		if (roty > 180) roty = roty-360;
		float targety = Utilities.CalcDampedSimpleHarmonicMotion(ref roty, ref rotationVelocity, 0f, Time.deltaTime, 22f, .4f);
		transform.localRotation = Quaternion.Euler(0f,targety,0f);

		float fov = Camera.main.fieldOfView;
		Camera.main.fieldOfView = Utilities.CalcDampedSimpleHarmonicMotion(ref fov, ref fovVelocity, 12f, Time.deltaTime, 30f, .5f);

		if (microShakeDuration > 0f){
			microShakeDamper.Target = 1f;
			microShaker.transform.localPosition = (Random.insideUnitSphere/1f) * Mathf.Clamp(microShakeDuration/5f, 0f, 1f) * microShakeDamper.Value;
			microShakeDuration -= Time.deltaTime;
			if (microShakeDuration <= 0f){
				microShaker.transform.localPosition = Vector3.zero;
				microShakeDamper.Target = 0f;
				microShakeDamper.Value = 0f;
			}
		}
	}

	private float GetRandomVal(){
		return Random.Range(-shakeAmplitude, shakeAmplitude);
	}

	private Vector3 GetRandomVec(){
		return new Vector3(GetRandomVal(), GetRandomVal()/2f, GetRandomVal());
	}


	void OnDestroy(){
		SmoothDamper.main.RemoveDamper(microShakeDamper);
	}

}
