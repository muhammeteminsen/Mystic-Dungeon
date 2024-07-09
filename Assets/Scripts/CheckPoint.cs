using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private Vector2[] checkPoints;
    public static Vector2 lastTransform;
    private EbonarAte�Etme ebonarAte�Etme;
    

    void Start()
    {
        ebonarAte�Etme = FindAnyObjectByType<EbonarAte�Etme>();

        
    }

    private void OnTriggerEnter2D(Collider2D temas)
    {
        if (temas.gameObject.CompareTag("Ebonar"))
        {

            lastTransform = ebonarAte�Etme.ebonar.transform.position;
            
            Debug.Log("Tamam");
        }
    }
}
