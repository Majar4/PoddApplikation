using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BL;

namespace PL
{
    public class Validator
    {
        private static string isCorrectURL(string url)
        {
            // Uri är som ett inbyggt regex. Här säger jag alltså:
            //Försök läsa strängen som en url, typen uri ska vara absolut
            //alltså ganska strikt, finns tre olika varianter av UriKind.
            //out = om TryCreate funkar så ska det lagras i variabeln uri.
            //I och med ! så säger vi: om detta inte kan ske så...
            if(!Uri.TryCreate(url, UriKind.Absolute, out Uri uri))
            {
                return "Ogiltig URL";
            }
            
            if (!url.StartsWith("http://") && !url.StartsWith("https://")){
                return "URL måste börja med http";
            }

            return null;
        }

        private static string isNotDuplicate(string input, IEnumerable<string> existingValues)
        {

            if (existingValues.Any(p => p.Equals(input, StringComparison.OrdinalIgnoreCase)))
            {
                return "Podden finns redan sparad!";
            }

            return null;
        }

        private static string isNotANumber(string input)
        {
            if(double.TryParse(input, out _))
            {
                return "Får inte vara en siffra!";
            }
            return null;
        }
        private static string isNotEmpty(string input)
        {
            if(string.IsNullOrWhiteSpace(input))
            {
                return "Rutan får inte lämnas tom";
            }
            return null;
        }
        // har gjort ComboBoxIsNotEmpty om vi vill använda den för ngn validering senare :)
        public static string ComboBoxIsNotEmpty (object selectedItem)
        {
            if (selectedItem == null) {
                return "Du måste välja ur listan";
            }
                return null; 
        }

        public static string RssIsValid(string rss, IEnumerable<string> existingURLs)
        {
            string checkIfEmpty = isNotEmpty(rss);
            if(checkIfEmpty != null)
            {
                return checkIfEmpty;
            }

            string checkRss = isCorrectURL(rss);
            if (checkRss != null)
            {
                return checkRss;
            }

            string checkDuplicate = isNotDuplicate(rss, existingURLs);

            if (checkDuplicate != null)
            {
                return checkDuplicate;
            }

            return null;
        }

        public static string NameIsValid(string input, IEnumerable<string> existingNames)
        {
            string checkIfEmpty = isNotEmpty(input);
            if (checkIfEmpty != null)
            {
                return checkIfEmpty;
            }

            string checkIfNumber = isNotANumber(input);
            if (checkIfNumber != null)
            {
                return checkIfNumber;
            }

            string checkDuplicate = isNotDuplicate(input, existingNames);

            if (checkDuplicate != null)
            {
                return checkDuplicate;
            }

            return null;

        }
    }
}
