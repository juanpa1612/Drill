using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameObject activeWindow;

    public void OpenWindow (GameObject windowToShow)
    {
        windowToShow.GetComponent<Animator>().SetBool("Active", true);
        activeWindow = windowToShow;
    }

    public void CloseWindow (GameObject windowToClose)
    {
        if (activeWindow)
        {
            windowToClose = activeWindow;
        }
        windowToClose.GetComponent<Animator>().SetBool("Active", false);
    }
    public void CloseWindow()
    {
        if (activeWindow != null)
        {
            activeWindow.GetComponent<Animator>().SetBool("Active", false);
        }
    }

    #region Singleton
    private static UIManager instance;
    private UIManager() { }

    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("UIManager.Instance es nula pero se esta intentando accederla");
            }

            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (this != instance)
                DestroyImmediate(this.gameObject);
        }
    }
    #endregion
}
