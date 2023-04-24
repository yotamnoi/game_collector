using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using System;
using TMPro;

public class leaderboard : MonoBehaviour

{
    public int leaderboardId = 6872;
    public TextMeshProUGUI playerNames;
    public TextMeshProUGUI scores;
    public GameObject leaderBoardUI;
    public TMP_InputField playerNameInput;



    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void showBoard()
    {
        leaderBoardUI.SetActive(true);
        StartCoroutine(FetchTopHighScore());
    }
    public void StopBoard()
    {
        leaderBoardUI.SetActive(false);
    }

    public void SetPlayerName()
    {
        LootLockerSDKManager.SetPlayerName(playerNameInput.text, (response) =>
        {
            if (response.success)
            {
                Debug.Log("changed name");
            }
            else
            {
                Debug.Log("could not change name" + response.Error);
            }
        });
    }

    public void submit(float gametime) {
        StartCoroutine(submitscore((int)Math.Floor(gametime)));
    }

    // Update is called once per frame
    public IEnumerator submitscore(int scoreToUpload)
    {
        bool done = false;
        string playerID = PlayerPrefs.GetString("PlayerID");
        LootLockerSDKManager.SubmitScore(playerID, scoreToUpload, leaderboardId,(response) =>
        {
            if (response.success)
            {
                Debug.Log("upload successfully");
                done = true;
            }
            else
            {
                Debug.Log("faild" + response.Error);
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }

    public IEnumerator FetchTopHighScore()
    {
        bool done = false;
        LootLockerSDKManager.GetScoreList(leaderboardId, 5, 0, (response) =>
        {
            if (response.success)
            {
                string tempPlayerNames = "Names\n";
                string tempPlayerScores = "time\n";

                LootLockerLeaderboardMember[] members = response.items;
                for (int i= 0; i < members.Length; i++)
                {
                    tempPlayerNames += members[i].rank + ". ";
                    if(members[i].player.name != "")
                    {
                        tempPlayerNames += members[i].player.name;
                    }
                    else
                    {
                        tempPlayerNames += members[i].player.id;
                    }
                    tempPlayerScores += members[i].score + "\n";
                    tempPlayerNames += "\n";
                }
                done = true;
                playerNames.text = tempPlayerNames;
                scores.text = tempPlayerScores;
            }
            else
            {
                Debug.Log("faild" + response.Error);
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }
}
