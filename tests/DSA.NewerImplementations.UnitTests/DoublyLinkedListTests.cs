using FluentAssertions;
using DSA.NewerImplementations;

namespace DSA.NewerImplementations.UnitTests;

public class DoublyLinkedListTests
{
    #region Doubly Linked List of type Int32

    #region New empty list

    #region Static methods

    [Fact]
    public void Intersect_GivenArgumentsTwoNewLists_ShouldReturnEmptyList()
    {
        //Given
        DoublyLinkedList<int> newLinkedList = new DoublyLinkedList<int>();
        DoublyLinkedList<int> otherNewLinkedList = new DoublyLinkedList<int>();

        //When
        DoublyLinkedList<int> resultingList = DoublyLinkedList<int>.Intersect(newLinkedList, otherNewLinkedList);
        Boolean flag = resultingList.IsEmpty();

        //Then
        flag.Should().BeTrue();
    }

    [Fact]
    public void Unify_GivenNewListAndArgumentIsNewList_ShouldReturnEmptyList()
    {
        //Given
        DoublyLinkedList<int> newLinkedList = new DoublyLinkedList<int>();
        DoublyLinkedList<int> otherNewLinkedList = new DoublyLinkedList<int>();

        //When
        DoublyLinkedList<int> resultingList = DoublyLinkedList<int>.Unify(newLinkedList, otherNewLinkedList);
        Boolean flag = resultingList.IsEmpty();

        //Then
        flag.Should().BeTrue();
    }

    #endregion Static methods

    [Fact]
    public void New_GivenTypeInt32_ShouldReturnTypeDoublyLinkedListWithTypeInt32()
    {
        //Given
        DoublyLinkedList<int> newLinkedList = new DoublyLinkedList<int>();

        //Then
        Assert.IsType<DoublyLinkedList<int>>(newLinkedList);
    }

    [Fact]
    public void IsEmpty_GivenNewList_ShouldReturnTrue()
    {
        //Given
        DoublyLinkedList<int> newLinkedList = new DoublyLinkedList<int>();

        //When
        Boolean flag = newLinkedList.IsEmpty();

        //Then
        flag.Should().BeTrue();        
    }

    [Fact]
    public void HasDetectedLoop_GivenNewList_ShouldReturnFalse()
    {
        //Given
        DoublyLinkedList<int> newLinkedList = new DoublyLinkedList<int>();

        //When
        Boolean flag = newLinkedList.HasDetectedLoop();

        //Then
        flag.Should().BeFalse();
    }

    [Fact]
    public void PrintAll_GivenNewList_ShouldReturnStringWithEmptyListMessage()
    {
        //Given
        DoublyLinkedList<int> newLinkedList = new DoublyLinkedList<int>();
        String expectedValue = DoublyLinkedList<int>.EmptyListReport;

        //When
        String report = newLinkedList.PrintAll();

        //Then
        report.Should().Be(expectedValue);
    }

    [Fact]
    public void PrintUniqueValues_GivenNewList_ShouldReturnStringWithEmptyListMessage()
    {
        //Given
        DoublyLinkedList<int> newLinkedList = new DoublyLinkedList<int>();
        String expectedValue = DoublyLinkedList<int>.EmptyListReport;

        //When
        String report = newLinkedList.PrintUniqueValues();

        //Then
        report.Should().Be(expectedValue);
    }

    [Fact]
    public void GetLength_GivenNewList_ShouldReturnZero()
    {
        //Given
        DoublyLinkedList<int> newLinkedList = new DoublyLinkedList<int>();
        UInt32 expectedValue = 0;

        //When
        UInt32 report = newLinkedList.GetLength();

        //Then
        report.Should().Be(expectedValue);
    }

    [Fact]
    public void TryRemoveAtHead_GivenNewList_ShouldReturnFalse()
    {
        //Given
        DoublyLinkedList<int> newLinkedList = new DoublyLinkedList<int>();

        //When
        Boolean flag = newLinkedList.TryRemoveAtHead();

        //Then
        flag.Should().BeFalse();
    }

    [Fact]
    public void TryRemoveAtTail_GivenNewList_ShouldReturnFalse()
    {
        //Given
        DoublyLinkedList<int> newLinkedList = new DoublyLinkedList<int>();

        //When
        Boolean flag = newLinkedList.TryRemoveAtTail();

        //Then
        flag.Should().BeFalse();
    }

    [Fact]
    public void TryRemoveFromHead_GivenNewListAndArgumentZero_ShouldReturnFalse()
    {
        //Given
        DoublyLinkedList<int> newLinkedList = new DoublyLinkedList<int>();
        Int32 valueToRemove = 0;

        //When
        Boolean flag = newLinkedList.TryRemoveFromHead(valueToRemove);

        //Then
        flag.Should().BeFalse();
    }

    [Fact]
    public void TryRemoveFromHead_GivenNewListAndArgumentOtherThanZero_ShouldReturnFalse()
    {
        //Given
        DoublyLinkedList<int> newLinkedList = new DoublyLinkedList<int>();
        Int32 valueToRemove = 9;

        //When
        Boolean flag = newLinkedList.TryRemoveFromHead(valueToRemove);

        //Then
        flag.Should().BeFalse();
    }

    [Fact]
    public void TryRemoveFromTail_GivenNewListAndArgumentZero_ShouldReturnFalse()
    {
        //Given
        DoublyLinkedList<int> newLinkedList = new DoublyLinkedList<int>();
        Int32 valueToRemove = 0;

        //When
        Boolean flag = newLinkedList.TryRemoveFromTail(valueToRemove);

        //Then
        flag.Should().BeFalse();
    }

    [Fact]
    public void TryRemoveFromTail_GivenNewListAndArgumentOtherThanZero_ShouldReturnFalse()
    {
        //Given
        DoublyLinkedList<int> newLinkedList = new DoublyLinkedList<int>();
        Int32 valueToRemove = 9;

        //When
        Boolean flag = newLinkedList.TryRemoveFromTail(valueToRemove);

        //Then
        flag.Should().BeFalse();
    }

    [Fact]
    public void TryReverse_GivenNewList_ShouldReturnFalse()
    {
        //Given
        DoublyLinkedList<int> newLinkedList = new DoublyLinkedList<int>();

        //When
        Boolean flag = newLinkedList.TryReverse();

        //Then
        flag.Should().BeFalse();
    }

    [Fact]
    public void TryRemoveDuplicateValues_GivenNewList_ShouldReturnFalse()
    {
        //Given
        DoublyLinkedList<int> newLinkedList = new DoublyLinkedList<int>();

        //When
        Boolean flag = newLinkedList.TryRemoveDuplicateValues();

        //Then
        flag.Should().BeFalse();
    }

    [Fact]
    public void IntersectWith_GivenNewListAndArgumentIsNewList_ShouldReturnEmptyList()
    {
        //Given
        DoublyLinkedList<int> newLinkedList = new DoublyLinkedList<int>();
        DoublyLinkedList<int> otherNewLinkedList = new DoublyLinkedList<int>();

        //When
        DoublyLinkedList<int> resultingList = newLinkedList.IntersectWith(otherNewLinkedList);
        Boolean flag = resultingList.IsEmpty();

        //Then
        flag.Should().BeTrue();
    }

    [Fact]
    public void UnifyWith_GivenNewListAndArgumentIsNewList_ShouldReturnEmptyList()
    {
        //Given
        DoublyLinkedList<int> newLinkedList = new DoublyLinkedList<int>();
        DoublyLinkedList<int> otherNewLinkedList = new DoublyLinkedList<int>();

        //When
        DoublyLinkedList<int> resultingList = newLinkedList.UnifyWith(otherNewLinkedList);
        Boolean flag = resultingList.IsEmpty();

        //Then
        flag.Should().BeTrue();
    }

    #endregion New empty list




    #endregion Doubly Linked List of type Int32
}