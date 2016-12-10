using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Camera))]
public class ScreenShakeEffect : MonoBehaviour {

    [SerializeField]
    private float ShakeDurationSeconds = 0.3f;

    [SerializeField]
    private float MaxShakeIntensity = 1;

    private Camera screenShakeCamera;
    private Vector3 cameraRestorePosition;
    private float shakeTimeElapsed = float.MaxValue;

	// Use this for initialization
	void Start () {
        this.screenShakeCamera = GetComponent<Camera>();
        this.cameraRestorePosition = screenShakeCamera.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(shakeTimeElapsed < ShakeDurationSeconds)
        {
            ShakeScreen();
            shakeTimeElapsed += Time.deltaTime;
            //once time is elapsed, restore the camera position
            if(shakeTimeElapsed >= ShakeDurationSeconds)
            {
                screenShakeCamera.transform.position = cameraRestorePosition;
            }
        }
	}

    private void ShakeScreen()
    {
        float shakeMagnitude = (1 - (shakeTimeElapsed / ShakeDurationSeconds)) * MaxShakeIntensity;
        Vector3 movedCamPos = this.cameraRestorePosition + (Random.onUnitSphere * shakeMagnitude);
        screenShakeCamera.transform.position = movedCamPos;
    }

    /**
     * Public methods, so other scripts can shake the screen
     **/
     public void StartScreenShake()
    {
        shakeTimeElapsed = 0f;
    }

}
