using System.Dynamic;
using System;
using System.Text.RegularExpressions;

namespace Util.Checker{
    class NumberChecker{

        /*
            pattern pour les nombre de 0 à 9 ou contenant les operandes comme (+ - * /) 
        */
        protected static string pattern = @"^(\d+(\.\d+)?)\s*([\+\-\*\/])\s*(\d+(\.\d+)?)$";

        // verify if input is match and return a list of matchs values
        public static String checkeAndReturnMatch(String input){
             
             // Si l'entrer ne pas verifier valide par le pattern
             if(!Regex.IsMatch(input, pattern)){

                throw new InvalidOperationException("Operation Invalide");
             } 
             
             var valides = Regex.Match(input, pattern);
            
             // extraire les données
             List<dynamic> validesMatchs = new List<dynamic>();

             var n1 = double.Parse(valides.Groups[1].Value);
             var n2 = double.Parse(valides.Groups[4].Value);
             var operand = valides.Groups[3].Value;
            
             validesMatchs.Add(n1);
             validesMatchs.Add(n2);
             validesMatchs.Add(operand);
             
             //Console.WriteLine("valide match groups = "+ validesMatchs);

             return validesMatchs;
        }

    }
}