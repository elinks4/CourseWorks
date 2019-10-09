namespace NewProjectTry
{
    public class Card
    {
        public int Id {get; set;}

        public string Name {get; set;}

        public string Mark {get; set;}

        public bool GotPair {get; set;}



        public Card(int species){

            if(species == 1){
                Name = "X";
            }
            else{
                Name = "O";
            }

        }


        public string CardName(){

            return Name;

        }
    }
}