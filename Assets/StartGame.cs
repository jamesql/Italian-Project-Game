 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.Events;
 using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    [SerializeField] UnityEvent anEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Methods
    private void OnMouseDown()
     {
         print("Starting Game...");
         SceneManager.LoadScene (sceneName:"SampleScene");
     }

}
