using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr : MonoBehaviour
{
    bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
    
    }
    void OnCollisionEnter2D(Collision2D col) {
    if (col.gameObject.GetComponent<playermove>()){
        
        if (isDead == false) {
            col.gameObject.GetComponent<playermove>().a.SetBool("is dead",true);
            col.gameObject.GetComponent<playermove>().canrun = false;
            StartCoroutine(waitTillRestart());
            isDead = true;
        }
        //Destroy(col.gameObject, 1);
     
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
