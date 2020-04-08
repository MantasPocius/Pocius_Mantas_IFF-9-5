using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pocius_Mantas_IFF_9_5
{
    public sealed class MyList
    {
        private MyNode head;
        private MyNode tail;
        private MyNode iterator;
        private int _count { get; set; }

        public MyList()
        {
            this.head = null;
        }

        public MyList(Module data)
        {
            MyNode node = new MyNode(data);
            this.head = node;
            this.tail = node;
        }

        public MyList(MyNode node)
        {
            this.head = node;
            this.tail = node;
        }

        public void Add(Module data)
        {
            MyNode node = new MyNode(data);
            //Empty
            if (this.head == null)
            {
                this.head = node;
                this.tail = node;
            }
            //Not empty
            else
            {
                tail.Link = node;
                tail = node;
            }
            this._count++;
        }

        public void Add(MyNode node)
        {
            Add(node.Data);
        }

        public void Begin()
        {
            this.iterator = this.head;
        }

        public bool Contains(Module one)
        {
            for (MyNode d = head; d != null; d = d.Link)
            {
                if (d.Data.Equals(one)) return true;
            }
            return false;
        }

        public int Count() => this._count;

        public void Dispose()
        {
            while (head != null)
            {
                MyNode iterator = head;
                head = head.Link;
                iterator = null;
            }
            head = null;
            tail = null;
            this._count = 0;
        }

        public bool Exist() => iterator != null;

        public void Insert(Module one, int index)
        {
            MyNode prior = null;
            var node = new MyNode(one);
            if (index == 0)//If insert as first
            {
                node.Link = head;
                head = node;
                this._count++;
                return;
            }
            if (index > _count)//If insert as last
            {
                Add(node);
            }
            int i = 0;
            for (Begin(); Exist(); Next())
            {
                if (i < index - 1)
                {
                    prior = iterator;
                }
                i++;
            }
            node.Link = prior.Link;
            prior.Link = node;
            this._count++;
        }

        public Module Get()
        {
            return iterator.Data;
        }

        public Module Find(Func<Module, bool> query)
        {
            for (Begin(); Exist(); Next())
            {
                if (query(Get())) return Get();
            }
            return default(Module);
        }

        private MyNode FindNode(Module one)
        {
            for (MyNode d = head; d != null; d = d.Link)
            {
                if (d.Data.Equals(one)) return d;
            }
            return null;
        }

        private MyNode FindNodeBefore(MyNode current)
        {
            if (current == this.head) return null;
            MyNode result;
            for (result = head; result.Link != current; result = result.Link) ;
            return result;
        }

        public void Next()
        {
            iterator = iterator.Link;
        }

        public void Remove(Module one)
        {
            if (!Contains(one)) return;
            if (_count == 1) // If removing only element, dispose.
            {
                Dispose();
                _count--;
                Begin();
                return;
            }
            var node = FindNode(one);
            var nodePrior = FindNodeBefore(node);
            var nodeFollowing = node?.Link;
            node.Link = null;
            if (nodePrior != null) // If removing first element, following becomes head.
            {
                nodePrior.Link = nodeFollowing;
            }
            else
            {
                head = nodeFollowing;
            }
            if (nodeFollowing == null)// If removing last element, prior becomes tail.
            {
                tail = nodePrior;
            }
            _count--;
            Begin();
        }

        public void Sort()
        {
            for (MyNode a = head; a?.Link != null; a = a.Link)
            {
                for (MyNode b = a.Link; b != null; b = b.Link)
                {
                    if (a.Data.CompareTo(b.Data) == -1)
                    {
                        Swap(a, b);
                    }
                }
            }
        }

        private void Swap(MyNode a, MyNode b)
        {
            Module tempData = a.Data;
            a.Data = b.Data;
            b.Data = tempData;
        }
    }
}