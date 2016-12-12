using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    [SerializeField]
    private Text gameOverText;

    [SerializeField]
    private Text gameOverTextShadow;

    [SerializeField]
    private Text retryText;

    [SerializeField]
    private Button retryButton;

    [SerializeField]
    private float effectDurationSeconds;

    [SerializeField]
    private float effectDelaySeconds = 0.1f;

    private float timeElapsed = 0f;
    private bool effectStarted = false;

    // Use this for initialization
    void Start () {
        //make it invisible to start with
        this.gameOverText.CrossFadeAlpha(0, 0, true);
        this.gameOverTextShadow.CrossFadeAlpha(0, 0, true);
        this.retryText.CrossFadeAlpha(0, 0, true);
        this.retryButton.image.CrossFadeAlpha(0, 0, true);
    }
	
	// Update is called once per frame
	void Update () {
        if (!effectStarted && timeElapsed > effectDelaySeconds)
        {
            this.gameOverText.CrossFadeAlpha(1, effectDurationSeconds, true);
            this.gameOverTextShadow.CrossFadeAlpha(1, effectDurationSeconds, true);
            this.retryText.CrossFadeAlpha(1, effectDurationSeconds, true);
            this.retryButton.image.CrossFadeAlpha(1, effectDurationSeconds, true);
            this.effectStarted = true;
        }
        else if(!effectStarted && timeElapsed <= effectDelaySeconds)
        {
            this.timeElapsed += Time.deltaTime;
        }
	}

    public void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
