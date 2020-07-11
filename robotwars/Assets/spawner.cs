using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
	public enum EnemyLevels
	{
		Easy,
		Medium,
		Hard,
		Boss
	}
	public EnemyLevels enemyLevel = EnemyLevels.Easy;
	public GameObject EasyEnemy;
	public GameObject MediumEnemy;
	public GameObject HardEnemy;
	public GameObject BossEnemy;
	private Dictionary<EnemyLevels, GameObject> Enemies = new Dictionary<EnemyLevels, GameObject>(4);

	public int totalEnemy = 10;
	private int numEnemy = 0;
	private int spawnedEnemy = 0;

	public int totalWaves = 100;
	private int numWaves = 0;
	private int SpawnID;

	private bool waveSpawn = false;
	public bool Spawn = true;
	// Start is called before the first frame update
	void Start()
    {
		SpawnID = Random.Range(1, 500);
		Enemies.Add(EnemyLevels.Easy, EasyEnemy);
		Enemies.Add(EnemyLevels.Boss, BossEnemy);
		Enemies.Add(EnemyLevels.Medium, MediumEnemy);
		Enemies.Add(EnemyLevels.Hard, HardEnemy);
	}

	// Update is called once per frame
	void Update()
	{
		if (Spawn)
		{
			if (numWaves < totalWaves + 1)
			{
				if (waveSpawn)
				{
					//spawns an enemy
					spawnEnemy();
				}
				if (numEnemy == 0)
				{
					Debug.Log("spawning next wave");
					// enables the wave spawner
					waveSpawn = true;
					//increase the number of waves
					numWaves++;
				}
				if (numEnemy == totalEnemy)
				{
					// disables the wave spawner
					waveSpawn = false;
				}
			}

		}
	}
	private void spawnEnemy()
	{
		GameObject Enemy = (GameObject)Instantiate(Enemies[enemyLevel], gameObject.transform.position, Quaternion.identity);
		Enemy.SendMessage("setName", SpawnID);
		numEnemy++;
		spawnedEnemy++;
	}
	// Call this function from the enemy when it "dies" to remove an enemy count
	public void killEnemy(int sID)
	{
		// if the enemy's spawnId is equal to this spawnersID then remove an enemy count
		if (SpawnID == sID)
		{
			numEnemy--;
            Debug.Log("enemy -1");
		}
	}
	//enable the spawner based on spawnerID
	public void enableSpawner(int sID)
	{
		if (SpawnID == sID)
		{
			Spawn = true;
		}
	}
	//disable the spawner based on spawnerID
	public void disableSpawner(int sID)
	{
		if (SpawnID == sID)
		{
			Spawn = false;
		}
	}

	// Enable the spawner, useful for trigger events because you don't know the spawner's ID.
	public void enableTrigger()
	{
		Spawn = true;
	}
}
