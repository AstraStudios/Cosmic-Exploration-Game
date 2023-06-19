using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // rotation variables
    [SerializeField] Transform centerPoint;
    [SerializeField] List <Transform> objectToRotate = new List<Transform>();
    [SerializeField] float speed;

    private Vector3 zAxis = new Vector3(0,0,1);

    // standard variables

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < objectToRotate.Count; i++)
            objectToRotate[i].RotateAround(centerPoint.position, zAxis, speed);
    }

    // public functions

    public void LoadGame()
    {
        SceneManager.LoadScene("PlayScene", LoadSceneMode.Single);
    }
}
