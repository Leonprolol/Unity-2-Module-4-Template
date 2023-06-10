using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shop : MonoBehaviour
{
    public GameObject player;


    void Start()
    {
    }

    void Update()
    {
    }

    public void closeShop() {
        gameObject.SetActive(false);

    }

    public void buyshotgun()
    {
        if (player.GetComponent<playermove>().coins >= 200 && player.GetComponent<playermove>().weapons.Contains("ShotGun") == false){
            player.transform.GetChild(0).GetComponent<attack>().shotgun = true;
            player.GetComponent<playermove>().coins -= 200;
        }
        else if (player.GetComponent<playermove>().coins >= 200 ) {
            player.transform.GetChild(0).GetComponent<attack>().ShotgunObj.GetComponent<Shotgun>().damage += 2;
            player.GetComponent<playermove>().coins -= 200;

        }
    }
    public void buypistol()
    {
        if (player.GetComponent<playermove>().coins >= 100){
            player.transform.GetChild(0).GetComponent<attack>().PistolObj.GetComponent<Pistol>().damage += 2;
            player.GetComponent<playermove>().coins -= 100;

        }
    }
    public void buymachinegun()
    {
        if (player.GetComponent<playermove>().coins >= 150){
            player.transform.GetChild(0).GetComponent<attack>().machinegun = true;
            player.GetComponent<playermove>().coins -= 150;

        }
        else if (player.GetComponent<playermove>().coins >= 200 ) {
            player.transform.GetChild(0).GetComponent<attack>().MachinegunObj.GetComponent<Machinegun>().damage += 2;
            player.GetComponent<playermove>().coins -= 200;

        }
    }
    public void buyrifle()
    {
        if (player.GetComponent<playermove>().coins >= 100){
            player.transform.GetChild(0).GetComponent<attack>().sniper = true;
            player.GetComponent<playermove>().coins -= 100;

        }
        else if (player.GetComponent<playermove>().coins >= 200 ) {
            player.transform.GetChild(0).GetComponent<attack>().SniperObj.GetComponent<Sniper>().damage += 2;
            player.GetComponent<playermove>().coins -= 100;

        }
    }
}
