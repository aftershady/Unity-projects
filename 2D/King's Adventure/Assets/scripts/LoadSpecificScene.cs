using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadSpecificScene : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip doorSound;
    public string sceneName;
    public Animator fadeSystem;
    public bool creditsArePlaying = false;
    public GameObject escapeButton;
    public bool isEscapeButtonActive = false;
    public GameObject Creditscanvas;

    public GameObject credits;

    private void Awake()
    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }

    void Start()
    {
        if(PlayerPrefs.GetInt("doorOpened") == 1)
        {
            LoadAndSaveData.instance.LoadData();
            PlayerPrefs.SetInt("doorOpened", 0);
        }
    }

    void Update()
    {
        if (creditsArePlaying)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TimerDisplay.instance.Continue();
                SceneManager.LoadScene("Main Menu");
            }
        }

        if (creditsArePlaying)
        {
            if (Input.anyKeyDown)
            {
                if(!isEscapeButtonActive)
                {
                    StartCoroutine(ActivateEscapeButton());
                }
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    TimerDisplay.instance.Continue();
                    SceneManager.LoadScene("Main Menu");
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if the player tag enter in coin
        if(collision.CompareTag("Player"))
        {
            LoadAndSaveData.instance.SaveData();
            PlayerPrefs.SetInt("doorOpened", 1);
            if(sceneName == "Credits")
            {
                collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                PlayCredits();
                return;
            }
            collision.GetComponent<PlayerMovement>().enabled = false;
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            StartCoroutine(loadNextScene(collision));
        }
    }

    public IEnumerator loadNextScene(Collider2D collision)
    {
        PlayerPrefs.SetInt("LevelReached", CurrentSceneManager.instance.levelToUnlock);
        audioSource.PlayOneShot(doorSound);
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        collision.GetComponent<PlayerMovement>().enabled = true;
        SceneManager.LoadScene(sceneName);
    }

    public void PlayCredits()
    {
        Creditscanvas.SetActive(true);
        StartCoroutine(waitForCredits());
        PlayerMovement.instance.enabled = false;
        credits.GetComponent<Animator>().SetTrigger("StartEndCredits");
        creditsArePlaying = true;

    }

    public IEnumerator waitForCredits()
    {
        yield return new WaitForSeconds(63);
        TimerDisplay.instance.Continue();
        SceneManager.LoadScene("Main Menu");
    }

    public IEnumerator ActivateEscapeButton()
    {
        isEscapeButtonActive = true;
        escapeButton.SetActive(true);
        yield return new WaitForSeconds(8f);
        escapeButton.SetActive(false);
        isEscapeButtonActive = false;
    }


}
