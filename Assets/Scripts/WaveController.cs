using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveController : MonoBehaviour {

    [SerializeField]
    private Wave[] waves;

    public static int currentWaveIndex = 0;

    [SerializeField]
    private GameWon gameWonScreen = null;

    [SerializeField]
    private Text waveUIText;

    [SerializeField]
    private Animator anim;

    private readonly int CinematicTriggerId = Animator.StringToHash("CinematicTrigger");

    private Wave currentWave = null;

    private void StartWave()
    {
        this.anim.SetTrigger(CinematicTriggerId);
        this.currentWave = waves[currentWaveIndex];
        this.waveUIText.text = this.currentWave.WaveText;
        this.currentWave.gameObject.SetActive(true);
    }

	// Use this for initialization
	void Start () {
        StartWave();
	}
	
	// Update is called once per frame
	void Update () {

        if (currentWave == null)
        {
            if (currentWaveIndex + 1 < this.waves.Length)
            {
                currentWaveIndex++;
                StartWave();
            }
            else
            {
                this.gameWonScreen.gameObject.SetActive(true);
            }
        }
        else if(currentWave != null && currentWave.IsWaveDone)
        {
            Destroy(this.currentWave.gameObject);
            this.currentWave = null;
        }

	}

    

}
