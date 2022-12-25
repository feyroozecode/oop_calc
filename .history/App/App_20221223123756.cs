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
        private static readonly string split_pattern = @"\s*([\+\-\*\/\=])\s*";
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
                var operations = Regex.Split(input, split_pattern);

                // initialisez le resultat, débutant à l'element (index 1)
                double value;
                if(!(double.TryParse(operations[0], out value))){
                    Fun.affiche("Entrer des valeur valide (Nombre ou les signe (+,-,*,/)) pour les calcul");

                    if(operations[0].EndsWith("=")){
                        Fun.affiche("var end with = ");
                    }
                }

                // default result value
                if(double.TryParse(operations[0], out value )){
                
                
            }   

            Fun.affiche("> "+ result); // Afficher le resultat
        }
    }
                    
}

