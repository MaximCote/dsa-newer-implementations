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

    public const Int32 firstNonSeededInteger = 42;
    public const Int32 secondNonSeededInteger = 43;
    public const Int32 thirdNonSeededInteger = 44;
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

    private DoublyLinkedList<Int32> _SeededIntList;
    private String _IntegerSeededPrintAllExpectedValues = String.Empty;
    private String _IntegerSeededReversedPrintAllExpectedValues = String.Empty;

    //private DoublyLinkedList<String> _SeededStringList;
    //private String _StringSeededPrintAllExpectedValues = String.Empty;

    public DoublyLinkedListTests()
    {
        //Seed an object with the contained type of Int32
        _SeededIntList = new DoublyLinkedList<Int32>(firstIntegerSeed, secondIntegerSeed);
        //_SeededIntList.TryInsertAtHead(thirdIntegerSeed);
        //Seed by inserting at Tail
        //_SeededIntList.TryInsertAtTail(fourthIntegerSeed);
        //_SeededIntList.TryInsertAtTail(fifthIntegerSeed);
        //_SeededIntList.TryInsertAtTail(sixthIntegerSeed);
        //
        _IntegerSeededPrintAllExpectedValues = 
            $"{firstIntegerSeed} -> {secondIntegerSeed}";

        _IntegerSeededReversedPrintAllExpectedValues =
            $"{secondIntegerSeed} -> {firstIntegerSeed}";

        //Seed an object with the contained type of String
        //_SeededStringList.TryInsertAtHead(firstStringSeed);
        //_SeededStringList.TryInsertAtHead(secondStringSeed);
        //_SeededStringList.TryInsertAtHead(thirdStringSeed);

        ////Seed by inserting at Tail
        //_SeededStringList.TryInsertAtTail(fourthStringSeed);
        //_SeededStringList.TryInsertAtTail(fifthStringSeed);
        //_SeededStringList.TryInsertAtTail(sixthStringSeed);
        ////
        //_StringSeededPrintAllExpectedValues =
        //    $"{thirdStringSeed} -> {secondStringSeed} -> {firstStringSeed}"
        //    + $" -> "
        //    + $"{fourthStringSeed} -> {fifthStringSeed} -> {sixthStringSeed}";
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
        String resultingListPrintAllOutput = resultingList.PrintAll();

        //Then
        resultingList.Should().NotBeNull();
        resultingList.Should().NotBe(newLinkedList);
        resultingListPrintAllOutput.Should().NotBeNullOrEmpty();
        resultingListPrintAllOutput.Should().Be(DoublyLinkedList<int>.EmptyListReport);
    }

    [Fact]
    public void Intersect_ContainedTypeInt32_GivenArgumentsTwoNewLists_ShouldReturnEmptyList()
    {
        //Given
        DoublyLinkedList<int> newLinkedList = new DoublyLinkedList<int>();
        DoublyLinkedList<int> otherNewLinkedList = new DoublyLinkedList<int>();

        //When
        DoublyLinkedList<int> resultingList = DoublyLinkedList<int>.Intersect(newLinkedList, otherNewLinkedList);
        Boolean resultingListIsEmptyFlag = resultingList.IsEmpty();

        //Then
        resultingListIsEmptyFlag.Should().BeTrue();
    }

    [Fact]
    public void Unify_ContainedTypeInt32_GivenNewListAndArgumentIsNewList_ShouldReturnEmptyList()
    {
        //Given
        DoublyLinkedList<int> newLinkedList = new DoublyLinkedList<int>();
        DoublyLinkedList<int> otherNewLinkedList = new DoublyLinkedList<int>();

        //When
        DoublyLinkedList<int> resultingList = DoublyLinkedList<int>.Unify(newLinkedList, otherNewLinkedList);
        Boolean resultingListIsEmptyFlag = resultingList.IsEmpty();

        //Then
        resultingListIsEmptyFlag.Should().BeTrue();
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
        Boolean newListIsEmptyFlag = newLinkedList.IsEmpty();

        //Then
        newListIsEmptyFlag.Should().BeTrue();        
    }

    [Fact]
    public void HasDetectedLoop_ContainedTypeInt32_GivenNewList_ShouldReturnFalse()
    {
        //Given
        DoublyLinkedList<int> newLinkedList = new DoublyLinkedList<int>();

        //When
        Boolean newListHasDetectedLoopFlag = newLinkedList.HasDetectedLoop();

        //Then
        newListHasDetectedLoopFlag.Should().BeFalse();
    }

    [Fact]
    public void PrintAll_ContainedTypeInt32_GivenNewList_ShouldReturnStringWithEmptyListMessage()
    {
        //Given
        DoublyLinkedList<int> newLinkedList = new DoublyLinkedList<int>();

        //When
        String newListPrintAllOutput = newLinkedList.PrintAll();

        //Then
        newListPrintAllOutput.Should().Be(DoublyLinkedList<int>.EmptyListReport);
    }

    [Fact]
    public void PrintUniqueValues_ContainedTypeInt32_GivenNewList_ShouldReturnStringWithEmptyListMessage()
    {
        //Given
        DoublyLinkedList<int> newLinkedList = new DoublyLinkedList<int>();

        //When
        String newListPrintUniqueValuesOutput = newLinkedList.PrintUniqueValues();

        //Then
        newListPrintUniqueValuesOutput.Should().Be(DoublyLinkedList<int>.EmptyListReport);
    }

    [Fact]
    public void GetLength_ContainedTypeInt32_GivenNewList_ShouldReturnZero()
    {
        //Given
        DoublyLinkedList<int> newLinkedList = new DoublyLinkedList<int>();

        //When
        UInt32 newListGetLengthOutput = newLinkedList.GetLength();

        //Then
        newListGetLengthOutput.Should().Be(0);
    }

    [Fact]
    public void Duplicate_ContainedTypeInt32_GivenNewList_ShouldReturnShouldReturnAnotherNewList()
    {
        //Given
        DoublyLinkedList<int> newLinkedList = new DoublyLinkedList<int>();
        String? newListPrintAllOutput = newLinkedList.PrintAll();

        //When
        DoublyLinkedList<int> resultingList = newLinkedList.Duplicate();
        String? resultingListPrintAllOutput = resultingList.PrintAll();

        //Then
        resultingList.Should().NotBeNull();
        resultingListPrintAllOutput.Should().Be(newListPrintAllOutput);
    }

    [Fact]
    public void TryInsertAtHead_ContainedTypeInt32_GivenNewList_ShouldReturnTrue()
    {
        //Given
        DoublyLinkedList<int> newLinkedList = new DoublyLinkedList<int>();
        String? newListPrintAllOutput = newLinkedList.PrintAll();

        //When
        Boolean newListTryInsertAtHeadFlag = newLinkedList.TryInsertAtHead(firstNonSeededInteger);
        String? resultingListPrintAllOutput = newLinkedList.PrintAll();

        //Then
        newListTryInsertAtHeadFlag.Should().BeTrue();
        resultingListPrintAllOutput.Should().NotBe(newListPrintAllOutput);
        resultingListPrintAllOutput.Should().Be($"{firstNonSeededInteger}");

    }

    [Fact]
    public void TryInsertAtTail_ContainedTypeInt32_GivenNewList_ShouldReturnTrue()
    {
        //Given
        DoublyLinkedList<int> newLinkedList = new DoublyLinkedList<int>();
        String? newListPrintAllOutput = newLinkedList.PrintAll();

        //When
        Boolean newListTryInsertAtTailFlag = newLinkedList.TryInsertAtTail(firstNonSeededInteger);
        String? resultingListPrintAllOutput = newLinkedList.PrintAll();

        //Then
        newListTryInsertAtTailFlag.Should().BeTrue();
        resultingListPrintAllOutput.Should().NotBe(newListPrintAllOutput);
        resultingListPrintAllOutput.Should().Be($"{firstNonSeededInteger}");
    }

    [Fact]
    public void TryRemoveAtHead_ContainedTypeInt32_GivenNewList_ShouldReturnFalse()
    {
        //Given
        DoublyLinkedList<int> newLinkedList = new DoublyLinkedList<int>();

        //When
        Boolean newListTryRemoveAtHeadFlag = newLinkedList.TryRemoveAtHead();

        //Then
        newListTryRemoveAtHeadFlag.Should().BeFalse();
    }

    [Fact]
    public void TryRemoveAtTail_ContainedTypeInt32_GivenNewList_ShouldReturnFalse()
    {
        //Given
        DoublyLinkedList<int> newLinkedList = new DoublyLinkedList<int>();

        //When
        Boolean newListTryRemoveAtTailFlag = newLinkedList.TryRemoveAtTail();

        //Then
        newListTryRemoveAtTailFlag.Should().BeFalse();
    }

    [Fact]
    public void TryRemoveFromHead_ContainedTypeInt32_GivenNewListAndArgumentZero_ShouldReturnFalse()
    {
        //Given
        DoublyLinkedList<int> newLinkedList = new DoublyLinkedList<int>();
        Int32 valueToRemove = 0;

        //When
        Boolean newListTryRemoveFromHeadFlag = newLinkedList.TryRemoveFromHead(valueToRemove);

        //Then
        newListTryRemoveFromHeadFlag.Should().BeFalse();
    }

    [Fact]
    public void TryRemoveFromHead_ContainedTypeInt32_GivenNewListAndArgumentOtherThanZero_ShouldReturnFalse()
    {
        //Given
        DoublyLinkedList<int> newLinkedList = new DoublyLinkedList<int>();
        Int32 valueToRemove = firstNonSeededInteger;

        //When
        Boolean newListTryRemoveFromHeadFlag = newLinkedList.TryRemoveFromHead(valueToRemove);

        //Then
        newListTryRemoveFromHeadFlag.Should().BeFalse();
    }

    [Fact]
    public void TryRemoveFromTail_ContainedTypeInt32_GivenNewListAndArgumentZero_ShouldReturnFalse()
    {
        //Given
        DoublyLinkedList<int> newLinkedList = new DoublyLinkedList<int>();
        Int32 valueToRemove = 0;

        //When
        Boolean newListTryRemoveFromTailFlag = newLinkedList.TryRemoveFromTail(valueToRemove);

        //Then
        newListTryRemoveFromTailFlag.Should().BeFalse();
    }

    [Fact]
    public void TryRemoveFromTail_ContainedTypeInt32_GivenNewListAndArgumentOtherThanZero_ShouldReturnFalse()
    {
        //Given
        DoublyLinkedList<int> newLinkedList = new DoublyLinkedList<int>();
        Int32 valueToRemove = firstNonSeededInteger;

        //When
        Boolean newListRemoveFromTailFlag = newLinkedList.TryRemoveFromTail(valueToRemove);

        //Then
        newListRemoveFromTailFlag.Should().BeFalse();
    }

    [Fact]
    public void TryReverse_ContainedTypeInt32_GivenNewList_ShouldReturnFalse()
    {
        //Given
        DoublyLinkedList<int> newLinkedList = new DoublyLinkedList<int>();

        //When
        Boolean newListTryReverseFlag = newLinkedList.TryReverse();

        //Then
        newListTryReverseFlag.Should().BeFalse();
    }

    [Fact]
    public void TryRemoveDuplicateValues_ContainedTypeInt32_GivenNewList_ShouldReturnFalse()
    {
        //Given
        DoublyLinkedList<int> newLinkedList = new DoublyLinkedList<int>();

        //When
        Boolean newListTryRemoveDuplicateFlag = newLinkedList.TryRemoveDuplicateValues();

        //Then
        newListTryRemoveDuplicateFlag.Should().BeFalse();
    }

    [Fact]
    public void IntersectWith_ContainedTypeInt32_GivenNewListAndArgumentIsNewList_ShouldReturnEmptyList()
    {
        //Given
        DoublyLinkedList<int> newLinkedList = new DoublyLinkedList<int>();
        DoublyLinkedList<int> otherNewLinkedList = new DoublyLinkedList<int>();

        //When
        DoublyLinkedList<int> resultingList = newLinkedList.IntersectWith(otherNewLinkedList);
        Boolean resultingListIsEmptyFlag = resultingList.IsEmpty();

        //Then
        resultingListIsEmptyFlag.Should().BeTrue();
    }

    [Fact]
    public void UnifyWith_ContainedTypeInt32_GivenNewListAndArgumentIsNewList_ShouldReturnEmptyList()
    {
        //Given
        DoublyLinkedList<int> newLinkedList = new DoublyLinkedList<int>();
        DoublyLinkedList<int> otherNewLinkedList = new DoublyLinkedList<int>();

        //When
        DoublyLinkedList<int> resultingList = newLinkedList.UnifyWith(otherNewLinkedList);
        Boolean resultingListIsEmptyFlag = resultingList.IsEmpty();

        //Then
        resultingListIsEmptyFlag.Should().BeTrue();
    }
    #endregion New empty list

    #region Seeded list

    #region Static methods
    [Fact]
    public void StaticDuplicate_ContainedTypeInt32_GivenArgumentListWithValues_ShouldReturnNewListWithEqualValues()
    {
        //Given
        DoublyLinkedList<int> seededObject = _SeededIntList;
        String? seededListPrintAllOutput = seededObject.PrintAll();

        //When
        DoublyLinkedList<int> resultingList = DoublyLinkedList<int>.Duplicate(seededObject);
        String? resultingListPrintAllOutput = resultingList.PrintAll();

        //Then
        resultingList.Should().NotBeNull();
        resultingListPrintAllOutput.Should().Be(seededListPrintAllOutput);
    }

    [Fact]
    public void StaticIntersect_ContainedTypeInt32_GivenArgumentsTwoListsWithNoValueOverlap_ShouldReturnEmptyList()
    {
        //Given
        DoublyLinkedList<int> duplicatedSeededObject = DoublyLinkedList<int>.Duplicate(_SeededIntList);
        DoublyLinkedList<int> otherList = new DoublyLinkedList<int>();
        otherList.TryInsertAtHead(firstNonSeededInteger);
        otherList.TryInsertAtHead(secondNonSeededInteger);
        otherList.TryInsertAtHead(thirdNonSeededInteger);

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
        otherList.TryInsertAtHead(firstNonSeededInteger);
        otherList.TryInsertAtHead(secondNonSeededInteger);
        otherList.TryInsertAtHead(thirdNonSeededInteger);
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
        String expectedValue = _IntegerSeededPrintAllExpectedValues;

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
        String expectedValue = _IntegerSeededPrintAllExpectedValues;

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

    [Fact]
    public void Duplicate_ContainedTypeInt32_GivenSeededList_ShouldReturnNewListWithEqualValues()
    {
        //Given
        DoublyLinkedList<int> seededObject = _SeededIntList;
        String? seededListPrintAllOutput = seededObject.PrintAll();

        //When
        DoublyLinkedList<int> resultingList = seededObject.Duplicate();
        String? resultingListPrintAllOutput = resultingList.PrintAll();

        //Then
        resultingList.Should().NotBeNull();
        resultingList.Should().NotBe(seededObject);
        resultingListPrintAllOutput.Should().Be(seededListPrintAllOutput);
    }

    [Fact]
    public void TryInsertAtHead_ContainedTypeInt32_GivenSeededListArgumentIsNonSeededValue_ShouldReturnTrue()
    {
        //Given
        DoublyLinkedList<int> seededObject = _SeededIntList.Duplicate();
        String? seededListPrintAllOutput = seededObject.PrintAll();

        //When
        Boolean seededListTryInsertAtHeadFlag = seededObject.TryInsertAtHead(firstNonSeededInteger);
        String? resultingListPrintAllOutput = seededObject.PrintAll();

        //Then
        seededListTryInsertAtHeadFlag.Should().BeTrue();
        resultingListPrintAllOutput.Should().NotBe(seededListPrintAllOutput);
        resultingListPrintAllOutput.Should().Be($"{firstNonSeededInteger} -> {_IntegerSeededPrintAllExpectedValues}");

    }

    [Fact]
    public void TryInsertAtTail_ContainedTypeInt32_GivenSeededListArgumentIsNonSeededValue_ShouldReturnTrue()
    {
        //Given
        DoublyLinkedList<int> seededObject = _SeededIntList.Duplicate();
        String? seededListPrintAllOutput = seededObject.PrintAll();

        //When
        Boolean seededListTryInsertAtTailFlag = seededObject.TryInsertAtTail(firstNonSeededInteger);
        String? resultingListPrintAllOutput = seededObject.PrintAll();

        //Then
        seededListTryInsertAtTailFlag.Should().BeTrue();
        resultingListPrintAllOutput.Should().NotBe(seededListPrintAllOutput);
        resultingListPrintAllOutput.Should().Be($"{_IntegerSeededPrintAllExpectedValues} -> {firstNonSeededInteger}");
    }

    [Fact]
    public void TryRemoveAtHead_ContainedTypeInt32_GivenSeededList_ShouldReturnTrue()
    {
        //Given
        DoublyLinkedList<int> seededObject = _SeededIntList.Duplicate();
        String? seededListPrintAllOutput = seededObject.PrintAll();

        //When
        Boolean seededListTryRemoveAtHeadFlag = seededObject.TryRemoveAtHead();
        String? resultingListPrintAllOutput = seededObject.PrintAll();

        //Then
        seededListTryRemoveAtHeadFlag.Should().BeTrue();
        resultingListPrintAllOutput.Should().NotBe(seededListPrintAllOutput);
        resultingListPrintAllOutput.Should().Be($"{secondIntegerSeed}");
    }

    [Fact]
    public void TryRemoveAtTail_ContainedTypeInt32_GivenSeededList_ShouldReturnTrue()
    {
        //Given
        DoublyLinkedList<int> seededObject = _SeededIntList.Duplicate();
        String? seededListPrintAllOutput = seededObject.PrintAll();

        //When
        Boolean seededListTryRemoveAtTailFlag = seededObject.TryRemoveAtTail();
        String? resultingListPrintAllOutput = seededObject.PrintAll();

        //Then
        seededListTryRemoveAtTailFlag.Should().BeTrue();
        resultingListPrintAllOutput.Should().NotBe(seededListPrintAllOutput);
        resultingListPrintAllOutput.Should().Be($"{firstIntegerSeed}");
    }

    [Fact]
    public void TryRemoveFromHead_ContainedTypeInt32_GivenSeededListAndArgumentIsNonSeededValue_ShouldReturnFalse()
    {
        //Given
        DoublyLinkedList<int> seededObject = _SeededIntList.Duplicate();
        String? seededListPrintAllOutput = seededObject.PrintAll();
        Int32 valueToRemove = firstNonSeededInteger;

        //When
        Boolean seededListTryRemoveFromHeadFlag = seededObject.TryRemoveFromHead(valueToRemove);
        String? resultingListPrintAllOutput = seededObject.PrintAll();

        //Then
        seededListTryRemoveFromHeadFlag.Should().BeFalse();
        resultingListPrintAllOutput.Should().Be(seededListPrintAllOutput);
    }

    [Fact]
    public void TryRemoveFromHead_ContainedTypeInt32_GivenSeededListAndArgumentIsSeededValue_ShouldReturnTrue()
    {
        //Given
        DoublyLinkedList<int> seededObject = _SeededIntList.Duplicate();
        String? seededListPrintAllOutput = seededObject.PrintAll();
        Int32 valueToRemove = secondIntegerSeed;

        //When
        Boolean seededListTryRemoveFromHeadFlag = seededObject.TryRemoveFromHead(valueToRemove);
        String? resultingListPrintAllOutput = seededObject.PrintAll();

        //Then
        seededListTryRemoveFromHeadFlag.Should().BeTrue();
        resultingListPrintAllOutput.Should().NotBe(seededListPrintAllOutput);
        resultingListPrintAllOutput.Should().Be($"{firstIntegerSeed}");
    }

    [Fact]
    public void TryRemoveFromTail_ContainedTypeInt32_GivenSeededListAndArgumentIsNonSeededValue_ShouldReturnFalse()
    {
        //Given
        DoublyLinkedList<int> seededObject = _SeededIntList.Duplicate();
        String? seededListPrintAllOutput = seededObject.PrintAll();
        Int32 valueToRemove = firstNonSeededInteger;

        //When
        Boolean seededListTryRemoveFromTailFlag = seededObject.TryRemoveFromTail(valueToRemove);
        String? resultingListPrintAllOutput = seededObject.PrintAll();

        //Then
        seededListTryRemoveFromTailFlag.Should().BeFalse();
        resultingListPrintAllOutput.Should().Be(seededListPrintAllOutput);
    }

    [Fact]
    public void TryRemoveFromTail_ContainedTypeInt32_GivenSeededListAndArgumentIsSeededValue_ShouldReturnTrue()
    {
        //Given
        DoublyLinkedList<int> seededObject = _SeededIntList.Duplicate();
        String? seededListPrintAllOutput = seededObject.PrintAll();
        Int32 valueToRemove = firstIntegerSeed;

        //When
        Boolean seededListTryRemoveFromHeadFlag = seededObject.TryRemoveFromHead(valueToRemove);
        String? resultingListPrintAllOutput = seededObject.PrintAll();

        //Then
        seededListTryRemoveFromHeadFlag.Should().BeTrue();
        resultingListPrintAllOutput.Should().NotBe(seededListPrintAllOutput);
        resultingListPrintAllOutput.Should().Be($"{secondIntegerSeed}");
    }

    [Fact]
    public void TryReverse_ContainedTypeInt32_GivenSeededList_ShouldReturnTrue()
    {
        //Given
        DoublyLinkedList<int> seededObject = _SeededIntList.Duplicate();
        String? seededListPrintAllOutput = seededObject.PrintAll();      

        //When
        Boolean seededListTryReverseFlag = seededObject.TryReverse();
        String? resultingListPrintAllOutput = seededObject.PrintAll();

        //Then
        seededListTryReverseFlag.Should().BeTrue();
        resultingListPrintAllOutput.Should().NotBe(seededListPrintAllOutput);
        resultingListPrintAllOutput.Should().Be($"{_IntegerSeededReversedPrintAllExpectedValues}");
    }

    #endregion Seeded list

    #endregion Doubly Linked List of type Int32
}