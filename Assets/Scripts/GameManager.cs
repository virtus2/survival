using Lean.Localization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static bool GameIsPaused = false;

    public GameObject mainCamera;
    public GameObject inGameObjects;
    public GameObject lobbyGameObjects;
    public GameObject dungeonGameObjects;

    public ItemManager itemManager;
    public Supply supply;
    public ExpBar expBar;
    public Player lobbyPlayer;
    public Player dungeonPlayer;
    public float playerMaxExp;
    public float playerCurrentExp;
    public int playerLevel;

    public float time;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        playerCurrentExp = 0f;
        playerMaxExp = 1f;
        playerLevel = 0;
        time = 0f;

        SetLobbyObjectsActive(false);
        SetDungeonObjectsActive(false);
    }

    public void OnMonsterDied(float exp)
    {
        
    }
    
    public void StartGame()
    {
        inGameObjects.SetActive(true);
        mainCamera.GetComponent<CameraFollow>().target = lobbyPlayer.transform;
        // 로비
        SetLobbyObjectsActive(true);
        UIController.Instance.SetLobbyUIActive(true);
        // 던전
        SetDungeonObjectsActive(false);
        UIController.Instance.SetDungeonUIActive(false);
    }

    public void StartDungeon()
    {
        mainCamera.GetComponent<CameraFollow>().target = dungeonPlayer.transform;
        // 로비
        SetLobbyObjectsActive(false);
        UIController.Instance.SetLobbyUIActive(false);
        // 던전
        SetDungeonObjectsActive(true);
        UIController.Instance.SetDungeonUIActive(true);
        // 타이머
        UIController.Instance.StartTimer();
        // 보급아이템
        InvokeRepeating("DropSupply", 60f, 60f);

        dungeonPlayer.GetComponent<Player>().EnterDungeon();
    }

    public void GameOver()
    {
        UIController.Instance.StopTimer();
        CancelInvoke("DropSupply");
    }

    public void ExitDungeon()
    {
        mainCamera.GetComponent<CameraFollow>().target = lobbyPlayer.transform;
        // 로비
        SetLobbyObjectsActive(true);
        UIController.Instance.SetLobbyUIActive(true);
        // 던전
        SetDungeonObjectsActive(false);
        UIController.Instance.SetDungeonUIActive(false);
    }
    public void SetLobbyObjectsActive(bool active)
    {
        lobbyGameObjects.SetActive(active);

    }
    public void SetDungeonObjectsActive(bool active)
    {
        dungeonGameObjects.SetActive(active);
    }

    
    public void DropSupply()
    {
        Vector2 pos = dungeonPlayer.transform.position + Random.onUnitSphere * 5f;
        supply.DropSupply(pos);
    }

    public void ChoiceSupply()
    {
        List<Item> item = itemManager.GetUnusedRandomItems(3);
        UIController.Instance.SetSupplyUIActive(true);
        UIController.Instance.SetSupplyUI(item);
        PauseGame(true);
    }

    public void OnSupplyChoose(Item item)
    {
        itemManager.SetUsedFlag(item);
        dungeonPlayer.GetComponent<Player>().AddItem(item);
        PauseGame(false);
    }

    public void PauseGame(bool pause)
    {
        if (pause)
        {
            GameIsPaused = true;
            Time.timeScale = 0f;
        }
        else
        {
            GameIsPaused = false;
            Time.timeScale = 1f;
        }
    }
    // 조이스틱 터치해서 상호작용할때
    public void InteractWith(GameObject go)
    {
        if (go.name.Equals("Portal"))
        {
            Debug.Log("Interact with Portal");
            StartDungeon();
        } 
        else if (go.name.Equals("Guide"))
        {
            Debug.Log("Interact with Guide");
        }
    }

    public Player GetDungeonPlayer()
    {
        return dungeonPlayer;
    }
}
