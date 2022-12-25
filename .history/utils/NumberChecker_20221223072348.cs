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
        public static bool checkeAndReturnMatch(String input){
             
             // Si l'entrer ne pas verifier valide par le pattern
             if(!Regex.IsMatch(input, pattern)){

                throw new InvalidOperationException("Operation Invalide");
             } 
             
             var valides = Regex.Match(input, pattern);
            
        
             //Console.WriteLine("valide match groups = "+ validesMatchs);

             return true;
        }

    }
}