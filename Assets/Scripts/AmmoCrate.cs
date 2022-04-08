using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCrate : MonoBehaviour
{
    public SoundManager soundManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerAttack>().addAmmo();
            soundManager.getItemSound();
            Destroy(this.gameObject);
        }
    }
}
