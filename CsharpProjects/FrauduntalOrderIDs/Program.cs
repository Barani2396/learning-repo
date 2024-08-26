string[] frauduntalOrderIDs = {"B123", "C234", "A345", "C15", "B177", "G3003", "C235", "B179"};

foreach (string frauduntalOrderID in frauduntalOrderIDs) {
    if (frauduntalOrderID.StartsWith("B")) {
        Console.WriteLine(frauduntalOrderID);
    }
}