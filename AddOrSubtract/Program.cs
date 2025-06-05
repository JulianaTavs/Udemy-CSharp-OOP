using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

Calculate("1plus2plus3plus4");
Calculate("1plus2plus3minus4");
Calculate("1minus2minus3minus4");
Calculate("1minus2plus3minus4");
Calculate("1plus2minus3plus4minus5");
Calculate("439plus779plus174");

static string Calculate(string str)
{

    var matches = Regex.Matches(str, @"(\d+)|(plus)|(minus)");


    List<int> numbers = new List<int>();

    List<char> operators = new List<char>();


    foreach (Match match in matches)
    {

        if (match.Groups[1].Success)
        {
            numbers.Add(int.Parse(match.Groups[1].Value));
        }

        else if (match.Groups[2].Success)
        {
            operators.Add('+');
        }

        else if (match.Groups[3].Success)
        {
            operators.Add('-');
        }
    }


    if (numbers.Count == 0)
    {
        return "0";
    }


    int result = numbers[0];


    for (int i = 0; i < operators.Count; i++)
    {

        if (i + 1 < numbers.Count)
        {
            if (operators[i] == '+')
            {
                result += numbers[i + 1];
            }
            else if (operators[i] == '-')
            {
                result -= numbers[i + 1];
            }
        }
        else
        {

            break;
        }
    }

    Console.WriteLine(result);
    return result.ToString();
}

