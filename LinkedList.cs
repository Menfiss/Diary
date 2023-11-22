using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Diary
{
    internal class LinkedList<T>
    {
        private Node head, tail, current;
        private int count;

        public int Count { get { return count; } }

        public void Add(T item)
        {
            Node node = new Node();
            if (IsEmpty())
            {
                node.Data = item;

                node.Next = head;
                
                tail = node;
                
                head = node;

                current = node;
                
                count++;

                return;
            }

            node.Data = item;

            node.Prev = tail;

            tail.Next = node;
            
            tail = node;
            
            current = node;

            count++;

        }
        public T RemoveCurrent()
        {
            if (IsEmpty())
            {
                MessageBox.Show("Diary is Empty");
                return default(T);
            }
            Node removed = current;

            if (current.Next != null)
            {
                current.Next.Prev = current.Prev;
            }
            else
            {
                tail = current.Prev;
            }

            if (current.Prev != null)
            {
                current.Prev.Next = current.Next;
            }
            else
            {
                head = current.Next;
            }

            current = current.Next != null ? current.Next : current.Prev;

            count--;

            return (T)removed.Data;
        }

        public void Next()
        {
            if (IsEmpty())
            {
                return;
            }
            else if (current.Next != null)
            {
                current = current.Next;
            }
            else
            {
                current = head;
            }
        }
        public void Previous()
        {
            if (IsEmpty())
            {
                return;
            }
            else if(current.Prev != null)
            {
                current = current.Prev;
            }
            else
            {
                current = tail;
            }
        }
        public T GetCurrent()
        {
            return current != null ? current.Data : default(T);
        }
        public T GetFirst()
        {
            return head != null ? head.Data : default(T);
        }
        public bool IsEmpty()
        {
            return count == 0;
        }
        private class Node
        {
            public Node Prev { get; set; }
            public Node Next { get; set; }
            public T Data { get; set; }
        }
    }
}
