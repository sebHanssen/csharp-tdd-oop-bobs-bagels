using exercise.main;

namespace exercise.tests;

public class Tests
{
    [Test]
    public void AddBagel()
    {
        //Set Up
        BagelShop shop = new BagelShop();
        //Execute
        shop.basket.add(shop.menu.bagels[0]);
        //verify
        Assert.That(shop.basket.content, Is.Not.Null);
        Assert.That(shop.basket.content[0].Name == "Plain Bagel");
    }

    [Test]
    public void RemoveBagel()
    {
        //Set Up
        BagelShop shop = new BagelShop();
        //Execute
        shop.basket.add(shop.menu.bagels[0]);
        shop.basket.add(shop.menu.bagels[1]);
        shop.basket.remove(shop.menu.bagels[0]);
        //verify
        Assert.That(shop.basket.content[0].Name == "Onion Bagel");
    }

    [Test]
    public void BasketCount()
    {
        //Set Up
        BagelShop shop = new BagelShop();
        //Execute
        shop.basket.add(shop.menu.bagels[0]);
        shop.basket.add(shop.menu.bagels[1]);
        shop.basket.add(shop.menu.bagels[1]);
        shop.basket.add(shop.menu.bagels[1]);
        //verify
        Assert.That(shop.basket.content.Count() == 3);
    }

    [Test]
    public void ChangeBasketCount()
    {
        //Set Up
        BagelShop shop = new BagelShop();
        //Execute
        shop.basket.add(shop.menu.bagels[0]);
        shop.basket.add(shop.menu.bagels[1]);
        shop.basket.add(shop.menu.bagels[1]);
        shop.basket.changeBasketLimit(4);
        shop.basket.add(shop.menu.bagels[1]);
        shop.basket.changeBasketLimit(2);
        //verify
        Assert.That(shop.basket.content.Count() == 4);
        Assert.That(shop.basket.errorMessage == "Limit cannot be lower than current items in basket");
    }
}