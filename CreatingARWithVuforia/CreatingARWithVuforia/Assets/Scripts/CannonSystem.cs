//This script controls the firing capabilities of the turret. It is responsible for creating the projectiles
//as well as controlling the visual and audio feedback involved in shooting

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CannonSystem : MonoBehaviour 
{

    public int playerID;

	[Header("Firing Properties")]
	public float maxProjectileForce = 1f;   //Maximum force of a projectile
	public float cooldown = 1f;

	[Header("Projectile Properties")]
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

	[Header("UI Objects")]
	public Slider angleSlider;
	public Text angleText;
	public Slider heightSlider;
	public Slider powerSlider;
	public Transform otherTurretTransform;

    [Header("Canvas Objects")]
    public Canvas Canvas1;
    public Canvas Canvas2;

    MenuManager manager;
    //Transform projectileSpawnTransform;         //Location where the projectiles should spawn
	bool canShoot = true;
	Animator anim;								//Reference to the animator component


	void Awake()
	{
		//Get a reference to the projectile spawn point. By providing the path to the object like this, we are making an 
		//inefficient method call more efficient
		//projectileSpawnTransform = GameObject.Find("Geometry/Cockpit/Turret Elevation Pivot Point/Projectile Spawn Point").transform;
 
		maxProjectileForce = powerSlider.value;

        manager = GameObject.Find("MenuManager").GetComponent<MenuManager>();
		//Get a reference to the animator component
		anim = GetComponent<Animator> ();

        // Set slider values to match scene size
        powerSlider.maxValue = powerSlider.maxValue * manager.sceneSize;
        powerSlider.minValue = powerSlider.minValue * manager.sceneSize;
	}

	public void FireProjectile()
	{
		if (!canShoot)
			return;

        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);
        Vector3 bulletScale = bullet.gameObject.transform.localScale;
        //change these values:
        float size2Scale = (float)1.15;
        float size3Scale = (float)1.75;
        switch (manager.sceneSize)
        {
            case 2:
                //need to change numbers to be the right values -- playtest
                bullet.gameObject.transform.localScale = new Vector3(bulletScale.x * size2Scale, bulletScale.y * size2Scale, bulletScale.z * size2Scale);
                break;
            case 3:
                //same here
                bullet.gameObject.transform.localScale = new Vector3(bulletScale.x * size3Scale, bulletScale.y * size3Scale, bulletScale.z * size3Scale);
                break;
            default:
                break;
        }
		bullet.tag = "p" + playerID;

        // Add velocity to the bullet
//        Vector3 speed = new Vector3(1, 0, 0);
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * maxProjectileForce;
//        bullet.GetComponent<Rigidbody>().angularVelocity = bullet.transform.up;

        // Destroy the bullet after 2 seconds
//        Destroy(bullet, 2.0f);
		anim.SetTrigger ("Fire");

		canShoot = false;

        //change canvas depending on the current player turn
        if(playerID == 1)
        {
			Canvas1.gameObject.SetActive (false);
			Canvas2.gameObject.SetActive (true);
        }

        if(playerID == 2)
        {
			Canvas2.gameObject.SetActive (false);
			Canvas1.gameObject.SetActive (true);
            
        }
		Invoke("CoolDown", cooldown);
	}

	public void RotateCannon() {
		Vector3 zeroVector = otherTurretTransform.position - transform.position;
		float zeroAngle = Vector3.Angle (zeroVector, Vector3.forward);

        //if (playerID == 1) {
			transform.eulerAngles = new Vector3 (heightSlider.value, zeroAngle + angleSlider.value);
		//} else {
		//	transform.eulerAngles = new Vector3 (heightSlider.value, zeroAngle + angleSlider.value);
		//}
//		angleText.text = "Angle: " + transform.eulerAngles.y;
	}

	public void changePower() {
        float size2Scale = (float)1.15;
        float size3Scale = (float)1.75;
        switch (manager.sceneSize)
        {
            case 2:
                //need to change numbers to be the right values -- playtest
                maxProjectileForce = powerSlider.value * size2Scale;
                break;
            case 3:
                //same here
                maxProjectileForce = powerSlider.value * size3Scale;
                break;
            default:
                maxProjectileForce = powerSlider.value;
                break;
        }
    }

	void CoolDown()
	{
		canShoot = true;
	}
}