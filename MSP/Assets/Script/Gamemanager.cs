using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{

    public GameObject overset;

    public Transform[] spawnPoint;
    public GameObject Star;
    public GameObject Poop;

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

        GameObject star = Instantiate(Star, spawnPoint[Ranpoint].position, spawnPoint[Ranpoint].rotation);
        pos = spawnPoint[Ranpoint];
        Rigidbody2D rigid = star.GetComponent<Rigidbody2D>();
    }

    public void Makepoop()
    {
        GameObject poop = Instantiate(Poop, pos.position, pos.rotation);
        Makestar();
    }
}
