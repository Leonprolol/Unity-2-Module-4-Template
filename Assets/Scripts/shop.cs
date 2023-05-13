using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject player;


    void Start()
    {
    }

    void Update()
    {
    }

    void buyshotgun()
    {
        if (player.GetComponent<playermove>().coins >= 200 && player.GetComponent<playermove>().weapons.Contains("ShotGun") == false){
            
        }
    }
     void buypistol()
    {
    }
      void buymachinegun()
    {
        if (player.GetComponent<playermove>().coins >= 150){
            
        }
    }
      void buyrifle()
    {
        if (player.GetComponent<playermove>().coins >= 100){
            
        }
    }
}
