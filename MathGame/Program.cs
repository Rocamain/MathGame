// See https://aka.ms/new-console-template for more information
using MathGame;

var menu = new Menu();

string name = Helpers.GetName();
var date = DateTime.UtcNow;

menu.Show(name, date);