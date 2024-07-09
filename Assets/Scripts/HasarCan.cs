using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasarCan : MonoBehaviour
{
    
    public GameObject ebonar;
    public GameObject yarat�kMermi;
    public GameObject yarat�k2Mermi;
    //public GameObject yarat�k3Mermi;
    //public GameObject yarat�k4Mermi;
    public GameObject yarat�kRight;
    public GameObject yarat�k2Right;
    //public GameObject yarat�k3Right;
    //public GameObject yarat�k4Right;
    private float tekrarSaniyesi = .75f;
    
    public float yarat�kAt�sH�z� = 2f;
    Yarat�k1CanHasar yarat�k1CanHasar;
    Yarat�k2CanHasar yarat�k2CanHasar;
    //Yarat�k3CanHasar yarat�k3CanHasar;
    //Yarat�k4CanHasar yarat�k4CanHasar;
    public bool ate�Ediyormu;
    Sounds sounds;
    

    void Start()
    {
        yarat�k1CanHasar = FindAnyObjectByType<Yarat�k1CanHasar>();
        yarat�k2CanHasar = FindAnyObjectByType<Yarat�k2CanHasar>();
        //yarat�k3CanHasar = FindAnyObjectByType<Yarat�k3CanHasar>();
        //yarat�k4CanHasar = FindAnyObjectByType<Yarat�k4CanHasar>();
        sounds = FindAnyObjectByType<Sounds>(); 

  
        InvokeRepeating("Yarat�kMermi2FNC", 0f, tekrarSaniyesi);
        InvokeRepeating("Yarat�kMermiFNC", 0f, tekrarSaniyesi);  
        
        
    }


    void Yarat�kMermiFNC()
    {
        if (yarat�kRight!=null && yarat�k1CanHasar.distanceArea)
        {
            GameObject Yarat�kMermi = Instantiate(yarat�kMermi, yarat�kRight.transform.position, yarat�kRight.transform.rotation);
            Rigidbody2D yarat�kMermiRigidbody = Yarat�kMermi.GetComponent<Rigidbody2D>();


            Vector2 ebonarKonum = new Vector2(ebonar.transform.position.x, ebonar.transform.position.y);
            Vector2 hareketY�n� = ebonarKonum - new Vector2(Yarat�kMermi.transform.position.x, Yarat�kMermi.transform.position.y);
            yarat�kMermiRigidbody.velocity = hareketY�n�.normalized * yarat�kAt�sH�z� * 10;
            
        }
            
   
    }
    void Yarat�kMermi2FNC()
    {
        if (yarat�k2Right!=null &&yarat�k2CanHasar.distanceArea)
        {
            GameObject Yarat�k2Mermi = Instantiate(yarat�k2Mermi, yarat�k2Right.transform.position, yarat�k2Right.transform.rotation);
            Rigidbody2D yarat�k2MermiRigidbody = Yarat�k2Mermi.GetComponent<Rigidbody2D>();


            Vector2 ebonarKonum = new Vector2(ebonar.transform.position.x, ebonar.transform.position.y);
            Vector2 hareketY�n� = ebonarKonum - new Vector2(Yarat�k2Mermi.transform.position.x, Yarat�k2Mermi.transform.position.y);
            yarat�k2MermiRigidbody.velocity = hareketY�n�.normalized * yarat�kAt�sH�z� * 10;
        }
            
          
    }
    //void Yarat�kMermi3FNC()
    //{
    //    if (yarat�k3Right!=null && ate�Ediyormu==true  )
    //    {
    //        GameObject Yarat�k3Mermi = Instantiate(yarat�k3Mermi, yarat�k3Right.transform.position, yarat�k3Right.transform.rotation);
    //        Rigidbody2D yarat�k2MermiRigidbody = Yarat�k3Mermi.GetComponent<Rigidbody2D>();


    //        Vector2 ebonarKonum = new Vector2(ebonar.transform.position.x, ebonar.transform.position.y);
    //        Vector2 hareketY�n� = ebonarKonum - new Vector2(Yarat�k3Mermi.transform.position.x, Yarat�k3Mermi.transform.position.y);
    //        yarat�k2MermiRigidbody.velocity = hareketY�n�.normalized * yarat�kAt�sH�z� * 10;
    //    }
            
          
    //} 
    //void Yarat�kMermi4FNC()
    //{
    //    if (yarat�k4Right!=null && ate�Ediyormu==true )
    //    {
    //        GameObject Yarat�k4Mermi = Instantiate(yarat�k4Mermi, yarat�k4Right.transform.position, yarat�k4Right.transform.rotation);
    //        Rigidbody2D yarat�k2MermiRigidbody = Yarat�k4Mermi.GetComponent<Rigidbody2D>();


    //        Vector2 ebonarKonum = new Vector2(ebonar.transform.position.x, ebonar.transform.position.y);
    //        Vector2 hareketY�n� = ebonarKonum - new Vector2(Yarat�k4Mermi.transform.position.x, Yarat�k4Mermi.transform.position.y);
    //        yarat�k2MermiRigidbody.velocity = hareketY�n�.normalized * yarat�kAt�sH�z� * 10;
    //    }
            
          
    //}
  

    


   
}
