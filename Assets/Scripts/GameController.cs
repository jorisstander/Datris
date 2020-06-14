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

    public CombinationManager combinationManager;

    public List<string> currentCombination;

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            check();
        }
    }

    // Update is called once per frame
    public void check()
    {

        gameObjects = new GameObject[0];
        blocks.Clear();
        gameObjects = GameObject.FindGameObjectsWithTag("block");

        foreach (GameObject g in gameObjects)
        {
            Vector3Int v3 = new Vector3Int
                ((int)g.transform.position.x, (int)g.transform.position.y, (int)g.transform.position.z);
            blocks.Add(v3, g);
            checkBlocks(v3);
        }
    }

    public void checkBlocks(Vector3Int pos)
    {
        currentCombination = combinationManager.getCurrentCombination();
        List<GameObject> objects = new List<GameObject>();

        Vector3Int[] directions = {
            Vector3Int.up,
            Vector3Int.down,
            Vector3Int.left,
            Vector3Int.right
        };

        foreach (Vector3Int v in directions)
        {
            //List<GameObject> glist = checkBlock(pos, v);
            string debugString = "direction: " + v + " : ";



            int i = 0;
            List<GameObject> blocks = new List<GameObject>();
            while (i < height)
            {
                GameObject g = checkBlock(pos, v * i);
                

                if (g)
                {
                    blocks.Add(g);
                    debugString += g.name + "  ";
                }
                else
                {
                    break;
                }
                i++;
            }
            List<GameObject> toRem = getCombination(blocks);

            if (toRem.Count > 0)
            {
                Destroy(toRem[0]);
                Destroy(toRem[1]);
                Destroy(toRem[2]);
                score += 3;
                combinationManager.CurrentCombination();
                Debug.Log("Combination found!" + currentCombination[0] + "  " + currentCombination[1] + "  " + currentCombination[2]);
            }

            //Debug.Log(debugString);
        }
    }

    List<GameObject> getCombination(List<GameObject> toCheck)
    {
        List<GameObject> ret = new List<GameObject>();

        if (toCheck.Count < currentCombination.Count) return ret;


        if (toCheck.Count < 3) return ret;

        //for (int i = 0; i < toCheck.Count; i++)
        //{
        //if (!(toCheck.GetRange(i, 3).Count >= 3)) return ret;
        int i = 0;
            Debug.Log(
                toCheck[i].name + "    " +
                toCheck[i + 1].name + "    " +
                toCheck[i + 2].name + "    " +
                currentCombination[0] + "   " +
                currentCombination[1] + "    " +
                currentCombination[2]
            );

            if (toCheck[i].name == (currentCombination[i + 0] + "(Clone)"))
            {
                Debug.Log("first one right!");
                if (toCheck[i + 1].name == (currentCombination[i + 1] + "(Clone)"))
                {
                    Debug.Log("second one right!");

                    if (toCheck[i + 2].name == (currentCombination[i + 2] + "(Clone)"))
                    {
                        Debug.Log("third one right!");
                        return toCheck.GetRange(i, 3);
                    }

                }
            }

        //}



        return ret;
    }




    GameObject checkBlock(Vector3Int pos, Vector3Int where)
    {
        GameObject g;
        blocks.TryGetValue(pos + where, out g);

        Debug.Log(where + "    " + (g ? g.name : " ") );

        return g;
    }



}


