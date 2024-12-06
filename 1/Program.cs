// Advent of Code 2024 Day 1

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

var temp = new string[2];
var leftNums = new List<int>();
var rightNums = new List<int>();

using (TextReader reader = File.OpenText("L:\\Programming\\Advent\\1\\input.txt"))
{
    while(reader.Peek() > -1)
    {
        temp = reader.ReadLine().Split();
        leftNums.Add(int.Parse(temp[0]));
        rightNums.Add(int.Parse(temp[3]));
    }
}

leftNums.Sort();
rightNums.Sort();

//Console.WriteLine("Count: " + leftNums.Count());

int dist = 0;
for(int i=0; i<leftNums.Count(); i++)
{
    dist += Math.Abs(leftNums[i]-rightNums[i]);
    //Console.WriteLine("Left: " + leftNums[i] + " Right: " + rightNums[i] + " Dist: " + Math.Abs(leftNums[i]-rightNums[i]));
}
Console.WriteLine("Dist: " + dist);

int similarity = 0;
foreach(int l in leftNums)
{
    int numSame = 0;
    foreach(int r in rightNums)
    {
        if(l==r) numSame++;
    }
    similarity += l*numSame;
}

Console.WriteLine("Similarity Score: " + similarity);