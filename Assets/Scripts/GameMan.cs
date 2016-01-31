using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using InControl;
using UnityEngine.UI;

public class GameMan : MonoBehaviour {

	bool currentlyPlaying = false;
	bool gameOver = false;

	public EnvironmentMan environment;

	public DefendingPlayer defendingPlayer;

	public MonkActions monkCtrlActions;
	public List<AttackerActions> attackerActions;

	public List<Transform> attackerTransforms;

	public Transform camSpawnPos;
	private ResourceType neededResource;
	ResourceSequence sequencer;
	public SpriteDisplay[] resourceDisplay;

	private int currentResourceTotal = 0;
	private int maxResources = 1;
	private int colorsScored = 0;
	private int colorGoal = 3;

	private InputMan joiner;

	public InputTimerRenderer timerRenderer;

	private float roundTimerFull = 120f;
	private float roundTimer = 0f;
	private float roundTimerNormalized{get{return roundTimer / roundTimerFull;}}

	private float spawnAttackerDelay = 1f;
	private UIMan uiMan;


	[HideInInspector] public GameObject spawnedCam;
	private CameraControl camControlScript;



	void Awake()
	{
		Time.timeScale = 1f;

		uiMan = GetComponent<UIMan> ();
		SetupCamera ();
		sequencer = gameObject.AddComponent<ResourceSequence>(); 

		joiner = GetComponent<InputMan>();
		joiner.OnStartPressed += (sender, e) => {
			uiMan.FadeInSequencePrompt();
			sequencer.StartInput(joiner.devices[0]);
			uiMan.FadeOutStart();
			uiMan.FadeInTimer();
		};

		joiner.OnStartAvailable += (sender, e) => {uiMan.FadeInStart();};

//		joiner.OnStartPressed += (sender, e) => {HardCodeStart();};

		joiner.OnPlayerJoined += (sender, e) => {uiMan.FadeOutText();};

		sequencer.OnInputted += (sender, e) => {
			resourceDisplay[e.index].SetResourceIcon(ResourceType.NONE);
			resourceDisplay[e.index].SetFadeActive(true);
		};

		sequencer.OnInputAgain += HandleOnInputAgain;
		sequencer.OnCheckInputFalse += (sender, e) => {
			resourceDisplay[0].GetComponentInParent<LocalPositionSpring>().velocity += new Vector3(20f, 0f, 0f);
			HandleOnInputAgain(sender, e);};
		sequencer.OnCheckInputTrue += HandleOnInputAgain;
	}

	void HandleOnInputAgain (object sender, System.EventArgs e)
	{
		foreach (var r in resourceDisplay) {
			r.SetFadeActive(false);
		}
	}

	void HardCodeStart(){
		sequencer.inputArray = new ResourceType[]{
			ResourceType.Fire,
			ResourceType.Fire,
			ResourceType.Fire,
			ResourceType.Fire
		};
		StartGame();
	}


	void Reset(){
		Application.LoadLevel (Application.loadedLevel);
	}


	void Update(){
		TimerUpdate();
	}

	void TimerUpdate(){
		if (currentlyPlaying && !gameOver){
			this.roundTimer -= Time.deltaTime;
			if (this.roundTimer <= 0){
				AttackerWins();
			}
		}
		timerRenderer.SetFloat(roundTimerNormalized);
	}

	// Use this for initialization
	public void StartGame () {
		uiMan.FadeOutSequencePrompt ();
		Debug.Log("START GAME!");
		SetupDefender();
		SetupAttackers ();
		roundTimer = roundTimerFull;
		currentlyPlaying = true;
	}

	void SetupDefender(){
		defendingPlayer.Init(joiner.devices[0], environment.shrineDestinations);
	}



	void SetupCamera(){
		Debug.Log("HEY");
		spawnedCam = PrefabManager.Instantiate ("CameraRig", Vector3.zero, camSpawnPos.rotation) as GameObject;
		camControlScript = spawnedCam.GetComponent<CameraControl> ();

	}



	void SetupAttackers()
	{
		attackerActions = new List<AttackerActions>();
		attackerTransforms = new List<Transform> ();

		var devices = joiner.devices;
		for(int i = 1; i < devices.Length; i++){
			SpawnAttacker(devices[i], (UnitColor)i);

		}
	}

	void SpawnAttacker(InputDevice dev, UnitColor color){
		var spawn = environment.playerSpawns[(int)color].transform.position;
		var attacker = PrefabManager.Instantiate ("AttackingPlayer", spawn).GetComponent<AttackingPlayer>();
		attackerTransforms.Add (attacker.transform);
		attacker.Init(dev, color);
		attacker.health.OnDie += (sender, e) => {
			attackerTransforms.Remove (attacker.transform);
			StartCoroutine(SpawnPlayerDelayed(dev, color));
		};
	}

	IEnumerator SpawnPlayerDelayed(InputDevice device, UnitColor c){

		yield return new WaitForSeconds(spawnAttackerDelay);
		SpawnAttacker(device, c);
	}



	public void AddResource(ResourceType collectedResource)

	{

		switch (collectedResource) 
		{
		case ResourceType.Skull:
			//play sound
			break;
		case ResourceType.Feather:
			//play sound
			break;
		case ResourceType.Fire:
			//play sound
			break;
		case ResourceType.Pyramid:
			//play sound
			break;
		}

		if (gameOver) return;
		Debug.Log ("in addResource " + collectedResource.ToString());
		if (collectedResource == sequencer.inputArray[colorsScored]) 
		{
			Debug.Log ("got needed color");

			currentResourceTotal++;
			Debug.Log ("currentResource count " + currentResourceTotal);
			if (currentResourceTotal >= maxResources)
			{
				currentResourceTotal = 0;
				Debug.Log ("Reset resources to : " + currentResourceTotal);
				resourceDisplay [colorsScored].SetResourceIcon (collectedResource);

				ColorScored();
			}
		}
	}

	void ColorScored()
	{
		Debug.Log ("in color scored");
		resourceDisplay[colorsScored].SetFadeActive(true);

		colorsScored++;
		Debug.Log ("colors scored " + colorsScored);
		SoundMan.main.ColorScored ();
		if (colorsScored >= colorGoal) 
		{
			DefenderWins();
		}
	}


	void SlowDown()
	{
		Time.timeScale = .1f;
		Invoke ("Reload", .5f);
	}
	void Reload(){
		Application.LoadLevel (Application.loadedLevel);
	}

	void DefenderWins()
	{
		Debug.Log("Defender wins the round!");
		//Debug.Break();
		uiMan.FadeInDefenderWins ();
		CameraControl.main.canAdd = false;
		CameraControl.main.m_Targets = new List<Transform> ();
		Invoke ("SlowDown", 1f);
		gameOver = true;

	}

	void AttackerWins()
	{
		Debug.Log("Attacker wins the round!");
		//Debug.Break();
		SoundMan.main.OutOfTime ();
		uiMan.FadeInAttackerWins ();
		CameraControl.main.canAdd = false;
		CameraControl.main.m_Targets = attackerTransforms;
		Invoke ("SlowDown", 1f);
		gameOver = true;

	}



}
