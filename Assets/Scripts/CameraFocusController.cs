// full tutorial here:
// https://medium.com/@harmittaa/setting-camera-focus-mode-for-vuforia-arcamera-in-unity-6b3745297c3d

using UnityEngine;
using System.Collections;
using Vuforia;

public class CameraFocusController: MonoBehaviour {

 // code from  Vuforia Developer Library
 // https://library.vuforia.com/articles/Solution/Camera-Focus-Modes
 void Start() {    
  var vuforia = VuforiaARController.Instance;    
  vuforia.RegisterVuforiaStartedCallback(OnVuforiaStarted);    
  vuforia.RegisterOnPauseCallback(OnPaused);
 }  

 private void OnVuforiaStarted() {    
  CameraDevice.Instance.SetFocusMode(
      CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
 }

 private void OnPaused(bool paused) {    
  if (!paused) // resumed
  {
       // Set again autofocus mode when app is resumed
       CameraDevice.Instance.SetFocusMode(
          CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);    
  }
 }
}
