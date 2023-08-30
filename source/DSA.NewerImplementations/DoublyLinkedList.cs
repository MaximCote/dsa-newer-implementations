
namespace DSA.NewerImplementations;

public sealed class DoublyLinkedList<T>
{
    private sealed class DLLNode<TValue> where TValue : T
    {
        public TValue Value { get; internal init; }
        internal DLLNode<TValue>? Previous { get; set; }
        internal DLLNode<TValue>? Next { get; set; }

        internal DLLNode(TValue value)
        {
			Value = value;
			Previous = null;
			Next = null;
        }
    }

    public const String EmptyListReport = "List is Empty!";

    private DLLNode<T>? Head { get; set; }
    private DLLNode<T>? Tail { get; set; }

    #region Constructors
    public DoublyLinkedList()
    {
        Head = null;
        Tail = null;
    }
    internal DoublyLinkedList(T headValue, T tailValue)
    {
        //Make Head point to the new node
        Head = new DLLNode<T>(headValue);        
        //Make Tail point to the new node
        Tail = new DLLNode<T>(tailValue);

        //Make the Head Next point to current Tail
        Head.Next = Tail;
        //Make the Tail Previous point to current Head
        Tail.Previous = Head;
    }
    internal DoublyLinkedList(T headValue, T linkedValue, T tailValue)
    {
        //Make Head point to the new node
        Head = new DLLNode<T>(headValue);
        //Make Tail point to the new node
        Tail = new DLLNode<T>(tailValue);

        DLLNode<T> linkedNode = new DLLNode<T>(linkedValue);

        Head.Next = linkedNode;
        linkedNode.Previous = Head;
        linkedNode.Next = Tail;
        Tail.Previous = linkedNode;
    }
    #endregion Constructors

    #region Public methods
    /// <remarks>
    ///     No self mutation.
    /// </remarks>
    public Boolean IsEmpty()
    {
        return 
            Head is null && Tail is null ? 
                true 
            : false;
    }

    /// <remarks>
    ///     No self mutation.
    /// </remarks>
    public Boolean HasDetectedLoop()
    {
        DLLNode<T>? @current = Head;
        DLLNode<T>? @further = null;

        //Traverse the list
        while ((@current is not null) && (@current.Next is not null))
        {
            @further = @current.Next;

            //Traverse the list further from current
            while (@further is not null)
            {
                //If a duplicate value is found
                if (@current.Equals(@further.Next))
                    return true;                
                else                
                    @further = @further.Next;                
            }

            @current = @current.Next;
        }

        //Return false when there is no loop
        return false;
    }

    /// <remarks>
    ///     No self mutation.
    /// </remarks>
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

    /// <remarks>
    ///     No self mutation.
    /// </remarks>
    public String PrintAll()
    {
        if (IsEmpty()) {
            return EmptyListReport;
        }

        String report = String.Empty;

        //Start at Head and traverse the list with next
        DLLNode<T>? @current = Head;        
        while (@current is not null) 
        {
            report += $"{@current.Value}";

            @current = @current.Next;
            if (@current is null)
                break;

            report += $" -> ";
        }

        return report;
    }

    /// <remarks>
    ///     No self mutation.
    /// </remarks>
    public String PrintUniqueValues()
    {
        if (IsEmpty())
        {
            return EmptyListReport;
        }

        DoublyLinkedList<T> duplicatedList;
        duplicatedList = this.Duplicate();
        duplicatedList.TryRemoveDuplicateValues();

        String report = duplicatedList.PrintAll();

        return report;
    }    

    /// <remarks>
    ///     No self mutation.
    /// </remarks>
    public DoublyLinkedList<T> Duplicate()
    {
        DoublyLinkedList<T> duplicatedList = new DoublyLinkedList<T>();

        //Start at Head and traverse the list with next
        DLLNode<T>? @current = this.Head;
        while (@current is not null && duplicatedList.TryInsertAtTail(@current.Value))
        {
            @current = @current?.Next;
        }

        return duplicatedList;
    }
    #endregion Public methods

    #region Internal methods
    /// <remarks>
    ///     Possibly mutate <see langword="this object"/>.
    /// </remarks>
    internal Boolean TryInsertAtHead(T valueToInsert)
    {
        if (valueToInsert is null)
            return false;
        if (GetLength().Equals(UInt32.MaxValue))
            return false;

        return TryInsertAtHead(new DLLNode<T>(valueToInsert));
    }

    /// <remarks>
    ///     Possibly mutate <see langword="this object"/>.
    /// </remarks>
    internal Boolean TryInsertAtTail(T valueToInsert)
    {
        if (valueToInsert is null)
            return false;
        if (GetLength().Equals(UInt32.MaxValue))
            return false;

        return TryInsertAtTail(new DLLNode<T>(valueToInsert));        
    }

    /// <remarks>
    ///     Possibly mutate <see langword="this object"/>.
    /// </remarks>
    internal Boolean TryRemoveAtHead()
    {
        if (IsEmpty() || Head is null)
            return false;

        if ((Head.Next?.Equals(Tail) ?? false)) {
            //!!!In-place self mutation!!!
            Tail = Head;
        }
        //!!!In-place self mutation!!!
        Head = Head.Next;
        if (Head?.Previous is null)
            return true;

        //!!!In-place self mutation!!!
        Head.Previous = null;
        return true;
    }

    /// <remarks>
    ///     Possibly mutate <see langword="this object"/>.
    /// </remarks>
    internal Boolean TryRemoveAtTail()
    {
        if (IsEmpty() || Tail is null)
            return false;

        if ( Tail.Equals(Head) ) 
        {
            //!!!In-place self mutation!!!
            Head = null;
        }
        else if ( Tail.Previous?.Equals(Head) ?? false )
        {
            //!!!In-place self mutation!!!
            Head.Next = null;
        }
        else if ( Tail.Previous is not null )
        {
            //!!!In-place self mutation!!!
            Tail.Previous.Next = null;            
        }

        Tail = Tail.Previous;
        return true;
    }

    /// <remarks>
    ///     Possibly mutate <see langword="this object"/>.
    /// </remarks>
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
                //!!!In-place self mutation!!!
                @current.Next.Previous = @current.Previous;
                //Make current node's previous next point to current's next
                //!!!In-place self mutation!!!
                @current.Previous.Next = @current.Next;

                return true;               
            }

            //Make current node point to current's next
            //It is okay for current or next to be null here
            @current = @current?.Next;
        }

        return false;
    }

    /// <remarks>
    ///     Possibly mutate <see langword="this object"/>.
    /// </remarks>
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
                //!!!In-place self mutation!!!
                @current.Next.Previous = @current.Previous;
                //Make current node's previous next point to current's next
                //!!!In-place self mutation!!!
                @current.Previous.Next = @current.Next;

                return true;
            }

            //Make current node point to current's previous
            //It is okay for current or previous to be null here
            @current = @current?.Previous;
        }

        return false;
    }

    /// <remarks>
    ///     Possibly mutate <see langword="this object"/>.
    /// </remarks>
    internal Boolean TryReverse()
    {
        if (this.IsEmpty())
            return false;

        DLLNode<T>? headBeforeReversal = Head;

        //Start at Head and traverse the list with next
        DLLNode<T>? @current = Head;
        DLLNode<T>? @previous = null;
        DLLNode<T>? @next = null;

        //Traverse the list
        while (@current is not null)
        {
            @next = @current.Next;

            //Reverse the pointers
            //!!!In-place self mutation!!!
            @current.Next = @previous;
            //!!!In-place self mutation!!!
            @current.Previous = @next;

            @previous = @current;
            //Move current next towards Tail
            @current = @next;
        }

        //Make Head point to the last previous
        Head = @previous;
        Tail = headBeforeReversal;

        return true;
    }
    
    /// <remarks>
    ///     Possibly mutate <see langword="this object"/>.
    /// </remarks>
    internal Boolean TryRemoveDuplicateValues()
    {
        if (this.IsEmpty())
            return false;

        Boolean duplicateFound = false;
        Boolean duplicateRemoved = false;

        DLLNode<T>? @current = Head;
        DLLNode<T>? @further = null;

        //Traverse the list
        while ((@current is not null) && (@current.Next is not null))
        {
            @further = @current.Next;

            //Traverse the list further from current
            while (@further is not null)
            {
                //If a duplicate value is found
                if (@current.Value?.Equals(@further.Value) ?? false)
                {
                    duplicateFound = true;

                    if (@further.Equals(Tail) && (@further.Next is null))
                    {
                        //If further node's Next is null then further points to Tail
                        //Remove the node with the duplicated value at Tail
                        duplicateRemoved = TryRemoveAtTail();
                    }
                    else if (@further.Next is not null && @further.Previous is not null)
                    {
                        //Remove the node that is most towards the Tail
                        //Make further node's Next Previous point to further's Previous
                        //!!!In-place self mutation!!!
                        @further.Next.Previous = @further.Previous;
                        //Make further node's Previous Next point to further's Next
                        //!!!In-place self mutation!!!
                        @further.Previous.Next = @further.Next;

                        duplicateRemoved = true;
                    }
                }

                @further = @further.Next;
            }

            @current = @current.Next;
        }

        return duplicateFound && duplicateRemoved;
    }

    /// <remarks>
    ///     No self mutation.
    /// </remarks>
    internal DoublyLinkedList<T> IntersectWith(DoublyLinkedList<T> other)
    {
        DoublyLinkedList<T> intersectedList = new DoublyLinkedList<T>();

        if (other.IsEmpty())
            return intersectedList;

        DoublyLinkedList<T> duplicatedList = this.Duplicate();

        //Starting from Head
        DLLNode<T>? @left = duplicatedList.Head;
        DLLNode<T>? @right = other.Head;

        //Traverse the orginial list
        while (@left is not null)
        {
            //Traverse the other list
            while (@right is not null)
            {
                //If a value match both nodes' value
                if (@left.Value?.Equals(@right.Value) ?? false)
                    intersectedList.TryInsertAtTail(@left.Value);

                @right = @right.Next;
            }
            //Reset right to the other Head
            @right = other.Head;
            //Move left next towards Tail
            @left = @left.Next;
        }

        intersectedList.TryRemoveDuplicateValues();
        return intersectedList;
    }

    /// <remarks>
    ///     No self mutation.
    /// </remarks>
    internal DoublyLinkedList<T> UnifyWith(DoublyLinkedList<T> other)
    {
        DoublyLinkedList<T> unifiedList = this.Duplicate();

        if (other.IsEmpty())
            return unifiedList;

        //Starting from Head
        DLLNode<T>? @current = unifiedList.Head;

        if (unifiedList.IsEmpty() && @current is null )
        {
            //Make current point to the other Head
            @current = other.Head;
            //Make Tail point to the other Tail
            unifiedList.Tail = other.Tail;
            unifiedList.TryRemoveDuplicateValues();

            return unifiedList;
        }

        //Traverse list until current is Tail
        while (@current?.Next is not null)
        {
            @current = @current.Next;
        }

        if (@current is not null && other.Head is not null)
        {
            //Make current Next point to the other Head
            @current.Next = other.Head;
            //Make other Head Previous point to current
            other.Head.Previous = @current;
        }

        unifiedList.Tail = other.Tail;
        
        unifiedList.TryRemoveDuplicateValues();

        return unifiedList;
    }
    #endregion Internal methods

    #region Private methods
    /// <remarks>
    ///     Possibly mutate <see langword="this object"/>.
    /// </remarks>
    private Boolean TryInsertAtHead(DLLNode<T>? nodeToInsert)
    {
        if (nodeToInsert is null || nodeToInsert.Value is null)
            return false;
        if (GetLength().Equals(UInt32.MaxValue))
            return false;

        //Make the node's Next point to current Head
        //!!!In-place self mutation!!!
        nodeToInsert.Next = Head;

        if (Head is not null)
        {
            //Make current Head's Previous point to the new node
            //!!!In-place self mutation!!!
            Head.Previous = nodeToInsert;
        }

        //Make Head point to the new node
        //!!!In-place self mutation!!!
        Head = nodeToInsert;
        //If Tail points to null make Tail point to Head
        //!!!In-place self mutation!!!
        Tail ??= Head;

        return true;
    }

    /// <remarks>
    ///     Possibly mutate <see langword="this object"/>.
    /// </remarks>
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
            //!!!In-place self mutation!!!
            Tail.Next = nodeToInsert;
        }

        //Make Tail point to the new node
        //!!!In-place self mutation!!!
        Tail = nodeToInsert;
        //If Head points to null make Head point to Tail
        //!!!In-place self mutation!!!
        Head ??= Tail;

        return true;
    }
    #endregion Private methods

    #region Static methods
    /// <remarks>
    ///     No self mutation.
    /// </remarks>
    public static DoublyLinkedList<T> Duplicate(DoublyLinkedList<T> list)
    {
        DoublyLinkedList<T> duplicatedList = new DoublyLinkedList<T>();

        //Start at Head and traverse the list with next
        DLLNode<T>? @current = list.Head;
        while (duplicatedList.TryInsertAtTail(@current))
        {
            @current = @current?.Next;
        }

        return duplicatedList;
    }

    /// <remarks>
    ///     No self mutation.
    /// </remarks>
    public static DoublyLinkedList<T> Intersect(DoublyLinkedList<T> left, DoublyLinkedList<T> right)
    {
        DoublyLinkedList<T> intersectedList = new DoublyLinkedList<T>();

        if (left.IsEmpty() && right.IsEmpty())
            return intersectedList;
        else if (left.IsEmpty())
            return right;
        else if (right.IsEmpty())
            return left;

        intersectedList = left;
        intersectedList = intersectedList.IntersectWith(right);
        return intersectedList;
    }

    /// <remarks>
    ///     No self mutation.
    /// </remarks>
    public static DoublyLinkedList<T> Unify(DoublyLinkedList<T> left, DoublyLinkedList<T> right)
    {
        DoublyLinkedList<T> unifiedList = new DoublyLinkedList<T>();

        if (left.IsEmpty() && right.IsEmpty())
            return unifiedList;
        else if (left.IsEmpty())
            return right;
        else if (right.IsEmpty())
            return left;

        unifiedList = left;
        unifiedList = unifiedList.UnifyWith(right);
        return unifiedList;
    }
    #endregion Static methods
}