using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField] private WarpEffectController warpEffectController;

    [SerializeField] private Transform catleScenePoint;
    [SerializeField] private Transform warpScenePoint;
    [SerializeField] private Transform cityScenePoint;
    [SerializeField] private GameObject catleObjects;
	[SerializeField] private GameObject startCanvas;
    [SerializeField] private GameObject warpObjects;
    [SerializeField] private GameObject cityObjects;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerController nonVRPlayerController;
    [SerializeField] private FireworkManager fireworkManager;
    [SerializeField] private ViveInputManager viveInputManager;

    [SerializeField] private GameObject directionalLight;
    [SerializeField] private GameObject catleDirectionalLight;
    [SerializeField] private Material nightBox;

    private PlayerController nowPlayerController;

    private bool isNight = false;
    private bool isLockMovement = true;
    private bool isLockMagic = true;

    private static GameManager instance;
    
    public static GameManager Instance
    {
        get
        {
            if (instance == null) Debug.LogError("GameManager is null");
            return instance;
        }
    }

    // Use this for initialization
    void Awake () {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        if(playerController.gameObject.activeInHierarchy)
        {
            nowPlayerController = playerController;
        }
        else if(nonVRPlayerController.gameObject.activeInHierarchy)
        {
            nowPlayerController = nonVRPlayerController;
        }

        if (cityScenePoint.gameObject.activeInHierarchy)
        {
            SettingCity();
        }
    }

    private void SettingPlayerPoint(Transform player, Transform point)
    {
        player.position = point.position;
        player.localRotation = point.localRotation;
    }

    public void SettingCatle()
    {
        IsLockMovement = false;
        IsLockMagic = false;
        catleObjects.SetActive(true);
        warpObjects.SetActive(false);
        cityObjects.SetActive(false);

        nowPlayerController.SettingWarp(catleScenePoint);
        SettingNight();
        fireworkManager.StartFirework();
    }

    public void SettingWarp(TeleportType teleportType)
    {
        IsLockMovement = true;
        IsLockMagic = true;
        catleObjects.SetActive(false);
        warpObjects.SetActive(true);
        cityObjects.SetActive(false);

        nowPlayerController.SettingWarp(warpScenePoint);
        warpEffectController.WarpSequence(teleportType);
    }

    public void SettingCity()
    {
        /*IsLockMovement = false;
        IsLockMagic = false;*/
        catleObjects.SetActive(false);
        warpObjects.SetActive(false);
        cityObjects.SetActive(true);

        nowPlayerController.SettingWarp(cityScenePoint);
    }

    public PlayerController GetPlayerController()
    {
        return nowPlayerController;
    }

    private void SettingNight()
    {
        RenderSettings.skybox = nightBox;
        directionalLight.SetActive(false);
        catleDirectionalLight.SetActive(false);
        isNight = true;
    }
	public void StartGame()
	{
		catleObjects.SetActive(true);
		startCanvas.SetActive(false);
	}
    public bool IsNight
    {
        get { return isNight; }
    }

    public bool IsLockMovement
    {
        get { return isLockMovement; }
        set { isLockMovement = value; }
    }

    public bool IsLockMagic
    {
        get { return isLockMagic; }
        set
        {
            isLockMagic = value;
        }
    }
}
