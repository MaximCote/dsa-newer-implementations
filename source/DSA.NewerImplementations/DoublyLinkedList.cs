namespace DSA.NewerImplementations;

public class DoublyLinkedList<T>
{
    internal class DLLNode<TValue> where TValue : T
    {
        internal TValue Value { get; init; }
        internal DLLNode<TValue>? Previous { get; set; }
        internal DLLNode<TValue>? Next { get; set; }

        public DLLNode(TValue value)
		{
			Value = value;
			Previous = null;
			Next = null;
        }

        public static implicit operator DLLNode<TValue>(TValue value)
        {
            return new(value);
        }
    }

    internal DLLNode<T>? Head { get; private set; }
    internal DLLNode<T>? Tail { get; private set; }

    public DoublyLinkedList()
    {
        Head = null;
        Tail = null;
    }

    public Boolean IsEmpty()
    {
        return 
            Head is null && Tail is null ? 
                true 
            : false;
    }

    public Boolean HasDetectedLoop()
    {
        //Starting from Head
        DLLNode<T>? @slow = Head, @fast = Head;

        while ((@slow is not null) && (@fast is not null) && (@fast.Next is not null))
        {
            @slow = @slow.Next;
            @fast = @fast.Next.Next;

            //If the slow and fast pointers are equal then there is a loop
            if (@slow?.Equals(@fast) ?? false)
            {
                return true;
            }
        }
        //Return false when there is no loop
        return false;
    }

    public Boolean PrintList()
    {
        if (IsEmpty()) {
            Console.WriteLine("List is Empty!");
            return false;
        }

        Console.Write("List : ");

        //Start at Head and traverse the list with next
        DLLNode<T>? @current = Head;        
        while (@current is not null) 
        {
            Console.Write(@current.Value);

            @current = @current.Next;
            if (@current is null)
                break;

            Console.Write(" -> ");
        }

        return true;
    }

    public UInt32 GetLength()
    {
        UInt32 lengthCount = 0;

        if (IsEmpty())
            return lengthCount;

        DLLNode<T>? @current = Head;
        while (@current != null)
        {
            lengthCount++;
            @current = @current.Next;
        }

        return lengthCount;
    }

    public DoublyLinkedList<T> Duplicate()
    {
        DoublyLinkedList<T> duplicatedList = new DoublyLinkedList<T>();

        //Start at Head and traverse the list with next
        DLLNode<T>? @current = this.Head;
        while (duplicatedList.TryInsertAtTail(@current))
        {
            @current = @current?.Next;
        }

        return duplicatedList;
    }

    internal Boolean TryInsertAtHead(T valueToInsert)
    {
        if (valueToInsert is null)
            return false;
        if (GetLength().Equals(UInt32.MaxValue))
            return false;

        return TryInsertAtHead(new DLLNode<T>(valueToInsert));
    }

    internal Boolean TryInsertAtTail(T valueToInsert)
    {
        if (valueToInsert is null)
            return false;
        if (GetLength().Equals(UInt32.MaxValue))
            return false;

        return TryInsertAtTail(new DLLNode<T>(valueToInsert));        
    }

    internal Boolean TryRemoveAtHead()
    {
        if (IsEmpty() || Head is null)
            return false;

        if ((Head.Next?.Equals(Tail) ?? false)) {
            //!!!List mutation!!!
            Tail = Head;
        }
        //!!!List mutation!!!
        Head = Head.Next;
        if (Head?.Previous is null)
            return true;

        //!!!List mutation!!!
        Head.Previous = null;
        return true;
    }

    internal Boolean TryRemoveAtTail()
    {
        if (IsEmpty() || Tail is null)
            return false;

        if ((Tail.Previous?.Equals(Head) ?? false)) {
            //!!!List mutation!!!
            Head = Tail;
        }

        //!!!List mutation!!!
        Tail = Tail.Previous;
        if (Tail?.Previous is null)
            return true;

        //!!!List mutation!!!
        Tail.Next = null;
        return true;
    }

    internal Boolean TryRemoveFromHead(T valueToRemove)
    {
        if (valueToRemove is null)
            return false;
        
        //If list is not empty start at the head
        DLLNode<T>? @current = Head;
        //Traverse and search the list for the value with next
        while (@current is not null)
        {            
            //If the value is found
            if ((@current?.Value?.Equals(valueToRemove) ?? false))
            {
                //If the current node's previous is null, then current node is the head
                if (@current.Previous is null)
                    return TryRemoveAtHead();
                //If the current node's next is null, then current node is the tail
                if (@current.Next is null)
                    return TryRemoveAtTail();

                //Make current node's next previous point to current's previous
                //!!!List mutation!!!
                @current.Next.Previous = @current.Previous;
                //Make current node's previous next point to current's next
                //!!!List mutation!!!
                @current.Previous.Next = @current.Next;

                return true;               
            }

            //Make current node point to current's next
            //It is okay for current or next to be null here
            @current = @current?.Next;
        }

        return false;
    }

    internal Boolean TryRemoveFromTail(T valueToRemove)
    {
        if (valueToRemove is null)
            return false;

        //If list is not empty start at the head
        DLLNode<T>? @current = Tail;
        //Traverse and search the list for the value with previous
        while (@current is not null)
        {
            //If the value is found
            if ((@current?.Value?.Equals(valueToRemove) ?? false))
            {
                //If the current node's next is null, then current node is the tail
                if (@current.Next is null)
                    return TryRemoveAtTail();
                //If the current node's previous is null, then current node is the head
                if (@current.Previous is null)
                    return TryRemoveAtHead();

                //Make current node's next previous point to current's previous
                //!!!List mutation!!!
                @current.Next.Previous = @current.Previous;
                //Make current node's previous next point to current's next
                //!!!List mutation!!!
                @current.Previous.Next = @current.Next;

                return true;
            }

            //Make current node point to current's previous
            //It is okay for current or previous to be null here
            @current = @current?.Previous;
        }

        return false;
    }

    internal Boolean TryReverse()
    {
        //Start at Head and traverse the list with next
        DLLNode<T>? @current = Head;
        DLLNode<T>? @previous = null;
        DLLNode<T>? @next = null;

        //While traversing the list, make the current node's Next point to the previous
        while (@current is not null)
        {
            @next = @current.Next;

            //Reverse the pointers
            //!!!List mutation!!!
            @current.Next = @previous;
            //!!!List mutation!!!
            @current.Previous = @next;

            @previous = @current;
            @current = @next;
        }

        //Make Head point to the last previous
        Head = @previous;

        return true;
    }

    private Boolean TryInsertAtHead(DLLNode<T>? nodeToInsert)
    {
        if (nodeToInsert is null || nodeToInsert.Value is null)
            return false;
        if (GetLength().Equals(UInt32.MaxValue))
            return false;

        //Make the node's Next point to current Head
        //!!!List mutation!!!
        nodeToInsert.Next = Head;

        if (Head is not null)
        {
            //Make current Head's Previous point to the new node
            //!!!List mutation!!!
            Head.Previous = nodeToInsert;
        }

        //Make Head point to the new node
        //!!!List mutation!!!
        Head = nodeToInsert;
        //If Tail points to null make Tail point to Head
        //!!!List mutation!!!
        Tail ??= Head;

        return true;
    }

    private Boolean TryInsertAtTail(DLLNode<T>? nodeToInsert)
    {
        if (nodeToInsert is null || nodeToInsert.Value is null)
            return false;
        if (GetLength().Equals(UInt32.MaxValue))
            return false;

        //Make the node's Previous point to current Tail
        nodeToInsert.Previous = Tail;

        if (Tail is not null)
        {
            //Make current Tail's Next point to new node
            //!!!List mutation!!!
            Tail.Next = nodeToInsert;
        }

        //Make Tail point to the new node
        //!!!List mutation!!!
        Tail = nodeToInsert;
        //If Head points to null make Head point to Tail
        //!!!List mutation!!!
        Head ??= Tail;

        return false;
    }    
}