using System.Collections;
using System.Collections.Generic;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine;

public class Logros : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {

        GooglePlayGames.PlayGamesPlatform.Activate();

    }
	
	// Update is called once per frame
	public void PrimerLogro ()
    {
        if (!Social.localUser.authenticated)
        {
            // authenticate user:
            Social.localUser.Authenticate((bool success) =>
            {
                if (success)
                {
                    Social.ReportProgress(GPGSIds.achievement_welcome_aboard, 100.0f, (bool success2) =>
                    {
                        // handle success or failure
                    });
                }
            });
        }
        // unlock achievement (achievement ID "Cfjewijawiu_QA")
    }
}
