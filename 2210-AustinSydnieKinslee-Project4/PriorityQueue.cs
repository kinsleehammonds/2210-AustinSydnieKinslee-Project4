///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  Project 4 - SuperMarket Simulation
//	File Name:         IPriorityQueue.cs
//	Description:       Contains to calsses and enum and regular Event class. 
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
/// The namespace of the project
/// </summary>
namespace _2210_AustinSydnieKinslee_Project4
{
    /// <summary>
    /// Priority Queue to bubble up the compared objects
    /// </summary>
    /// <typeparam name="T">The class being used</typeparam>
    public class PriorityQueue<T> : IPriorityQueue<T> where T : IComparable
    {
        //helping properties
        private Node<T> top;                       
        public int Count { get; set; }
       
        /// <summary>
        /// Adds item to the priority queue
        /// </summary>
        /// <param name="item">item being brought in</param>
        public void Enqueue(T item)
        {
            //if pq empty than add a new node
            if(Count == 0)
            {
                //sets the node to that value
                top = new Node<T>(item, null);
            }
            else
            {
                
                Node<T> current = top;
                Node<T> previous = null;

                //serach for the first node in the linked structure that is smaller than the item
                while (current != null && current.Item.CompareTo(item) >= 0)
                {
                    previous = current;
                    current = current.Next;

                }//end while

                //have found the place to insert the new node
                Node<T> newNode = new Node<T>(item, current);
                
                //if there is a previous node, set it to link to the new node
                if(previous != null)
                {
                    previous.Next = newNode;
                }
                else
                {
                    top = newNode;

                }//end if else

            }

            Count++; //add 1 to the number of nodes in the pq

        }//end Enqueue


        /// <summary>
        /// Takes away the first item in the pq
        /// </summary>
        public void Dequeue()
        {
            //cannot remove item form pq
            if (IsEmpty())
            {
                //throw exception
                throw new InvalidOperationException("Cannot remove from an empty priority queue.");
            }
            else
            {
                //else remove top node and decrement count
                Node<T> oldNode = top;
                top = top.Next;
                Count--;
                oldNode = null; // do this so the removed node can be garbage collected

            }//end if else

        }//end Dequeue

        /// <summary>
        /// Clears the pq
        /// </summary>
        public void Clear()
        {
            top = null;     //nodes will be garbage collected
            Count = 0;      //count to zero because there are no nodes

        }//end clear

        /// <summary>
        /// Returns the top value in the pq
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            //if it is not empty
            if (!IsEmpty())
            {
                //return the top item
                return top.Item;
            }
            else
            {
                //else throw and exception
                throw new InvalidOperationException("Cannot obtain top of empty priority queue.");

            }//end if else

        }//end Peek

        /// <summary>
        /// Returns if the pq is empty of not
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            //returns true if count is 0
            return Count == 0;

        }//end isEmpty

    }//end PriorityQueue

}//end Namespace
