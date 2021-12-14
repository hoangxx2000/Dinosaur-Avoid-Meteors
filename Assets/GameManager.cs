using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Dino playerPrefab;
    public Stone[] stoneFrefab;
    public float spawnTime;
    int score;
    bool isGameover;
    bool isGamebegin;
    Dino dinoClone;

    public int Score { get => score; set => score = value; }
    public bool IsGameover { get => isGameover; set => isGameover = value; }
    public bool IsGamebegin { get => isGamebegin; set => isGamebegin = value; }
    public void PlayGame()
    {
        if (playerPrefab)
            dinoClone = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        StartCoroutine(Spawn());
        GameGUIManager.Ins.ShowGameGui(true);
    }
    public override void Start()
    {
        GameGUIManager.Ins.ShowGameGui(false);
    }
    public override void Awake()
    {
        MakeSingleton(false);
    }
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(3f);
        isGamebegin = true;
        if (stoneFrefab != null && stoneFrefab.Length > 0)
        {
            while (!isGameover)
            {
                int randIxd = Random.Range(0, stoneFrefab.Length);
                if (stoneFrefab[randIxd] != null)
                {
                    Instantiate(stoneFrefab[randIxd], new Vector3(dinoClone.transform.position.x, Random.Range(6f, 9f),0f),Quaternion.identity);
                }
                yield return new WaitForSeconds(spawnTime);
            }
        }
        yield return null;
    }
}
