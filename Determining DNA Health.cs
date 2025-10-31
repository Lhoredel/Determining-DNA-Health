using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{
     public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<string> genes = Console.ReadLine().TrimEnd().Split(' ').ToList();

        List<int> health = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(healthTemp => Convert.ToInt32(healthTemp)).ToList();

        int s = Convert.ToInt32(Console.ReadLine().Trim());
        
        long minHealth = long.MaxValue;
        long maxHealth = long.MinValue;
        
        for (int sItr = 0; sItr < s; sItr++)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
            
            int first = Convert.ToInt32(firstMultipleInput[0]);
            int last = Convert.ToInt32(firstMultipleInput[1]);
            string d = firstMultipleInput[2];

            long currentHealth = CalculateHealth(genes, health, first, last, d);
            
            if (currentHealth < minHealth) minHealth = currentHealth;
            if (currentHealth > maxHealth) maxHealth = currentHealth;
        }

        Console.WriteLine($"{minHealth} {maxHealth}");
    }
    
    private static long CalculateHealth(List<string> genes, List<int> health, int first, int last, string d)
    {
        long totalHealth = 0;
        for (int i = first; i <= last; i++)
        {
            string gene = genes[i];
            int geneHealth = health[i];
    
            int occurrences = CountOccurrences(d, gene);
            totalHealth += (long)occurrences * geneHealth;
        }
        
        return totalHealth;
    }

    private static int CountOccurrences(string text, string pattern)
    {
        if (pattern.Length > text.Length) return 0;
        
        int count = 0;
        for (int i = 0; i <= text.Length - pattern.Length; i++)
        {
            bool match = true;
            for (int j = 0; j < pattern.Length; j++)
            {
                if (text[i + j] != pattern[j])
                {
                    match = false;
                    break;
                }
            }
            if (match) count++;
        }
        return count;
    }
} 
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
   
