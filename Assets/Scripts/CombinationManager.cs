using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class CombinationManager : MonoBehaviour
{

    static System.Random rnd = new System.Random();

    // creating public lists
    public List<List<answer>> AllCombinations = new List<List<answer>>();
    public List<answer> combination1 = new List<answer>();
    public List<answer> combination2 = new List<answer>();
    public List<answer> combination3 = new List<answer>();

    // setting texts
    public GameObject answer1;
    public GameObject answer2;
    public GameObject answer3;

    public List<answer> currentCombination = new List<answer>();

    public List<string> getCurrentCombination()
    {
        if(currentCombination.Count == 0)
        {
            CurrentCombination();
        }
        List<string> ret = new List<string>();

        foreach (answer a in currentCombination)
        {
            ret.Add(a.Name);
        }

        return ret;
    }

    // Start is called before the first frame update


    /* possible tiles (all lowercase) :
     * -----------------
     * modelyear
     * carline
     * salesgroup
     * trimline
     * model
     * modeldata
     * standardequipment
     * technicalparameter
     */
    void Start()
    {

        // adds answers to a combination
        
        combination1.Add(new answer("modelyear", "modelyear"));
        combination1.Add(new answer("carline", "carline"));
        combination1.Add(new answer("salesgroup", "salegroup"));

        // adds answers to a combination

        combination2.Add(new answer("trimline", "trimline"));
        combination2.Add(new answer("model", "model"));
        combination2.Add(new answer("modeldata", "modeldata"));

        // adds answers to a combination

        combination3.Add(new answer("standardequipment", "standardequipment"));
        combination3.Add(new answer("standardequipment", "standardequipment"));
        combination3.Add(new answer("standardequipment", "standardequipment"));

        List<answer> combo4 = new List<answer>();

        combo4.Add(new answer("modeldata", "modeldata"));
        combo4.Add(new answer("standardequipment", "standardequipment"));
        combo4.Add(new answer("standardequipment", "standardequipment"));

        List<answer> combo5 = new List<answer>();

        combo5.Add(new answer("salegroup", "salesgroup"));
        combo5.Add(new answer("trimline", "trimline"));
        combo5.Add(new answer("model", "model"));

        // creates a list with all the combinations

        AllCombinations.Add(combination1);
        AllCombinations.Add(combination2);
        AllCombinations.Add(combination3);
        AllCombinations.Add(combo4);
        AllCombinations.Add(combo5);


        //List<answer> CurrentCombination1 = AllCombinations[b];

        // starting combination
        CurrentCombination();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public class answer
    {
        public answer(string name, string type)
        {
            this.Name = name;
            this.Type = type;

        }

        public string Name { get; set; }
        public string Type { get; set; }
    }

    // picks a random combination
    public void CurrentCombination()
    {
        // picks a random number
        int b = rnd.Next(0, AllCombinations.Count);
        currentCombination = AllCombinations[b];
        // setting the combination on canvas
        answer1.GetComponent<Text>().text = AllCombinations[b][0].Name;
        answer2.GetComponent<Text>().text = AllCombinations[b][1].Name;
        answer3.GetComponent<Text>().text = AllCombinations[b][2].Name;

    }
}
