using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartEffect : MonoBehaviour {

    [SerializeField]
    private AudioSource gameBgMusic;

    [SerializeField]
    private Image gameStartPanel;

    [SerializeField]
    private float effectDurationSeconds;

    [SerializeField]
    private float effectDelaySeconds;

    private float timeElapsed = 0f;
    private bool hasEffectStarted = false;

	// Use this for initialization
	void Start () {
        Color c = gameStartPanel.color;
        c.a = 1;
        gameStartPanel.color = c;
        gameBgMusic.volume = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (!hasEffectStarted && timeElapsed > effectDelaySeconds)
        {
            hasEffectStarted = true;
            gameStartPanel.CrossFadeAlpha(0, effectDurationSeconds, true);
        }
        if(gameBgMusic.volume < 1.0)
        {
            gameBgMusic.volume = (timeElapsed - effectDelaySeconds) / effectDurationSeconds;
        }
        if(timeElapsed < (effectDurationSeconds + effectDelaySeconds))
        {
            this.timeElapsed += Time.deltaTime;
        }
	}
}
