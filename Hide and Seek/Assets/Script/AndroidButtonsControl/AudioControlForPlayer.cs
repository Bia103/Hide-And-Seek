using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControlForPlayer : MonoBehaviour
{

    public bool boolangiu = true;
    //public AudioListener audioListener;
    // Start is called before the first frame update
    public void MuteToggle(bool muted) {
        
        if (boolangiu) {
            AudioListener.volume = 0;
            boolangiu = false;
        } else {
            AudioListener.volume = 1;
            boolangiu = true;
        }
    }

}
