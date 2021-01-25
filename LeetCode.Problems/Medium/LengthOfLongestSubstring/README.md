And I need to find repeating characters. 

If there is a repeating character than subtract the first position from the second position.
```csharp
var startPosition = 0;
var resultList = new List<int>();
for (var i = 1; i < s.Length; i++)
{
    var index = s.IndexOf(s[i], startPosition, i - startPosition);
    if (index == -1) continue;

    resultList.Add(i - startPosition);
    startPosition = index + 1;
}

resultList.Add(s.Length - startPosition);
return resultList.Max();
```
***
**startPosition** variable will hold the first position of the repeating character. 

Positions start with 1, indexes start with 0. 

So, the initial value of this variable should be 0.
```csharp
var startPosition = 0;
```
***
**resultList** variable should hold the lengths of substrings. 
```csharp
var resultList = new List<int>();
```
***
Loop each character of the given string except the first one.

Because the first character can not be the second occurrence.
```csharp
for (var i = 1; i < s.Length; i++)
```
***
Find the position of the last repeating character. 

Because a substring can contain another substring like abba.

Even if bba contains only one **a**, it contains two **b**.
```csharp
var index = s.IndexOf(s[i], startPosition, i - startPosition);
```
***
If the current loop character is unique then continue to find a repeating character. 
```csharp
if (index == -1) continue;
```
***
If the code step over to the below statement then there is a repeating character. 

Add the length of the substring to the **resultList**.
```csharp
resultList.Add(i - startPosition);
```
***
Update the value of startPosition.
```csharp
startPosition = index + 1;
```
***
There should be a valid substring at the end of the string.

Then calculate the length of the length of last substring. 

Add the length to the **resultList**.
```csharp
resultList.Add(s.Length - startPosition);
```
***
Find and return the max value in the **resultList**
```csharp
return resultList.Max();
```
