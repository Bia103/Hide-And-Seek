using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePlayer : MonoBehaviour
{
    public GameObject player;

    public void onPlayerInstantiate() {
        Instantiate(player);
    }

}
