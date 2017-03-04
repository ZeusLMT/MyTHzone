using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartWindow : GenericWindow {
    public Text welcomeText;
	public Button continueButton;
    public Toggle Sound;

	public override void Open ()
	{
		var canContinue = true;

		continueButton.gameObject.SetActive (canContinue);

		if (continueButton.gameObject.activeSelf) {
			firstSelected = continueButton.gameObject;
		}

        welcomeText.text = "Welcome to MYTHzone, " + KeyboardWindow.playerName + "!";

        base.Open ();
	}

	public void NewGame(){
        Manager.Open(2);
	}

	public void Continue(){
		Debug.Log ("Continue Pressed");
	}

	public void Exit(){
		Debug.Log ("Exit Pressed");
	}
    public void SoundToggle()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (Sound.isOn) Sound.isOn = false;
            else Sound.isOn = true;
        }
    }

    public void SoundOnOff()
    {
        if (Sound.isOn) AudioListener.volume = 1;
        else if (!Sound.isOn) AudioListener.volume = 0;
    }

    
    void Update()
    {
        SoundToggle();
    }
	
}
