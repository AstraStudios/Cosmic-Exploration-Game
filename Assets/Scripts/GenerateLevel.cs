using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    [SerializeField] List<GameObject> levels = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        int randLevel = Random.Range(0, levels.Count);
        Instantiate(levels[randLevel], new Vector2(0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewLevelOnButtonPress()
    {
        Destroy(GameObject.FindGameObjectWithTag("Level"));
        int randLevel = Random.Range(0, levels.Count);
        Instantiate(levels[randLevel], new Vector2(0, 0), Quaternion.identity);
    }
}
