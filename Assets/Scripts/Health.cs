using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float totalHealth;
    public float currentHealth { get; private set; }
    
    private void Awake()
    {
        currentHealth = totalHealth;
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
