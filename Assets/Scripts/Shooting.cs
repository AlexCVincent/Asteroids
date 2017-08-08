using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace functions
{


    public class Shooting : MonoBehaviour
    {

        //Stores the object we want to Instatiate
        public GameObject projectilePrefab;
        //Speed at which the projectile travels
        public float projectileSpeed = 20f;
        //Rate at which projectiles are fired
        public float shootRate = 0.1f;
        //Timer to count ip to shootRate
        private float shootTimer = 0f;
        //Container for Rigidbody 2D
        private Rigidbody2D rigid;
        public float recoil = 15f;

        // Use this for initialization
        void Start()
        {
            //Get the RigidBody component
            rigid = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            //Increase timer in 1-second increments
            shootTimer += Time.deltaTime;
            //AND = &&
            //Or = ||

            //IF space bar is pressed AND shootTimer >= shootRate
            //CALL shoot()

            if (Input.GetKey("space") && shootTimer >= shootRate)
            {
                Shoot();
                shootTimer = 0;
            }

        }
        void Shoot()
        {
            //Instatiate a new copy of projectilePrefab
            GameObject projectile = Instantiate(projectilePrefab);
            //Position of projectile is equal to transform position
            projectile.transform.position = transform.position;
            //Apply a force to the projectile
            Rigidbody2D ProjectileRigid = projectile.GetComponent<Rigidbody2D>();
            ProjectileRigid.AddForce(transform.right * projectileSpeed, ForceMode2D.Impulse);
            //Apply a recoil to the player
            rigid.AddForce(-transform.right * recoil, ForceMode2D.Impulse);
        }
    }
}
