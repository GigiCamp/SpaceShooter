using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    public CanvasGroup pausePanel;
    private bool isPaused;

    public AudioMixer mixer;

    // Start is called before the first frame update
    void Start()
    {
        pausePanel.alpha = 0;
        isPaused = false;
        pausePanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
        {
            pausePanel.gameObject.SetActive(true);
            pausePanel.GetComponent<FadeScript>().Fade(true);
            Time.timeScale = 0;
            isPaused = true;
            mixer.SetFloat("MasterVolume", -80);
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isPaused == true)
        {
            pausePanel.GetComponent<Animator>().SetBool("Exit", true);
            pausePanel.GetComponent<FadeScript>().Fade(false);
            Time.timeScale = 1;
            isPaused = false;
            mixer.SetFloat("MasterVolume", 0);
        }
    }
}
