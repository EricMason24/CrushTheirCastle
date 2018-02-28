//This script controls the firing capabilities of the turret. It is responsible for creating the projectiles
//as well as controlling the visual and audio feedback involved in shooting

using UnityEngine;
using UnityEngine.Events;

public class CannonSystem : MonoBehaviour 
{
	[Header("Firing Properties")]
	public float maxProjectileForce = 180f;   //Maximum force of a projectile
	public float cooldown = 1f;

	[Header("Projectile Properties")]
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    Transform projectileSpawnTransform;         //Location where the projectiles should spawn
	bool canShoot = true;
	Animator anim;								//Reference to the animator component


	void Awake()
	{
		//Get a reference to the projectile spawn point. By providing the path to the object like this, we are making an 
		//inefficient method call more efficient
		projectileSpawnTransform = GameObject.Find("Geometry/Cockpit/Turret Elevation Pivot Point/Projectile Spawn Point").transform;

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
        Vector3 speed = new Vector3(1, 0, 0);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward;
        //bullet.GetComponent<Rigidbody>().angularVelocity = bullet.transform.up;

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
		anim.SetTrigger ("Fire");

		canShoot = false;
		Invoke("CoolDown", cooldown);
	}

	void CoolDown()
	{
		canShoot = true;
	}
}