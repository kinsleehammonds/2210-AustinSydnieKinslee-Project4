///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  Project 4 - SuperMarket Simulation
//	File Name:         IPriorityQueue.cs
//	Description:       Contains the interface for the priority queue
//	Course:            CSCI 2210 - Data Structures	
//	Author:            Austin Hamilton, hamiltonaj@etsu.edu, Dept. of Computing, East Tennessee State University
//                     Sydnie Dery, derysf@etsu.edu, Dept. of Computing, East Tennessee State University
//                     Kinslee Hammonds, hammondsk1@etsu.edu, Dept. of Computing, East Tennessee State University
//	Created:           Monday, November 22, 2021
//	Copyright:         Austin Hamilton, Sydnie Dery, Kinslee Hammonds, 2021
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// The namespace for the project
/// </summary>
namespace _2210_AustinSydnieKinslee_Project4
{
    /// <summary>
    /// Interface to implement into the Priority class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IPriorityQueue<T> : IContainer<T> where T: IComparable
    {
        //methods to be overriden
        void Enqueue(T item);
        void Dequeue();
        T Peek();

    }//end IPriorityQueue

}//end namespace
