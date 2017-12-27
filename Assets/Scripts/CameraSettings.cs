using UnityEngine;
using System.Collections;
using Vuforia;

public class CameraSettings : MonoBehaviour {

    private bool mVuforiaStarted = false;
    private bool mAutofocusEnabled = true;


    void Start () 
    {
        var vuforia = VuforiaARController.Instance;
        vuforia.RegisterVuforiaStartedCallback(OnVuforiaStarted);
        vuforia.RegisterOnPauseCallback(OnPaused);
    }
	
	public bool IsAutofocusEnabled()
    {
        return mAutofocusEnabled;
    }

    public void SwitchAutofocus(bool ON)
    {
        if (ON)
        {
            if (CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO))
            {
                Debug.Log("Successfully enabled continuous autofocus.");
                mAutofocusEnabled = true;
            }
            else
            {
                // Fallback to normal focus mode
                Debug.Log("Failed to enable continuous autofocus, switching to normal focus mode");
                mAutofocusEnabled = false;
                CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_NORMAL);
            }
        }
        else
        {
            Debug.Log("Disabling continuous autofocus (enabling normal focus mode).");
            mAutofocusEnabled = false;
            CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_NORMAL);
        }
    }
    public void TriggerAutofocusEvent()
    {
        // Trigger an autofocus event
        CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_TRIGGERAUTO);

        // Then restore original focus mode
        StartCoroutine(RestoreOriginalFocusMode());
    }
	private void OnVuforiaStarted()
    {
        mVuforiaStarted = true;
        // Try enabling continuous autofocus
        SwitchAutofocus(true);
    }
	private void OnPaused(bool paused)
    {
        bool appResumed = !paused;
        if (appResumed && mVuforiaStarted)
        {
            // Restore original focus mode when app is resumed
            if (mAutofocusEnabled)
                CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
            else
                CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_NORMAL);
        }
	}
	private IEnumerator RestoreOriginalFocusMode()
    {
        // Wait 1.5 seconds
        yield return new WaitForSeconds(1.5f);

        // Restore original focus mode
        if (mAutofocusEnabled)
            CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
        else
            CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_NORMAL);
    }
	
	
}
