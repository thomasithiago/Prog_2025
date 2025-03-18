﻿namespace Aula02.Models
{
    public class TypeCasting
    {
        //Declarando variavéis na classe
        public int myInteger = 20;
        public long myLong;

        public string myType1;
        public string myType2;
        public TypeCasting()
        {
            //Conversão implicita de tipos 
            myLong = myInteger;
            //myInteger = myLong;
            //Neste caso o long é muito grande para para o int, e a conversão implicita não é permitida

            //Conversão explicita 
            long myLong2 = 138129210;
            int myInteger2;
            myInteger2 = (int)myLong2;

            //É Possivel identificar qual é o tipo de uma variavel em tempo de execução
            myType1 = myLong2.GetType(). ToString();   
            myType2 = myInteger2.GetType(). ToString();


        }

    }
}
