using System;

public class Helper 
{
    public static T GetRandomEnum<T>()
    {
        Random random = new Random();
        System.Array A = System.Enum.GetValues(typeof(T));
        T V = (T)A.GetValue(random.Next(0, A.Length));
        return V;
    }
}
