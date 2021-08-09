using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float velocidad = 2;
    public Renderer bg;
    public GameObject col1;
    public GameObject piedra1;
    public GameObject piedra2;
    public GameObject piedra3;
    public GameObject piedra4;
    public GameObject piedra5;
    public GameObject piedra6;
    public GameObject piedra7;
    public GameObject piedra8;
    public GameObject piedra9;
    public GameObject piedra10;
    public GameObject piedra11;
    public GameObject piedra12;
    public GameObject piedra13;
    public GameObject piedra14;
    public GameObject piedra15;
    public GameObject piedra16;
    public GameObject piedra17;
    public GameObject piedra18;
    public GameObject piedra19;
    public GameObject piedra20;
    public bool start = false;
    public bool gameOver = false;

    public GameObject menuInicio;
    public GameObject menuGameOver;

    public List<GameObject> suelo;
    public List<GameObject> obstaculos;

    private void Start()
    {
        // Crear Mapa
        for (int i = 0; i < 21; i++)
        {
            suelo.Add(Instantiate(col1, new Vector2(-10 + i, -3), Quaternion.identity));
        }

        //Crear Obstaculos
        obstaculos.Add(Instantiate(piedra1, new Vector2(7, -2), Quaternion.identity));
        obstaculos.Add(Instantiate(piedra2, new Vector2(10, -2), Quaternion.identity));
        obstaculos.Add(Instantiate(piedra3, new Vector2(11, -2), Quaternion.identity));
        obstaculos.Add(Instantiate(piedra4, new Vector2(13, -2), Quaternion.identity));
        obstaculos.Add(Instantiate(piedra5, new Vector2(15, -2), Quaternion.identity));
        obstaculos.Add(Instantiate(piedra6, new Vector2(16, -2), Quaternion.identity));
        obstaculos.Add(Instantiate(piedra7, new Vector2(18, -2), Quaternion.identity));
        obstaculos.Add(Instantiate(piedra8, new Vector2(19, -2), Quaternion.identity));
        obstaculos.Add(Instantiate(piedra9, new Vector2(21, -2), Quaternion.identity));
        obstaculos.Add(Instantiate(piedra10, new Vector2(11, -1), Quaternion.identity));
        obstaculos.Add(Instantiate(piedra11, new Vector2(11, 0), Quaternion.identity));
        obstaculos.Add(Instantiate(piedra12, new Vector2(15, -1), Quaternion.identity));
        obstaculos.Add(Instantiate(piedra13, new Vector2(18, -1), Quaternion.identity));
        obstaculos.Add(Instantiate(piedra14, new Vector2(18, -0), Quaternion.identity));
        obstaculos.Add(Instantiate(piedra15, new Vector2(21, -1), Quaternion.identity));
        obstaculos.Add(Instantiate(piedra16, new Vector2(21, 0), Quaternion.identity));
        obstaculos.Add(Instantiate(piedra17, new Vector2(15, 0), Quaternion.identity));
        obstaculos.Add(Instantiate(piedra18, new Vector2(16, 3), Quaternion.identity));
        obstaculos.Add(Instantiate(piedra19, new Vector2(17, 1), Quaternion.identity));

    }

    private void Update()
    {
        if (!start && !gameOver)
        {
            menuInicio.SetActive(true);
            if (Input.GetKeyDown(KeyCode.X))
            {
                start = true;
            }
        }
        else if (gameOver)
        {
            menuGameOver.SetActive(true);
            if (Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        else
        {
            menuInicio.SetActive(false);
            menuInicio.SetActive(false);
            //Mover BG
            bg.material.mainTextureOffset = bg.material.mainTextureOffset + new Vector2(0.015f, 0) * velocidad * Time.deltaTime;

            // Mover Mapa
            for (int i = 0; i < suelo.Count; i++)
            {
                if (suelo[i].transform.position.x <= -10)
                {
                    suelo[i].transform.position = new Vector3(10f, -3, 0);
                }
                suelo[i].transform.position = suelo[i].transform.position + new Vector3(-1, 0, 0) * velocidad * Time.deltaTime;
            }

            //Mover Obstaculos
            for (int i = 0; i < obstaculos.Count; i++)
            {
                if (obstaculos[i].transform.position.x <= -10)
                {
                    float randomObs = Random.Range(10, 18);
                    obstaculos[i].transform.position = new Vector3(randomObs, -2, 0);
                }
                obstaculos[i].transform.position = obstaculos[i].transform.position + new Vector3(-1, 0, 0) * velocidad * Time.deltaTime;
            }
        }
    }

}
