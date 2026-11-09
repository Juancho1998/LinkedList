using Backend;
using System.Collections.Generic;

namespace Backend;

public class DoublyLinkedList<T> where T : IComparable<T>
{
    private DoubleNode<T>? _head;
    private DoubleNode<T>? _tail;

    public DoublyLinkedList()
    {
        _head = null; // This line can be removed
        _tail = null; // This line can be removed
    }

    public void InsertItem(T data)
    {
        var newNode = new DoubleNode<T>(data);
        //When list is null
        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
            return;
        }
        // When new element is less than or equal to first element
        if (data.CompareTo(_head.Data) <= 0)
        {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
            return;
        }
        //When new element is greater than or equal to last element
        if (_tail != null && data.CompareTo(_tail.Data) >= 0)
        {
            _tail.Next = newNode;
            newNode.Prev = _tail;
            _tail = newNode;
            return;
        }
        //When new element is greater than or equal to last element
        var current = _head.Next;
        while (current != null && current.Data!.CompareTo(data) < 0)
        {
            current = current.Next;
        }
        newNode.Next = current;
        newNode.Prev = current!.Prev;
        newNode.Prev!.Next = newNode;
        current.Prev = newNode;

    }

    public void OrderDescending()
    {
        if (_head == null || _head.Next == null)
        {
            return;
        }
        var current = _head;
        DoubleNode<T>? temp = null;

        while (current != null)
        {
            temp = current.Prev;
            current.Prev = current.Next;
            current.Next = temp;
            current = current.Prev;
        }

        temp = _head;
        _head = _tail;
        _tail = temp;
    }

    public List<T> GetModes()
    {
        var modes = new List<T>();

        if (_head == null)
        {
            return modes;
        }
        var counts = new Dictionary<T, int>();
        var current = _head;
        int maxCount = 0;

        while (current != null)
        {
            if (current.Data == null)
            {
                current = current.Next;
                continue;
            }
            if (counts.ContainsKey(current.Data))
            {
                counts[current.Data]++;
            }
            else
            {
                counts[current.Data] = 1;
            }

            if (counts[current.Data] > maxCount)
            {
                maxCount = counts[current.Data];
            }
            current = current.Next;
        }

        foreach (var mode in counts)
        {
            if (mode.Value == maxCount)
            {
                modes.Add(mode.Key);
            }
        }
        return modes;
    }

    public string GetGraph()
    {
        if (_head == null)
        {
            return "La lista esta vacía.";
        }

        var counts = new Dictionary<T, int>();
        var current = _head;

        while (current != null)
        {
            if (current.Data != null)
            {
                if (counts.ContainsKey(current.Data))
                {
                    counts[current.Data]++;
                }
                else
                {
                    counts[current.Data] = 1;
                }
            }
            current = current.Next;
        }
        var output = string.Empty;

        foreach (var amount in counts)
        {
            var asterisks = new string('*', amount.Value);
            output += $"{amount.Key} {asterisks}\n";
        }
        return output.TrimEnd();
    }


    public bool Exists(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public bool RemoveOccurrence(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data != null && current.Data.Equals(data))
            {
                if (_head == _tail)
                {
                    _head = null;
                    _tail = null;
                    return true;
                }
                if (current == _head)
                {
                    _head = _head.Next;
                    _head!.Prev = null;
                    return true;
                }
                if (current == _tail)
                {
                    _tail = _tail.Prev;
                    _tail!.Next = null;
                    return true;
                }

                current.Prev!.Next = current.Next;
                current.Next!.Prev = current.Prev;
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public bool RemoveAllOccurrence(T data)
    {
        var current = _head;
        bool wasRemoved = false;

        while (current != null)
        {
            var nextNode = current.Next;

            if (current.Data != null && current.Data.Equals(data))
            {
                if (_head == _tail)
                {
                    _head = null;
                    _tail = null;
                }
                else if (current == _head)
                {
                    _head = _head.Next;
                    _head!.Prev = null;
                }
                else if (current == _tail)
                {
                    _tail = _tail.Prev;
                    _tail!.Next = null;
                }
                else
                {
                    current.Prev!.Next = current.Next;
                    current.Next!.Prev = current.Prev;
                }
                wasRemoved = true;
            }
            current = nextNode;
        }
        return wasRemoved;
    }

    public override string ToString()
    {
        var output = string.Empty;
        var current = _head;
        while (current != null)
        {
            output += $"{current.Data}, ";
            current = current.Next;
        }
        return output;
    }

    public string ToStringReverse()
    {
        var output = string.Empty;
        var current = _tail;
        while (current != null)
        {
            output += $"{current.Data}, ";
            current = current.Prev;
        }
        return output;
    }
}