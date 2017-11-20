using System.Collections;
using System.Collections.Generic;
using Firebase.Auth;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginButton : MonoBehaviour {
    
    public FirebaseAuth firebaseAuth;

    public InputField emailInput;
    public InputField passwordInput;
 
    void Start () {
        firebaseAuth = FirebaseAuth.DefaultInstance;
    }

    public void OnMouseDown()
    {
        gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;
    }

    public void OnMouseUp()
    {
        login(emailInput.text, passwordInput.text);
    }
    
    public void login(string email, string password)
    {
        firebaseAuth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled || task.IsFaulted)
            {
                return;
            }
            else
            {
                FirebaseUser user = task.Result;
                PlayerPrefs.SetString("LoginUser", user != null ? user.Email : "Unknown");
                SceneManager.LoadScene("MainMenu");
            }
        });
    }
}
