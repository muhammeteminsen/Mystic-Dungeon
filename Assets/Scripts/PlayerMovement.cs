using BarthaSzabolcs.Tutorial_SpriteFlash;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    float moveSpeed = 5f;
    Rigidbody2D rb;
    public Camera kamera;

    private Yarat�k1CanHasar yarat�k1CanHasar;
    private Yarat�k2CanHasar yarat�k2CanHasar;

    public int ebonarCan;
    private bool yetenekObjeAl�nd� = false;
    bool anahtarAl�nd�;
    bool isWalking = false;
    bool secretchest;
    public int yetenekGeli�tirme;
    public int sceneIndex;

    public static int _enemyHit = 20;

    private UIControl u�Control;



    MainAnimations _mainAnimationforhit;
    SimpleFlash flasheffect;
    HasarCan hasarCan;
    Sounds sounds;




    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
      


        yarat�k1CanHasar = FindAnyObjectByType<Yarat�k1CanHasar>();
        yarat�k2CanHasar = FindAnyObjectByType<Yarat�k2CanHasar>();
        u�Control = FindAnyObjectByType<UIControl>();
        _mainAnimationforhit = FindAnyObjectByType<MainAnimations>();
        flasheffect = FindAnyObjectByType<SimpleFlash>();
        hasarCan = FindAnyObjectByType<HasarCan>();

        yetenekGeli�tirme = PlayerPrefs.GetInt(nameof(yetenekGeli�tirme));

        sounds = FindAnyObjectByType<Sounds>();
        sceneIndex = PlayerPrefs.GetInt(nameof(sceneIndex), 0);
        ebonarCan = PlayerPrefs.GetInt(nameof(ebonarCan),100);


    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sand�k" && Input.GetKeyDown(KeyCode.E) && ebonarCan < 100)
        {
            ebonarCan = 100;
            Debug.Log("Can Al�nd�");
            PlayerPrefs.SetInt(nameof(ebonarCan), ebonarCan);
            u�Control.originalHealthBar.sprite = u�Control._healthBar[5];
            sounds.caseOpening.Play();
            Destroy(GameObject.FindWithTag("Sand�k"));
        }
        if (collision.gameObject.tag == "Gizli Sand�k" && Input.GetKeyDown(KeyCode.E))
        {
            secretchest = true;
            sounds.caseOpening.Play();
            Destroy(GameObject.FindWithTag("Gizli Sand�k"));
        }
    }
    private void OnTriggerEnter2D(Collider2D temas)
    {


        if (temas.gameObject.tag == "Ba�lang��Kap�")
        {
            sceneIndex += 2;
            SceneManager.LoadScene(sceneIndex);
            u�Control.Veri();

        }
        else if (temas.gameObject.tag == "1Kap�"  && anahtarAl�nd� == true)
        {
            sceneIndex++;
            SceneManager.LoadScene(sceneIndex);
            u�Control.Veri();

        }
        else if (temas.gameObject.tag == "2Kap�" && yarat�k1CanHasar.yarat�kCan <= 0 && anahtarAl�nd� == true)
        {
            sceneIndex++;
            SceneManager.LoadScene(sceneIndex);
            u�Control.Veri();

        }
        else if (temas.gameObject.tag == "3Kap�" && yarat�k1CanHasar.yarat�kCan <= 0 && anahtarAl�nd� == true)
        {
            sceneIndex++;
            SceneManager.LoadScene(sceneIndex);
            u�Control.Veri();

        }
        else if (temas.gameObject.tag == "4Kap�")
        {
            sceneIndex++;
            SceneManager.LoadScene(sceneIndex);
            u�Control.Veri();


        }
        else if (temas.gameObject.tag == "5-8Kap�")
        {
            sceneIndex++;
            SceneManager.LoadScene(sceneIndex);
            u�Control.Veri();


        }
        else if (temas.gameObject.tag == "9Kap�" && yarat�k1CanHasar.yarat�kCan <= 0 && anahtarAl�nd� == true)
        {
            sceneIndex++;
            SceneManager.LoadScene(sceneIndex);
            u�Control.Veri();


        }
        else if (temas.gameObject.tag == "10Kap�" && yarat�k1CanHasar.yarat�kCan <= 0 && yarat�k2CanHasar.yarat�k2Can <= 0 && anahtarAl�nd� == true && secretchest)
        {
            sceneIndex++;
            SceneManager.LoadScene(sceneIndex);
            u�Control.Veri();


        }
        if (temas.gameObject.CompareTag("Anahtar"))
        {
            anahtarAl�nd� = true;
            Destroy(GameObject.FindWithTag("Anahtar"));
            sounds.doorOpening.Play();
            Debug.Log("Anahtar");
        }

        if (temas.gameObject.CompareTag("YetenekGeli�tirme"))
        {
            yetenekGeli�tirme += 300;
            YetenekGeli�tirme.birKereOlu�turuldu = true;
            yetenekObjeAl�nd� = true;

            PlayerPrefs.SetInt(nameof(yetenekGeli�tirme), yetenekGeli�tirme);
            PlayerPrefs.Save();
            sounds.skillTalent.Play();
            _mainAnimationforhit._mainAnimation.SetTrigger("health");
            if (yetenekObjeAl�nd�)
            {
                Destroy(GameObject.FindWithTag("YetenekGeli�tirme"));
            }
        }

        if (temas.gameObject.tag == "Yarat�kMermi")
        {

            ebonarCan -= _enemyHit;
            _mainAnimationforhit._mainAnimation.SetTrigger("!hit");
            flasheffect.Flash();
            HealtBarFeedBack.healthBar.SetTrigger("health");
            sounds.ebonarDamageSound.Play();
            if (yarat�k1CanHasar.yarat�kCan < 60)
            {
                yarat�k1CanHasar.yarat�kCan += 10;
            }

        }
        if (temas.gameObject.tag == "Yarat�kMermi2")
        {

            ebonarCan -= _enemyHit;
            _mainAnimationforhit._mainAnimation.SetTrigger("!hit");
            flasheffect.Flash();
            HealtBarFeedBack.healthBar.SetTrigger("health");
            sounds.ebonarDamageSound.Play();
            if (yarat�k2CanHasar.yarat�k2Can < 60)
            {
                yarat�k2CanHasar.yarat�k2Can += 10;
            }
        }

    }

    private void OnTriggerExit2D(Collider2D temas)
    {

        YetenekGeli�tirme.birKereOlu�turuldu = false;


    }
    void Update()
    {
        Debug.Log(ebonarCan);
        Debug.Log(sceneIndex);
        //ImleceG�reHareketFNC();
        HareketFNC();
        PlayerPrefs.SetInt(nameof(sceneIndex), sceneIndex);
        u�Control.yetenekGeli�tirmeText.text = yetenekGeli�tirme.ToString();


        if (Input.GetKeyDown(KeyCode.A))
        {
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        bool walkingThisFrame = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);

        if (walkingThisFrame && !isWalking)
        {
            sounds.ebonarWalkSound.Play();
            isWalking = true;
        }
        else if (!walkingThisFrame && isWalking)
        {
            sounds.ebonarWalkSound.Stop();
            isWalking = false;
        }


    }




    void HareketFNC()
    {


        float movehorizontal = Input.GetAxis("Horizontal");
        float movevertical = Input.GetAxis("Vertical");


        Vector2 movement = new Vector2(movehorizontal, movevertical);
        rb.velocity = movement * moveSpeed;

    }
    void ImleceG�reHareketFNC()
    {

        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;


    }
}
