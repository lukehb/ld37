using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveComponent : MonoBehaviour {

    [SerializeField]
    private float delaySeconds;

    [SerializeField]
    private Enemy enemyPrefab;

    [SerializeField]
    private Transform spawnLocation;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Enemy SpawnEnemy(Player player)
    {
        //spawn the damagable at this spawners location
        Enemy enemy = Instantiate(enemyPrefab, this.spawnLocation.position, this.spawnLocation.rotation);
        enemy.GoKillThisGuy(player);
        return enemy;
    }

    public float DelaySeconds
    {
        get { return delaySeconds; }
    }

}
