// Advent of Code 2024 Day 5
/*
pages must be printed in a specific order
X|Y means X must be printed before Y (if both are being updated)
Any time before, not immediately before

Part 1: identify which updates are in the right order
Also find the middle page number of each update that is being printed (must be in correct order)
The result is the sum of the middle page numbers of the correctly-ordered updates

*/

using System;
using System.IO;
using System.Collections.Generic; 

var lines = new List<string>();

using (TextReader reader = File.OpenText("L:\\Programming\\Advent\\5\\input.txt"))
{
    while(reader.Peek() > -1)
    {
        lines.Add(reader.ReadLine());
    }
}

// Part 2

var comesBefore = new Dictionary<string,List<string>>();
int incorrectCount = 0;
int middleSum = 0;
bool correctOrder;

foreach(string l in lines)
{
    if(l.Contains('|')) // this line must be a rule
    {
        string[] nums = l.Split('|');
        // if list contains left number as a key, add right number as a value
        if(comesBefore.ContainsKey(nums[0])) comesBefore[nums[0]].Add(nums[1]);
        // if not, create it
        else comesBefore.Add(nums[0],new List<string> {nums[1]});
    }
    else if(l.Contains(',')) // this line must be an update
    {
        correctOrder = true;
        string[] pages = l.Split(',');
        // iterate through all pairs of numbers in the update
        for(int i=pages.Length-1; i>0; i--)
        {
            for(int j=i-1; j>=0; j--)
            {
                if(comesBefore.ContainsKey(pages[i]))
                {
                    if(comesBefore[pages[i]].Contains(pages[j]))
                    {
                        correctOrder = false;
                        (pages[i],pages[j]) = (pages[j],pages[i]); // swap values
                    }
                }
            }
        }
        if(!correctOrder) 
        {
            incorrectCount++;
            //int mid = int.Parse(pages[(int)Math.Ceiling((decimal)(pages.Length)/2)]);
            middleSum += int.Parse(pages[pages.Length/2]);
        }
    }
}

Console.WriteLine(incorrectCount);
Console.WriteLine(middleSum);


/* Part 1

// might as well work in strings the whole time to avoid converting
// key comes before value
var comesBefore = new Dictionary<string,List<string>>();
int correctCount = 0;
int middleSum = 0;
bool correctOrder;


foreach(string l in lines)
{
    if(l.Contains('|')) // this line must be a rule
    {
        string[] nums = l.Split('|');
        // if list contains left number as a key, add right number as a value
        if(comesBefore.ContainsKey(nums[0])) comesBefore[nums[0]].Add(nums[1]);
        // if not, create it
        else comesBefore.Add(nums[0],new List<string> {nums[1]});
    }
    else if(l.Contains(',')) // this line must be an update
    {
        correctOrder = true;
        string[] pages = l.Split(',');
        // iterate through all pairs of numbers in the update
        for(int i=pages.Length-1; i>0; i--)
        {
            for(int j=i-1; j>=0; j--)
            {
                if(comesBefore.ContainsKey(pages[i]))
                {
                    if(comesBefore[pages[i]].Contains(pages[j]))
                    {
                        correctOrder = false;
                    }
                }
            }
        }
        if(correctOrder) 
        {
            correctCount++;
            //int mid = int.Parse(pages[(int)Math.Ceiling((decimal)(pages.Length)/2)]);
            middleSum += int.Parse(pages[pages.Length/2]);
        }
    }
}

Console.WriteLine(correctCount);
Console.WriteLine(middleSum);

*/