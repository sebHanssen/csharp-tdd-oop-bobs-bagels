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
        Assert.That(shop.basket.content[0].Variant == "Onion");
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
        Assert.That(shop.basket.content[0].Variant == "Plain");
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

    [Test]
    public void RemoveItemError()
    {
        //Set Up
        BagelShop shop = new BagelShop();
        //Execute
        shop.basket.add(shop.menu.bagels[0]);
        shop.basket.add(shop.menu.bagels[1]);
        shop.basket.add(shop.menu.bagels[1]);
        shop.basket.changeBasketLimit(4);
        shop.basket.add(shop.menu.bagels[1]);
        shop.basket.remove(shop.menu.bagels[0]);
        shop.basket.remove(shop.menu.bagels[0]);
        //verify
        Assert.That(shop.basket.content.Count() == 3);
        Assert.That(shop.basket.errorMessage == "There is no Onion Bagel in your basket to remove");
    }
    [Test]
    public void Total()
    {
        //Set Up
        BagelShop shop = new BagelShop();
        //Execute
        shop.basket.add(shop.menu.bagels[0]);
        shop.basket.add(shop.menu.bagels[1]);
        //verify
        Assert.That(shop.basket.content.Count() == 2);
        Assert.That(0.88d == shop.basket.total());
    }
}