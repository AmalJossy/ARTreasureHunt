using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class TapHandling : MonoBehaviour {
	
	private const float DOUBLE_TAP_MAX_DELAY = 0.5f;//seconds
    private float mTimeSinceLastTap = 0;

	protected int mTapCount = 0;
	public string prevscene;
	// Use this for initialization
	void Start () {
		mTapCount = 0;
		mTimeSinceLastTap = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.Escape))
        {
			SceneManager.LoadScene(prevscene);
        }
		HandleTap();
	}
	private void HandleTap(){	
		
        if (mTapCount == 1)
        {
            mTimeSinceLastTap += Time.deltaTime;
            if (mTimeSinceLastTap > DOUBLE_TAP_MAX_DELAY)
            {
                // reset touch count and timer
                mTapCount = 0;
                mTimeSinceLastTap = 0;
            }
        }
        else if (mTapCount == 2)
        {
            // we got a double tap
            OnDoubleTap();

            // reset touch count and timer
            mTimeSinceLastTap = 0;
            mTapCount = 0;
        }

        if (Input.GetMouseButtonUp(0))
        {
            mTapCount++;
        }
	}

	
	protected virtual void OnDoubleTap() {
		CameraSettings camSettings = GetComponentInChildren<CameraSettings>();
        if (camSettings)
        {
            camSettings.TriggerAutofocusEvent();
        }		
		
	}

	
}
