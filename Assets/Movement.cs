using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement: MonoBehaviour {

 private float speed = 2.0 f;
 public GameObject character;

 public float mouseSensitivity = 100.0 f;
 public float clampAngle = 80.0 f;

 private float rotY = 0.0 f; // rotation around the up/y axis
 private float rotX = 0.0 f; // rotation around the right/x axis

 // Start is called before the first frame update
 void Start() {
  Vector3 rot = transform.localRotation.eulerAngles;
  rotY = rot.y;
  rotX = rot.x;
 }

 // Update is called once per frame
 void Update() {
  // Walking Movement
  if (Input.GetKey(KeyCode.RightArrow)) {
   character.transform.position += Vector3.right * speed * Time.deltaTime;
  }
  if (Input.GetKey(KeyCode.LeftArrow)) {
   character.transform.position += Vector3.left * speed * Time.deltaTime;
  }
  if (Input.GetKey(KeyCode.UpArrow)) {
   character.transform.position += Vector3.forward * speed * Time.deltaTime;
  }
  if (Input.GetKey(KeyCode.DownArrow)) {
   character.transform.position += Vector3.back * speed * Time.deltaTime;
  }

  // Looking Movement
  float mouseX = Input.GetAxis("Mouse X");
  float mouseY = -Input.GetAxis("Mouse Y");

  rotY += mouseX * mouseSensitivity * Time.deltaTime;
  rotX += mouseY * mouseSensitivity * Time.deltaTime;

  rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

  Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0 f);
  transform.rotation = localRotation;

 }

}
