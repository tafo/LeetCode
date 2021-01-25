In order to code an **O(n)** solution, I should loop the elements(numbers) of the array only one time. 
So, I need to store them in a dictionary. **Keys** will be numbers, **Values** will be their indexes. 
Then I will check that is there any key whose value is equal to **target - number** in the dictionary. 
`Dictionary<TKey, TValue>` is a good choice for this problem. 
```csharp
public int[] TwoSum(int[] nums, int target)
{
    var set = new Dictionary<int, int>();
    for (var i = 0; i < nums.Length; i++)
    {
        var number = nums[i];
        if (set.ContainsKey(target - number))
        {
            return new[] {set[target - number], i};
        }

        if (!set.ContainsKey(number))
        {
            set.Add(number, i);
        }
    }

    throw new ArgumentException();
}
```
***
Declare key-value dictionary to store numbers.
```csharp
var set = new Dictionary<int, int>();
```
***
Loop each number in the array until find the complementary number.
```csharp
for (var i = 0; i < nums.Length; i++)
```
***
Assign the element of the array to a integer variable to have an elegant code. 
```csharp
var number = nums[i];
```
***
If the dictionary contains the complementary number then return it. 
```csharp
if (set.ContainsKey(target - number))
{
    return new[] {set[target - number], i};
}
```
***
If the current number is not a complementary number then add it to the dictionary. 
```csharp
if (!set.ContainsKey(number))
{
    set.Add(number, i);
}
```
***
The problem description says "each input would have exactly one solution".
So throw the right exception if there is no valid solution. 
Throwing exception is necessary to compile the solution. 
```csharp
throw new ArgumentException();
```
***
```tafo
return 
{
    I am open to any kind of feedback
}
```
