using System;
using System.Net.Http;
using System.Text.RegularExpressions;
/*
* domyslnine prywatne (dodajemy public)
* pascal case AddPerson();
* pasek ready na dole oznacza ze nasz projekt znajduje sie w jakims repo
* typy zmiennych takie jak w javie ( poza string i bool - nie kastujem 1 do true)
* int? = null -- zmienna nullowalna
* trzeba inicjowac var, warto korzystac
* Task <typ zwracany >
* metody async poprzedzamy awaitem 
*/


namespace cw1
{
    public class Program
    {
        public static async System.Threading.Tasks.Task Main(string[] args) {
            //{
            //    int? tmp1 = null, tmp2=2,tmp3=3;
            //    string str1 = "Ala ma kota";
            //    string str2 = "i psa";
            //    Console.WriteLine($"{str1} {str2} {tmp2+tmp3}");
            //    // albo +

            //    string path = $@"C:\Users\s19048\Desktop\cw1\{tmp3}";

            //    var tmp4 = "aa";
            //    // ********************
            //    var newPerson = new Person { FirstName = "Nina" };

            //    Console.WriteLine("Hello World!");

            var url =args.Length>0?args[0]: "https://www.pja.edu.pl";
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {

                    if (response.IsSuccessStatusCode)
                    {
                        var htmlContent = await response.Content.ReadAsStringAsync();
                        var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+", RegexOptions.IgnoreCase);
                        var matches = regex.Matches(htmlContent);
                        foreach (var match in matches)
                        {
                            Console.WriteLine(match.ToString());
                        }



                    }
                }

                    
            }
               
            //httpClient.Dispose();

            // jest mozliwosc asynchronicznego wywolania
           




        }
    }
}
