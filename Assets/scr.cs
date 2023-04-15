using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    
    }
    void OnTriggerEnter2D(Collider2D col) {
    if (col.gameObject.GetComponent<playermove>()){
        
        //Destroy(col.gameObject, 1);
        col.gameObject.GetComponent<playermove>().a.SetBool("is dead",true);
        col.gameObject.GetComponent<playermove>().canrun = false;
        StartCoroutine(waitTillRestart());
    }
}

IEnumerator waitTillRestart() {
    yield return new WaitForSeconds(1.0f);

    Scene currentScene = SceneManager.GetActiveScene ();

    string sceneName = currentScene.name;
   
    SceneManager.LoadScene(currentScene.buildIndex);
    
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
