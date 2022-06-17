using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayFabManager : MonoBehaviour
{

    public TMP_Text messageText;
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;

    public void RegisterButton() {
        var request = new RegisterPlayFabUserRequest {
            Email = emailInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSucces, OnError);
    }

    void OnRegisterSucces(RegisterPlayFabUserResult result) {
        messageText.text = "Registered and logged in!";
    }


    // Update is called once per frame
    public void LoginButton()
    {
        var request = new LoginWithEmailAddressRequest{
            Email = emailInput.text,
            Password = passwordInput.text,
        };

        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSucces, OnError);
    }

    void OnLoginSucces(LoginResult result){
        messageText.text  = "Succesful login";
        changeScene();
    }

     void OnError(PlayFabError error){
        Debug.Log("Error while logging");
        Debug.Log(error.GenerateErrorReport());
    }

    void changeScene(){
        SceneManager.LoadScene("SampleScene");
    }
}
