
using zad6;

List<Item> items = new List<Item> ();
StreamReader sr = new StreamReader("C:\\test\\products.txt");
Koszyk koszyk = new Koszyk();

int id= 1;
while (!sr.EndOfStream) {
    string line = sr.ReadLine();
    if (line != null) {
        string[] parts = line.Split(' ');
        Item temp = new Item {
            Id = id++,
            Name = parts[0],
            Price = decimal.Parse(parts[1]),
            Quantity = 0
        };
        items.Add(temp);
    }
}
sr.Close();



string out_text = "Products:\n\n";
foreach (Item item in items) {
    out_text+=item.Id+". "+item.Name+"\t";
    if ((item.Id % 4) == 0) {
        out_text+= "\n";
    }

}
Console.WriteLine(out_text);


while (true)
{
    Console.WriteLine("\nWhat do you want to do?\n 0:exit\n 1:add \n 2:dell \n 3:show \n 4:show items\n\n");
    string choice = Console.ReadLine();
    if(choice == "1")
    {
        Console.WriteLine("Enter product ID to add to the cart:");
        int productId = int.Parse(Console.ReadLine());
        koszyk.DodajProdukt(items.FirstOrDefault(i => i.Id == productId));
        Console.WriteLine("how many items do you want to add?");
        int quantity = int.Parse(Console.ReadLine());
        koszyk.changeQuantity(productId, quantity);

    }
    else if(choice == "2")
    {
        Console.WriteLine("\nEnter product ID to remove from the cart:\n");
        int productId = int.Parse(Console.ReadLine());
        Console.WriteLine("how many items do you want to remove?");
        int quantity = int.Parse(Console.ReadLine());
        int quantityInCart = koszyk.produkty.FirstOrDefault(i => i.Id == productId)?.Quantity ?? 0;
        if(quantity >= quantityInCart)
        {
            koszyk.UsunProdukt(productId);
        }
        else
        {
            koszyk.changeQuantity(productId, quantityInCart - quantity);
        }
    }
    else if (choice == "3")
    {
        koszyk.WyswietlProdukty();
    }
    else if (choice == "4")
    {
        Console.WriteLine(out_text);
    }
    else if (choice == "0")
    {
        break;
    }
    else
    {
        Console.WriteLine("Invalid choice, try again.");
    }
}
