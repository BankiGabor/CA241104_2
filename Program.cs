using CA241104_2;
using System.Text;

List<Versenyzo> versenyzok = [];

using StreamReader sr = new("..\\..\\..\\src\\forras.txt", Encoding.UTF8);
while (!sr.EndOfStream)
{
    versenyzok.Add(new(sr.ReadLine()));
}

Console.WriteLine($"versenyzők száma: {versenyzok.Count}");

var f1 = versenyzok.Count(v => v.Kategoria == "25-29");
Console.WriteLine($"25-29es kategóriában versenyzok száma: {f1} fő");

var f2 = versenyzok.Average(v => 2014 - v.Szul);
Console.WriteLine($"versenyzők átlag életkora: {f2:0.00} év");

var f3 = versenyzok.Sum(v => v.VersenyIdok["úszás"].TotalHours);
Console.WriteLine($"úszással töltött idő összesen: {f3:0.00} óra");

var f4 = versenyzok.Where(v => v.Kategoria == "elit").Average(v => v.VersenyIdok["úszás"].TotalMinutes);
Console.WriteLine($"átlag úszással töltött idő az elit kategóriában: {f4:0.00} perc");

var f5 = versenyzok.Where(v => v.Nem).MinBy(v => v.Osszido);
Console.WriteLine($"Férfi győztes: {f5}");

var f6 = versenyzok.GroupBy(v => v.Kategoria);
Console.WriteLine($"A versenyt befejezők száma kategória szerint:");
foreach (var grp in f6)
{
    Console.WriteLine($"\t{(grp.Key)}: {grp.Count()} fő");
}

var f7 = versenyzok.GroupBy(v => v.Kategoria).OrderBy(g => g.Key).ToDictionary(g => g.Key, g => g.Average(v => v.VersenyIdok["I. depó"].TotalMinutes + v.VersenyIdok["II. depó"].TotalMinutes));
Console.WriteLine($"kategóriánkénti átlag depóban töltött idő:");
foreach (var kvp in f7)
{
    Console.WriteLine($"\t{kvp.Key}: {kvp.Value:0.00}");
}