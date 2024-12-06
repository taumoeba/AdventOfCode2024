// Advent of Code 2024 Day 4

using System;
using System.IO;
using System.Collections.Generic; 

/*

valid X-MAS if A has two Ms and two Ss in diagonal corners,
and they both form MAS

*/

var lines = new List<string>();

// fill reportList with a list of arrays of levels (an array of levels is a report)
using (TextReader reader = File.OpenText("L:\\Programming\\Advent\\4\\input.txt"))
{
    while(reader.Peek() > -1)
    {
        lines.Add(reader.ReadLine());
    }
}

int lineIndex = 0;
int charIndex = 0;
int xmasCount = 0;
char ne, nw, se, sw;

foreach(string l in lines)
{
    charIndex = 0;
    foreach(char c in l)
    {
        if(c=='A' && charIndex>0 && charIndex<l.Count()-1 && lineIndex>0 && lineIndex<lines.Count-1) // found 'A' and it's not on an edge
        {
            ne = lines[lineIndex-1][charIndex+1];
            nw = lines[lineIndex-1][charIndex-1];
            se = lines[lineIndex+1][charIndex+1];
            sw = lines[lineIndex+1][charIndex-1];

            if(ne=='M' && nw=='M' && se=='S' && sw=='S') xmasCount++;
            if(ne=='S' && nw=='M' && se=='S' && sw=='M') xmasCount++;
            if(ne=='M' && nw=='S' && se=='M' && sw=='S') xmasCount++;
            if(ne=='S' && nw=='S' && se=='M' && sw=='M') xmasCount++;
        }
        charIndex++;
    }
    lineIndex++;
}

Console.WriteLine(xmasCount);


/* Part 1

int lineIndex = 0;
int charIndex = 0;
int xmasCount = 0;

foreach(string l in lines)
{
    charIndex = 0;
    foreach(char c in l)
    {
        if(c=='X')
        {
            // right/east
            if(charIndex<=l.Count()-4)
            {
                if(l.Substring(charIndex,4)=="XMAS") xmasCount++;
            }
            // left/west
            if(charIndex>=3)
            {
                if(l.Substring(charIndex-3,4)=="SAMX") xmasCount++; 
            }
            // up/north
            if(lineIndex>=3)
            {
                if(lines[lineIndex-1][charIndex]=='M' && lines[lineIndex-2][charIndex]=='A' && lines[lineIndex-3][charIndex]=='S') xmasCount++;
            }
            // down/south
            if(lineIndex<=lines.Count-4)
            {
                if(lines[lineIndex+1][charIndex]=='M' && lines[lineIndex+2][charIndex]=='A' && lines[lineIndex+3][charIndex]=='S') xmasCount++;
            }
            // up-right/northeast
            if(lineIndex>=3 && charIndex<=l.Count()-4)
            {
                if(lines[lineIndex-1][charIndex+1]=='M' && lines[lineIndex-2][charIndex+2]=='A' && lines[lineIndex-3][charIndex+3]=='S') xmasCount++;
            }
            // up-left/northwest
            if(lineIndex>=3 && charIndex>=3)
            {
                if(lines[lineIndex-1][charIndex-1]=='M' && lines[lineIndex-2][charIndex-2]=='A' && lines[lineIndex-3][charIndex-3]=='S') xmasCount++;
            }
            // down-right/southeast
            if(lineIndex<=lines.Count-4 && charIndex<=l.Count()-4)
            {
                if(lines[lineIndex+1][charIndex+1]=='M' && lines[lineIndex+2][charIndex+2]=='A' && lines[lineIndex+3][charIndex+3]=='S') xmasCount++;
            }
            // down-left/southwest
            if(lineIndex<=lines.Count-4 && charIndex>=3)
            {
                if(lines[lineIndex+1][charIndex-1]=='M' && lines[lineIndex+2][charIndex-2]=='A' && lines[lineIndex+3][charIndex-3]=='S') xmasCount++;
            }
        }
        charIndex++;
    }
    lineIndex++;
}

Console.WriteLine(xmasCount);
*/