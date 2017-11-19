using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

	public GameObject playEffect;
	public GameObject collectionEffect;
	public GameObject optionsEffect;
	public GameObject settingsButton;
	public GameObject playButton;
	public GameObject collectionButton;
	public GameObject optionsBackground;
	public GameObject settingsBackgroundEffect;
    public Transform transform1;
    public Transform transform2;
    public Transform transform3;
    public Transform transform4;
    public float settingsSpeed;
    float startTime;
    bool open = false;
	bool close = false;
	bool opening = false;
    Vector3 defaultVector1;
    Vector3 defaultVector2;

    void Start()
    {
        defaultVector1 = transform1.position;
        defaultVector2 = transform3.position;
    }

    public void play() {
		playEffect.GetComponent<Image>().color = Color.white; 
	}

    public void collectionDown()
    {
        collectionEffect.GetComponent<Image>().color = Color.white;
    }

    public void collection() {

        SceneManager.LoadScene("Collection");
    }

	public void options() {
		if (!opening) {
            opening = true;
            optionsEffect.SetActive (true);
			playButton.SetActive (false);
			collectionButton.SetActive (false);
            startTime = Time.timeSinceLevelLoad;
            close = false;
			open = true;
        } else {
            opening = false;
            optionsEffect.SetActive (false);
			playButton.SetActive (true);
			collectionButton.SetActive (true);
			optionsBackground.SetActive(false);
			settingsBackgroundEffect.SetActive (false);
            startTime = Time.timeSinceLevelLoad;
            open = false;
			close = true;
			
		}
	}

	void Update() {
        if (settingsButton.transform.position == transform2.position)
        {
            if (opening)
            {
                settingsBackgroundEffect.SetActive(true);
                optionsBackground.SetActive(true);
            }
            open = false;
        }
        if (settingsButton.transform.position == defaultVector1)
        {
            close = false;
        }
        if (open)
        {
            settingsButton.transform.position = Vector3.Lerp(transform1.position, transform2.position, (Time.timeSinceLevelLoad - startTime) * settingsSpeed);
            optionsEffect.transform.position = Vector3.Lerp(transform3.position, transform4.position, (Time.timeSinceLevelLoad - startTime) * settingsSpeed);
        }
        if (close)
        {
            settingsButton.transform.position = Vector3.Lerp(transform1.position, defaultVector1, (Time.timeSinceLevelLoad - startTime) * settingsSpeed);
            optionsEffect.transform.position = Vector3.Lerp(transform3.position, defaultVector2, (Time.timeSinceLevelLoad - startTime) * settingsSpeed);
        }
        
    }
}
