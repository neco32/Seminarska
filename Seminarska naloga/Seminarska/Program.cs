/*
Izziv vas vabi, da se potopite globoko v svet algoritmov. Vaša naloga je optimizirati klasične tehnike
razvrščanja za učinkovitejšo obdelavo velikih naborov podatkov. To je fantastična priložnost, da
napnete svoje mišice za reševanje problemov in izboljšate delovanje temeljnih algoritmov.
a) Pregled izziva: Izberite kateri koli tradicionalni algoritem za razvrščanje, kot je Bubble Sort,
Merge Sort ali Quick Sort, in ga optimizirajte, da zmanjšate njegovo časovno in prostorsko
kompleksnost.
b) Zahteve:
• Izbira algoritma: izberite algoritem za razvrščanje, za katerega menite, da ima prostor za
optimizacijo.
• Cilji optimizacije: Osredotočite se na izboljšanje algoritma za izboljšanje njegove
učinkovitosti pri velikih nizih podatkov.
• Primerjalna analiza: primerjajte zmogljivost vašega optimiziranega algoritma z izvirno
različico.
c) Namigi za začetek:
• Preglejte osnovne principe izbranega algoritma za razvrščanje in prepoznajte morebitne
neučinkovitosti.
• Raziščite napredne koncepte, kot so hibridni algoritmi ali tehnike inženiringa algoritmov, ki
bi jih lahko uporabili.
• Razmislite o vrstah podatkov, ki jih bo razvrstil vaš algoritem. Ali je mogoče optimizacije
prilagoditi specifičnim značilnostim podatkov?
d) Koraki izziva:
• 1. korak: Analizirajte in razumite trenutno izvedbo izbranega algoritma za razvrščanje.
• 2. korak: Izvedite optimizacije, katerih cilj je zmanjšanje kompleksnosti in izboljšanje
zmogljivosti.
• 3. korak: preizkusite optimizirani algoritem in ga primerjajte s standardnimi nabori
podatkov, da ocenite izboljšavo.
e) Dodatna naloga: Vzporedna obdelava Za tiste, ki iščejo dodaten izziv, implementirajte svoj
optimizirani algoritem za razvrščanje z uporabo tehnik vzporedne obdelave, da še izboljšate
njegovo zmogljivost. To bi lahko vključevalo uporabo večnitnosti ali drugih metod sočasnosti za
pospešitev postopka razvrščanja na večjedrnih procesorjih.
f) Zakaj je to pomembno: Optimiziranje algoritmov za razvrščanje je ključnega pomena za
izboljšanje učinkovitosti programske opreme, ki obravnava velike količine podatkov. Te veščine
so bistvenega pomena za inženirje programske opreme, zlasti tiste, ki delajo na področjih, kot so
obdelava podatkov, baze podatkov in visoko zmogljivo računalništvo.
*/

using WindowsFormsApp1;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] tabela = { 7, 8, 10, 2, 26, 4, 19, 5, 3, 16, 11, 6, 13, 12 };
        int[] tabela2 = { 7, 8, 10, 2, 26, 4, 19, 5, 3, 16, 11, 6, 13, 12 };
        Console.WriteLine(tabela.Length - 1);
        tabela = Quick_Sort.QuickSort(tabela, 0, tabela.Length - 1);
        tabela2 = Quick_Sort.QuickSort2(tabela2, 0, tabela.Length - 1);
        Console.WriteLine("Tabela 1: ");
        for (int i = 0; i < tabela.Length; i++)
        {
            Console.Write(tabela[i] + "\t");
        } 
        /*double vsotaPartition = 0;
        double vsotaPartition2 = 0;

        for (int i = 0; i < 1000; i++)
        {
            int[] tabela1 = new int[10000];
            int[] tabela2 = new int[10000];
            Random rnd = new Random();
            for (int j = 0; j < tabela1.Length - 1; j++)
            {
                int value = rnd.Next(0, 10000);
                tabela1[j] = value;
                tabela2[j] = value;
            }

            DateTime start = DateTime.Now;
            tabela1 = Quick_Sort.QuickSort(tabela1, 0, tabela1.Length - 1);
            DateTime end = DateTime.Now;
            vsotaPartition += (end - start).TotalMilliseconds;

            start = DateTime.Now;
            tabela2 = Quick_Sort.QuickSort2(tabela2, 0, tabela2.Length - 1);
            end = DateTime.Now;
            vsotaPartition2 += (end - start).TotalMilliseconds;

        }
        Console.WriteLine("Povprecje Partition: " + vsotaPartition / 1000 + "ms");
        Console.WriteLine("Povprecje Partition2: " + vsotaPartition2 / 1000 + "ms");*/
    }

}
