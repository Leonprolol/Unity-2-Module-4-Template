using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class attack : MonoBehaviour
{
    public GameObject bullet;
    public GameObject firepoint;
    public GameObject gun;
    //public GameObject knifeReal;
    public GameObject PistolObj;
    public GameObject ShotgunObj;
    public GameObject SniperObj;
    public GameObject MachinegunObj;
    private Vector3 directions;
    public Transform square;


    public bool machinegun = false;
    public bool shotgun = false;
    public bool sniper = false;




    
    private int currentWeapon = 0;

    private List<Gunner> weapons;

    public int ammo = 100;
    public float cooldown = 1.5f;
    private bool canAttack = true;
    private bool knife = false;
    private Animator knifeanimtion;
    public GameObject ammoText;
    public Animator a;
    //public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        weapons = new List<Gunner>();
        //knifeanimtion = knifeReal.GetComponent<Animator>();
        a = GetComponent<Animator>();
        Shotgun shot = new Shotgun();
        Pistol pistol = new Pistol();
        Machinegun machinegun = new Machinegun();
        Sniper sniper = new Sniper();
        pistol.damage = 20;
        weapons.Add(shot);
        weapons.Add(pistol);
        weapons.Add(machinegun);
        weapons.Add(sniper);
    }

    // Update is called once per frame
    void Update()
    {
        square.gameObject.SetActive(true);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        square.position = new Vector3(worldPosition.x, worldPosition.y, 1);
        directions = square.position-firepoint.transform.position;
        

       
        //worldPosition.z = 0f; // Assuming your character is on the 2D plane (z = 0)

        // Compare the character's position with the mouse position to determine the direction
        //Vector3 characterPosition = transform.position; 
        /*
        Vector3 direction = worldPosition - transform.parent.position;

        // Flip the character's sprite accordingly
        if (direction.x > 0f)
        {
            spriteRenderer.flipX = false; // Face right (no flip)
        }
        else if (direction.x < 0f)
        {
            spriteRenderer.flipX = true; // Face left (flip the sprite horizontally)
        }
        */
        if (Input.GetKeyDown(KeyCode.Alpha1)){
          //  knife = true;
            //knifeReal.SetActive(true);
            gun.SetActive(false);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2)){
            //knife = false;
            gun.SetActive(false);

            //knifeReal.SetActive(false);
            gun = PistolObj;
            currentWeapon = 0;
            gun.SetActive(true);
        }
         
        if (Input.GetKeyDown(KeyCode.Alpha3) && shotgun){
            //knife = false;
            gun.SetActive(false);

           // knifeReal.SetActive(false);
            gun = ShotgunObj;
            currentWeapon = 1;
            gun.SetActive(true);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha4) && sniper){
            knife = false;
            gun.SetActive(false);

            //knifeReal.SetActive(false);
            gun = SniperObj;
            currentWeapon = 2;
            gun.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) && machinegun){
            //knife = false;
            gun.SetActive(false);

            //knifeReal.SetActive(false);
            gun = MachinegunObj;
            currentWeapon = 3;
            gun.SetActive(true);
        }
     if (Input.GetMouseButtonDown(0)){
        if (knife == true) {
           // a.Play("Stab");

        }
        else {
         
            if (ammo > 0 && canAttack == true && knife == false) {
            //Debug.Break();
            a.Play("fire");
            GameObject bulletClone = Instantiate(bullet, firepoint.transform.position, Quaternion.identity); 
            bulletClone.GetComponent<bullet>().fire(directions);
            
            //weapons[currentWeapon].damage;
            bulletClone.GetComponent<bullet>().setDamage(gun.GetComponent<Gunner>().damage);

          
            weapons[currentWeapon].ammo = weapons[currentWeapon].ammo-1;
            canAttack = false;
            StartCoroutine(attackcooldown());
            }
        }
    
       
     }   
     if (Input.GetKeyDown(KeyCode.R) && knife == false) {
        weapons[currentWeapon].ammo = 100;
     }
      ammoText.GetComponent<TextMeshProUGUI>().text = "Ammo:" + weapons[currentWeapon].ammo.ToString();

    }

    IEnumerator attackcooldown(){
        yield return new WaitForSeconds(gun.GetComponent<Gunner>().cooldown);
        canAttack = true;
    } 
}
