
```csharp
public double FindMedianSortedArrays(int[] nums1, int[] nums2)
{
    double output;
    var size = nums1.Length + nums2.Length;
    var middlePosition = size / 2;
    var leftIndex = 0;
    var rightIndex = 0;
    var middleElements = new double[2];
    var medianIndex = 0;
    var counter = 0;
    while (counter <= middlePosition)
    {
        if (leftIndex == nums1.Length)
        {
            middleElements[medianIndex] = nums2[rightIndex++];
            medianIndex = 1 - medianIndex;
            counter++;
            continue;
        }

        if (rightIndex == nums2.Length)
        {
            middleElements[medianIndex] = nums1[leftIndex++];
            medianIndex = 1 - medianIndex;
            counter++;
            continue;
        }

        if (nums1[leftIndex] < nums2[rightIndex])
        {
            middleElements[medianIndex] = nums1[leftIndex++];
            medianIndex = 1 - medianIndex;
            counter++;
            continue;
        }

        middleElements[medianIndex] = nums2[rightIndex++];
        medianIndex = 1 - medianIndex;
        counter++;
    }

    if ((size & 1) == 1)
    {
        output = ((size / 2) & 1) == 1 ? middleElements[1] : middleElements[0];
    }
    else
    {
        output = (middleElements[0] + middleElements[1]) / 2;
    }

    return output;
}
```
***
Find the middle position.
if the middle position is even then calculate the average of the middle two numbers. 
Otherwise, the middle position contains directly the median.
```csharp
var size = nums1.Length + nums2.Length;
var middlePosition = size / 2;
```
***
There can be two numbers in the middle at most. 
```csharp
var middleElements = new double[2];
```
***
If the size is odd and half of the size is odd then the median will be the second number in the middle elements.
```csharp
{
    numbers = {1, 2, 3}
    middleElements[0] = 1;
    middleElements[1] = 2;
}
```
If the size is odd and half of the size is even then the median will be the first number in the middle elements. 
```csharp
{
    numbers = {1, 2, 3, 4, 5}
    middleElements[0] = 1;
    middleElements[1] = 2;
    middleElements[0] = 3;
}
```
```csharp
if ((size & 1) == 1)
{
    output = ((size / 2) & 1) == 1 ? middleElements[1] : middleElements[0];
}
else
{
    output = (middleElements[0] + middleElements[1]) / 2;
}
```
***
```tafo
return 
{
    I am open to any kind of feedback
    If you request an explanation I will response as soon as possible
    {
        for beginners and junior coders
    }
}
```