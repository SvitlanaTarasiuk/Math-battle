using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCardScript : MonoBehaviour
{
    public int RandomCard(int countArray)//передавати довжину колоди і вибирати відповідний масив
    {  
        float[] chanceArray=new float[countArray];

        if (countArray == 6)
        {
            chanceArray = new float[6] { 0.25f, 0.1f, 0.1f, 0.25f, 0.15f, 0.15f };
        }
        else if (countArray == 7)
        {
            chanceArray = new float[7] { 0.25f, 0.1f, 0.1f, 0.25f, 0.1f, 0.1f,0.1f};
        }
        else if (countArray == 8)
        {
            chanceArray = new float[8] { 0.25f, 0.1f, 0.1f, 0.20f, 0.1f, 0.1f,0.1f,0.05f};
        }
        else if (countArray == 9)
        {
            chanceArray = new float[9] { 0.15f, 0.1f, 0.1f, 0.15f, 0.15f, 0.15f,0.10f,0.05f,0.05f};
        }
        else if (countArray == 10)
        {
            chanceArray = new float[10] { 0.15f, 0.1f, 0.1f, 0.1f, 0.15f, 0.15f,0.1f,0.05f,0.05f,0.05f };
        }
        else if (countArray == 11)
        {
            chanceArray = new float[11] { 0.13f, 0.1f, 0.1f, 0.1f, 0.15f, 0.15f, 0.1f, 0.05f, 0.05f, 0.05f,0.02f };
        }
        else if (countArray == 12)
        {
            chanceArray = new float[12] { 0.1f, 0.1f, 0.1f, 0.1f, 0.15f, 0.15f, 0.1f, 0.05f, 0.05f, 0.05f, 0.02f,0.03f };
        }
        else if (countArray == 13)
        {
            chanceArray = new float[13] { 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.05f, 0.05f, 0.02f, 0.03f,0.05f };
        }
        else if (countArray == 14)
        {
            chanceArray = new float[14] { 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.05f, 0.05f, 0.05f, 0.02f, 0.03f, 0.05f,0.05f };
        }       

        int result = (int)Chance(chanceArray);

        float Chance(float[] percent)
        {
            float total = 0;
            foreach (float elem in percent)
            {
                total += elem;
            }
            float randomPoint = Random.value * total;
            for (int i = 0; i < percent.Length; i++)
            {
                if (randomPoint < percent[i])
                {
                    return i;
                }
                else
                {
                    randomPoint -= percent[i];
                }
            }
            return percent.Length - 1;
        }
        return result;
    }
}
