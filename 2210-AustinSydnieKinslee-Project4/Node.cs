///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  Project 4 - SuperMarket Simulation
//	File Name:         Node.cs
//	Description:       Contains the node class to use in the Priority Queue
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
/// Namespace of the project
/// </summary>
namespace _2210_AustinSydnieKinslee_Project4
{
    /// <summary>
    /// Class that will holds the values to put into the Priority Queue
    /// </summary>
    /// <typeparam name="T">Any type to be brought in</typeparam>
    public class Node<T> where T: IComparable
    {
        //properties to be used
        public T Item { get; set; }

        public Node<T> Next { get; set; }

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="value">value to be put into the node</param>
        /// <param name="link">the link to the nodes next node</param>
        public Node(T value, Node<T> link)
        {
            //setting those values to the ones being brought in
            Item = value;
            Next = link;
            
        }//end Node

    }//end Node

}//end Namespace
