// Advent of Code 2024 Day 2

using System;
using System.IO;
using System.Collections.Generic;

bool increasing = true;
int safeNum = 0;
int safeNum2 = 0;
var reportList = new List<string[]>();

// fill reportList with a list of arrays of levels (an array of levels is a report)
using (TextReader reader = File.OpenText("L:\\Programming\\Advent\\2\\input2.txt"))
{
    while(reader.Peek() > -1)
    {
        reportList.Add(reader.ReadLine().Split());
    }
}

foreach(string[] report in reportList)
{
    int[] reportInt = new int[report.Count()]; // array for storing reports that are cast to ints
    for(int i=0; i<report.Count(); i++) // cast reports to ints
    {
        reportInt[i] = int.Parse(report[i]);
    }
    bool safe = true;
    for(int i=1; i<reportInt.Count(); i++)
    {
        if(Math.Abs(reportInt[i-1]-reportInt[i])>3 || reportInt[i-1]==reportInt[i]) safe = false; // difference between two levels must be non-zero and not greater than 3
        if(i==1) // first case is unique because the starting direction (increasing or decreasing) matters; the rest of the report must match it
        {
            if(reportInt[i-1]-reportInt[i] < 0) increasing = true; 
            else increasing = false;
        }
        else
        {
            if(reportInt[i-1]-reportInt[i] < 0 && !increasing) safe = false;
            if(reportInt[i-1]-reportInt[i] > 0 && increasing) safe = false;
        }
    }
    if(safe) safeNum++;
    else // Problem Dampener. If removing one level would make the report safe, it counts as safe.
    {
        bool safe2 = true;
        bool increasing2 = true;
        int[] modifiedReportInt = new int[reportInt.Count()-1];
        //Console.WriteLine("-----------------------");
        //foreach(int n in reportInt) Console.Write(n + " ");
        //Console.WriteLine("\n-----------------------");
        for(int i=0; i<reportInt.Count(); i++)
        {
            int k=0;
            safe2=true;
            // fill modifiedReportInt with the values of reportInt except for the value at index i
            for(int j=0; j<modifiedReportInt.Count(); j++)
            {
                if(k==i) k++; // skip index i
                modifiedReportInt[j] = reportInt[k];
                k++;
            }
            // check modifiedReportInt with same logic as above
            for(int f=1; f<modifiedReportInt.Count(); f++)
            {
                if(Math.Abs(modifiedReportInt[f-1]-modifiedReportInt[f])>3 || modifiedReportInt[f-1]==modifiedReportInt[f]) safe2 = false;
                if(f==1)
                {
                    if(modifiedReportInt[f-1]-modifiedReportInt[f] < 0) increasing2 = true; 
                    else increasing2 = false;
                }
                else
                {
                    if(modifiedReportInt[f-1]-modifiedReportInt[f] < 0 && !increasing2) safe2 = false;
                    if(modifiedReportInt[f-1]-modifiedReportInt[f] > 0 && increasing2) safe2 = false;
                }
            }
            if(safe2) 
            {
                safeNum2++;
                //Console.WriteLine("Safe!\n");
                //foreach(int n in modifiedReportInt) Console.Write(n + " ");
                break; // don't count multiple variations of the same report as safe
            }
        }
        //Console.WriteLine("\n");
    }
}

//Console.WriteLine(safeNum);
//Console.WriteLine(safeNum2);
Console.WriteLine(safeNum+safeNum2);