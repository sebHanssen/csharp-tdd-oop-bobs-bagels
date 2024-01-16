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
}