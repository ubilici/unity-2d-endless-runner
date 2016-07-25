using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;

    private bool gameStarted;
    private TimeManager timeManager;
    private GameObject player;
    private GameObject floor;
    private Spawner spawner;

    void Awake()
    {
        floor = GameObject.Find("Foreground");
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        timeManager = GetComponent<TimeManager>();
    }

    void Start()
    {
        var floorHeight = floor.transform.localScale.y;

        var pos = floor.transform.position;
        pos.x = 0;
        pos.y = -((Screen.height / PixelPerfectCamera.pixelToUnits) / 2) + (floorHeight / 2);
        floor.transform.position = pos;

        spawner.active = false;

        Time.timeScale = 0;
    }

    void Update()
    {
        if (!gameStarted && Time.timeScale == 0)
        {
            if (Input.anyKeyDown)
            {
                timeManager.ManipulateTime(1, 1f);
                ResetGame();
            }
        }
    }

    void OnPlayerKilled()
    {
        spawner.active = false;

        var playerDestroyScript = player.GetComponent<DestroyOffscreen>();
        playerDestroyScript.DestroyCallback -= OnPlayerKilled;

        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        timeManager.ManipulateTime(0, 5.5f);

        gameStarted = false;
    }

    void ResetGame()
    {
        spawner.active = true;

        player = GameObjectUtil.Instantiate(playerPrefab, new Vector3(0, (Screen.height / PixelPerfectCamera.pixelToUnits) / 2 + 100, 0));

        var playerDestroyScript = player.GetComponent<DestroyOffscreen>();
        playerDestroyScript.DestroyCallback += OnPlayerKilled;

        gameStarted = true;
    }
}
