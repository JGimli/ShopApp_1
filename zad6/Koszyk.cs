using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad6
{
    public class Koszyk
    {
        public List<Item> produkty = new List<Item>();

        public void DodajProdukt(Item produkt)
        {
            produkty.Add(produkt);
        }
        public void UsunProdukt(int id)
        {
            var produkt = produkty.FirstOrDefault(p => p.Id == id);
            if (produkt != null)
            {
                produkty.Remove(produkt);
            }
        }
        public void WyswietlProdukty()
        {
            Console.WriteLine("Produkty w koszyku:\n\n");
            decimal totalPrice = 0;
            foreach (var produkt in produkty)
            {
                Console.WriteLine($"ID: {produkt.Id} \tNazwa: {produkt.Name} \tCena jednostkowa: {produkt.Price} \tIlość: {produkt.Quantity}\tCena: {produkt.Quantity*produkt.Price}\n");
                totalPrice += (produkt.Price*produkt.Quantity);
            }
            Console.WriteLine("Łączna cena produktów w koszyku: " + totalPrice + "\n\n");
        }
        public void changeQuantity(int id, int quantity)
        {
            var produkt = produkty.FirstOrDefault(p => p.Id == id);
            if (produkt != null)
            {
                produkt.Quantity = quantity;
            }
        }


    }
}
