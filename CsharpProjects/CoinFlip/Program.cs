Random coin = new Random();
int flip = coin.Next(0, 2);
Console.WriteLine($"Coin flip: {(flip == 0 ? "heads" : "tails")}");