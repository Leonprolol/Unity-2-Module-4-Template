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
    void OnCollisionEnter2D(Collision2D col) {
    if (col.gameObject.GetComponent<playermove>()){
        print(col.gameObject.GetComponent<playermove>().isDead);

        if (col.gameObject.GetComponent<playermove>().isDead == false) {
            col.gameObject.GetComponent<playermove>().isDead = true;
            col.gameObject.GetComponent<playermove>().a.SetBool("is dead",true);
            col.gameObject.GetComponent<playermove>().canrun = false;
            Scene currentScene = SceneManager.GetActiveScene ();

            string sceneName = currentScene.name;
        
            SceneManager.LoadScene(currentScene.buildIndex);
            StartCoroutine(waitTillRestart());
        }
        //Destroy(col.gameObject, 1);
     
    }
}

IEnumerator waitTillRestart() {
   
    yield return new WaitForSeconds(1.0f);
 print("hello 1 second later");
    
    
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
