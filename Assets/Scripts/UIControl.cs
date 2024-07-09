using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private EbonarAte�Etme ebonarAte�Etme;
    
    public GameObject _yetenekGeli�tirmeUI;
    public TextMeshProUGUI yetenekGeli�tirmeText;
    public TextMeshProUGUI sald�r�G�c�Text;
    public TextMeshProUGUI Z�rhText;
    public TextMeshProUGUI CanText;
    int sald�r�G�c�;
    int z�rh;
    int can;
    bool _yetenekGeli�tirme;
    public GameObject gameOver;

    public Image originalHealthBar;
    public Sprite[] _healthBar;

    public Image enemy1HealthBar;
    public Image enemy2HealthBar;
    //public Image enemy2HealthBar1;
    //public Image enemy2HealthBar2;
    public float smoothspeed = 3f;



    public Button Sald�r�G�c�Button;
    public Button Z�rhButton;
    public Button CanButton;


    int yetenekGeli�tirmeXPSald�r� = 0;
    int yetenekGeli�tirmeXPCan = 0;
    int yetenekGeli�tirmeXPZ�rh = 0;

    Sounds sounds;
    Yarat�k1CanHasar yarat�k1CanHasar;
    Yarat�k2CanHasar yarat�k2CanHasar;
    //Yarat�k3CanHasar yarat�k3CanHasar;
    //Yarat�k4CanHasar yarat�k4CanHasar;

    private void Start()
    {
        
        playerMovement = FindAnyObjectByType<PlayerMovement>();
        ebonarAte�Etme = FindAnyObjectByType<EbonarAte�Etme>();
        sounds = FindAnyObjectByType<Sounds>();
        yarat�k1CanHasar = FindAnyObjectByType<Yarat�k1CanHasar>();
        yarat�k2CanHasar = FindAnyObjectByType<Yarat�k2CanHasar>();
        //yarat�k3CanHasar =  FindAnyObjectByType<Yarat�k3CanHasar>();
        //yarat�k4CanHasar =  FindAnyObjectByType<Yarat�k4CanHasar>();
        Time.timeScale = 1;
        _yetenekGeli�tirmeUI.SetActive(false);

        if (playerMovement.yetenekGeli�tirme >= 2 * 100)
            Sald�r�G�c�Button.interactable = true;
        CanButton.interactable = true;

        if (playerMovement.yetenekGeli�tirme >= 4 * 100)
            Z�rhButton.interactable = true;



        EbonarAte�Etme._ebonarHit = PlayerPrefs.GetInt(nameof(EbonarAte�Etme._ebonarHit), 10);
        PlayerMovement._enemyHit = PlayerPrefs.GetInt(nameof(PlayerMovement._enemyHit), 20);
        playerMovement.ebonarCan = PlayerPrefs.GetInt(nameof(playerMovement.ebonarCan), 100);

        yetenekGeli�tirmeXPSald�r� = PlayerPrefs.GetInt(nameof(yetenekGeli�tirmeXPSald�r�), 0);
        yetenekGeli�tirmeXPZ�rh = PlayerPrefs.GetInt(nameof(yetenekGeli�tirmeXPZ�rh), 0);
        yetenekGeli�tirmeXPCan = PlayerPrefs.GetInt(nameof(yetenekGeli�tirmeXPCan), 0);

        Debug.Log(yetenekGeli�tirmeXPSald�r�);
        Debug.Log(yetenekGeli�tirmeXPZ�rh);
        Debug.Log(yetenekGeli�tirmeXPCan);
    }



    public void Sald�r�G�c�()
    {
        EbonarAte�Etme._ebonarHit += 3;
        playerMovement.yetenekGeli�tirme -= 2 * 150;
        yetenekGeli�tirmeXPSald�r� += 100;
        sald�r�G�c� = EbonarAte�Etme._ebonarHit;
        
        sounds.skillTalent.Play();
    }
    public void Z�rh()
    {
        PlayerMovement._enemyHit -= 5;
        playerMovement.yetenekGeli�tirme -= 450;
        yetenekGeli�tirmeXPZ�rh += 100;
        z�rh = PlayerMovement._enemyHit;
        
        sounds.skillTalent.Play();
    }
    public void Can()
    {
        playerMovement.ebonarCan += 4;
        playerMovement.yetenekGeli�tirme -= 2 * 150;
        yetenekGeli�tirmeXPCan += 100;
        can = playerMovement.ebonarCan;
       
        sounds.skillTalent.Play();
    }
    public void Veri() 
    {
        PlayerPrefs.SetInt(nameof(EbonarAte�Etme._ebonarHit), EbonarAte�Etme._ebonarHit);
        PlayerPrefs.SetInt(nameof(PlayerMovement._enemyHit), PlayerMovement._enemyHit);
        PlayerPrefs.SetInt(nameof(playerMovement.ebonarCan), playerMovement.ebonarCan);
        PlayerPrefs.SetInt(nameof(yetenekGeli�tirmeXPCan), yetenekGeli�tirmeXPCan);
        PlayerPrefs.SetInt(nameof(yetenekGeli�tirmeXPSald�r�), yetenekGeli�tirmeXPSald�r�);
        PlayerPrefs.SetInt(nameof(yetenekGeli�tirmeXPZ�rh), yetenekGeli�tirmeXPZ�rh);
    }
    public void YetenekGeli�tir�Ex�t()
    {
        _yetenekGeli�tirme = !_yetenekGeli�tirme;
        _yetenekGeli�tirmeUI.SetActive(_yetenekGeli�tirme);
    }




    public void TekrarDene()
    {
        SceneManager.LoadScene(playerMovement.sceneIndex);
        playerMovement.ebonarCan =50;
        
    }
    public void AnaEkranaD�n()
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.Save();
    }
    void Update()
    {
        if (yarat�k1CanHasar.yarat�k != null)
        {
            enemy1HealthBar.fillAmount = (float)yarat�k1CanHasar.yarat�kCan / 100;
        }
        if (yarat�k2CanHasar.yarat�k2 != null)
        {
            enemy2HealthBar.fillAmount = (float)yarat�k2CanHasar.yarat�k2Can / 100;
        }
        //if (yarat�k3CanHasar.yarat�k2 != null)
        //{
        //    enemy2HealthBar1.fillAmount = (float)yarat�k3CanHasar.yarat�k2Can / 100;
        //}
        //if (yarat�k4CanHasar.yarat�k2 != null)
        //{
        //    enemy2HealthBar2.fillAmount = (float)yarat�k4CanHasar.yarat�k2Can / 100;
        //}






        if (playerMovement.ebonarCan <= 0)
            originalHealthBar.sprite = _healthBar[0];


        if (playerMovement.ebonarCan > 15 && playerMovement.ebonarCan <= 30)
            originalHealthBar.sprite = _healthBar[1];

        if (playerMovement.ebonarCan > 30 && playerMovement.ebonarCan <= 45)
            originalHealthBar.sprite = _healthBar[2];

        if (playerMovement.ebonarCan > 45 && playerMovement.ebonarCan <= 60)
            originalHealthBar.sprite = _healthBar[3];

        if (playerMovement.ebonarCan > 60 && playerMovement.ebonarCan <= 75)
            originalHealthBar.sprite = _healthBar[4];

        sald�r�G�c�Text.text = sald�r�G�c�.ToString();
        CanText.text = can.ToString();
        Z�rhText.text = z�rh.ToString();







        if (Input.GetKeyDown(KeyCode.Tab))
        {

            _yetenekGeli�tirme = !_yetenekGeli�tirme;
            _yetenekGeli�tirmeUI.SetActive(_yetenekGeli�tirme);

        }

        if (gameOver.activeSelf == true)
        {
            Time.timeScale = 0;
            sounds.gameOverSound.Play();
        }





        else if (!_yetenekGeli�tirme)
        {
            Time.timeScale = 1;
            ebonarAte�Etme.mermiC�k�sYeri.GetComponent<EbonarAte�Etme>().enabled = true;

        }
        else if (_yetenekGeli�tirme)
        {
            Time.timeScale = 0;
            ebonarAte�Etme.mermiC�k�sYeri.GetComponent<EbonarAte�Etme>().enabled = false;

        }


        sald�r�G�c� = EbonarAte�Etme._ebonarHit;
        z�rh = PlayerMovement._enemyHit;
        can = playerMovement.ebonarCan;





        if (playerMovement.yetenekGeli�tirme >= 2 * 100)
            Sald�r�G�c�Button.interactable = true;
        CanButton.interactable = true;

        if (playerMovement.yetenekGeli�tirme >= 4 * 100)
            Z�rhButton.interactable = true;


        if (playerMovement.yetenekGeli�tirme <= 0 * 100 || yetenekGeli�tirmeXPSald�r� == 5 * 100 || playerMovement.yetenekGeli�tirme < 2 * 100 || EbonarAte�Etme._ebonarHit == 25)
        {
            Sald�r�G�c�Button.interactable = false;

        }
        if (playerMovement.yetenekGeli�tirme <= 0 * 100 || yetenekGeli�tirmeXPCan == 5 * 100 || playerMovement.yetenekGeli�tirme < 2 * 100 || playerMovement.ebonarCan == 120)
        {
            CanButton.interactable = false;

        }
        if (playerMovement.yetenekGeli�tirme <= 0 * 100 || yetenekGeli�tirmeXPZ�rh == 2 * 100 || playerMovement.yetenekGeli�tirme < 4 * 100 || PlayerMovement._enemyHit == 10)
        {
            Z�rhButton.interactable = false;

        }
        PlayerPrefs.Save();
    }


}
