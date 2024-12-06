// Advent of Code 2024 Day 3

using System;
using System.IO;
using System.Collections.Generic; 
using System.Text.RegularExpressions;

string input = File.ReadAllText("L:\\Programming\\Advent\\3\\input.txt"); // read in text as a single string
int[] doOrDont = new int[input.Count()];
int count = 0;

// look for each occurence of 'do()' and mark its index with a 7
foreach(Match m in Regex.Matches(input, @"do\(\)")) 
{
    doOrDont[m.Index] = 7;
}
// look for each occurence of 'don't() and mark its index with an 8
foreach(Match m in Regex.Matches(input, @"don't\(\)")) 
{
    doOrDont[m.Index] = 8;
}

// iterate through the doOrDont array and fill it with 1's or 0's 
// to mark whether the current index should me included in the final count
bool doIt = true;
for(int i=0; i<doOrDont.Count(); i++)
{
    if(doOrDont[i]==7) doIt = true;
    else if(doOrDont[i]==8) doIt = false;

    if(doIt) doOrDont[i] = 1;
    else doOrDont[i] = 0;
}

// iterate through the mul(xxx,yyy) matches and add the result to the count
// if a do() command is active.
foreach(Match m in Regex.Matches(input, @"mul\((\d{1,3}),(\d{1,3})\)"))
{
    if(doOrDont[m.Index] == 1) count += int.Parse(m.Groups[1].ToString()) * int.Parse(m.Groups[2].ToString());
}

Console.WriteLine(count);



/* Part 1

string input = File.ReadAllText("L:\\Programming\\Advent\\3\\input.txt");

int count = 0;

foreach(Match m in Regex.Matches(input, @"mul\((\d{1,3}),(\d{1,3})\)"))
{
    count += int.Parse(m.Groups[1].ToString()) * int.Parse(m.Groups[2].ToString());
}

Console.WriteLine(count);

*/