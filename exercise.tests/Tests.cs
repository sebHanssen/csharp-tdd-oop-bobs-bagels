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
        Assert.That(0.88d == shop.basket.total());
    }
    [Test]
    public void CheckPrice()
    {
        //Set Up
        BagelShop shop = new BagelShop();
        //Execute
        shop.basket.add(shop.menu.bagels[0]);
        shop.basket.add(shop.menu.bagels[1]);
        //verify
        Assert.That(shop.checkPrice(shop.menu.bagels[0]) == 0.49);
        Assert.That(shop.checkPrice(shop.menu.bagels[1]) == 0.39);
    }
    [Test]
    public void AddFilling()
    {
        //Set Up
        BagelShop shop = new BagelShop();
        //Execute
        shop.basket.add(shop.menu.bagels[0]);
        shop.basket.add(shop.menu.bagels[1]);
        shop.basket.add(shop.menu.bagels[1]);
        shop.basket.changeBasketLimit(4);
        shop.basket.add(shop.menu.coffee[0]);
        shop.basket.addFilling(shop.basket.content[0], shop.menu.filling[0]);
        shop.basket.addFilling(shop.menu.bagels[1], shop.menu.filling[0]);
        shop.basket.addFilling(shop.menu.bagels[2], shop.menu.filling[0]);
        //verify
        Assert.That(shop.basket.total(), Is.EqualTo(Math.Round(2.62d, 2)));
        Assert.That(shop.basket.errorMessage == "There is no Everything Bagel in your basket to add Bacon on.");
        shop.basket.addFilling(shop.menu.coffee[0], shop.menu.filling[0]);
        Assert.That(shop.basket.errorMessage == "You can only put filling on a Bagel");
    }
    [Test]
    public void CheckFillingPrice()
    {
        //Set Up
        BagelShop shop = new BagelShop();
        //Execute
        shop.basket.add(shop.menu.bagels[0]);
        shop.basket.addFilling(shop.basket.content[0], shop.menu.filling[0]);
        //verify
        Assert.That(shop.basket.userQuery, Is.EqualTo("The price of this filling is 0,12$. Are you sure you want to add it?"));
    }
    [Test]
    public void CheckMenu()
    {
        //Set Up
        BagelShop shop = new BagelShop();
        //Execute
        shop.basket.add(new Coffee("jfdsfgdsl", 123.23, "white coffee", "sdfasdf"));
        //verify
        Assert.That(shop.basket.content.Count(), Is.EqualTo(0));
        Assert.That(shop.basket.errorMessage, Is.EqualTo("This product does not exist in our menu."));
    }
    [Test]
    public void ApplyDiscounts()
    {
        //Set Up
        BagelShop shop = new BagelShop();
        //Execute
        shop.basket.add("BGLO", 8);
        shop.basket.add("BGLP", 12);
        shop.basket.add("COFB", 2);
        shop.basket.add("COFC", 1);
        //verify
        Assert.That(Math.Round(9.46d, 2), Is.EqualTo(shop.basket.total()));
        /*
        BGLO * 6 = Discounted for 2.49 (6 Bagel offer)
        BGLO * 1 + COFB * 1 = Discounted for 1.25 (Coffee + Bagel offer)
        BGLO * 1 + COFC * 1 = Discounted for 1.25 (Coffee + Bagel offer)
        BGLP * 12 = Discounted 3.49 (12 Bagel offer)
        COFB * 1 = No discount, 0.99
        */
    }
}