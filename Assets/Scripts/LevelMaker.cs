using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMaker : MonoBehaviour
{
    public List<int> angles;

    public Material killerMat, safeMat;

    [SerializeField] GameObject emptyPrefab;
    [Space(5)]
    public int katSayisi = 5;
    GameObject silindirGO;
    float yLevel = .9f;

    public static LevelMaker instance;


    void Awake()
    {
        if (instance == null)
            instance = this;

        SetAngles();
        silindirGO = GameObject.Find("Silindir");
    }

    IEnumerator Start()
    {
        MakeFloors(katSayisi);
        yield return new WaitForSeconds(.1f);
        silindirGO.transform.rotation = Quaternion.Euler(0, 22.5f, 0);
    }




    void MakeFloors(int floorCount)
    {
        for (int j = 0; j < floorCount; j++)
        {
            GameObject floor = Instantiate(emptyPrefab, silindirGO.transform.position, Quaternion.identity);
            floor.transform.parent = silindirGO.transform;
            floor.name = "Floor " + j;
            floor.transform.localPosition = new Vector3(floor.transform.position.x, yLevel - (j * .2f), floor.transform.position.z);
        }

    }

    void SetAngles()
    {
        for (int i = 0; i < 8; i++)
        {
            angles.Add(i * 45);
        }
    }


}
