using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if ((collision.gameObject.CompareTag("Ebonar") || collision.gameObject.CompareTag("Yarat�kMermi") || collision.gameObject.CompareTag("Yarat�kMermi2") || collision.gameObject.CompareTag("YetenekGeli�tirme") || collision.gameObject.CompareTag("CheckPoint")))
        {
            return;
        }
        else
        {
            Destroy(GameObject.FindWithTag("EbonarMermi"));
            
        }
    }
}