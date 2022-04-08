using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Main Settings")]
    public GameObject projectilePrefab;
    public float Speed;
    public float lifetime;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", lifetime);
    }

    void DestroyProjectile()
    {
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        projectilePrefab.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }
}
