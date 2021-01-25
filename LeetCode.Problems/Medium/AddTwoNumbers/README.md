In order to code a **O(max(m,n))** solution, I should loop the node chains only one time. 
And I need to sum the values of nodes whose order are same. 
If a node chain has more nodes than the other one then I should use 0(zero) instead of the missing nodes' values
```csharp
public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
{
var tempHeadNode = new ListNode();
var currentNode = tempHeadNode;
var carry = 0;
do
{
    var value1 = l1?.val ?? 0;
    var value2 = l2?.val ?? 0;
    var sum = value1 + value2 + carry;
    var nextNode = new ListNode
    {
        val = sum > 9 ? sum - 10 : sum
    };
    carry = sum / 10;
    currentNode.next = nextNode;
    currentNode = currentNode.next;
    l1 = l1?.next;
    l2 = l2?.next;
} while (l1 != null || l2 != null);

if (carry == 1)
{
    currentNode.next = new ListNode(1);
}

return tempHeadNode.next;
```
***
Create a temporary node that will be linked to actual head node.
If I directly create a root node instead of this temporary node, I have to check the root node whether it is null or not for each loop.
```csharp
var tempHeadNode = new ListNode();
```
***
currentNode will hold the sum of nodes are at the same order.
```csharp
var currentNode = tempHeadNode;
```
***
Since the sum of two nodes that are at the same order can be more than 9, I need to bring (carry) the ten over to the next(left) whole number. 
```csharp
var carry = 0;
```
***
The sum of node values that are at the same order.
If the node is null then 0 is used as the value of it. 
```csharp
var value1 = l1?.val ?? 0;
var value2 = l2?.val ?? 0;
var sum = value1 + value2 + carry;
```
***
**val** variable will hold the ones part of the sum.
```csharp
var nextNode = new ListNode
{
    val = sum > 9 ? sum - 10 : sum
};
```
***
**carry** variable will hold the tens part of the sum. 
```csharp
carry = sum / 10;
```
***
Linked the new node to the current node then assign it to the current node. 
Because the next node will be the current node in the next iteration. 
```csharp
currentNode.next = nextNode;
currentNode = currentNode.next;
```
***
Use the next nodes of given input nodes.
Because I already calculated the sum of them. 
```csharp
l1 = l1?.next;
l2 = l2?.next;
```
***
Continue to loop while any of given input nodes are not null.
```csharp
while (l1 != null || l2 != null);
```
***
At the end of the loop, carry can still hold the value 1.
if carry is 1 then create a new node and link it to the current node.
```csharp
if (carry == 1)
{
    currentNode.next = new ListNode(1);
}
```
***
Return the next node of the temporary head node.
Because it is the root node. 
```csharp
return tempHeadNode.next;
```
***
```tafo
return
{
    I am open to any kind of feedback.
}
```
