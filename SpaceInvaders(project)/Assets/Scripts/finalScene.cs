using UnityEngine;
using UnityEngine.SceneManagement;

public class finalScene : MonoBehaviour
{
    [SerializeField] Canvas winCanvas;
    [SerializeField] Canvas loseCanvas;
    [SerializeField] Canvas hud;
    [SerializeField] Canvas pauseCanvas;

    private Canvas canvasScript;

    [SerializeField] GameObject game;
    [SerializeField] GameObject aliens;

    [SerializeField] AudioSource buttonEffect;
    [SerializeField] AudioSource pause;

    void Start()
    {
        canvasScript = (Canvas)GetComponent<Canvas>();

        winCanvas = winCanvas.GetComponent<Canvas>();
        loseCanvas = loseCanvas.GetComponent<Canvas>();
        hud = hud.GetComponent<Canvas>();

        winCanvas.enabled = false;
        loseCanvas.enabled = false;
        pauseCanvas.enabled = false;
        hud.enabled = true;

        buttonEffect.Stop();
        pause.Stop();

        Time.timeScale = 1;
    }

    
    void Update()
    {
        if (enemyShotScript.lost)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            loseCanvas.enabled = true;
            winCanvas.enabled = false;
            hud.enabled = false;
            game.SetActive(false);
        }
        else if (aliens.GetComponentInChildren<Rigidbody2D>() == null)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            winCanvas.enabled = true;
            loseCanvas.enabled = false;
            hud.enabled = false;
            game.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) &&  game.activeSelf)
        {
            pause.Play();
            if (!pauseCanvas.enabled)
            {
                Time.timeScale = 0;
                pauseCanvas.enabled = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else if (pauseCanvas.enabled)
            {
                Time.timeScale = 1;
                pauseCanvas.enabled = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }

        }

    }

    public void ButtonRestart()
    {
        winCanvas.enabled = false;
        buttonEffect.Play();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        Destroy(GameObject.FindGameObjectWithTag("Music"));
        enemyShotScript.lost = false;
        SceneManager.LoadScene("Main");
    }

    public void ButtonkExit()
    {
        buttonEffect.Play();
        Application.Quit();
    }
}
