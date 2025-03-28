using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Elements")]
    [SerializeField] private GameObject menuPanel;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayButtonPressed()
    {
        GameManager.instance.SetGameState(GameManager.GameState.Game);
       

        menuPanel.SetActive(false);
    }
}
