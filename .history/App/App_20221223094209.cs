using System.Text.RegularExpressions;
using System;
using fun;
using Operation;

// interfaces
using Interface.OperInterface;
using Interface.AdvancedOp;
using Util.Checker;

namespace Application{
    class Calculator {
        
        // import all operations and set to protected static for using
        protected static OperInterface addOp = UtilFactory.Factory.CreateInstace<AddOper>();
        protected static OperInterface subOp = UtilFactory.Factory.CreateInstace<SubOper>();
        protected static OperInterface multiOp = UtilFactory.Factory.CreateInstace<Multiple>();
        protected static OperInterface divideOp = UtilFactory.Factory.CreateInstace<DivideOper>();
        protected static OperInterface moduloOp = UtilFactory.Factory.CreateInstace<ModuloOp>();
        protected static OperInterface compareOp = UtilFactory.Factory.CreateInstace<CompareOp>();

        // advanced operations 
        protected static AdvancedOpInterface racineOp = UtilFactory.Factory.CreateInstace<RacineOp>();
        protected static AdvancedOpInterface expoOp = UtilFactory.Factory.CreateInstace<ExpoOp>();
        // Regex Checker
        protected static NumberChecker matchChecker = new NumberChecker();

        // Regex
        private static readonly string pattern = @"^[0-9+-/*()]+$";
        //Console.WriteLine(op.Calc(5, 7));
        public static void startApp(){
           Fun.affiche("Start");

            mainLoop();
        }

        // parcour general de l'app
        public static void mainLoop(){
            bool parcourir = true;

            while (parcourir)
            {
                Fun.affiche("Faite votre operation ou cliquer sur q pour quitter");

                string userInput = Fun.getInput();

                if(userInput == "q"){
                    parcourir = false;
                } 
                else{
                    launchCalc(userInput);
                }
            }
        }

        public static void launchCalc(String input){

            /*
            if(!Regex.IsMatch(input, pattern)){
                throw new InvalidOperationException("Invalid Op");
            }    */

             // Split the input string into separate operations
                //var operations = Regex.Split(input, @"\s*([\+\-\*\/])\s*");

                string[] operations = new String[0];
                input.Split(' ');

                // initialisez le resultat, débutant à lelement (index 1)

                double result = double.Parse(operations[0]);

                // recuperer la valeur à gauche, l'operateur et droite
                //double left = double.Parse(operations[0]);

                // itration à travers les operations, debuter, à l'index 2
                for(int i =1; i < operations.Length; i += 2){

                    //extraire le second operande de la liste d'insctruction
                    double right = i

                    //extraire l'operateur
                    string operateur = operations[i];

                    switch(operateur){
                        case "+":
                            result += right; 
                            break;    
                        case "-":
                            result = subOp.Calc(result, right);
                            break;
                        case "*":
                            result = multiOp.Calc(result, right);
                            break;    
                        case "/":
                            result = divideOp.Calc(result, right);
                            break;
                        case "==":
                            result = compareOp.Calc(result, right);
                            break;    
                        case "V":
                            result = racineOp.Calc((result));
                            break;    
                        case "**":
                            result = expoOp.Calc(result);
                            break;
                        case "%":
                            result = moduloOp.Calc(result, right);
                            break;
                        default :
                            throw new InvalidOperationException("Operation Invalide");
                    }

                Fun.affiche("Resultat = "+ result);
            }   
        }
    }
                    
}

