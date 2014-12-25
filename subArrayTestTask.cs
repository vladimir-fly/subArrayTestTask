using System;

class Program
{
  public static void Main(string[] args)
  {
    int[] numbers = new[]
        //{520, 34, -1, 7, -9, 5, 236, 8, 9, -66, 443, -3, 1, -6};
        //{-4, -4, -21, -5, -110, -100};
        {-5, -6, 1, 2, -1, 3, 5, -10};
        
    subArrayFind(numbers);
  }

  public static void subArrayFind(int[] numbers)
  {
    int leftIndex = 0,
        rightIndex = 0,
        i = 0,
        j = 0,
        tmpSum = 0,
        maxSum = 0;

    bool hasNoPositiveNumbers = true;
    int size = numbers.Length;

    for(j = 0; j < size; j++)
    {
      if (numbers[j] > 0) hasNoPositiveNumbers = false;

      if(numbers[j] < 0)
      {
        if(maxSum < tmpSum)
        {
          leftIndex = i;
          rightIndex = j - 1;
          maxSum = tmpSum;
        }
        tmpSum += numbers[j];

        if(tmpSum <= 0)
        {
          i = j + 1;
          tmpSum = 0;
        }
      }
      else tmpSum += numbers[j];
    }

    if(maxSum < tmpSum)
    {
      leftIndex = i;
      rightIndex = j - 1;
    }

    if (hasNoPositiveNumbers)
    {
      int max = int.MinValue;
      int position = 0;
      for (i = 0; i < numbers.Length; i++)
        if (numbers[i] > max)
        {
          max = numbers[i];
          position = i;
        }

        leftIndex = position;
        rightIndex = position;
        maxSum = max;
    }

    Console.WriteLine("leftIndex: " + leftIndex +
                      "; rightIndex: " + rightIndex +
                      "; maxSum: " + maxSum);
  }
}
