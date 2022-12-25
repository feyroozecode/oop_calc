// disable nullable var value
#nullable disable

namespace fun {
    class Fun {
        public static void affiche(String s){
            Console.WriteLine(s);
        }

        public static String getInput(){
            return Console.ReadLine();
        }

        public static bool Continuez(){
            String userRes ;

            Console.WriteLine("\n Voulez vous continuez, (OUI: o & NON: sur n'importe quel touche ) ?");
            userRes = Console.ReadLine();

            if(userRes == "o"){
                return true;
            } else {
                Console.WriteLine("\n Fin, au revoir  🥱");
                return false;
            }

    }
    }
}