
using Ex07;

Retangulo retangulo = new Retangulo();

Console.WriteLine("Entre a altura do retângulo:");
retangulo.Altura = retangulo.ValidarValores();

Console.WriteLine("Entre com a largura do retângulo:");
retangulo.Largura = retangulo.ValidarValores();

Console.WriteLine(retangulo);


