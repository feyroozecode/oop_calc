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
        //private static readonly string pattern = @"^(\d+(\.\d+)?)\s*([\+\-\*\/])\s*(\d+(\.\d+)?)$";
        private static readonly string pattern = @"^([0-9+-/=%*V])$";
        // Lancement du programme
        public static void startApp(){
           Fun.affiche("Start");

            mainLoop();
        }

        // parcour general de l'app
        public static void mainLoop(){
            bool parcourir = true;

            while (parcourir)
            {
                Fun.affiche("Entrer votre des insctruction pour calculer ou cliquer sur q pour quitter");

                string userInput = Fun.getInput();

                if(userInput == "q"){
                    parcourir = false;
                    Fun.Continuez();
                }
               
                else{
                    launchCalc(userInput);
                }
            }
        }

        public static void launchCalc(String input){

             // Effecer les sapces separant les nombres des instructions 
                var operations = Regex.Split(input, @"\s*([\+\-\*\/])\s*");

                // initialisez le resultat, débutant à lelement (index 1)
                
                double value;

                if(!double.TryParse(operations[0], out value)){
                    Fun.affiche("Entrer des valeur valide (Nombre ou les signe (+,-,*,/)) pour les calcul");
                }

                double result = double.Parse(operations[0]);


                if(res)
                // itration à travers les operations, debuter, à l'index 2
                for(int i = 1; i < operations.Length; i += 2){

                    //extraire le second operande de la liste d'insctruction
                    double right = double.Parse(operations[i + 1]);

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
                        case "=":
                            result = 0 ;
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
                            Fun.affiche("Veuillez entrer des valleurs comprise entre 0 à 9 et des intruction comme +");
                            return;
                    }
            }   

            Fun.affiche("> "+ result); // Afficher le resultat
        }
    }
                    
}

