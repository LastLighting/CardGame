using System.Collections;
using System.Collections.Generic;
using Firebase.Auth;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SingUpButton : MonoBehaviour {
	
	private FirebaseAuth firebaseAuth;
	
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
		singUp(emailInput.text, passwordInput.text);
	}
	
	public void singUp(string email, string password)
	{
		if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
		{
			//Error handling
			return;
		}

		firebaseAuth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
		{
			if (task.IsCanceled)
			{
				Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
				return;
			}
			if (task.IsFaulted)
			{
				Debug.LogError("CreateUserWithEmailAndPasswordAsync error: " + task.Exception);
				/*if (task.Exception.InnerExceptions.Count > 0)
					UpdateErrorMessage(task.Exception.InnerExceptions[0].Message);
				return;*/
			}

			FirebaseUser newUser = task.Result; // Firebase user has been created.
			Debug.LogFormat("Firebase user created successfully: {0} ({1})", newUser.DisplayName, newUser.UserId);
			/*UpdateErrorMessage("Signup Success");*/
		});
	}
}
