using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField] GameObject tilePrefab;
    public float rotationSpeed = 5f;
    LevelMaker levelMaker;

    void Awake()
    {
        levelMaker = LevelMaker.instance;
    }

    void Start()
    {
        MakeTiles();

    }


    void MakeTiles()
    {
        int emptyOne = Random.Range(0, 8);
        int killerOne = Random.Range(0, 8);
        if (killerOne == emptyOne)
        {
            killerOne = Random.Range(0, 8);
        }
        for (int i = 0; i < 8; i++)
        {
            int rand = Random.Range(0, 100);
            GameObject tile = Instantiate(tilePrefab, transform.position, Quaternion.identity);
            tile.transform.parent = transform;
            tile.transform.Rotate(0, levelMaker.angles[i], 0);


            if (i == emptyOne) // Kesinlikle en az bir tane olması gereken boşluk 
            {
                tile.GetComponent<MeshRenderer>().enabled = false;
                tile.GetComponent<MeshCollider>().enabled = false;
            }
            if (rand < 10) //%10 ihtimalle boşluk
            {
                tile.GetComponent<MeshRenderer>().enabled = false;
                tile.GetComponent<MeshCollider>().enabled = false;
            }
            if (i == killerOne)
            {
                tile.GetComponent<MeshRenderer>().material = levelMaker.killerMat;
                tile.name = "Killer";
                tile.tag = "Killer";
            }
            if (rand > 10 && rand < 25) //%15 ihtimalle killer
            {
                tile.GetComponent<MeshRenderer>().material = levelMaker.killerMat;
                tile.name = "Killer";
                tile.tag = "Killer";
            }

            if (i == 1 && gameObject.name == "Floor 0")
            {
                tile.name = "StartTile";
                tile.tag = "Untagged";
                tile.GetComponent<MeshRenderer>().enabled = true;
                tile.GetComponent<MeshCollider>().enabled = true;
                tile.GetComponent<MeshRenderer>().material = levelMaker.safeMat;
            }
        }
    }
}
