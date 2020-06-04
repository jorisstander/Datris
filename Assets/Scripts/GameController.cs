using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public enum State
    {
        Pause,
        Running,
        GameOver,
        Starting
    };


    public static int height = 20;
    public static int width = 10;

    public State state;

    public int score;
    public Transform[,] objects;
    public Dictionary<Vector3Int, GameObject> blocks = new Dictionary<Vector3Int, GameObject>();
    public GameObject[] gameObjects;

    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        blocks.Clear();
        gameObjects = GameObject.FindGameObjectsWithTag("block");

        foreach (GameObject g in gameObjects)
        {
            Vector3Int v3 = new Vector3Int((int)g.transform.position.x, (int)g.transform.position.y, (int)g.transform.position.z);
            Debug.Log("G:" + g.name + ",   " + v3.ToString());
            blocks.Add(v3, g);
            checkBlocks(v3);
        }
    }

    void checkBlocks(Vector3Int pos)
    {
        Vector3Int[] directions = {
            Vector3Int.up,
            Vector3Int.down,
            Vector3Int.left,
            Vector3Int.right
        };

        foreach(Vector3Int v in directions)
        {
            GameObject g = checkBlock(pos, v);
            if(g)
            {
                Debug.Log(g.gameObject.transform.position);
            }
        }
    }

    GameObject checkBlock(Vector3Int pos, Vector3Int where)
    {
        GameObject g;
        blocks.TryGetValue(pos + where, out g);
        if (g)
        {
            return g;
        }
        return g;
        

        
    }



}
