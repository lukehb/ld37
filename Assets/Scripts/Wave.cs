using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

    [SerializeField]
    private Player player;

    [SerializeField]
    private WaveComponent[] waveComponents;

    private float timeElapsed = 0f;
    private Enemy[] spawnedEnemies;
    private bool isWaveDone = false;

    public bool IsWaveDone { get { return this.isWaveDone;}}

    // Use this for initialization
    void Start () {
        this.spawnedEnemies = new Enemy[this.waveComponents.Length];
	}
	
	// Update is called once per frame
	void Update () {
        if (isWaveDone) { return;  }

		if(waveComponents != null)
        {
            this.timeElapsed += Time.deltaTime;
            TrySpawnWaveComponents();
        }else
        {
            CheckIfWaveEnded();
        }
	}

    private void CheckIfWaveEnded()
    {
        bool allDestroyed = true;
        foreach (Enemy enemy in spawnedEnemies)
        {
            if(enemy != null)
            {
                allDestroyed = false;
            }
        }
        if (allDestroyed)
        {
            isWaveDone = true;
        }
    }

    private void TrySpawnWaveComponents()
    {
        bool thingsLeftToSpawn = false;
        for (int i = 0; i < waveComponents.Length; i++)
        {
            WaveComponent waveComponent = waveComponents[i];
            if (waveComponent != null)
            {
                thingsLeftToSpawn = true;
                if (timeElapsed > waveComponent.DelaySeconds)
                {
                    spawnedEnemies[i] = waveComponent.SpawnEnemy(player);
                    waveComponents[i] = null;
                }
            }
        }
        if (!thingsLeftToSpawn)
        {
            waveComponents = null;
        }
    }
}
