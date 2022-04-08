using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    public SoundManager soundManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Health>().getMedkit();
            soundManager.getItemSound();
            Destroy(this.gameObject);
        }
    }
}
