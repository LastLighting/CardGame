using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour {

    public void OnMouseDown()
    {
        gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;
    }

    public void OnMouseUp()
    {
        SceneManager.LoadScene(1);
    }
}
