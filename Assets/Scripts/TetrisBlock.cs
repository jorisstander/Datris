using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;



public class TetrisBlock : MonoBehaviour
{
    private float previousTime;
    public float fallTime = 0.8f;
    public static int height = 20;
    public static int width = 10;
    private static Transform[,] grid = new Transform[GameController.width, GameController.height];
    public GameController controller;


    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        // movement left
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left;
            //border check
            if (!validMove())
                transform.position -= new Vector3(-1, 0, 0);
        }

        // movement right
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += Vector3.right;
            //border check
            if (!validMove())
                transform.position -= new Vector3(1, 0, 0);
        }
        //movement down
        if(Time.time - previousTime > (Input.GetKey(KeyCode.DownArrow) ?fallTime / 10 : fallTime))
        {
            transform.position += new Vector3(0, -1, 0);
            //border check
            if (!validMove())
            {
                transform.position -= new Vector3(0, -1, 0);
                // add it to the grid
                AddToGrid();
                //disables and start new falling block
                this.enabled = false;
                FindObjectOfType<SpawnTetromino>().NewTetromino();
            }
            previousTime = Time.time;
        }

    }

    // checks the grid for solution
    void CheckForSolution()
    {
        
    }
    // adds the blocks to a grid for checking on solutions later
    void AddToGrid()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            grid[roundedX, roundedY] = children;
        }
        controller.check();
    }
    //checks if move is valid
    bool validMove()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            if(roundedX < 0 || roundedX >= GameController.width || roundedY < 0 || roundedY >= GameController.height)
            {
                return false;
            }

            if (grid[roundedX, roundedY] != null)
                return false;
        }
        return true;
    }



}
