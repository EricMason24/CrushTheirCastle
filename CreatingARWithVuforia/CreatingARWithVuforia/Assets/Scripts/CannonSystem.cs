//This script controls the firing capabilities of the turret. It is responsible for creating the projectiles
//as well as controlling the visual and audio feedback involved in shooting

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CannonSystem : MonoBehaviour 
{
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

    Transform projectileSpawnTransform;         //Location where the projectiles should spawn
	bool canShoot = true;
	Animator anim;								//Reference to the animator component


	void Awake()
	{
		//Get a reference to the projectile spawn point. By providing the path to the object like this, we are making an 
		//inefficient method call more efficient
		projectileSpawnTransform = GameObject.Find("Geometry/Cockpit/Turret Elevation Pivot Point/Projectile Spawn Point").transform;


		maxProjectileForce = powerSlider.value;


		//Get a reference to the animator component
		anim = GetComponent<Animator> ();
	}

	public void FireProjectile()
	{
		if (!canShoot)
			return;

        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        // Add velocity to the bullet
//        Vector3 speed = new Vector3(1, 0, 0);
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * maxProjectileForce;
//        bullet.GetComponent<Rigidbody>().angularVelocity = bullet.transform.up;

        // Destroy the bullet after 2 seconds
//        Destroy(bullet, 2.0f);
		anim.SetTrigger ("Fire");

		canShoot = false;
		Invoke("CoolDown", cooldown);
	}

	public void RotateCannon() {
		transform.eulerAngles = new Vector3 (heightSlider.value, angleSlider.value);
		angleText.text = "Angle: " + transform.eulerAngles.y;
	}

	public void changePower() {
		maxProjectileForce = powerSlider.value;
	}

	void CoolDown()
	{
		canShoot = true;
	}
}