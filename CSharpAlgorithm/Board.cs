using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAlgorithm
{
    class MyLinkedListNode<T>
    {
        public T Data;
        public MyLinkedListNode<T> Next;
        public MyLinkedListNode<T> Prev;
    }

    class MyLinkedList<T>
    {
        public MyLinkedListNode<T> Head = null; // 첫번째
        public MyLinkedListNode<T> Tail = null; // 마지막
        public int Count = 0;

        public MyLinkedListNode<T> AddLast(T data)
        {
            MyLinkedListNode<T> newRoom = new MyLinkedListNode<T>();
            newRoom.Data = data;

            // 만약 아직 방이 아예 없었다면, 새로 추가한 첫번째 방이 Head;
            if (Head == null)
                Head = newRoom;
            
            // 기존의 마지막 방과 새로 추가되는 방 연결
            if(Tail != null)
            {
                Tail.Next = newRoom;
                newRoom.Prev = Tail;
            }

            // 새로 추가되는 방을 마지막 방으로 한다.
            Tail = newRoom;
            Count++;
            return newRoom;
        }

        public void Remove(MyLinkedListNode<T> room)
        {
            if (Head == null)
                return;

            // 첫 번째 방의 옆 방을 첫번째 방으로 한다.
            if (Head == room)
                Head = Head.Next;

            // 기존의 마지막 방의 이전 방을 마지막 방으로 한다.
            if (Tail == room)
                Tail = Tail.Prev;

            if (room.Prev != null)
                room.Prev.Next = room.Next;

            if (room.Next != null)
                room.Next.Prev = room.Prev;

            Count--;
        }
    }


   class Board
    {
        public int[] _data = new int[25]; // 배열
        public MyLinkedList<int> _data3 = new MyLinkedList<int>(); // 연결 리스트

        public void Initialize()
        {
            _data3.AddLast(101);
            _data3.AddLast(102);
            MyLinkedListNode<int> node = _data3.AddLast(103);
            _data3.AddLast(104);
            _data3.AddLast(105);

            _data3.Remove(node);

        }
    }
}
