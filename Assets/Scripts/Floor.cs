using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField] GameObject tilePrefab;
    [Range(2, 20)] public float rotationSpeed = 5f;
    LevelMaker levelMaker;

    void Awake()
    {
        levelMaker = LevelMaker.instance;
    }

    void Start()
    {
        MakeTiles();
    }


    void MakeTiles() //Basic Procgen, infinite levels
    {
        int emptyOne = Random.Range(0, 8);
        int killerOne = Random.Range(0, 8);

        for (int i = 0; i < 8; i++)
        {
            GameObject tile = Instantiate(tilePrefab, transform.position, Quaternion.identity);
            tile.transform.parent = transform;
            tile.transform.Rotate(0, i * 45, 0);


            int rand = Random.Range(0, 100);
            if (i == killerOne || (rand > 10 && rand < 25)) // Kesinlikle en az bir tane olması gereken killer, %15 ihtimalle killer
            {
                tile.GetComponent<MeshRenderer>().material = levelMaker.killerMat;
                tile.name = "Killer";
                tile.tag = "Killer";
            }
            if (i == emptyOne || rand < 10) // Kesinlikle en az bir tane olması gereken boşluk, %10 ihtimalle boşluk
            {
                tile.GetComponent<MeshRenderer>().enabled = false;
                tile.GetComponent<MeshCollider>().enabled = true;
                tile.GetComponent<MeshCollider>().isTrigger = true;
            }

            if (i == 1 && gameObject.name == "Floor 0") //Oyun başlar başlamaz top killer tile'ın üzerinde olmasın diye
            {
                tile.name = "StartTile";
                tile.tag = "Untagged";
                tile.GetComponent<MeshRenderer>().enabled = true;
                tile.GetComponent<MeshCollider>().enabled = true;
                tile.GetComponent<MeshCollider>().isTrigger = false;
                tile.GetComponent<MeshRenderer>().material = levelMaker.safeMat;
            }
        }
    }
}
