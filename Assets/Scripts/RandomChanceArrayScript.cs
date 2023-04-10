using UnityEngine;

public class RandomChanceArrayScript 
{
    private float[] Chance(int countArray)//transfer the length of the log and select the appropriate array
    {
        float[] chanceArray = new float[countArray];

        if (countArray == 6)
        {
            chanceArray = new float[6] { 0.22f, 0.16f, 0.13f, 0.20f, 0.15f, 0.14f };
        }
        else if (countArray == 7)
        {
            chanceArray = new float[7] { 0.18f, 0.11f, 0.12f, 0.19f, 0.15f, 0.14f, 0.11f };
        }
        else if (countArray == 8)
        {
            chanceArray = new float[8] { 0.08f, 0.11f, 0.10f, 0.12f, 0.15f, 0.14f, 0.13f, 0.17f };
        }
        else if (countArray == 9)
        {
            chanceArray = new float[9] { 0.05f, 0.07f, 0.09f, 0.14f, 0.15f, 0.14f, 0.11f, 0.10f, 0.14f };
        }
        else if (countArray == 10)
        {
            chanceArray = new float[10] { 0.06f, 0.07f, 0.05f, 0.08f, 0.15f, 0.14f, 0.13f, 0.11f, 0.09f, 0.12f };
        }

        return chanceArray;

    }
    
    public int RandomChance(int countArray)
    {
        float[] percent = Chance(countArray);
        int result = RandomNumberChance(percent);
        return result;
    }

    private int RandomNumberChance(float[] percent)
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

    public float[] RandomShuffle(int numberRandom)//mixing
    {
        float[] percent = Chance(numberRandom);

        for (int i = 0; i < percent.Length; i++)//mixing array
        {
            float temp = percent[i];
            int randomIndex = Random.Range(0, percent.Length);
            percent[i] = percent[randomIndex];
            percent[randomIndex] = temp;
        }
        return percent;
    }

    public int RandomNewCard(int numberRandom)
    {
        float[] percentShuffle = RandomShuffle(numberRandom);
        int result = RandomNumberChance(percentShuffle);
        return result;
    }
}
