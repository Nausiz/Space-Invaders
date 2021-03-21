using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
	[SerializeField] Canvas settingsMenu;
	[SerializeField] Canvas instructionMenu1;
	[SerializeField] Canvas instructionMenu2;

	[SerializeField] Button btnStart;
	[SerializeField] Button btnSettings;
	[SerializeField] Button btnInstruction;
	[SerializeField] Button btnExit;
	[SerializeField] Button btnNext;
	[SerializeField] Button btnBackInstuction;

	[SerializeField] GameObject music;

	[SerializeField] AudioSource buttonEffect;

	private Canvas menuUI;

	void Start()
	{
		menuUI = (Canvas)GetComponent<Canvas>();

		settingsMenu = settingsMenu.GetComponent<Canvas>();
		instructionMenu1 = instructionMenu1.GetComponent<Canvas>();
		instructionMenu2 = instructionMenu2.GetComponent<Canvas>();

		btnStart = btnStart.GetComponent<Button>();
		btnExit = btnExit.GetComponent<Button>();
		btnSettings = btnSettings.GetComponent<Button>();
		btnInstruction = btnInstruction.GetComponent<Button>();
		btnNext = btnNext.GetComponent<Button>();
		btnBackInstuction = btnBackInstuction.GetComponent<Button>();

		settingsMenu.enabled = false;
		instructionMenu1.enabled = false;
		instructionMenu2.enabled = false;

		Cursor.visible = menuUI.enabled;
		Cursor.lockState = CursorLockMode.Confined;

		buttonEffect.Stop();

		score.scorePoints = 0;

	}


	void Update()
	{
		Cursor.visible = menuUI.enabled;

		if (menuUI.enabled)
		{
			Cursor.lockState = CursorLockMode.Confined;
			Cursor.visible = true;
		}
	}



	public void ButtonStart()
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;

		menuUI.enabled = false;
		buttonEffect.Play();
		DontDestroyOnLoad(music);
		SceneManager.LoadScene("Game");
	}

	public void ButtonkExit()
	{
		buttonEffect.Play();
		Application.Quit();
	}

	public void ButtonSettings()
	{
		buttonEffect.Play();
		settingsMenu.enabled = true;
		instructionMenu1.enabled = false;
		instructionMenu2.enabled = false;

	}

	public void ButtonInstruction()
	{
		buttonEffect.Play();
		instructionMenu1.enabled = true;
		instructionMenu2.enabled = false;
		settingsMenu.enabled = false;
		
	}

	public void ButtonNext()
	{
		buttonEffect.Play();
		instructionMenu1.enabled = false;
		instructionMenu2.enabled = true;
		settingsMenu.enabled = false;
	}

	public void ButtonBackInstruction()
	{
		buttonEffect.Play();
		instructionMenu1.enabled = true;
		instructionMenu2.enabled = false;
		settingsMenu.enabled = false;
	}


	public void ButtonBack()
	{
		buttonEffect.Play();
		settingsMenu.enabled = false;
		instructionMenu1.enabled = false;
		instructionMenu2.enabled = false;
		menuUI.enabled = true;

	}
}
