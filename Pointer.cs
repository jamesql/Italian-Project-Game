using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pointer: MonoBehaviour {

// Ray Cast Objs
 public Camera cam;
 public float range = 50f;

// Highlighting Objs
 public Material highlightMaterial;
 Material originalMaterial;
 GameObject lastHighlightedObject;

// timer vars
bool TimerEnabled = true;
float time = 0.0f;

 // Scene Objects
 public TextMesh displayText;
 public TextMesh TimerDisplay;
public AudioSource audio;
 // Imported Foods
 public GameObject chicken;
 public GameObject wine;
 public GameObject cheese;
 public GameObject icecream;
 public GameObject egg;
 public GameObject steak;
 public GameObject pineapple;
 // Imported Foods

 // List of active foods
 private List < GameObject > list = new List < GameObject > ();
 private GameObject active;
 // Start is called before the first frame update
 void Start() {
  AddFoodsToList();
  UpdateActive();
 }

 // Update is called once per frame
 void Update() {
   if (TimerEnabled) { time += Time.deltaTime; TimerDisplay.text = time.ToString(); }
  Ray ray = cam.ViewportPointToRay(cam.ScreenToViewportPoint(Input.mousePosition));
  RaycastHit hit;
  if (Physics.Raycast(ray, out hit, 100)) {
   HighlightObject(hit.collider.gameObject);
   GameObject castedObj = hit.collider.gameObject;
   if (Input.GetKeyDown(KeyCode.E))
    if (castedObj.name == active.name) {
     UpdateActive(castedObj);
    } else playDunder();
  } else {
   ClearHighlighted();
  }
 }

// Highlights an object
 void HighlightObject(GameObject gameObject) {
  if (lastHighlightedObject != gameObject) {
   ClearHighlighted();
   originalMaterial = gameObject.GetComponent < MeshRenderer > ().sharedMaterial;
   gameObject.GetComponent < MeshRenderer > ().sharedMaterial = highlightMaterial;
   lastHighlightedObject = gameObject;
  }
 }

// Clears highlighting from object
 void ClearHighlighted() {
  if (lastHighlightedObject != null) {
   lastHighlightedObject.GetComponent < MeshRenderer > ().sharedMaterial = originalMaterial;
   lastHighlightedObject = null;
  }
 }

// Restarts game
 void RestartGame() {
   TimerEnabled = false;
  SceneManager.LoadScene(sceneName: "StartingScene");
 }

// Updates active and if game is started, removes active
 void UpdateActive(GameObject selected) {
   list.Remove(active);
  if (list.Count == 0) {
   RestartGame();
   return;
  }
  active = list[Random.Range(0, list.Count)];
  displayText.text = active.name;
  Destroy(selected);
 }

 // Updates active and if game is started, removes active
 // Overloaded Function
 void UpdateActive() {
  active = list[Random.Range(0, list.Count - 1)];
  displayText.text = active.name;
 }

// Used to convert foods array in to ArrayList
 void AddFoodsToList() {
  GameObject[] foods = {chicken, wine, cheese, icecream, egg, pineapple, steak};
  foreach(GameObject obj in foods) {
      list.Add(obj);
  }
 }

  // Sound Players
  void playDunder() {
    audio.Play();
  }
}