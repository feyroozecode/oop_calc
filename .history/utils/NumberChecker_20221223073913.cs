using System.Dynamic;
using System;
using System.Text.RegularExpressions;

namespace Util.Checker{
    class NumberChecker{

        /*
            pattern pour les nombre de 0 à 9 ou contenant les operandes comme (+ - * /) 
        */
        public static string PATTERN = @"^(\d+(\.\d+)?)\s*([\+\-\*\/])\s*(\d+(\.\d+)?)$";
        public static String INPUT_SEPARATE_PATTER = @"\s*([\+\-\*\/])\s*"
        // verify if input is match and return a list of matchs values
        public static bool checkeAndReturnMatch(String input){
             
             // Si l'entrer ne pas verifier valide par le pattern
             if(!Regex.IsMatch(input, PATTERN)){

                throw new InvalidOperationException("Operation Invalide");
             } 
             
             //var valides = Regex.Match(input, PATTERN);
        
             //Console.WriteLine("valide match groups = "+ validesMatchs);

             return true;
        }

    }
}