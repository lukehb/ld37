using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour {

    [SerializeField]
    private Wave[] waves;

    [SerializeField]
    private int currentWaveIndex = 0;

    private Wave currentWave = null;

	// Use this for initialization
	void Start () {
        this.currentWave = waves[currentWaveIndex];
        this.currentWave.gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {

        if (currentWave == null && currentWaveIndex + 1 < this.waves.Length)
        {
            currentWaveIndex++;
            this.currentWave = this.waves[currentWaveIndex];
            this.currentWave.gameObject.SetActive(true);
        }
        else if(currentWave != null && currentWave.IsWaveDone)
        {
            Destroy(this.currentWave.gameObject);
            this.currentWave = null;
        }

	}

    

}
