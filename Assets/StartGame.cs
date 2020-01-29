using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class StartGame: MonoBehaviour {

 [SerializeField] UnityEvent anEvent;

 // On mouse down trigger this method
 private void OnMouseDown() {
  SceneManager.LoadScene(sceneName: "SampleScene");
 }

}
