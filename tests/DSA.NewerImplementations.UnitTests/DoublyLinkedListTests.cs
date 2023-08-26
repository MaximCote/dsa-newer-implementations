using FluentAssertions;
using DSA.NewerImplementations;
using System.Collections.Generic;

namespace DSA.NewerImplementations.UnitTests;

public class DoublyLinkedListTests
{
    #region Seed constants
    
    #region Integer constants
    public const Int32 firstIntegerSeed = 1;
    public const Int32 secondIntegerSeed = 2;
    public const Int32 thirdIntegerSeed = 3;
    public const Int32 fourthIntegerSeed = 7;
    public const Int32 fifthIntegerSeed = 8;
    public const Int32 sixthIntegerSeed = 9;
    #endregion Integer constants

    #region String constants
    public const String firstStringSeed = "one";
    public const String secondStringSeed = "two";
    public const String thirdStringSeed = "three";
    public const String fourthStringSeed = "seven";
    public const String fifthStringSeed = "eight";
    public const String sixthStringSeed = "nine";
    #endregion String constants

    #endregion Seed constants

    private DoublyLinkedList<Int32> _SeededIntList = new ();
    private DoublyLinkedList<String> _SeededStringList = new ();

    private String _SeededPrintAllExpectedValues = String.Empty;

    public DoublyLinkedListTests()
    {
        //Seed an object with the contained type of Int32
        //Seed by inserting at Head
        _SeededIntList.TryInsertAtHead(firstIntegerSeed);
        _SeededIntList.TryInsertAtHead(secondIntegerSeed);
        _SeededIntList.TryInsertAtHead(thirdIntegerSeed);
        //Seed by inserting at Tail
        _SeededIntList.TryInsertAtTail(fourthIntegerSeed);
        _SeededIntList.TryInsertAtTail(fifthIntegerSeed);
        _SeededIntList.TryInsertAtTail(sixthIntegerSeed);
        //
        _SeededPrintAllExpectedValues = 
            $"{thirdIntegerSeed} -> {secondIntegerSeed} -> {firstIntegerSeed}"
            + $" -> " 
            + $"{fourthIntegerSeed} -> {fifthIntegerSeed} -> {sixthIntegerSeed}";

        //Seed an object with the contained type of String
        //Seed by inserting at Head
        _SeededStringList.TryInsertAtHead(firstStringSeed);
        _SeededStringList.TryInsertAtHead(secondStringSeed);
        _SeededStringList.TryInsertAtHead(thirdStringSeed);

        //Seed by inserting at Tail
        _SeededStringList.TryInsertAtTail(fourthStringSeed);
        _SeededStringList.TryInsertAtTail(fifthStringSeed);
        _SeededStringList.TryInsertAtTail(sixthStringSeed);
    }

    #region Doubly Linked List of type Int32

    #region New empty list

    #region Static methods
    [Fact]
    public void StaticDuplicate_ContainedTypeInt32_GivenNewList_ShouldReturnAnotherNewList()
    {
        //Given
        DoublyLinkedList<int> newLinkedList = new DoublyLinkedList<int>();

        //When
        DoublyLinkedList<int> resultingList = DoublyLinkedList<int>.Duplicate(newLinkedList);
        String resultingListPrintOutput = resultingList.PrintAll();

        //Then
        resultingList.Should().NotBeNull();
        resultingList.Should().NotBe(newLinkedList);
        resultingListPrintOutput.Should().NotBeNullOrEmpty();
        resultingListPrintOutput.Should().Be(DoublyLinkedList<int>.EmptyListReport);
    }

    [Fact]
    public void Intersect_ContainedTypeInt32_GivenArgumentsTwoNewLists_ShouldReturnEmptyList()
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
    public void Unify_ContainedTypeInt32_GivenNewListAndArgumentIsNewList_ShouldReturnEmptyList()
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
    public void New_ContainedTypeInt32_GivenTypeInt32_ShouldReturnTypeDoublyLinkedListWithTypeInt32()
    {
        //Given
        DoublyLinkedList<int> newLinkedList = new DoublyLinkedList<int>();

        //Then
        Assert.IsType<DoublyLinkedList<int>>(newLinkedList);
    }

    [Fact]
    public void IsEmpty_ContainedTypeInt32_GivenNewList_ShouldReturnTrue()
    {
        //Given
        DoublyLinkedList<int> newLinkedList = new DoublyLinkedList<int>();

        //When
        Boolean flag = newLinkedList.IsEmpty();

        //Then
        flag.Should().BeTrue();        
    }

    [Fact]
    public void HasDetectedLoop_ContainedTypeInt32_GivenNewList_ShouldReturnFalse()
    {
        //Given
        DoublyLinkedList<int> newLinkedList = new DoublyLinkedList<int>();

        //When
        Boolean flag = newLinkedList.HasDetectedLoop();

        //Then
        flag.Should().BeFalse();
    }

    [Fact]
    public void PrintAll_ContainedTypeInt32_GivenNewList_ShouldReturnStringWithEmptyListMessage()
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
    public void PrintUniqueValues_ContainedTypeInt32_GivenNewList_ShouldReturnStringWithEmptyListMessage()
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
    public void GetLength_ContainedTypeInt32_GivenNewList_ShouldReturnZero()
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
    public void TryRemoveAtHead_ContainedTypeInt32_GivenNewList_ShouldReturnFalse()
    {
        //Given
        DoublyLinkedList<int> newLinkedList = new DoublyLinkedList<int>();

        //When
        Boolean flag = newLinkedList.TryRemoveAtHead();

        //Then
        flag.Should().BeFalse();
    }

    [Fact]
    public void TryRemoveAtTail_ContainedTypeInt32_GivenNewList_ShouldReturnFalse()
    {
        //Given
        DoublyLinkedList<int> newLinkedList = new DoublyLinkedList<int>();

        //When
        Boolean flag = newLinkedList.TryRemoveAtTail();

        //Then
        flag.Should().BeFalse();
    }

    [Fact]
    public void TryRemoveFromHead_ContainedTypeInt32_GivenNewListAndArgumentZero_ShouldReturnFalse()
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
    public void TryRemoveFromHead_ContainedTypeInt32_GivenNewListAndArgumentOtherThanZero_ShouldReturnFalse()
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
    public void TryRemoveFromTail_ContainedTypeInt32_GivenNewListAndArgumentZero_ShouldReturnFalse()
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
    public void TryRemoveFromTail_ContainedTypeInt32_GivenNewListAndArgumentOtherThanZero_ShouldReturnFalse()
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
    public void TryReverse_ContainedTypeInt32_GivenNewList_ShouldReturnFalse()
    {
        //Given
        DoublyLinkedList<int> newLinkedList = new DoublyLinkedList<int>();

        //When
        Boolean flag = newLinkedList.TryReverse();

        //Then
        flag.Should().BeFalse();
    }

    [Fact]
    public void TryRemoveDuplicateValues_ContainedTypeInt32_GivenNewList_ShouldReturnFalse()
    {
        //Given
        DoublyLinkedList<int> newLinkedList = new DoublyLinkedList<int>();

        //When
        Boolean flag = newLinkedList.TryRemoveDuplicateValues();

        //Then
        flag.Should().BeFalse();
    }

    [Fact]
    public void IntersectWith_ContainedTypeInt32_GivenNewListAndArgumentIsNewList_ShouldReturnEmptyList()
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
    public void UnifyWith_ContainedTypeInt32_GivenNewListAndArgumentIsNewList_ShouldReturnEmptyList()
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

    #region Seeded list

    #region Static methods
    [Fact]
    public void StaticDuplicate_ContainedTypeInt32_GivenArgumentListWithValues_ShouldReturnNewListWithEqualValues()
    {
        //Given
        DoublyLinkedList<int> seededObject = _SeededIntList;
        String listToDuplicatePrintOutput = seededObject.PrintAll();

        //When
        DoublyLinkedList<int> resultingList = DoublyLinkedList<int>.Duplicate(seededObject);
        String resultingListPrintOutput = resultingList.PrintAll();

        //Then
        resultingList.Should().NotBeNull();
        resultingListPrintOutput.Should().BeEquivalentTo(listToDuplicatePrintOutput);
    }

    [Fact]
    public void StaticIntersect_ContainedTypeInt32_GivenArgumentsTwoListsWithNoValueOverlap_ShouldReturnEmptyList()
    {
        //Given
        DoublyLinkedList<int> duplicatedSeededObject = DoublyLinkedList<int>.Duplicate(_SeededIntList);
        DoublyLinkedList<int> otherList = new DoublyLinkedList<int>();
        otherList.TryInsertAtHead(6);
        otherList.TryInsertAtHead(5);
        otherList.TryInsertAtHead(4);

        //When
        DoublyLinkedList<int> resultingList = DoublyLinkedList<int>.Intersect(duplicatedSeededObject, otherList);
        Boolean flag = resultingList.IsEmpty();

        //Then
        flag.Should().BeTrue();
    }

    [Fact]
    public void StaticUnify_ContainedTypeInt32_GivenSeededListAndArgumentIsListWithNoValueOverlap_ShouldReturnConcatenatedList()
    {
        //Given
        DoublyLinkedList<int> duplicatedSeededObject = DoublyLinkedList<int>.Duplicate(_SeededIntList);
        DoublyLinkedList<int> otherList = new DoublyLinkedList<int>();
        otherList.TryInsertAtHead(6);
        otherList.TryInsertAtHead(5);
        otherList.TryInsertAtHead(4);
        String duplicatedSeededObjectPrintOutput = duplicatedSeededObject.PrintAll();
        String otherListPrintOutput = otherList.PrintAll();

        //When
        DoublyLinkedList<int> resultingList = DoublyLinkedList<int>.Unify(duplicatedSeededObject, otherList);
        String resultingListPrintOutput = resultingList.PrintAll();

        //Then
        resultingListPrintOutput.Should().Be(duplicatedSeededObjectPrintOutput + $" -> " + otherListPrintOutput);
    }
    #endregion Static methods

    [Fact]
    public void IsEmpty_ContainedTypeInt32_GivenSeededList_ShouldReturnFalse()
    {
        //Given
        DoublyLinkedList<int> seededObject = _SeededIntList;

        //When
        Boolean flag = seededObject.IsEmpty();

        //Then
        flag.Should().BeFalse();
    }

    [Fact]
    public void HasDetectedLoop_ContainedTypeInt32_GivenSeededListWithNoLoop_ShouldReturnFalse()
    {
        //Given
        DoublyLinkedList<int> seededObject = _SeededIntList;

        //When
        Boolean flag = seededObject.HasDetectedLoop();

        //Then
        flag.Should().BeFalse();
    }

    [Fact]
    public void PrintAll_ContainedTypeInt32_GivenSeededList_ShouldReturnStringWithAllSeededValues()
    {
        //Given
        DoublyLinkedList<int> seededObject = _SeededIntList;
        String expectedValue = _SeededPrintAllExpectedValues;

        //When
        String resultOutput = seededObject.PrintAll();

        //Then
        resultOutput.Should().Be(expectedValue);
    }

    [Fact]
    public void PrintUniqueValues_ContainedTypeInt32_GivenSeededList_ShouldReturnStringWithAllSeededUniqueValues()
    {
        //Given
        DoublyLinkedList<int> seededObject = _SeededIntList;
        String expectedValue = _SeededPrintAllExpectedValues;

        //When
        String resultOutput = seededObject.PrintUniqueValues();

        //Then
        resultOutput.Should().Be(expectedValue);
    }

    [Fact]
    public void GetLength_ContainedTypeInt32_GivenSeededList_ShouldNotReturnZero()
    {
        //Given
        DoublyLinkedList<int> seededObject = _SeededIntList;
        UInt32 unexpected = 0;

        //When
        UInt32 report = seededObject.GetLength();

        //Then
        report.Should().NotBe(unexpected);
    }

    #endregion Seeded list

    #endregion Doubly Linked List of type Int32
}