using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Yarat�k") || collision.gameObject.CompareTag("Yarat�k2") || collision.gameObject.CompareTag("YetenekGeli�tirme") || collision.gameObject.CompareTag("CheckPoint"))
        {
            return;
        }
        else
        {
            Destroy(GameObject.FindWithTag("Yarat�kMermi"));
            Destroy(GameObject.FindWithTag("Yarat�kMermi2"));

        }
    }
}
