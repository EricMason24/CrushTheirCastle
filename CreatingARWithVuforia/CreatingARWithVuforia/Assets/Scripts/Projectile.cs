//This script controls the behavior of the projectiles we fire. It handles exploding force as well as
//cleaning itself up from the scene

using UnityEngine;
using UnityEngine.Events;

public class Projectile : MonoBehaviour
{
    [Header("Projectile Properties")]
    public float lifeTime = 2.0f;               //The amount of time the projectile lives
    public float gravity = 9.8f;
    public float explosionDuration = .25f;
    public float explosionForce = 100f;         //The amount of force the projectile explodes with
    public float explosionRadius = 4f;          //The radius of the explosion
    public LayerMask targetLayerMask;           //The layermask that determines which objects are affected by the explosion

    [Header("Object References")]
    public GameObject explosion;

    MenuManager manager;

    //Rigidbody rigidBody;						//Reference to the rigidbody of the projectile
    //Collider sphereCollider;					//Reference to the collider of the projectile
    //bool exploded;								//Has the projectile exploded?


    void Awake()
    {
        //Get references to the collider and rigidbody
        manager = GameObject.Find("MenuManager").GetComponent<MenuManager>();
        transform.localScale += transform.localScale * manager.sceneSize;
        //sphereCollider = GetComponent<Collider> ();
        //rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Reduce the lifetime of the projectile
        lifeTime -= Time.deltaTime;
        //If the projectile has no life left...
        if (lifeTime <= 0f)
        {
            //...make it explode and then destroy it
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //We've hit something, so explode
        //Explode();

        //Try to get a Target script off of the thing we hit
        Target target = collision.gameObject.GetComponent<Target>();

        //If there was a Target script on the thing we hit, tell it we hit it
        if (target != null && !target.gameObject.CompareTag(gameObject.tag))
        {
            target.Hit();
            Explode();
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("ground"))
        {
            Explode();
        }
    }

    void Explode()
    {
        //If we've already exploded, leave
        //if (exploded)
            //return;

        Instantiate(explosion, transform.position, transform.rotation);

        //Find all colliders that are with the explosion radius that are also on the target layer
        //Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, targetLayerMask);
        ////Loop through the colliders and...
        //for (int i = 0; i < colliders.Length; i++)
        //{
        //    //...find the rigidbody on the game objects...
        //    Rigidbody rb = colliders[i].GetComponent<Rigidbody>();
        //    //...and send them flying with an explosive force
        //    rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, 2f);
        //}

        GetComponent<Collider>().enabled = false;
        Destroy(gameObject);
    }
}
