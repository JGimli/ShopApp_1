# ShopApp

ShopApp is a small console shopping-cart application written in C# for .NET 9. It reads a product catalog from a text file, lists the available products, and lets the user add or remove products from an in-memory cart.

## Features

- Loads products from `C:\test\products.txt`
- Assigns product IDs based on catalog order
- Displays the available product catalog
- Adds products to the shopping cart
- Updates product quantities
- Removes products or reduces their quantity
- Calculates and displays the cart total

## Requirements

- Windows
- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)

No external NuGet packages are used.

## Project structure

```text
ShopApp_1/
|-- zad6.sln
`-- zad6/
    |-- zad6.csproj
    |-- Program.cs
    |-- Item.cs
    `-- Koszyk.cs
```

- `Program.cs` loads the catalog and provides the interactive console menu.
- `Item.cs` defines a product's ID, name, price, and quantity.
- `Koszyk.cs` manages the cart and calculates the displayed total.
- `zad6.csproj` defines the executable as a .NET 9 project.
- `zad6.sln` is the Visual Studio solution file.

## Product file

Before running the application, create:

```text
C:\test\products.txt
```

Each line must contain a product name and a decimal price separated by a space:

```text
Bread 5.99
Milk 3.49
Coffee 21.90
Apple 2.10
```

The parser assigns IDs automatically, starting from `1`, in the order in which lines appear. Product names are not required to contain spaces because the current parser splits each line on the first separator position and reads only the first word as the name.

## Build

From the repository root:

```powershell
dotnet build zad6.sln
```

For a release build:

```powershell
dotnet build zad6.sln -c Release
```

## Run

Make sure `C:\test\products.txt` exists, then run:

```powershell
dotnet run --project zad6/zad6.csproj
```

The application displays the catalog and waits for menu input.

## Console menu

| Choice | Action |
| --- | --- |
| `0` | Exit the application |
| `1` | Enter a product ID and quantity to add |
| `2` | Enter a product ID and quantity to remove or reduce |
| `3` | Show the cart and total price |
| `4` | Show the available products |

Example cart workflow:

```text
What do you want to do?
 1:add

Enter product ID to add to the cart:
1
how many items do you want to add?
2

What do you want to do?
 3:show
```

## Data model

`Item` contains:

- `Id`
- `Name`
- `Price`
- `Quantity`

`Koszyk` stores `Item` objects in a `List<Item>` and exposes methods to add, remove, update, and display products.

## Current limitations

- The product file path is hard-coded to `C:\test\products.txt`.
- Product and cart data exist only in memory and are lost after the application exits.
- Input parsing is intentionally simple and does not include complete validation or recovery.
- The catalog format assumes one product name token followed by a price.
