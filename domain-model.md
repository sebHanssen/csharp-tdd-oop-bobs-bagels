```
1.
As a member of the public,
So I can order a bagel before work,
I'd like to add a specific type of bagel to my basket.

3.
As a member of the public,
So that I can not overfill my small bagel basket
I'd like to know when my basket is full when I try adding an item beyond my basket capacity.
```
```
10.
As the manager,
So we don't get any weird requests,
I want customers to only be able to order things that we stock in our inventory.
```
| Classes    | Methods            | Function                 | Scenario                | Outputs              |
|------------|--------------------|--------------------------|-------------------------|----------------------|
| `Basket`   | `add(product)`     | Adds product to basket   | Basket not full         | string               |
|            |                    |                          | Basket full             | errorMessage changed |
|            |                    |                          | Product is not on menu  | errorMessage changed |

```
2.
As a member of the public,
So I can change my order,
I'd like to remove a bagel from my basket.
5.
As a member of the public
So that I can maintain my sanity
I'd like to know if I try to remove an item that doesn't exist in my basket.
```
| Classes    | Methods               | Function                  | Scenario                      | Outputs              |
|------------|-----------------------|---------------------------|-------------------------------|----------------------|
| `Basket`   | `remove(string bagel)`| Removes bagel from basket | Item exists in basket         | remove string        |
|            |                       |                           | Item does not exist in basket | errorMessage changed |

```
4.
As a Bob's Bagels manager,
So that I can expand my business,
I’d like to change the capacity of baskets.
```
| Classes    | Methods                 | Function                 | Scenario                                                          | Outputs                    |
|------------|-------------------------|--------------------------|-------------------------------------------------------------------|----------------------------|
| `Basket`   | `changeBasketlimit(int)`| Changes basket limit     | New basket limit is larger than current amount of items in basket | Basket limit changed       |
|            |                         |                          | New basket limit is less than current amount of items in basket   | Basket limit not changed   |

```
6.
As a customer,
So I know how much money I need,
I'd like to know the total cost of items in my basket.
```
| Classes | Methods | Function            | Scenario | Output |
|---------|---------|---------------------|----------|--------|
| Basket  | total() | Returns total price |          | double |

```
7.
As a customer,
So I know what the damage will be,
I'd like to know the cost of a bagel before I add it to my basket.
```
| Classes   | Methods             | Function                 | Scenario               | Output |
|-----------|---------------------|--------------------------|------------------------|--------|
| BagelShop | checkPrice(product) | Returns price of product | Product exists         | double |
|           |                     |                          | Product does not exist | null   |

```
8.
As a customer,
So I can shake things up a bit,
I'd like to be able to choose fillings for my bagel.
```
```
9.
As a customer,
So I don't over-spend,
I'd like to know the cost of each filling before I add it to my bagel order.
```
| Classes | Methods                                    | Function              | Scenario                       | Output               |
|---------|--------------------------------------------|-----------------------|--------------------------------|----------------------|
| Basket  | addFilling(Product bagel, Product filling) | Adds filling to bagel | Bagel exists in basket         | filling added        |
|         |                                            |                       | Bagel does not exist in basket | errorMessage changed |


