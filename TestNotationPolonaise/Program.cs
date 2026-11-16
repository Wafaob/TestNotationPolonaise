using System;
using System.Collections.Generic;

namespace TestNotationPolonaise
{
    class Program
    {
        /// <summary>
        /// saisie d'une réponse d'un caractère parmi 2
        /// </summary>
        /// <param name="message">message à afficher</param>
        /// <param name="carac1">premier caractère possible</param>
        /// <param name="carac2">second caractère possible</param>
        /// <returns>caractère saisi</returns>
        static char saisie(string message, char carac1, char carac2)
        {
            char reponse;
            do
            {
                Console.WriteLine();
                Console.Write(message + " (" + carac1 + "/" + carac2 + ") ");
                string entree = Console.ReadLine();
                reponse = entree.Length > 0 ? char.ToUpper(entree[0]) : '\0';
            } while (reponse != carac1 && reponse != carac2);
            return reponse;
        }

        /// <summary>
        /// Saisie de formules en notation polonaise pour tester la fonction de calcul
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            char reponse;
            // boucle sur la saisie de formules
            do
            {
                Console.WriteLine();
                Console.WriteLine("entrez une formule polonaise en séparant chaque partie par un espace = ");
                string laFormule = Console.ReadLine();
                // affichage du résultat
                Console.WriteLine("Resultat =  " + Polonaise(laFormule));
                reponse = saisie("Voulez-vous continuer ?", 'O', 'N');
            } while (reponse == 'O');
        }
        static double Polonaise(string laFormule)
        {
            string[] morceaux = laFormule.Split(' ');

            if (morceaux.Length == 1 && double.TryParse(morceaux[0], out double nombre))
            {
                return nombre;
            }


            Stack<double> pile = new Stack<double>();

            for (int i = morceaux.Length - 1; i >= 0; i--)
            {
                string element = morceaux[i];

                if (double.TryParse(element, out nombre))
                {
                    pile.Push(nombre);
                }
                else if (element == "+")
                {
                    if (pile.Count < 2)
                    {
                        return double.NaN;
                    }

                    else
                    {
                        double num1 = pile.Pop();
                        double num2 = pile.Pop();

                        double somme = num1 + num2;
                        pile.Push(somme);
                    }

                }

                else if (element == "-")
                {
                    if (pile.Count < 2)
                    {
                        return double.NaN;
                    }

                    else
                    {
                        double num1 = pile.Pop();
                        double num2 = pile.Pop();

                        double resultat = num1 - num2;
                        pile.Push(resultat);
                    }
                }

                else if (element == "*")
                {
                    if (pile.Count < 2)
                    {
                        return double.NaN;
                    }

                    else
                    {
                        double num1 = pile.Pop();
                        double num2 = pile.Pop();

                        double produit = num1 * num2;
                        pile.Push(produit);
                    }
                }


                else if (element == "/")
                {
                    if (pile.Count < 2)
                    {
                        return double.NaN;
                    }

                    else
                    {
                        double num1 = pile.Pop();
                        double num2 = pile.Pop();
                        if (num2 == 0)
                        {
                            return double.NaN;
                        }
                        double division = num1 / num2;
                        pile.Push(division);


                    }

                }

                else
                {
                    return double.NaN;
                }
            }
            if (pile.Count == 1)
            {
                return pile.Pop();
            }

            return double.NaN;

        }
    }
}
