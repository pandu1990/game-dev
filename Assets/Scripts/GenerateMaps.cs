using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMaps : MonoBehaviour {

    [SerializeField]GameObject backgroundImg;

    int rowUnitNum = 0;
    int colUnitNum = 0;

    public Pickup pickup;

    public TextAsset csvFile;

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


        initMap();

    }

    void initMap(){

        int rowNo = 0, colNo = 0;

        string[] records = csvFile.text.Split('\n');
        foreach(string record in records){
            colNo = 0;
            string[] fields = record.Split(',');
            foreach (string field in fields)
            {
                //check type
                int n;
                bool isNumeric = int.TryParse(field, out n);
                if (isNumeric) {
                    //score blocks
                    pickup.points = n;
                    Instantiate(pickup, new Vector3(colNo + 0.5f, rowUnitNum - rowNo - 1 + 0.5f, 0), Quaternion.identity);

                }


                colNo++;
            }
            Debug.Log(colNo);
            rowNo++;
        }

        ////for (int i = 0; i < rowUnitNum;i++){
        ////    for (int j = 0;j<colUnitNum)
        ////}
        //pickup.points = 100;
        //Instantiate(pickup, new Vector3(0.5f, 2.5f, 0), Quaternion.identity);
        //pickup.points = 200;
        //Instantiate(pickup, new Vector3(2.5f, 4.5f, 0), Quaternion.identity);
   
    }


	
	// Update is called once per frame
	void Update () {
		
	}
}
