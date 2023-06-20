using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    //.. 프리팹들을 보관할 변수
    public GameObject[] prefabs;

    //.. 풀 담당을 하는 리스트들
    List<GameObject>[] pools;

    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;
        //...선택한 풀의 놀고 있는 게임오브젝트 접근
        //... 발견하면 select 변수에 할당하도록
        foreach(GameObject item in pools[index])
        {
            if (!item.activeSelf)
            {
                //..발견되면 seslect 변수에 할당
                select = item;
                select.SetActive(true);
                break;
            }
        }
        //... 모두 사용 되었다면 
        if(!select) 
        {
            //... 새롭게 생성하고  select 변수에 할당
            select = Instantiate(prefabs[index],transform);
            //...그리고 풀에 등록함
            pools[index].Add(select);
        }

        return select;
    }
}
