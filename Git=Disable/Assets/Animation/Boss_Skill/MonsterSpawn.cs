using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    static public int State;
    bool StateSpawn_1;
    bool StateSpawn_El1;
    bool StateSpawn_2;
    bool StateSpawn_El2;
    bool StateSpawn_3;
    bool StateSpawn_El3;
    public static int SpawnCount;
    [SerializeField] GameObject Goblin;
    [SerializeField] GameObject Skeleton;
    [SerializeField] GameObject FlyEye;
    [SerializeField] GameObject Mushroom;
    [SerializeField] GameObject El1;
    [SerializeField] GameObject El2;
    [SerializeField] GameObject El3;
    [SerializeField] GameObject ElSpawn1;
    [SerializeField] GameObject ElSpawn2;
    [SerializeField] GameObject ElSpawn3;
    [SerializeField] GameObject Spawn1_1;
    [SerializeField] GameObject Spawn1_2;
    [SerializeField] GameObject Spawn1_3;
    [SerializeField] GameObject Spawn1_4;
    [SerializeField] GameObject Spawn1_5;
    [SerializeField] GameObject Spawn1_6;
    [SerializeField] GameObject Spawn1_7;
    [SerializeField] GameObject Spawn1_8;
    [SerializeField] GameObject Spawn1_9;
    [SerializeField] GameObject Spawn1_10;
    [SerializeField] GameObject Spawn1_11;
    [SerializeField] GameObject Spawn1_12;
    [SerializeField] GameObject Spawn1_13;
    [SerializeField] GameObject Spawn1_14;
    [SerializeField] GameObject Spawn1_15;
    [SerializeField] GameObject Spawn2_1;
    [SerializeField] GameObject Spawn2_2;
    [SerializeField] GameObject Spawn2_3;
    [SerializeField] GameObject Spawn2_4;
    [SerializeField] GameObject Spawn2_5;
    [SerializeField] GameObject Spawn2_6;
    [SerializeField] GameObject Spawn2_7;
    [SerializeField] GameObject Spawn2_8;
    [SerializeField] GameObject Spawn2_9;
    [SerializeField] GameObject Spawn2_10;
    [SerializeField] GameObject Spawn2_11;
    [SerializeField] GameObject Spawn2_12;
    [SerializeField] GameObject Spawn2_13;
    [SerializeField] GameObject Spawn2_14;
    [SerializeField] GameObject Spawn2_15;
    [SerializeField] GameObject Spawn3_1;
    [SerializeField] GameObject Spawn3_2;
    [SerializeField] GameObject Spawn3_3;
    [SerializeField] GameObject Spawn3_4;
    [SerializeField] GameObject Spawn3_5;
    [SerializeField] GameObject Spawn3_6;
    [SerializeField] GameObject Spawn3_7;
    [SerializeField] GameObject Spawn3_8;
    [SerializeField] GameObject Spawn3_9;
    [SerializeField] GameObject Spawn3_10;
    [SerializeField] GameObject Spawn3_11;
    [SerializeField] GameObject Spawn3_12;
    [SerializeField] GameObject Spawn3_13;
    [SerializeField] GameObject Spawn3_14;
    [SerializeField] GameObject Spawn3_15;
    [SerializeField] GameObject Spawn3_16;
    [SerializeField] GameObject Spawn3_17;
    [SerializeField] GameObject Spawn3_18;
    [SerializeField] GameObject Spawn3_19;
    [SerializeField] GameObject Spawn3_20;
    void Start()
    {
        State= 0;
        StateSpawn_1 = false;
        StateSpawn_El1 = false;
        StateSpawn_2 = false;
        StateSpawn_El2 = false;
        StateSpawn_3 = false;
        StateSpawn_El3 = false;
    }
    void Update()
    {
        Debug.Log(SpawnCount);
        if(State == 1)
        {
            if(StateSpawn_1 == false)
            {
                Instantiate(Mushroom, Spawn1_1.transform);
                SpawnCount++;
                Instantiate(Mushroom, Spawn1_2.transform);
                SpawnCount++;
                Instantiate(Mushroom, Spawn1_3.transform);
                SpawnCount++;
                Instantiate(Mushroom, Spawn1_4.transform);
                SpawnCount++;
                Instantiate(Mushroom, Spawn1_5.transform);
                SpawnCount++;
                Instantiate(Mushroom, Spawn1_6.transform);
                SpawnCount++;
                Instantiate(Mushroom, Spawn1_7.transform);
                SpawnCount++;
                Instantiate(Mushroom, Spawn1_8.transform);
                SpawnCount++;
                Instantiate(Mushroom, Spawn1_9.transform);
                SpawnCount++;
                Instantiate(Mushroom, Spawn1_10.transform);
                SpawnCount++;
                Instantiate(Mushroom, Spawn1_11.transform);
                SpawnCount++;
                Instantiate(Mushroom, Spawn1_12.transform);
                SpawnCount++;
                Instantiate(Mushroom, Spawn1_13.transform);
                SpawnCount++;
                Instantiate(Mushroom, Spawn1_14.transform);
                SpawnCount++;
                Instantiate(Mushroom, Spawn1_15.transform);
                SpawnCount++;
                Debug.Log("스폰 완료!");
                StateSpawn_1 = true;
            }
            if (StateSpawn_1 == true && SpawnCount == 0 && StateSpawn_El1 == false)
            {
                Instantiate(El1, ElSpawn1.transform);
                StateSpawn_El1= true;
            }
        }
    }
}
