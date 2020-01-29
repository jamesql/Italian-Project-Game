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


 // Scene Objects
 public TextMesh displayText;

 // Imported Foods
 public GameObject chicken;
 public GameObject wine;
 public GameObject cheese;
 public GameObject icecream;
 public GameObject egg;
 public GameObject steak;
 // Imported Foods

// Foods 1d array
 private GameObject[] foods = {chicken, wine, cheese, icecream, egg, steak};

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
  Ray ray = cam.ViewportPointToRay(cam.ScreenToViewportPoint(Input.mousePosition));
  RaycastHit hit;
  if (Physics.Raycast(ray, out hit, 100)) {
   HighlightObject(hit.collider.gameObject);
   GameObject castedObj = hit.collider.gameObject;
   if (Input.GetKeyDown(KeyCode.E))
    if (castedObj.name == active.name) {
     UpdateActive(castedObj);
    }
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
  SceneManager.LoadScene(sceneName: "StartingScene");
 }

// Updates active and if game is started, removes active
 void UpdateActive(GameObject selected) {
  if (active != null)
   list.Remove(active);
  if (list.Count == 0) {
   restartGame();
   return;
  }
  active = list[Random.Range(0, list.Count - 1)];
  displayText.text = active.name;
  Destroy(selected);
 }

// Used to convert foods array in to ArrayList
 void AddFoodsToList() {
  foreach(GameObject obj in foods) {
      list.Add(obj);
  }
 }
}