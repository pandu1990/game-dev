using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMaps : MonoBehaviour {

    [SerializeField]GameObject backgroundImg;

    int rowUnitNum = 0;
    int colUnitNum = 0;

    public Pickup pickup;
    [SerializeField] GameObject wall;
    public Mystery mystery;

    public TextAsset[] csvFile;

    enum BLOCKTYPE
    {

        SpeedUp
    };

    // Use this for initialization
    void Start () {
        float bkImgWidth = backgroundImg.GetComponent<SpriteRenderer>().bounds.size.x;
        float bkImgHeight = backgroundImg.GetComponent<SpriteRenderer>().bounds.size.y;
        rowUnitNum = Mathf.RoundToInt(bkImgHeight);
        colUnitNum = Mathf.RoundToInt(bkImgWidth);
        //rowUnitNum = Mathf.RoundToInt(bkImgWidth);
        //colUnitNum = Mathf.RoundToInt(bkImgHeight);

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
                //check type
                int n;
                //var obj;
                bool isNumeric = int.TryParse(field, out n);
                if (isNumeric) {
                    //score blocks
                    pickup.points = n;
                    Instantiate(pickup, new Vector3(colNo + 0.5f, rowUnitNum - rowNo - 1 + 0.5f, 0), Quaternion.identity);

                }
                else{
                    switch (field.Trim()){
                        case "Wall":
                            wall.isStatic = true;
                            Instantiate(wall, new Vector3(colNo + 0.5f, rowUnitNum - rowNo - 1 + 0.5f, 0), Quaternion.identity);
                            break;
                        case "Mystery:Reverse":
                            mystery.mysteryType = Mystery.MYSTERYDIRECTION.ReverseDirection;
                            Instantiate(mystery, new Vector3(colNo + 0.5f, rowUnitNum - rowNo - 1 + 0.5f, 0), Quaternion.identity);
                            break;
                        case "Mystery:Speedup":
                            mystery.mysteryType = Mystery.MYSTERYDIRECTION.SpeedUp;
                            Instantiate(mystery, new Vector3(colNo + 0.5f, rowUnitNum - rowNo - 1 + 0.5f, 0), Quaternion.identity);
                            break;
                    }
                }


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


	
	// Update is called once per frame
	void Update () {
		
	}
}
