using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rankingSystem : MonoBehaviour
{
    [Header ("Game Objects")]
    public Text rankText;
    public List<GameObject> rankList;


    private void LateUpdate()
    {
        bubleSort(rankList);
        writeUi(rankList);
    }

    //Rank Write 
    public void writeUi(List<GameObject> arr)
    {
        rankText.text = "";
        for (int i = arr.Count-1; i >= 0; i--)
        {
            rankText.text += arr[i].name +("\n");
        }
    }

//Buble Sort ile listeyi siralama
    public static void bubleSort(List<GameObject> arr)
    {
        GameObject temp;

        for (int write = 0; write < arr.Count; write++)
        {
            for (int sort = 0; sort < arr.Count - 1; sort++)
            {
                if (arr[sort].transform.position.z > arr[sort + 1].transform.position.z)
                {
                    temp = arr[sort + 1];
                    arr[sort + 1] = arr[sort];
                    arr[sort] = temp;
                }
            }
        }
    }
}





