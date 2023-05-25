using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMaker : MonoBehaviour
{
    public Material killerMat, safeMat;
    GameObject silindirGO;
    [SerializeField] GameObject emptyPrefab, lastFloor;
    public static LevelMaker instance;
    [Space(5)]
    public int katSayisi;


    void Awake()
    {
        if (instance == null)
            instance = this;

        silindirGO = GameObject.Find("Silindir");
        katSayisi = Random.Range(9, 30);
    }

    IEnumerator Start()
    {
        MakeFloors(katSayisi);
        lastFloor.transform.localPosition = new Vector3(lastFloor.transform.position.x, 0.9f - ((katSayisi + 1) * .2f), lastFloor.transform.position.z);
        yield return new WaitForSeconds(.1f);
        silindirGO.transform.rotation = Quaternion.Euler(0, 22.5f, 0); //İki tile'ın arasında başlıyordu, direkt birinin üstünde başlaması için
    }




    void MakeFloors(int floorCount)
    {
        for (int j = 0; j < floorCount; j++)
        {
            GameObject floor = Instantiate(emptyPrefab, silindirGO.transform.position, Quaternion.identity);
            floor.transform.parent = silindirGO.transform;
            floor.name = "Floor " + j;
            floor.transform.localPosition = new Vector3(floor.transform.position.x, 0.9f - (j * .2f), floor.transform.position.z);
        }
    }


}
