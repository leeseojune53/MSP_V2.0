using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{

    public GameObject overset;

    public Transform[] spawnPoint;
    public GameObject Star;
    public GameObject Poop;

    public Text scoreText;

    public bool[,] ispoop = new bool[16,8];

    Transform pos;
    
    public void GameOver()
    {
        overset.SetActive(true);
    }

    public void GameRetry()
    {
        SceneManager.LoadScene(0);
    }

    public void Makestar()
    {
        int Ranpoint = Random.Range(0, 128);
        int x;
        int y;
        x = Mathf.CeilToInt(spawnPoint[Ranpoint].position.x) + 7;
        y = Mathf.CeilToInt(spawnPoint[Ranpoint].position.y) + 3;
        while (ispoop[x,y])
        {
            Ranpoint = Random.Range(0, 128);
            x = Mathf.CeilToInt(spawnPoint[Ranpoint].position.x) + 7;
            y = Mathf.CeilToInt(spawnPoint[Ranpoint].position.y) + 3;
        }
        GameObject star = Instantiate(Star, spawnPoint[Ranpoint].position, spawnPoint[Ranpoint].rotation);
        pos = spawnPoint[Ranpoint];
        ispoop[x, y] = true;
        Rigidbody2D rigid = star.GetComponent<Rigidbody2D>();//is poop함수를 만듦
    }

    public void Makepoop()
    {
        GameObject poop = Instantiate(Poop, pos.position, pos.rotation);
        Makestar();
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
    
}
