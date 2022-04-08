using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float totalHealth;
    public float currentHealth { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        currentHealth = totalHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getHit()
    {
        currentHealth = Mathf.Clamp(currentHealth - 1, 0, totalHealth);
    }

    public void getMedkit()
    {
        currentHealth = Mathf.Clamp(currentHealth + 1, 0, totalHealth);
    }
}
