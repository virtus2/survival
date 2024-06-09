using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{

    // 모든 메인메뉴 인터페이스들 들어있는 오브젝트
    public GameObject menuUI;
    public GameObject mainMenu;
    public GameObject joystick;
    // 상점
    public GameObject shopPanel;
    // 설정
    public GameObject settingMenu;
    #region 인게임 인터페이스들
    // 모든 인게임 인터페이스들 들어있는 오브젝트
    public GameObject ingameUI;
    public GameObject lobbyUI;
    public GameObject dungeonUI;
    public GameObject pausePanel;
    public GameObject pauseButton;
    public GameObject expBar;
    // 던전 타이머
    public Timer timer;
    // 던전 Supply 고르는 창
    public GameObject supplyPanel;
    #endregion

    public static UIController Instance;

    // Start is called before the first frame update
    private void Awake()
    {
        Screen.SetResolution(Screen.width, (Screen.width * 16) / 9, true);
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Instance = this;

    }

    private void Start()
    {
        ingameUI.SetActive(false);
        menuUI.SetActive(true);
    }

    #region 일시정지 관련 인터페이스들
    public void SetPausePanelActive(bool activate)
    {
        if (activate)
        {
            pausePanel.SetActive(true);
            pauseButton.SetActive(false);
            expBar.SetActive(false);
            joystick.SetActive(false);
        }
        else
        {
            pausePanel.SetActive(false);
            pauseButton.SetActive(true);
            expBar.SetActive(true);
            joystick.SetActive(true);
        }
    }
    public void OnPauseButtonClicked()
    {
        SetPausePanelActive(true);
        GameManager.Instance.PauseGame(true);
    }
    public void OnResumeButtonClicked()
    {
        SetPausePanelActive(false);
        GameManager.Instance.PauseGame(false);
    }
    #endregion
    public void OnSettingButtonClickedInGame()
    {
        ingameUI.SetActive(false);
        settingMenu.SetActive(true);
    }
    public void SetMenuUIActive(bool active)
    {
        menuUI.SetActive(active);
    }

    public void SetIngameUIActive(bool active)
    {
        ingameUI.SetActive(active);
    }
    #region 메인메뉴 인터페이스들
    public void OnStartButtonClicked()
    {
        menuUI.SetActive(false);
        ingameUI.SetActive(true);
        GameManager.Instance.StartGame();
    }

    public void OnSettingButtonClickedInMenu()
    {
        mainMenu.SetActive(false);
        settingMenu.SetActive(true);
    }

    public void OnReturnButtonClicked()
    {
        settingMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    #endregion

    public void SetLobbyUIActive(bool active)
    {
        lobbyUI.SetActive(active);
    }

    public void SetDungeonUIActive(bool active)
    {
        dungeonUI.SetActive(active);
    }
    #region 던전 타이머 인터페이스
    public void StopTimer()
    {
        timer.StopTimer();
    }

    public void StartTimer()
    {
        timer.StartTimer();
    }
    #endregion
    public void SetSupplyUIActive(bool active)
    {
        supplyPanel.SetActive(active);
    }

    public void SetSupplyUI(List<Item> item)
    {
        SupplyPanel panel = supplyPanel.GetComponent<SupplyPanel>();
        panel.SetButtonUI(item);
    }

    public void OnSupplyButtonClicked()
    {
        SetSupplyUIActive(false);
    }


    
}
