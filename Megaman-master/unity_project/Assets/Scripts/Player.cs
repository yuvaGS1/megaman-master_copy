
using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
	#region Variables

	public int p_score;
	public GameObject power;
	public int count = 0;
	public int i;
	public int j;
	public int[] p_array = {1, 2, 4, 6, 8, 0};
	private Text theText;

	// Unity Editor Variables
	[SerializeField] protected Rigidbody deathParticlePrefab;
	[SerializeField] protected Renderer playerTexRend;
	[SerializeField] protected Transform playerTexObj;
	[SerializeField] protected List<Material> playerMaterials;
	
	// Public Properties
	public bool IsPlayerInactive 		{ get; set; }
	public bool IsFrozen 				{ get { return movement.IsFrozen; } 				set { movement.IsFrozen = value; }				}
	public bool IsExternalForceActive 	{ get { return movement.IsExternalForceActive; }	set { movement.IsExternalForceActive = value; } 	}
	public bool IsDead 					{ get { return health.IsDead; } 					set { health.IsDead = value; }					}
	public bool CanShoot 				{ get { return shooting.CanShoot; } 				set { shooting.CanShoot = value; }				}
	public float CurrentHealth 			{ get { return health.CurrentHealth; } 			set { health.CurrentHealth = value; } 			}
	public Vector3 ExternalForce 		{ get { return movement.ExternalForce; } 			set { movement.ExternalForce = value; } 			}
	public Vector3 CheckpointPosition 	{ get { return movement.CheckPointPosition; } 	set { movement.CheckPointPosition = value; } 		}
	
	// Protected Instance Variables
	protected int walkingTexIndex = 0;
	protected int standingTexIndex = 0;
	protected float walkingTexInterval = 0.2f;
	protected float standingTexInterval = 0.3f;
	protected Health health = null;
	protected Vector2 texScaleLeft = new Vector2(1.0f, -1.0f);
	protected Vector2 texScaleRight = new Vector2(-1.0f, -1.0f);
	protected Collider col = null;
	protected Movement movement = null;
	protected Shooting shooting = null;
	protected LevelCamera levelCamera = null;


	#endregion


	#region MonoBehaviour

	// Constructor 
	protected void Awake()
	{
		GameEngine.Player = this;

		Assert.IsNotNull(deathParticlePrefab);
		Assert.IsNotNull(playerTexRend);
		Assert.IsNotNull(playerTexObj);
		Assert.IsTrue(playerMaterials.Count == 17);

		levelCamera = FindObjectOfType<LevelCamera>();
		Assert.IsNotNull(levelCamera);

		movement = gameObject.GetComponent<Movement>();
		Assert.IsNotNull(movement);

		shooting = gameObject.GetComponent<Shooting>();
		Assert.IsNotNull(shooting);

		health = gameObject.GetComponent<Health>();
		Assert.IsNotNull(health);

		col = GetComponent<Collider>();
		Assert.IsNotNull(col);
	}
	
	// Use this for initialization 
	protected void Start()
	{
		j = p_array.Length - 1;
		i = 0; 
		Debug.Log ("i=" +i);
		Debug.Log ("j=" +j);
		p_score = PlayerPrefs.GetInt ("P_Score");
		IsPlayerInactive = false;
		health.HealthbarPosition = new Vector2(10,10);
		health.ShowHealthBar = true;
		GameObject.Find ("powerpack").transform.localScale = new Vector3(0, 0, 0);
	}
	// for powerpacks
	void FixedUpdate () 
	{
		PowerPacks();
	}
	// Update is called once per frame 
	protected void Update()
	{
		if (IsPlayerInactive == false)
		{
			// Handle the horizontal and Vertical movements
			movement.HandleMovement();

			// Handle shooting
			if((Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Z)) || (Input.GetKeyDown(KeyCode.B)) && shooting.CanShoot == true)
			{   
				shooting.Shoot(movement.IsTurningLeft);
				GameEngine.SoundManager.Play(AirmanLevelSounds.SHOOTING);
			}
			
			// Handle health...
			if (health.IsHurting)
			{
				if (Time.time - health.HurtingTimer >= health.HurtingDelay)
				{
					movement.IsHurting = false;
					health.IsHurting = false;	
				}
			}
			
			// Assign the appropriate texture to the player...
			AssignTexture();

			if (Input.GetKeyDown (KeyCode.A)) 
			{
				Debug.Log ("power array Length - A");
				Debug.Log (p_array.Length);
				count = p_array[j];
				GameObject.Find("powerpack").GetComponent<Text>().text = count.ToString();
				GameObject.Find ("powerpack").transform.localScale = new Vector3(1 ,1 ,1);
				if(j > 0)
				{
					Debug.Log (count);
					j = j - 1;
				}
				else
				{
					j = p_array.Length-1;

				}
				StartCoroutine(PowerLayers ());
			}

			if (Input.GetKeyDown (KeyCode.S)) 
			{
				Debug.Log ("power array Length - S");
				Debug.Log (p_array.Length);
				count = p_array[i];
				GameObject.Find("powerpack").GetComponent<Text>().text = count.ToString();
				GameObject.Find ("powerpack").transform.localScale = new Vector3(1 ,1 ,1);
				if(i == p_array.Length-1)
				{
					i = 0;
				}
				else
				{
					Debug.Log (count);
					i = i + 1;
				}
				StartCoroutine(PowerLayers ());
			}


			if (transform.position.z != 0)
			{
				Vector3 pos = transform.position;
				pos.z = 0;
				transform.position = pos;
			}
		}
	}

	// powerpack controller
	private void PowerPacks()
	{
		if (Input.GetKeyDown (KeyCode.Alpha0)) 
		{
			GameObject.Find("powerpack").GetComponent<Text>().text = "0";
			GameObject.Find ("powerpack").transform.localScale = new Vector3(1 ,1 ,1);
			StartCoroutine(PowerLayers ());
		}
		if (Input.GetKeyDown (KeyCode.Alpha1)) 
		{
			GameObject.Find("powerpack").GetComponent<Text>().text = "1";
			GameObject.Find ("powerpack").transform.localScale = new Vector3(1 ,1 ,1);
			StartCoroutine(PowerLayers ());
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) 
		{
			GameObject.Find("powerpack").GetComponent<Text>().text = "2";
			GameObject.Find ("powerpack").transform.localScale = new Vector3(1 ,1 ,1);
			StartCoroutine(PowerLayers ());
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) 
		{
			GameObject.Find("powerpack").GetComponent<Text>().text = "3";
			GameObject.Find ("powerpack").transform.localScale = new Vector3(1 ,1 ,1);
			StartCoroutine(PowerLayers ());
		}
		if (Input.GetKeyDown (KeyCode.Alpha4)) 
		{
			GameObject.Find("powerpack").GetComponent<Text>().text = "4";
			GameObject.Find ("powerpack").transform.localScale = new Vector3(1 ,1 ,1);
			StartCoroutine(PowerLayers ());
		}
		if (Input.GetKeyDown (KeyCode.Alpha5)) 
		{
			GameObject.Find("powerpack").GetComponent<Text>().text = "5";
			GameObject.Find ("powerpack").transform.localScale = new Vector3(1 ,1 ,1);
			StartCoroutine(PowerLayers ());
		}
		if (Input.GetKeyDown (KeyCode.Alpha6)) 
		{
			GameObject.Find("powerpack").GetComponent<Text>().text = "6";
			GameObject.Find ("powerpack").transform.localScale = new Vector3(1 ,1 ,1);
			StartCoroutine(PowerLayers ());
		}
		if (Input.GetKeyDown (KeyCode.Alpha7)) 
		{
			GameObject.Find("powerpack").GetComponent<Text>().text = "7";
			GameObject.Find ("powerpack").transform.localScale = new Vector3(1 ,1 ,1);
			StartCoroutine(PowerLayers ());
		}
		if (Input.GetKeyDown (KeyCode.Alpha8)) 
		{
			GameObject.Find("powerpack").GetComponent<Text>().text = "8";
			GameObject.Find ("powerpack").transform.localScale = new Vector3(1 ,1 ,1);
			StartCoroutine(PowerLayers ());
		}
		if (Input.GetKeyDown (KeyCode.Alpha9)) 
		{
			GameObject.Find("powerpack").GetComponent<Text>().text = "9";
			GameObject.Find ("powerpack").transform.localScale = new Vector3(1 ,1 ,1);
			StartCoroutine(PowerLayers ());
		}
	}
	IEnumerator PowerLayers()
	{
		yield return new WaitForSeconds(5);
		//GameObject.Find ("powerpack").transform.localScale = new Vector3(0, 0, 0);
	}


	// Called when the behaviour becomes disabled or inactive
	protected void OnDisable()
	{
		GameEngine.Player = null;
	}

	#endregion


	#region Protected Functions
	
	// 
	protected void Reset() 
	{
		health.Reset();
		movement.Reset();
		shooting.Reset();
		playerTexRend.enabled = true;
		IsPlayerInactive = false;
	}
	
	// 
	protected void CreateDeathParticle(float speed, Vector3 pos, Vector3 vel)
	{
		Rigidbody particle = (Rigidbody) Instantiate(deathParticlePrefab, pos, transform.rotation);
		Physics.IgnoreCollision(particle.GetComponent<Collider>(), col);
		particle.transform.Rotate(90,0,0);
		particle.velocity =  vel * speed;
	}
	
	// 
	protected IEnumerator CreateDeathParticles(Vector3 pos) 
	{
		float deathParticleSpeed = 6.0f;
		
		// Before the wait...
		Vector3 p1 = pos + Vector3.up;
		Vector3 p2 = pos - Vector3.up;
		Vector3 p3 = pos + Vector3.right;
		Vector3 p4 = pos - Vector3.right;
		
		Vector3 p5 = pos + Vector3.up + Vector3.right;
		Vector3 p6 = pos + Vector3.up - Vector3.right;
		Vector3 p7 = pos - Vector3.up - Vector3.right;
		Vector3 p8 = pos - Vector3.up + Vector3.right;
		
		p1.z = p2.z = -5;
		p3.z = p4.z = -7;
		p5.z = p6.z = p7.z = p8.z = -9;
		
		this.CreateDeathParticle(deathParticleSpeed, p1, (transform.up));
		this.CreateDeathParticle(deathParticleSpeed, p2, (-transform.up));
		this.CreateDeathParticle(deathParticleSpeed, p3, (transform.right));
		this.CreateDeathParticle(deathParticleSpeed, p4, (-transform.right));
		this.CreateDeathParticle(deathParticleSpeed, p5, (transform.up + transform.right));
		this.CreateDeathParticle(deathParticleSpeed, p6, (transform.up - transform.right));
		this.CreateDeathParticle(deathParticleSpeed, p7, (-transform.up - transform.right));
		this.CreateDeathParticle(deathParticleSpeed, p8, (-transform.up + transform.right));
		
		// Start the wait...
		yield return new WaitForSeconds(0.7f);
		
		// After the wait...
		this.CreateDeathParticle(deathParticleSpeed / 2.5f, p1, transform.up);
		this.CreateDeathParticle(deathParticleSpeed / 2.5f, p2,-transform.up);
		this.CreateDeathParticle(deathParticleSpeed / 2.5f, p3, transform.right);
		this.CreateDeathParticle(deathParticleSpeed / 2.5f, p4,-transform.right);
	}
	
	// 
	protected IEnumerator MovePlayerUp()
	{
		while (true)
		{
			transform.position += Vector3.up * 35.0f * Time.deltaTime;
			yield return null;
		}
	}
	
	// started from last position
	protected IEnumerator MakeThePlayerLeaveStageRoutine()
	{
		playerTexRend.material = playerMaterials[14];
		yield return new WaitForSeconds(0.05f);
		
		playerTexRend.material = playerMaterials[15];
		yield return new WaitForSeconds(0.05f);
		
		GameEngine.SoundManager.Play(AirmanLevelSounds.LEAVE_LEVEL);
		playerTexRend.material = playerMaterials[16];
		playerTexObj.localScale = new Vector3(0.04f, 1.0f, 0.2f);

		StartCoroutine(MovePlayerUp());
		
		yield return new WaitForSeconds(3.0f);
		
		StopCoroutine(MovePlayerUp());

		IsPlayerInactive = false;
		Application.LoadLevel (0);
	}

	// 
	protected IEnumerator WaitAndResetRoutine() {

		yield return new WaitForSeconds (3);
		Application.LoadLevel(4);

		// Before the wait... 
		health.IsDead = true;
		movement.IsFrozen = true;
		playerTexRend.enabled = false;
		levelCamera.ShouldStayStill = true;
		shooting.CanShoot = false;
		
		
		CharacterController cc = (CharacterController) GetComponent(typeof(CharacterController));
		cc.detectCollisions = false;
		
		GameEngine.SoundManager.Stop(AirmanLevelSounds.STAGE);
		GameEngine.SoundManager.Stop(AirmanLevelSounds.BOSS_MUSIC);
		GameEngine.SoundManager.Play(AirmanLevelSounds.DEATH);
		
		// Start the wait... 
		yield return new WaitForSeconds(3.6f);
		
		// After the wait... 
		
		// Reset the camera
		levelCamera.Reset();
		
		// Reset the player
		Reset();
		cc.detectCollisions = true;		

		if (GameEngine.AirMan)
		{
			GameEngine.AirMan.Reset();
		}
		
		// Play the music again...
		GameEngine.SoundManager.Play(AirmanLevelSounds.STAGE);
		levelCamera.ShouldStayStill = false;
		
		// Reset all the enemy bots...
		int enemyRobotsLayer = 10;
		GameObject[] enemyRobots = Helper.FindGameObjectsWithLayer(enemyRobotsLayer);
		foreach (GameObject robot in enemyRobots)
		{
			robot.SendMessage("Reset");
		}
		
		// Reset the birdtriggers...
		GameObject[] birdTriggers = GameObject.FindGameObjectsWithTag("birdTrigger");
		foreach(GameObject trigger in birdTriggers)
		{
			trigger.GetComponent<Collider>().enabled = true;	
		}
		
		// Start another wait to avoid double deaths by the hand of deathtriggers... 
		yield return new WaitForSeconds(0.3f);
		
		// Reset the deathtriggers...
		GameObject[] triggers = GameObject.FindGameObjectsWithTag("deathTrigger");
		foreach(GameObject trigger in triggers)
		{
			trigger.GetComponent<Collider>().enabled = true;	
		}
	}

	// 	
	protected void AssignTexture()
	{
		if (health.IsHurting == true && health.IsDead == false)
		{
			playerTexObj.transform.localScale = new Vector3(0.1175f, 1.0f, 0.1175f);
			playerTexRend.material = playerMaterials[7];
			playerTexRend.material.color *= 0.75f + Random.value;
		}
		else if (movement.IsJumping == true)
		{
			if (shooting.IsShooting == true)
			{
				playerTexObj.transform.localScale = new Vector3(0.1175f, 1.0f, 0.1175f);
				playerTexRend.material = playerMaterials[9];
			}
			else
			{
				playerTexObj.transform.localScale = new Vector3(0.1175f, 1.0f, 0.1175f);
				playerTexRend.material = playerMaterials[2];
			}
		}
		else if (movement.IsWalking == true)
		{
			walkingTexIndex = (int) (Time.time / walkingTexInterval);

			if (shooting.IsShooting == true)
			{
				playerTexObj.transform.localScale = new Vector3(0.13f, 1.0f, 0.1f);
				playerTexRend.material = playerMaterials[ (walkingTexIndex % 4) + 10];
			}
			else
			{
				playerTexObj.transform.localScale = new Vector3(0.1f, 1.0f, 0.1f);
				playerTexRend.material = playerMaterials[ (walkingTexIndex % 4) + 3];
			}
		}
		// Standing...
		else 
		{	
			if (shooting.IsShooting == true)
			{
				playerTexObj.transform.localScale = new Vector3(0.128f, 1.0f, 0.1f);
				playerTexRend.material = playerMaterials[8];
			}
			else
			{
				playerTexObj.transform.localScale = new Vector3(0.1f, 1.0f, 0.1f);
				standingTexIndex = (int) (Time.time / standingTexInterval);
				playerTexRend.material = (standingTexIndex % 10 == 0) ? playerMaterials[1] : playerMaterials[0];
			}
		}
		
		playerTexRend.material.SetTextureScale("_MainTex", (movement.IsTurningLeft) ? texScaleLeft : texScaleRight );
	}

	#endregion


	#region Public Functions
	
	// 
	public void PlayEndSequence()
	{
		StartCoroutine(MakeThePlayerLeaveStageRoutine());
	}

	// 
	public void KillPlayer() 
	{
		StartCoroutine(CreateDeathParticles(transform.position));
		StartCoroutine(WaitAndResetRoutine());
		Debug.Log ("died");

	}
	
	// 
	public void TakeDamage(float damage)
	{
		// If the player isn't already hurting or dead...
		if (health.IsHurting == false && health.IsDead == false)
		{
			GameEngine.SoundManager.Play(AirmanLevelSounds.HURTING);
			health.ChangeHealth(-damage);
			movement.IsHurting = true;
			p_score = PlayerPrefs.GetInt ("P_Score");
			if(p_score == 0){}
			else { p_score = p_score - 10; }
			PlayerPrefs.SetInt("P_Score", p_score);
			Debug.Log(PlayerPrefs.GetInt ("P_Score"));
			Debug.Log("its attacking");
			
			if (health.IsDead == true)
			{
				KillPlayer();
			}
		}
	}

	#endregion
}