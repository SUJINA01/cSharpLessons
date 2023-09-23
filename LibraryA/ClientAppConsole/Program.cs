using LibraryA;

Book book = new Book();
book.Title = "To kill a Mocking Bird";
book.Author = "Harper Lee";
book.Genre = "Social";
book.BookPrice = 100;
book.DateOfPublish =new  DateTime(1995, 06, 01);
book.BookmarkPage(125);
Console.WriteLine( book.GetCurrentPage());
Calculator calculator = new Calculator();
int addresult = calculator.Add(100, 60);
Console.WriteLine( addresult );
int multiplyResult  = calculator.Multiply(100, 60);
Console.WriteLine( multiplyResult);
int divideResult = calculator.Divide(100, 60);
Console.WriteLine( divideResult);