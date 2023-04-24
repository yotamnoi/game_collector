using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class player_manager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LogInRot());
    }

    IEnumerator LogInRot()
    {
        bool done = false;
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                Debug.Log("player logged in");
                PlayerPrefs.SetString("PlayerID",response.player_id.ToString());
                done = true;
            }
            else
            {
                Debug.Log("could not start session");
                done = true;    
            }
        });
        yield return new WaitWhile(() => done == false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
