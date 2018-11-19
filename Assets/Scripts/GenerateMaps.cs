using System.Collections;
using System.Collections.Generic;
//using System;
using UnityEngine;

public class GenerateMaps : MonoBehaviour {

    [SerializeField]GameObject backgroundImg;

    int rowUnitNum = 0;
    int colUnitNum = 0;

    public Pickup pickup;
    [SerializeField] GameObject wall;
    public Mystery mystery;
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;

    public TextAsset[] csvFile;
    public TextAsset InitialParam;

    Object[,] gameObjects = new Object[20, 32];


    // Use this for initialization
    void Start () {
        float bkImgWidth = backgroundImg.GetComponent<SpriteRenderer>().bounds.size.x;
        float bkImgHeight = backgroundImg.GetComponent<SpriteRenderer>().bounds.size.y;
        rowUnitNum = Mathf.RoundToInt(bkImgHeight);
        colUnitNum = Mathf.RoundToInt(bkImgWidth);

        int level = PlayerPrefs.GetInt("Level",1);

        initMap(level);

    }

    public void initMap(int level){

        int rowNo = 0, colNo = 0;

        string[] records = csvFile[level-1].text.Split('\n');
        foreach(string record in records){
            colNo = 0;
            string[] fields = record.Split(',');
            foreach (string field in fields)
            {
                Object obj=new Object();

                //check type
                int n;
                bool isNumeric = int.TryParse(field, out n);
                if (isNumeric) {
                    //score blocks
                    pickup.points = n;
                    obj = Instantiate(pickup, new Vector3(colNo + 0.5f, rowUnitNum - rowNo - 1 + 0.5f, 0), Quaternion.identity);

                }
                else{
                    switch (field.Trim()){
                        case "Wall":
                            wall.isStatic = true;
                            obj = Instantiate(wall, new Vector3(colNo + 0.5f, rowUnitNum - rowNo - 1 + 0.5f, 0), Quaternion.identity);
                            break;
                        case "Mystery:Reverse":
                            mystery.mysteryType = Mystery.MYSTERYDIRECTION.ReverseDirection;
                            obj = Instantiate(mystery, new Vector3(colNo + 0.5f, rowUnitNum - rowNo - 1 + 0.5f, 0), Quaternion.identity);
                            break;
                        case "Mystery:Speedup":
                            mystery.mysteryType = Mystery.MYSTERYDIRECTION.SpeedUp;
                            obj = Instantiate(mystery, new Vector3(colNo + 0.5f, rowUnitNum - rowNo - 1 + 0.5f, 0), Quaternion.identity);
                            break;
                        case "Mystery:Disappear":
                            mystery.mysteryType = Mystery.MYSTERYDIRECTION.Disappear;
                            obj = Instantiate(mystery, new Vector3(colNo + 0.5f, rowUnitNum - rowNo - 1 + 0.5f, 0), Quaternion.identity);
                            break;
                        case "Player1":
                            obj = Instantiate(player1, new Vector3(colNo + 0.5f, rowUnitNum - rowNo - 1 + 0.5f, 0), Quaternion.identity);
                            break;
                        case "Player2":
                            obj = Instantiate(player2, new Vector3(colNo + 0.5f, rowUnitNum - rowNo - 1 + 0.5f, 0), Quaternion.identity);
                            break;
                    }
                }

                gameObjects[rowNo, colNo] = obj;

                colNo++;
            }
            rowNo++;
        }


        //Instantiate(wall, new Vector3(0.5f, 2.5f, 0), Quaternion.identity);
        //Instantiate(wall, new Vector3(1.5f, 5.5f, 0), Quaternion.identity);


        //pickup.points = 100;
        //Instantiate(pickup, new Vector3(0.5f, 2.5f, 0), Quaternion.identity);
        //pickup.points = 200;
        //Instantiate(pickup, new Vector3(2.5f, 4.5f, 0), Quaternion.identity);

    }

    public void removeBlocks(List<Vector2Int> Positions){
        foreach (Vector2Int pos in Positions){
            Debug.Log(gameObjects[pos.x, pos.y]);
            GameObject obj=(GameObject)gameObjects[pos.x, pos.y];
            obj.SetActive(false);
        }
    }


	
	// Update is called once per frame
	void Update () {
		
	}
}
