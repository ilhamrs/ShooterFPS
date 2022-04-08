using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float speed;

    private Rigidbody zombieRb;
    private GameObject player;
    private Animator zombieAnim;
    private Transform target;
    private bool isDeath;

    // Start is called before the first frame update
    void Start()
    {
        zombieRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        target = player.GetComponent<Transform>();
        zombieAnim = GetComponent<Animator>();
        isDeath = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDeath)
        {
            zombieAnim.SetFloat("speed", speed);
            Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            transform.LookAt(target);

            float distance = Vector3.Distance(player.transform.position, transform.position);

            if (distance <= 1)
            {
                zombieAnim.SetBool("isNear", true);
            }
            else
            {
                zombieAnim.SetBool("isNear", false);
                zombieRb.MovePosition(pos);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "projectile")
        {
            GetComponent<Health>().getHit();
            float health = GetComponent<Health>().currentHealth;
            if (health <= 0)
            {
                Dead();
            }
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().getHit();
            Debug.Log("you got attack!");
        }
    }

    public void Dead()
    {
        isDeath = true;
        zombieAnim.SetBool("isDead", true);
        Invoke("destroyZombie", 3);
    }

    private void destroyZombie()
    {
        Destroy(this.gameObject);
    }
}
