using MathGame;

var menu = new Menu();

// Ask for Players name
string name = Helpers.GetName();

// Create directory if does not exist to register the Records
Helpers.CreateDirectory();

var date = DateTime.UtcNow;
menu.Show(name, date);
