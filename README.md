# Generator Testova
Aplikacija koja omogućava studentima da vežbaju tako što kreira test od nasumično odabranih pitanja.
Aplikacija omogućava import i export pitanja na osnovu kojih se generišu testovi na način koji je lak za deljenje i modifikovanje.

## Uputstvo za korišćenje 
### Generisanje testova
 Pri pokretanju vam se nudi drop down lista sa postojećim predmetima ako želite da generišete test odaberite predmet a zatim odaberite oblasti.
 Ukoliko želite da uklonite odabranu oblast iz selektovanih samo kliknite na željenu oblast i ukloni.
 Test sadrži 20 pitanja jednako raspoređenih po oblastima, a u slučaju izbora celog predmeta random se bira 20 pitanja nezavisno od oblasti.
 U slučaju da neka oblast/predmet nemaju dovoljno pitanja broj pitanja će samo biti smanjen na broj dostupnih.
 
 ### Dodavanje pitanja
 Dodavanje novog predmeta se vrši na početnoj formi.
 Ukoliko želite da dodate oblasti za izabrani predmet odaberite ga i to uradite na sledećoj formi.
 Za dodavanje pitanja na početnoj formi odaberite dugme ažuriraj pitanja.
 Dugme dodaj pitanja vam omogućava da importujete text fajl sa pitanjima možete odabrati određenu oblast ili ceo predmet(**Napomena** pitanja dodata za ceo predmet se  smatraju kao pitanja koja nemaju dodeljenu oblast i kao takva su dostupna samo ako čekirate odaberi sve oblasti kada kreirate test)
 Izvuci pitanja kreira text fajl sa svim do sada postojećim pitanjima koji zatim možete menjati.
 Obriši pitanja vam omogućava da uklonite pitanja za odbranu oblast ili za ceo predmet. Ako vršite eksport pitanja a zatim menjate tekst i želite da ih ponovo ubacite prvo očistite željenu oblast ili predmet a zatim ponovo importujte pitanja.
 
 ### Pravila za format fajla sa pitanjima 
 
 -Pitanja i odgovori se odvajaju znakom |
 -Fajl ne treba da počinje | (videti primer dole)
 -Navodnici su dozvoljeni pri unosu ali neće biti sačuvani u bazi
 -Raspored novih redova nije bitan
 
 **Primer strukture fajla sa pitanjima**
 
 Pitanje1|Odgovor1|  
 Pitanje2|Odgovor2|Pitanje3|Odgovor3|  
 Pitanje4|  
 Odgovor4|  
