# Design

Complete this document for **Part B**.

## 1. Saved recipe collection

I used a HashSet<int> to stored IDs of the saved recipes. I think HashSet is suitable because it doesnt allow duplicate and all the IDs must be unique. Add method must be unique id, have remove method, and also can check the ID if saved. The hash-based have an everage expected time complex as O(1). Before add an id, it need to check whether the ID is in the dictionary or not this can prevent an invalid ID to saved. The getsavedrecipes helps to convert the HashSet to the list and return as a IReadOnlyList<int>.

## 2. Integration

Part is basically extend the existeing RecipeManager rather than creating a new program. Both method that was used for search title and protein is using existing dictionary from part A and applying LinQ to filter it and select the result. The save method uses to store the recipes IDs seperately in a HashSet, while add method is check the existing recipes Dictionary before saving an ID. The application work ask calling a existing IRecipeManager API, so that the new methods will work with the supllied menu and Part A functions still working.  

## 3. Basic complexity

| Operation | Structure | Expected complexity | Reason |
| --- | --- | --- | --- |
| Lookup recipe by ID | Dictionary | Average O(1) | Hash-based key lookup. |
| Traverse cooking plan | LinkedList | O(n) | Each planned recipe may need to be visited. |
| Complete next instruction | Queue | O(1) | The item at the front is removed. |
| LINQ title/ingredient search | Recipe collection | O(n) | Each recipe may need to be inspected. |
| Check whether a recipe is saved | HashSet | Average O(1) | Hash-based membership checks. |
| Add and Remove recipe | HashSet | Average O(1) | Hash-based insertion and removal. |
| Get saved recipe IDs | HashSet convert to list | Average O(k) | Each of the k saved IDs is copied to the new list. |

n is the number of recipes or planned items being examined, k is the number of saved recipe IDs.